using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public abstract class Publicacion:IValidable
    {

        private List<Articulo> _articulos = new List<Articulo>();

        public int Id { get; set; }
        private static int _ultimoId;
        public string Nombre { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFinalizado { get; set; }
        public Estado EstadoPublicacion { get; set; }
        public Administrador Usuario { get; set; }
        public Cliente UsuarioComprador { get; set; }

        public Publicacion(string nombre,
                        Estado estado,
                        Administrador usuario,                     
                        List<Articulo> articulos,
                        DateTime fechaPublicacion)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            EstadoPublicacion = estado;
            Usuario = usuario;
      
            _articulos = articulos;
            FechaPublicacion = fechaPublicacion;
        }
        public Publicacion() { }

        public List<Articulo> Articulos()
        { 
            return _articulos;
        }
        
        public virtual decimal ObtenerPrecio()
        {
            decimal preciofinal = 0;
            foreach (Articulo articulo in _articulos)
            {
                preciofinal += articulo.Precio;
            }
            return preciofinal;
        }
        public override string ToString()
        {
            decimal precioPublicacion = 0;
            string respuesta = string.Empty;
            respuesta = $"Id: {Id}\n" +
                $"Nombre: {Nombre}\n" +
                $"Usuario: {Usuario.Nombre} {Usuario.Apellido}\n" +
                $"Estado: {EstadoPublicacion}\n" +
                $"Fecha Publicación: {FechaPublicacion.ToShortDateString()}\n";
            if (EstadoPublicacion == Estado.CERRADA) respuesta += $"Fecha Finalizado: {FechaFinalizado.ToShortDateString()}\n";
            respuesta += $"ARTICULOS:\n";
            foreach (Articulo unArticulo in _articulos)
            {
                respuesta += $"Id: {unArticulo.Id} " +
                    $"{unArticulo.Nombre} " +
                    $"${unArticulo.Precio}\n";
                precioPublicacion += unArticulo.Precio;
            }
            respuesta += $"Total de la publicación: ${precioPublicacion}\n";
            return respuesta;
        }
        public void AgregarArticuloProducto(Articulo articulo)
        {
            if (articulo == null) throw new Exception("Datos incorrectos al intentar agregar Articulos.");
            _articulos.Add(articulo);
        }
        public void QuitarArticuloProducto(Articulo articulo)
        {
            if (articulo == null) throw new Exception("Datos incorrectos al intentar quitar Articulos.");
            _articulos.Remove(articulo);
        }
        public abstract void Finalizar(Cliente cliente);
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                 Usuario == null ||
                 string.IsNullOrEmpty(FechaPublicacion.ToString()))
            {
                throw new Exception("Datos incorrectos al intentar ingresar la PUBLICACIÓN.");
            }
            if (_articulos.Count == 0) throw new Exception("Debe seleccionar al menos un artículo para la publicacion");
            if (FechaPublicacion > DateTime.Now) throw new Exception("La fecha de publicacion no puede ser mayor a la actual.");
            foreach(Articulo unArticulo in _articulos)
            {
                if (unArticulo == null) throw new Exception("Articulo mal ingresado");
            }
        }
    }
}
