
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public abstract class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        private string _password;
        private static int _ultimoId;

        public string Password
        {
            set { _password = value; }
        }
        public string ObtenerPassword()
        {
            return _password;
        }

        public Usuario() { }

        public Usuario(string nombre,
                       string apellido,
                       string email,
                       string password)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            _password = password;
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(Email) ||
                     string.IsNullOrEmpty(_password))
                throw new Exception("Nombre, Apellido, Mail y Pasword no pueden estar vacios.");
            ValidarPassword(_password);
        }
        public void ValidarPassword(string password)
        {

        }


        public abstract override string ToString();
    }
}
