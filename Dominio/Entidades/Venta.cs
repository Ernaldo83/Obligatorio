using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Venta : Publicacion, IValidable
    {
        public bool Oferta {get;set;}
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
        public override void Finalizar(Cliente cliente)
        {
            if (cliente.SaldoBilletera <= ObtenerPrecio()) throw new Exception("Saldo insuficiente para realizar la compra");
            UsuarioComprador = cliente;
			EstadoPublicacion = Estado.CERRADA;
			FechaFinalizado = DateTime.Now;
			cliente.SaldoBilletera -= ObtenerPrecio();
		}
        public override void Validar()
        {
            base.Validar();
        }
    }
}
