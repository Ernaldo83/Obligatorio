using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Venta : Publicacion, IValidable
    {
        public bool Oferta { get; set; }
        public Venta()
        {

        }
        public Venta(string nombre,
                        Estado estado,
                        Administrador usuario,
                        List<Articulo> articulos,
                        DateTime fechaPublicacion) : base(nombre,
                                                           estado,
                                                           usuario,
                                                           articulos,
                                                           fechaPublicacion)
        {
            Oferta = false;
        }
        public override decimal ObtenerPrecio()
        {
            decimal preciofinal = base.ObtenerPrecio();
            return preciofinal;
        }
        public override void Finalizar(Usuario usuario)
        {
            Cliente cliente = (Cliente)usuario;
            if (EstadoPublicacion == Estado.CERRADA || EstadoPublicacion == Estado.CANCELADA) throw new Exception("No se puede comprar una publicacion Finalizada o Cancelada");
            if (cliente.SaldoBilletera <= ObtenerPrecio()) throw new Exception("Saldo insuficiente para realizar la compra");
            EstadoPublicacion = Estado.CERRADA;
            FechaFinalizado = DateTime.Now;
            cliente.SaldoBilletera -= ObtenerPrecio();
            UsuarioComprador = cliente;
            UsuarioFinalizador = cliente;
        }
        public override void Validar()
        {
            base.Validar();
        }
        public override void CargarOferta(Cliente cliente, int valorOferta)
        {

        }

    }
}
