using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Disponible { get; set; }
    }

    public class BibliotecaService
    {
        private List<Libro> _libros;

        public BibliotecaService()
        {
            _libros = new List<Libro>();
        }

        public bool AgregarLibro(Libro libro)
        {
            if (string.IsNullOrEmpty(libro.Titulo) || string.IsNullOrEmpty(libro.Autor))
                return false;

            libro.Disponible = true;
            libro.Id = _libros.Count + 1;
            _libros.Add(libro);
            return true;
        }

        public Libro BuscarLibroPorId(int id)
        {
            return _libros.FirstOrDefault(l => l.Id == id);
        }

        public bool PrestarLibro(int id)
        {
            var libro = BuscarLibroPorId(id);
            if (libro == null || !libro.Disponible)
                return false;

            libro.Disponible = false;
            return true;
        }

        public bool DevolverLibro(int id)
        {
            var libro = BuscarLibroPorId(id);
            if (libro == null || libro.Disponible)
                return false;

            libro.Disponible = true;
            return true;
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            return _libros.Where(l => l.Disponible).ToList();
        }
    }
 }