using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Administrador : Usuario,IValidable
    {
        public Administrador() { }
        public Administrador(
           string nombre,
           string apellido,
           string email,
           string password): base(nombre,apellido,email,password)
        {         
        }
        public override string ToString()
        {          
            return $"Id: {Id}\nNombre: {Nombre}\nApellido: {Apellido}\nEmail: {Email}\nTipo: Administrador";         
        }
        public override void Validar()
        {
            base.Validar();
        }

    }
}
