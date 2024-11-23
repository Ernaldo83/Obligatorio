
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public abstract class Usuario : IValidable
    {
        private static int _ultimoId;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Usuario()
        {
            Id = _ultimoId++;
        }

        public Usuario(string nombre,
                       string apellido,
                       string email,
                       string password)
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(Email) ||
                     string.IsNullOrEmpty(Password))
                throw new Exception("Nombre, Apellido, Mail y Pasword no pueden estar vacios.");
            ValidarPassword(Password);
        }
        public void ValidarPassword(string password)
        {
            int _numeros = 0;
            if (password.Length < 8) throw new Exception("La contraseña debe tener al menos 8 caracteres");
            for (int i = 0; i < password.Length; i++)
            {
                if (Convert.ToInt32(password[i]) >= 48 && Convert.ToInt32(password[i]) <= 57)
                { _numeros++; }
            }
            if (_numeros == password.Length || _numeros == 0) throw new Exception("La contraseña debe ser alfanumérica");
        }
        public abstract override string ToString();
    }
}
