using Dominio.Interfaces;

namespace Dominio.Entidades
{
	public class Cliente : Usuario, IValidable, IEquatable<Cliente>
	{
		public decimal SaldoBilletera { get; set; }

		public Cliente() 
		{ 
		
		}

		public Cliente(
		   string nombre,
		   string apellido,
		   string email,
		   string password,
		   decimal Billetera) : base(nombre, apellido, email, password)
		{
			SaldoBilletera = Billetera;
		}
		public override string ToString()
		{
			string mensaje = string.Empty;
			mensaje += $"Id: {Id}\nNombre: {Nombre}\nApellido: {Apellido}\nEmail: {Email}\nCuentaSaldo: {SaldoBilletera}\nTipo: Cliente";
			return mensaje;
		}
		public override void Validar()
		{
			base.Validar();
            if (SaldoBilletera < 0) throw new Exception("El monto no puede ser negativo");
            if (SaldoBilletera == 0) throw new Exception("Solo pueden ingresarse valores numéricos mayores que cero");
        }

		public void CargarSaldo(decimal saldo)
		{
			if (saldo < 0) throw new Exception("El monto no puede ser negativo");
			if (saldo == 0) throw new Exception("Solo pueden ingresarse valores numéricos mayores que cero");
			SaldoBilletera += saldo;
		}

		public bool Equals(Cliente? other)
		{
			if (other == null) throw new Exception("Error 547");
			if (other.Email == Email) return true;
			return false;
		}
	}
}
