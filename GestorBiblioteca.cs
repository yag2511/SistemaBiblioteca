using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaBiblioteca
{
    public class GestorBiblioteca
    {
        private List<Libro> libros = new List<Libro>();
        private string archivo = "libros.txt";

        public GestorBiblioteca()
        {
            CargarLibros();
        }

        // 1. Registrar libros
        public void RegistrarLibro(string titulo, string autor)
        {
            int nuevoId = libros.Count + 1;
            libros.Add(new Libro(nuevoId, titulo, autor));
            GuardarLibros();
            Console.WriteLine("¡Libro registrado con éxito!");
        }

        // 2. Consultar catálogo
        public void MostrarCatalogo()
        {
            Console.WriteLine("\n--- CATÁLOGO DE LIBROS ---");
            if (libros.Count == 0) Console.WriteLine("No hay libros registrados.");
            foreach (var lib in libros)
            {
                string estado = lib.Prestado ? "Prestado" : "Disponible";
                Console.WriteLine($"ID: {lib.Id} | Título: {lib.Titulo} | Autor: {lib.Autor} | Estado: {estado}");
            }
        }

        // 3. Buscar libros
        public void BuscarLibro(string criterio)
        {
            Console.WriteLine($"\n--- RESULTADOS DE BÚSQUEDA: '{criterio}' ---");
            var resultados = libros.FindAll(l => l.Titulo.ToLower().Contains(criterio.ToLower()) || l.Autor.ToLower().Contains(criterio.ToLower()));
            
            if (resultados.Count == 0) Console.WriteLine("No se encontraron libros.");
            foreach (var lib in resultados)
            {
                string estado = lib.Prestado ? "Prestado" : "Disponible";
                Console.WriteLine($"ID: {lib.Id} | Título: {lib.Titulo} | Autor: {lib.Autor} | Estado: {estado}");
            }
        }

        // 4. Registrar préstamos y 5. Devoluciones
        public void CambiarEstadoPrestamo(int id, bool prestar)
        {
            Libro lib = libros.Find(l => l.Id == id);
            if (lib != null)
            {
                if (prestar && lib.Prestado)
                    Console.WriteLine("El libro ya está prestado.");
                else if (!prestar && !lib.Prestado)
                    Console.WriteLine("El libro ya está en la biblioteca.");
                else
                {
                    lib.Prestado = prestar;
                    GuardarLibros();
                    Console.WriteLine(prestar ? "Préstamo registrado." : "Devolución registrada.");
                }
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        // 6. Mostrar disponibles y prestados (Se puede hacer con el catálogo, pero lo separamos)
        public void MostrarPorEstado(bool prestado)
        {
            Console.WriteLine($"\n--- LIBROS {(prestado ? "PRESTADOS" : "DISPONIBLES")} ---");
            var filtrados = libros.FindAll(l => l.Prestado == prestado);
            if (filtrados.Count == 0) Console.WriteLine("No hay libros en esta categoría.");
            foreach (var lib in filtrados)
            {
                Console.WriteLine($"ID: {lib.Id} | Título: {lib.Titulo} | Autor: {lib.Autor}");
            }
        }

        // 7. Manejo de Archivos (Guardar y Cargar)
        private void GuardarLibros()
        {
            using (StreamWriter sw = new StreamWriter(archivo))
            {
                foreach (var lib in libros)
                {
                    sw.WriteLine(lib.ToFileString());
                }
            }
        }

        private void CargarLibros()
        {
            if (File.Exists(archivo))
            {
                string[] lineas = File.ReadAllLines(archivo);
                foreach (string linea in lineas)
                {
                    libros.Add(Libro.FromFileString(linea));
                }
            }
        }
    }
}
