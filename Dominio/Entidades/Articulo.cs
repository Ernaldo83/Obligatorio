
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Articulo : IValidable
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        public Categoria UnaCategoria { get; set; }
        public decimal Precio { get; set; }

        public Articulo(string nombre, Categoria categoria, decimal precio)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            UnaCategoria = categoria;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"Id : {Id}\nNombre : {Nombre.ToUpper()}\nPrecio : {Precio}\nCategoria : {UnaCategoria.Nombre}\n";
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre)) throw new Exception("El nombre no puede ser vacio o nulo");
            if (UnaCategoria == null) throw new Exception("La categoria no puede ser nula");
            if (Precio <= 0) throw new Exception("El precio no puede ser cero o negativo");
        }

       
    }
}
