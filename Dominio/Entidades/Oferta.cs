
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Oferta:IValidable
    {
        public int Id { get; set; }
        private static int _ultimoId;
        public decimal Precio { get; set; }
        public Cliente Usuario;
        public DateTime Fecha { get; set; }

        public Oferta(Cliente usuario, decimal precio)
        {
            Id = _ultimoId++;
            Usuario = usuario;
            Precio = precio;
            Fecha = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Id Oferta: {Id}\nDatos del Oferente:\n\t" + 
                   $"Nombre: {Usuario.Nombre} {Usuario.Apellido}\n\t" + 
                   $"Email: {Usuario.Email}\nMonto de la puja: ${Precio}\nRealizado el: {Fecha}\n\n";
        }
        public void Validar()
        {
            if (Precio < 0) throw new Exception("El precio no puede ser menor que cero");
            if (Usuario == null) throw new Exception("El mail ingresado no corresponde a un cliente válido.");
        }
    }
}
