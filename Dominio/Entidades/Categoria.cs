
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Categoria:IValidable
    {
        private static int _ultimoId;
        public int Id;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(string nombre, string descripcion)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nCategoria: {Nombre.ToUpper()}\nDescripción : {Descripcion}\n";
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("Nombre de la Categoría, sin datos");
            if (string.IsNullOrEmpty(Descripcion)) throw new Exception("Decripción de la categoria, sin datos");
        }
    }
}
