// Prueba de PR 3
using System;

namespace SistemaBiblioteca
{
    // Clase que representa un Libro
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Prestado { get; set; }

        public Libro(int id, string titulo, string autor, bool prestado = false)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Prestado = prestado;
        }

        // Convierte el libro a texto para guardarlo en el archivo
        public string ToFileString()
        {
            return $"{Id}|{Titulo}|{Autor}|{Prestado}";
        }

        // Reconstruye un libro a partir del texto del archivo
        public static Libro FromFileString(string linea)
        {
            string[] partes = linea.Split('|');
            return new Libro(int.Parse(partes[0]), partes[1], partes[2], bool.Parse(partes[3]));
        }
    }
}
