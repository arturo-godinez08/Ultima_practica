/*
 * Created by SharpDevelop.
 * User: Arturo
 * Date: 13/05/2014
 * Time: 09:03 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;
namespace practica6
{
	/// <summary>
	/// Description of Profesor.
	/// </summary>
	public class Profesor : MySQL
	{
		public Profesor()
		{
		}
	
	public void Mostrar(){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string id = myReader["id"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            Console.WriteLine("ID: " + id +
				                  " Código: " + codigo + 
				                  " Nombre: " + nombre);
	       }

            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}

		public void Agregar(){
			string id,codigo,nombre;
			this.abrirConexion();
			Console.WriteLine("dame codigo");
			codigo = Console.ReadLine();
			Console.WriteLine("dame nombre");
			nombre = Console.ReadLine();
	
			Console.WriteLine("\r !!Registro insertado a base de datos!!");
			
			string sql = "INSERT INTO `profesor` (  `codigo` , `nombre`) VALUES ('" + codigo + "', '" + nombre + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
	
	
	public void editarCodigoRegistro(){
			this.abrirConexion();
			string id,codigo,s,nombre;
				Console.WriteLine("dame el id");
				id = Console.ReadLine();
				string query = "select *from `profesor` WHERE (`id`='" + id + "')";
			
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(query, 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	

	         if(myReader.HasRows){
	         myReader.Read();	
	            id = myReader["id"].ToString();
	            codigo = myReader["codigo"].ToString();
	            nombre = myReader["nombre"].ToString();
	            Console.WriteLine("ID: " + id +
				                  " Código: " + codigo +
								" Nombre: " + nombre);				                  
				 Console.WriteLine("\r ¿Desea Editarlo?!");
					s = Console.ReadLine();
				if( s=="s"){
				Console.WriteLine("dame el nuevo codigo");
				codigo = Console.ReadLine();
				Console.WriteLine("dame el nuevo nombre");
				nombre = Console.ReadLine();
				
	            myReader.Close();
				myReader = null;
		         
	               
	            myCommand.Dispose();
				myCommand = null;
				string sql = "UPDATE `profesor` SET `nombre`='" + nombre + "', `codigo`='" + codigo + "' WHERE (`id`='" + id + "')";
				this.ejecutarComando(sql);
				this.cerrarConexion();                 
					}else{
						
            myReader.Close();
			myReader = null;
	         
               
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
					}
				
		
				
		}
            else{
            	
            myReader.Close();
			myReader = null;
	         
               
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
					Console.WriteLine("menu");
            }
				
		}
			
		public void editarNombreRegistro(){
			this.abrirConexion();
			string id,nombre;
				Console.WriteLine("dame el id del registro a editar Nombre");
				id = Console.ReadLine();
				Console.WriteLine("dame el nuevo Nombre");
				nombre = Console.ReadLine();
				Console.WriteLine("\r !!Nombre editado");
				
			string sql = "UPDATE `profesor` SET `nombre`='" + nombre + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
				
		
			
		public void eliminarRegistroPorId(){
			string id,s;
			this.abrirConexion();
			
		    Console.WriteLine("\r Dame el ID del registro que quieres Eliminar");
			id = Console.ReadLine();
			Console.WriteLine("¿Esta seguro de querer eliminar?");
			s = Console.ReadLine();
			if (s=="s"){
			string sql = "DELETE FROM `profesor` WHERE (`id`='" + id + "')";
			Console.WriteLine("\r Registro Eliminado!!");
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		 else 
		 	Console.WriteLine("\r Regresa al menu");
		}
		
	private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}

		private string querySelect(){
			return "SELECT * " +
	           	"FROM profesor";
		}
	
	}
	
}
