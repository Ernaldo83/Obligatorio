using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Cliente : Usuario, IValidable
    {
        public decimal SaldoBilletera { get; set; }

        public Cliente() { }
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
            if (SaldoBilletera < 0) throw new Exception("El saldo no puede ser negativo");
        }
    }
}
