using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Cristofer
{

    internal class clsMenu
    {
        //private static int opcion = 0;   // global

        private clsEmpleado[] empleados;

        public clsMenu(int maxEmpleados)
        {
            empleados = new clsEmpleado[maxEmpleados];
        }

        public void MosMen() //MENU 
        {


            Console.WriteLine(" Menu ");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados ");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reporte");
            Console.WriteLine("7. Salir");
        }
        public void EmpAgre()//Datos empleados
        {

            Console.WriteLine("Ingrese el nombre del empleado");
            String Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la cedula del empleado.");
            String Cedula = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del empleado");
            String Direccion = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del empleado");
            String Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el salario del empleado");
            double Salario = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] == null)
                {
                    empleados[i] = new clsEmpleado(Cedula, Nombre, Direccion, Telefono, Salario);
                    Console.WriteLine("Empleado agregado.");
                    return;

                }

            }
            Console.WriteLine("Intentelo luego");


        }

        public void ConEmp() //almacenados
        {

            Console.WriteLine("Empleados Almacenados");


            Console.WriteLine("Lista de Empleados");
            foreach (var clsEmpleado in empleados)
            {
                if (clsEmpleado != null)
                {
                    Console.WriteLine($", NOMBRE: {clsEmpleado.Nombre},CEDULA: {clsEmpleado.Cedula}, DIRECCIÓN: {clsEmpleado.Direccion}, TEL: {clsEmpleado.Telefono}, SALARIO:  {clsEmpleado.Salario}");

                }

            }

        }

        public void ModEmp()
        {

            Console.WriteLine("Empleados almacenados");
            Console.WriteLine("Digite el numero de cedula del empleado a modificar");
            String cedula = Console.ReadLine();

            for (int i = 0; i < empleados.Length; i++)
            {

                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    Console.WriteLine("Digite el nombre del nuevo empleado");
                    empleados[i].Nombre = Console.ReadLine();
                    Console.WriteLine("Digite el telefono del nuevo empleado");
                    empleados[i].Telefono = Console.ReadLine();
                    Console.WriteLine("Digite el salario del nuevo empleado");
                    empleados[i].Salario = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Digite la direccion del nuevo empleado");
                    empleados[i].Direccion = Console.ReadLine();

                    Console.WriteLine("Modificacion realizada");
                    return;

                }
            }
            Console.WriteLine("Usuario no encontrado, digite bien el numero de cedula");


        }
        public void BorEmp() //eliminacion 
        {
            Console.WriteLine("Eliminacion de empleados");
            Console.WriteLine("Digite la cedula del empleado e eliminar");
            string cedula = Console.ReadLine();

            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i] != null && empleados[i].Cedula == cedula)
                {
                    empleados[i] = null;
                    Console.WriteLine("Empleado eliminado");
                    return;
                }
            }
            Console.WriteLine("Usuario no encontrado, digite de nuevo la cedula ");
        }

        private void ConEmpCed(string cedula) // opcion privada para submenu reporte
        {
            foreach (var empleado in empleados)
            {
                if (empleado != null && empleado.Cedula == cedula)
                {
                    Console.WriteLine($" NOMBRE: {empleado.Nombre},CÉDULA: {empleado.Cedula}, DIRECCIÓN: {empleado.Direccion}, TEL: {empleado.Telefono}, Salario: {empleado.Salario}");
                    return;
                }
            }
            Console.WriteLine("NÚMERO DE CÉDULA NO ENCONTRADO");
        }


        private void LisEmP() // forma en orden acendentes con arrays 
        {
            Array.Sort(empleados, delegate (clsEmpleado emp1, clsEmpleado emp2)
            {
                if (emp1 != null && emp2 != null)
                {
                    return emp1.Nombre.CompareTo(emp2.Nombre);
                }
                return 0;
            });

            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    Console.WriteLine($" NOMBRE: {empleado.Nombre}, CÉDULA: {empleado.Cedula}, DIRECCIÓN: {empleado.Direccion}, TEL: {empleado.Telefono}, SALARIO: {empleado.Salario}");
                }
            }
        }



        private void CalProm() // para submenu calculo
        {
            double totalSalarios = 0;
            int contador = 0;
            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    totalSalarios += empleado.Salario;
                    contador++;
                }
            }
            if (contador > 0)
            {
                double promedio = totalSalarios / contador;
                Console.WriteLine($"EL PROMEDIO DE SALARIO ES : {promedio}");
            }
            else
            {
                Console.WriteLine("Error, sin empleado no encontrado calcular");
            }
        }




        private void CalSalMax() // calculo salario maximo

        {
            double salarioMaximo = double.MinValue;
            double salarioMinimo = double.MaxValue;

            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    if (empleado.Salario > salarioMaximo)
                    {
                        salarioMaximo = empleado.Salario;
                    }
                    if (empleado.Salario < salarioMinimo)
                    {
                        salarioMinimo = empleado.Salario;
                    }
                }
            }

            if (salarioMaximo != double.MinValue && salarioMinimo != double.MaxValue)
            {
                Console.WriteLine("Salarios");

                Console.WriteLine($"El salario encontrado mas alto es: {salarioMaximo}");
                Console.WriteLine($"El salario encontrado mas bajo es:: {salarioMinimo}");
            }
            else
            {
                Console.WriteLine("Sin salarios para calcular (alto y bajo)");
            }
        }
        public void MenRep()
        {
            int opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Menu reportes");
            Console.WriteLine("1. Consultar empleados");
            Console.WriteLine("2. Listar todo los empleados");
            Console.WriteLine("3. Calcular y mostrar promedio");
            Console.WriteLine("Calcular y mostrar el salario más alto y el más bajo de todos los empleados");



            switch (opcion)
            {
                case 1:
                    Console.Write(" Digite la cedula del usuario a buscar ");
                    string cedula = Console.ReadLine();
                    ConEmpCed(cedula);
                    break;
                case 2:
                    LisEmP();
                    break;
                case 3:
                    CalProm();
                    break;
                case 4:
                    CalSalMax();
                    break;
                default:
                    Console.WriteLine("Opcipn no aceptada, intentelo de nuevo");
                    break;
            }




        }

        public void IncArre()
        {
            empleados = new clsEmpleado[empleados.Length];
            Console.WriteLine("Arreglos iniciados ");
        }
    }
}










