using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesABB
{
    class Program
    {
        public static ArbolBB arbolito = new ArbolBB();
        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                Console.WriteLine("Operaciones en ABB para edades");
                Console.WriteLine("1. Insertar edad");
                Console.WriteLine("2. Recorrido InOrden");
                Console.WriteLine("3. Buscar edad");
                Console.WriteLine("4. Eliminar edad");
                Console.WriteLine("5. Salir");
                Console.Write("Digite #  de opción: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:arbolito.InsertarEdad();break;
                    case 2:arbolito.RecorridoInOrden();break;
                    case 3:arbolito.BuscarEdad();break;
                    case 4:arbolito.EliminarEdad();break;
                    case 5:Console.WriteLine("Saliste del sw") ;break;
                    default:Console.WriteLine("Ingrese # de opción correcta");break;
                }
            } while (op!=5);
            Console.ReadKey();
        }
    }
}
