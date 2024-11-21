using Dominio.Interfaces;

namespace Dominio.Entidades
{
	public class Subasta : Publicacion, IValidable
	{
		private List<Oferta> _ofertas = new List<Oferta>();
	//	private List<Oferta> _ofertasFinalizadas = new List<Oferta>();

		public Subasta(string nombre,
				Estado estado,
				Administrador usuario,
				List<Articulo> articulos,
				DateTime fechaPublicacion
			  ) : base(nombre, estado, usuario, articulos, fechaPublicacion)
		{
		}
		public Subasta() { }

		public override IEnumerable<Articulo> Articulos()
		{
			return base.Articulos();
		}

		public List<Oferta> MostrarOfertas()
		{
			return _ofertas;
		}
		public override decimal ObtenerPrecio()
		{
			if (_ofertas.Count > 0)
			{
				return _ofertas[_ofertas.Count - 1].Precio;
			}
			return base.ObtenerPrecio();
		}
		public void CargarOferta(Oferta oferta)
		{
			oferta.Validar();
			if (oferta == null) throw new Exception("Parametro incorrecto para crear una oferta");
			if (EstadoPublicacion == Estado.CERRADA || EstadoPublicacion == Estado.CANCELADA) throw new Exception("No se puede ofertar en una publicacion Finalizada o Cancelada");
			if (_ofertas.Count > 0)
			{
				if (oferta.Precio <= _ofertas[_ofertas.Count - 1].Precio) throw new Exception("El valor debe ser mayor que el precio actual");
				if (oferta.Usuario.Equals(_ofertas[_ofertas.Count - 1].Usuario))
				{
					_ofertas[_ofertas.Count - 1].Precio = oferta.Precio;
				}
				else
				{
					_ofertas.Add(oferta);
				}
			}
			else
			{
				_ofertas.Add(oferta);
			}

		}
		public override void Validar()
		{
			base.Validar();
		}

		public override void Finalizar(Cliente cliente)
		{
			if (_ofertas.Count == 0)
			{
				EstadoPublicacion = Estado.CANCELADA;
				FechaFinalizado = DateTime.Now;
				throw new Exception("La subasta fue cancelada por falta de ofertas.");
			}
			bool _clienteValido = false;

			for (int i = _ofertas.Count - 1; i >= 0; i--)
			{
				Cliente unCliente = _ofertas[i].Usuario;
				if (ValidarSaldo(unCliente))
				{
					UsuarioComprador = unCliente;
					EstadoPublicacion = Estado.CERRADA;
					FechaFinalizado = DateTime.Now;
					unCliente.SaldoBilletera -= ObtenerPrecio();
					_clienteValido = true;
					break;
				}
				_ofertas.Remove(_ofertas[i]);
			}
			if (!_clienteValido)
			{
				EstadoPublicacion = Estado.CANCELADA;
				FechaFinalizado = DateTime.Now;
				throw new Exception("La subasta fue cancelada porque ningun cliente cuenta con saldo suficiente.");
			}
		}
		private bool ValidarSaldo(Cliente unCliente)
		{
			return unCliente.SaldoBilletera >= ObtenerPrecio();
		}
	}
}
