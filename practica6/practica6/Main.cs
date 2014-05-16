/*
 * Created by SharpDevelop.
 * User: Arturo
 * Date: 13/05/2014
 * Time: 10:59 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;
namespace practica6
{
	class Mainclass
	{
		public static void Main(string[] args)
		{
			int opc=0;
			
			//Console.BackgroundColor = ConsoleColor.Blue;
			
			do{
				Console.WriteLine("Menu opciones");
				Console.WriteLine("1) Mostrar");
				Console.WriteLine("2) Agregar");
				Console.WriteLine("3) Editar codigo y nombre");
				Console.WriteLine("4) Editar solo nombre");
				Console.WriteLine("5) Eliminar registro");
				Console.WriteLine("6) salir");
				
				opc=Convert.ToInt16(Console.ReadLine());
				Profesor profe = new Profesor();
				switch(opc)
				{
						case 1: profe.Mostrar(); 
						break;
						
					    case 2: profe.Agregar();
						break;
						
					    case 3:profe.editarCodigoRegistro(); 
						break;
						
						case 4: profe.editarNombreRegistro();
						break;
						
					    case 5: profe.eliminarRegistroPorId();
						break;
						
						case 6: return;
						break;
						
		}
				//opc = Console.ReadLine();
			}while(opc!=6);
			Console.WriteLine("Adios..."); 
            Console.ReadKey(true); 
				
				
			}
		}
	}

