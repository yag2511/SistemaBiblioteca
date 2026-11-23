using System;

namespace SistemaBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorBiblioteca gestor = new GestorBiblioteca();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== SISTEMA DE GESTIÓN DE BIBLIOTECA ===");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Mostrar catálogo completo");
                Console.WriteLine("3. Buscar libro (Título/Autor)");
                Console.WriteLine("4. Registrar préstamo");
                Console.WriteLine("5. Registrar devolución");
                Console.WriteLine("6. Mostrar libros Disponibles");
                Console.WriteLine("7. Mostrar libros Prestados");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el título del libro: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese el autor: ");
                        string autor = Console.ReadLine();
                        gestor.RegistrarLibro(titulo, autor);
                        break;
                    case "2":
                        gestor.MostrarCatalogo();
                        break;
                    case "3":
                        Console.Write("Ingrese título o autor a buscar: ");
                        string busqueda = Console.ReadLine();
                        gestor.BuscarLibro(busqueda);
                        break;
                    case "4":
                        Console.Write("Ingrese el ID del libro a prestar: ");
                        if (int.TryParse(Console.ReadLine(), out int idPrestamo))
                            gestor.CambiarEstadoPrestamo(idPrestamo, true);
                        break;
                    case "5":
                        Console.Write("Ingrese el ID del libro a devolver: ");
                        if (int.TryParse(Console.ReadLine(), out int idDevolucion))
                            gestor.CambiarEstadoPrestamo(idDevolucion, false);
                        break;
                    case "6":
                        gestor.MostrarPorEstado(false);
                        break;
                    case "7":
                        gestor.MostrarPorEstado(true);
                        break;
                    case "8":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
