using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Cristofer
{
   
    
        internal class Program //CLASE RELACION CON TODAS MENÚ 
        {
            static void Main(string[] args)
            {

                clsMenu menu = new clsMenu(1000);

                while (true)
                {
                    menu.MosMen();

                    Console.Write("Digite una opcion valida: ");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            menu.EmpAgre();
                            break;
                        case 2:
                            menu.ConEmp();
                            break;
                        case 3:
                            menu.ModEmp();
                            break;
                        case 4:
                            menu.BorEmp();
                            break;
                        case 5:
                            menu.IncArre();
                            break;
                        case 6:
                            menu.MenRep();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opcion inbalida, digite una opcion valida (1-7)");
                            break;
                    }
                }
            }
        }
    }

