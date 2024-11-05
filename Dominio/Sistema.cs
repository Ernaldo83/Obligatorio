using Dominio.Entidades;
namespace Dominio
{
    
    public class Sistema
    {
        private static Sistema _instancia;
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Categoria> _categorias = new List<Categoria>();

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                    _instancia.PreCargar();
                }
                
                return _instancia;
            }
        }
        #region "PRE CARGAS DEL SISTEMA"
        public void PreCargar()
        {
            PrecargarUsuarios();
            PrecargarCategorias();
            PrecargarArticulos();
            PrecargarPublicaciones();
            PrecargarOfertas();
        }
        
        private void PrecargarUsuarios()
        {
            //PROMT DE CHAT GPT
            //con el siguiente formato
            //AgregarCliente(new Cliente("Diego", "Geymonat", "dgeymonat85@gmail.com", "Geymon4t", 135000));
            //genera 10 usuarios con mail ficticios

            AgregarCliente(new Cliente("Diego", "Geymonat", "dgeymonat85@gmail.com", "Geymon4t", 135000));
            AgregarCliente(new Cliente("Ana", "Martínez", "ana.martinez92@example.com", "AnaM4rt", 150000));
            AgregarCliente(new Cliente("Luis", "Pérez", "luis.perez76@example.com", "Lui5Pez", 120000));
            AgregarCliente(new Cliente("María", "Lopez", "maria.lopez88@example.com", "Mar1Lopez", 140000));
            AgregarCliente(new Cliente("Carlos", "Sánchez", "carlos.sanchez80@example.com", "CarloS8", 160000));
            AgregarCliente(new Cliente("Laura", "González", "laura.gonzalez91@example.com", "LauR4Gonz", 110000));
            AgregarCliente(new Cliente("Javier", "Torres", "javier.torres89@example.com", "Jav1Torres", 130000));
            AgregarCliente(new Cliente("Sofía", "Ramírez", "sofia.ramirez85@example.com", "Sofi4Rami", 155000));
            AgregarCliente(new Cliente("Pedro", "Jiménez", "pedro.jimenez93@example.com", "Pedr0Jim", 145000));
            AgregarCliente(new Cliente("Isabel", "Cruz", "isabel.cruz90@example.com", "IsabeL90", 125000));
            AgregarCliente(new Cliente("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev@gmail.com", "3rn4ld0", 125000));

            //PROMT DE CHAT GPT
            //con el siguiente formato
            //AgregarAdministrador(new Administrador("Diego", "Geymonat", "dgeymonat84@gmail.com", "Geymon4t"));
            //genera 2 usuarios con mail ficticios
            AgregarAdministrador(new Administrador("Diego", "Geymonat", "dgeymonat84@gmail.com", "Geymon4t"));
            AgregarAdministrador(new Administrador("Lucía", "Fernández", "lucia.fernandez77@example.com", "Luc1aF"));

            //PRECARGAS CON ERROR
            // AgregarCliente(new Cliente("", "Geymonat", "dgeymonat85@gmail.com", "Geymon4t", 135000)); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
            // AgregarCliente(new Cliente("Diego", "", "dgeymonat85@gmail.com", "Geymon4t", 135000)); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
            // AgregarCliente(new Cliente("Diego", "Geymonat", "", "Geymon4t", 135000)); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
            // AgregarCliente(new Cliente("Diego", "Geymonat", "dgeymonat85@gmail.com", "", 135000)); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
            // AgregarCliente(new Cliente("Diego", "Geymonat", "dgey44monat85@gmail.com", "Geymon4t", -2)); --El saldo no puede ser negativo

            //AgregarAdministrador(new Administrador("", "Rodriguez", "ernaldo.rodriguez.dev1@gmail.com", "1234")); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
            //AgregarAdministrador(new Administrador("Ernaldo", "", "ernaldo.rodriguez.dev1@gmail.com", "1234")); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
            //AgregarAdministrador(new Administrador("Ernaldo", "Rodriguez", "", "1234")); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
            //AgregarAdministrador(new Administrador("Ernaldo", "Rodriguez", "ernaldo.rodriguez.dev1@gmail.com", "")); --Nombre, Apellido, Mail y Pasword no pueden estar vacios.
        }
        private void PrecargarCategorias()
        {
            AgregarCategoria(new Categoria("Deportes", "Todo lo necesario para el deporte"));
            AgregarCategoria(new Categoria("Indumentaria", "Distintas prendas para distintas ocasiones"));
            AgregarCategoria(new Categoria("Salud", "Todo para el cuidado"));
            AgregarCategoria(new Categoria("Tecnología", "Celulares, computadoras, consolas y más..."));
            AgregarCategoria(new Categoria("Niños", "Todo para los peques"));
            AgregarCategoria(new Categoria("Hogar", "Accesorio para el hogar"));
            AgregarCategoria(new Categoria("Entretenimiento", "Para tu tiempo libre"));
            AgregarCategoria(new Categoria("Educación", "Para crecer y aprender"));

            //PRECARGAS CON ERROR
            //AgregarCategoria(new Categoria("", "Todo lo necesario para el deporte")); --Nombre de la Categoría, sin datos
            //AgregarCategoria(new Categoria("Deportes", "")); --Decripción de la categoria, sin datos
        }
        private void PrecargarArticulos()
        {
            //PROMT DE CHAT GPT
            //con las siguientes categorias :
            //Deportes
            //Indumentaria
            //Salud
            //Tecnología 
            //Niños
            //Hogar
            //Educación
            //y con el siguiente formato
            //AgregarArticulo(new Articulo("Zapatillas de correr", BuscarCategoria("Indumentaria"), 80));
            //generar 50 articulos diferentes de bazar

            AgregarArticulo(new Articulo("Zapatillas de correr", BuscarCategoria("Indumentaria"), 80));
            AgregarArticulo(new Articulo("Pelota de fútbol", BuscarCategoria("Deportes"), 30));
            AgregarArticulo(new Articulo("Botella de agua reutilizable", BuscarCategoria("Salud"), 15));
            AgregarArticulo(new Articulo("Auriculares inalámbricos", BuscarCategoria("Tecnología"), 60));
            AgregarArticulo(new Articulo("Juguete de bloques", BuscarCategoria("Niños"), 25));
            AgregarArticulo(new Articulo("Juego de sábanas", BuscarCategoria("Hogar"), 50));
            AgregarArticulo(new Articulo("Libro de matemáticas", BuscarCategoria("Educación"), 20));
            AgregarArticulo(new Articulo("Raqueta de tenis", BuscarCategoria("Deportes"), 100));
            AgregarArticulo(new Articulo("Mochila escolar", BuscarCategoria("Indumentaria"), 40));
            AgregarArticulo(new Articulo("Suplemento vitamínico", BuscarCategoria("Salud"), 30));
            AgregarArticulo(new Articulo("Smartwatch", BuscarCategoria("Tecnología"), 120));
            AgregarArticulo(new Articulo("Juego de pintura", BuscarCategoria("Niños"), 45));
            AgregarArticulo(new Articulo("Cojín decorativo", BuscarCategoria("Hogar"), 25));
            AgregarArticulo(new Articulo("Cuaderno de notas", BuscarCategoria("Educación"), 10));
            AgregarArticulo(new Articulo("Balón de baloncesto", BuscarCategoria("Deportes"), 40));
            AgregarArticulo(new Articulo("Chaqueta impermeable", BuscarCategoria("Indumentaria"), 90));
            AgregarArticulo(new Articulo("Té orgánico", BuscarCategoria("Salud"), 12));
            AgregarArticulo(new Articulo("Cámara digital", BuscarCategoria("Tecnología"), 200));
            AgregarArticulo(new Articulo("Rompecabezas de animales", BuscarCategoria("Niños"), 30));
            AgregarArticulo(new Articulo("Lámpara de mesa", BuscarCategoria("Hogar"), 55));
            AgregarArticulo(new Articulo("Libro de ciencias", BuscarCategoria("Educación"), 22));
            AgregarArticulo(new Articulo("Patineta", BuscarCategoria("Deportes"), 80));
            AgregarArticulo(new Articulo("Gorra deportiva", BuscarCategoria("Indumentaria"), 20));
            AgregarArticulo(new Articulo("Aceite esencial", BuscarCategoria("Salud"), 18));
            AgregarArticulo(new Articulo("Tablet", BuscarCategoria("Tecnología"), 250));
            AgregarArticulo(new Articulo("Kits de ciencia", BuscarCategoria("Niños"), 35));
            AgregarArticulo(new Articulo("Estante de libros", BuscarCategoria("Hogar"), 120));
            AgregarArticulo(new Articulo("Diccionario ilustrado", BuscarCategoria("Educación"), 15));
            AgregarArticulo(new Articulo("Set de pesas", BuscarCategoria("Deportes"), 70));
            AgregarArticulo(new Articulo("Camiseta de deporte", BuscarCategoria("Indumentaria"), 25));
            AgregarArticulo(new Articulo("Batido de proteínas", BuscarCategoria("Salud"), 35));
            AgregarArticulo(new Articulo("Altavoz Bluetooth", BuscarCategoria("Tecnología"), 90));
            AgregarArticulo(new Articulo("Muñeca de acción", BuscarCategoria("Niños"), 40));
            AgregarArticulo(new Articulo("Organizador de cocina", BuscarCategoria("Hogar"), 30));
            AgregarArticulo(new Articulo("Manual de gramática", BuscarCategoria("Educación"), 20));
            AgregarArticulo(new Articulo("Bicicleta", BuscarCategoria("Deportes"), 500));
            AgregarArticulo(new Articulo("Zapatos de vestir", BuscarCategoria("Indumentaria"), 100));
            AgregarArticulo(new Articulo("Mascarilla facial", BuscarCategoria("Salud"), 10));
            AgregarArticulo(new Articulo("PC portátil", BuscarCategoria("Tecnología"), 800));
            AgregarArticulo(new Articulo("Set de arte", BuscarCategoria("Niños"), 45));
            AgregarArticulo(new Articulo("Alfombra antideslizante", BuscarCategoria("Hogar"), 75));
            AgregarArticulo(new Articulo("Atlas del mundo", BuscarCategoria("Educación"), 30));
            AgregarArticulo(new Articulo("Kit de escalada", BuscarCategoria("Deportes"), 150));
            AgregarArticulo(new Articulo("Pantalones deportivos", BuscarCategoria("Indumentaria"), 60));
            AgregarArticulo(new Articulo("Protector solar", BuscarCategoria("Salud"), 20));
            AgregarArticulo(new Articulo("Dispositivo de streaming", BuscarCategoria("Tecnología"), 100));
            AgregarArticulo(new Articulo("Juego de mesa", BuscarCategoria("Niños"), 50));
            AgregarArticulo(new Articulo("Cuchillos de cocina", BuscarCategoria("Hogar"), 80));
            AgregarArticulo(new Articulo("Libro de literatura", BuscarCategoria("Educación"), 25));
            AgregarArticulo(new Articulo("Tabla de surf", BuscarCategoria("Deportes"), 300));
            AgregarArticulo(new Articulo("Bufanda de lana", BuscarCategoria("Indumentaria"), 50));
            AgregarArticulo(new Articulo("Termómetro digital", BuscarCategoria("Salud"), 25));
            AgregarArticulo(new Articulo("Router WiFi", BuscarCategoria("Tecnología"), 80));
            AgregarArticulo(new Articulo("Juego de construcción", BuscarCategoria("Niños"), 55));
            AgregarArticulo(new Articulo("Cama plegable", BuscarCategoria("Hogar"), 250));
            AgregarArticulo(new Articulo("Libro de arte", BuscarCategoria("Educación"), 30));

            //PRECARGAS CON ERROR
            //AgregarArticulo(new Articulo("", BuscarCategoria("Indumentaria"), 80)); --En nombre no puede ser vacio o nulo
            //AgregarArticulo(new Articulo("Zapatillas de correr", BuscarCategoria(""), 80)); --No se ha cargado la categoria en el parametro
            //AgregarArticulo(new Articulo("Zapatillas de correr", BuscarCategoria("Indumentaria"), 0)); --El precio no puede ser cero o negativo
        }
        private void PrecargarPublicaciones()
        {
            //VENTAS
            AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(20), BuscarArticulo(25),
               BuscarArticulo(42), BuscarArticulo(38)}, FechaRandom()));
            AgregarPublicacion(new Venta("Mantente en forma", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(45), BuscarArticulo(38),
               BuscarArticulo(25)}, FechaRandom()));
            AgregarPublicacion(new Venta("Sal de tu casa", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> { BuscarArticulo(42), BuscarArticulo(25),
               BuscarArticulo(20), BuscarArticulo(45) }, FechaRandom()));
            AgregarPublicacion(new Venta("Luce el mejor look", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(26), BuscarArticulo(48),
               BuscarArticulo(17), BuscarArticulo(9)}, FechaRandom()));
            AgregarPublicacion(new Venta("Mantente saludable", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(46), BuscarArticulo(13),
               BuscarArticulo(7)}, FechaRandom()));
            AgregarPublicacion(new Venta("Para cuidar tu cuerpo", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(43), BuscarArticulo(35),
               BuscarArticulo(2), BuscarArticulo(32)}, FechaRandom()));
            AgregarPublicacion(new Venta("Para quedarte en casa", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(41), BuscarArticulo(8),
               BuscarArticulo(10)}, FechaRandom()));
            AgregarPublicacion(new Venta("Cultiva tu mente", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(31), BuscarArticulo(49),
               BuscarArticulo(24), BuscarArticulo(5)}, FechaRandom()));
            AgregarPublicacion(new Venta("Mantente actualizado", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(28), BuscarArticulo(22),
               BuscarArticulo(12), BuscarArticulo(3)}, FechaRandom()));
            AgregarPublicacion(new Venta("Lo que no te puede faltar", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(17), BuscarArticulo(9),
               BuscarArticulo(1), BuscarArticulo(0)}, FechaRandom()));

            //SUBASTAS
            AgregarPublicacion(new Subasta("Verano en la Playa", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(4), BuscarArticulo(6),
               BuscarArticulo(9), BuscarArticulo(45)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Mantente en forma", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(45), BuscarArticulo(38),
               BuscarArticulo(25)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Sal de tu casa", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> { BuscarArticulo(42), BuscarArticulo(25),
               BuscarArticulo(20), BuscarArticulo(45) }, FechaRandom()));
            AgregarPublicacion(new Subasta("Luce el mejor look", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(26), BuscarArticulo(48),
               BuscarArticulo(17), BuscarArticulo(9)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Mantente saludable", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(46), BuscarArticulo(13),
               BuscarArticulo(7)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Para cuidar tu cuerpo", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(43), BuscarArticulo(35),
               BuscarArticulo(2), BuscarArticulo(32)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Para quedarte en casa", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(41), BuscarArticulo(8),
               BuscarArticulo(10)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Cultiva tu mente", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(31), BuscarArticulo(49),
               BuscarArticulo(24), BuscarArticulo(5)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Mantente actualizado", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(28), BuscarArticulo(22),
               BuscarArticulo(12), BuscarArticulo(3)}, FechaRandom()));
            AgregarPublicacion(new Subasta("Lo que no te puede faltar", Estado.ABIERTA,
               BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(17), BuscarArticulo(9),
               BuscarArticulo(1), BuscarArticulo(0)}, FechaRandom()));

            //PRECARGAS CON ERROR
            //AgregarPublicacion(new Venta("", Estado.ABIERTA,
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(20)}, FechaRandom())); --Datos incorrectos al intentar ingresar la PUBLICACIÓN.
            //AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
            //   BuscarAdministrador(""), new List<Articulo> { BuscarArticulo(20) }, FechaRandom())); --No se ha cargado el email en el parametro
            //AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> { BuscarArticulo(1540) }, FechaRandom())); --Articulo mal ingresado
            //AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> { BuscarArticulo(20) }, new DateTime(2025,12,20))); --La fecha de publicacion no puede ser mayor a la actual.
            //AgregarPublicacion(new Venta("Verano en la Playa", Estado.ABIERTA,
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {}, FechaRandom())); --Debe seleccionar al menos un artículo para la publicacion

            //AgregarPublicacion(new Subasta("", Estado.ABIERTA,
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(17), BuscarArticulo(9),
            //   BuscarArticulo(1), BuscarArticulo(0)}, FechaRandom())); ----Datos incorrectos al intentar ingresar la PUBLICACIÓN.
            //AgregarPublicacion(new Subasta("Lo que no te puede faltar", Estado.ABIERTA,
            //   BuscarAdministrador(""), new List<Articulo> {BuscarArticulo(17), BuscarArticulo(9),
            //   BuscarArticulo(1), BuscarArticulo(0)}, FechaRandom())); ----No se ha cargado el email en el parametro
            //AgregarPublicacion(new Subasta("Lo que no te puede faltar", Estado.ABIERTA,
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(17), BuscarArticulo(9),
            //   BuscarArticulo(1), BuscarArticulo(1000)}, FechaRandom())); ----Articulo mal ingresado
            //AgregarPublicacion(new Subasta("Lo que no te puede faltar", Estado.ABIERTA,
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {BuscarArticulo(17), BuscarArticulo(9),
            //   BuscarArticulo(1), BuscarArticulo(0)}, new DateTime(2025,12,20))); ----La fecha de publicacion no puede ser mayor a la actual.
            //   BuscarAdministrador("dgeymonat84@gmail.com"), new List<Articulo> {}, FechaRandom())); ----Debe seleccionar al menos un artículo para la publicacion
        }
        private void PrecargarOfertas()
        {
            Subasta unaPublicacion = BuscarPublicacionSubasta(10);
            unaPublicacion.CargarOferta(new Oferta(BuscarCliente("ernaldo.rodriguez.dev@gmail.com"), 1334));
            unaPublicacion.CargarOferta(new Oferta(BuscarCliente("dgeymonat85@gmail.com"), 256));
            unaPublicacion = BuscarPublicacionSubasta(19);
            unaPublicacion.CargarOferta(new Oferta(BuscarCliente("ernaldo.rodriguez.dev@gmail.com"), 1334));
            unaPublicacion.CargarOferta(new Oferta(BuscarCliente("dgeymonat85@gmail.com"), 256));

            //Subasta unaPublicacion = BuscarPublicacionSubasta(1);
            //unaPublicacion.CargarOferta(new Oferta(BuscarCliente("ernaldo.rodriguez.dev@gmail.com"), 1334)); --El id ingresado no es una subasta.
            //Subasta unaPublicacion = BuscarPublicacionSubasta(20);
            //unaPublicacion.CargarOferta(new Oferta(BuscarCliente("ernaldo.rodriguez.dev@gmail.com"), 1334));--La publicación no es válida.
            //Subasta unaPublicacion = BuscarPublicacionSubasta(10);
            //unaPublicacion.CargarOferta(new Oferta(BuscarCliente(""), 1334));--No se ha cargado el email en el parametro
            //Subasta unaPublicacion = BuscarPublicacionSubasta(10);
            //unaPublicacion.CargarOferta(new Oferta(BuscarCliente("dgeymonat84@gmail.com"), 1334))--El mail ingresado no corresponde a un cliente válido.
            //Subasta unaPublicacion = BuscarPublicacionSubasta(10);
            //unaPublicacion.CargarOferta(new Oferta(BuscarCliente("fghdfhdgh"), 1334)) --El mail ingresado no corresponde a un cliente válido.
        }
        private static DateTime FechaRandom()
        {
            bool flag = false;
            DateTime fecha;
            do
            {
                int anio = new Random().Next(2022, 2025);
                int mes = new Random().Next(1, 13);
                int dia = new Random().Next(1, 29);
                fecha = new DateTime(anio, mes, dia);
                DateTime fechaActual = DateTime.Now;
                if (fechaActual > fecha)
                    flag = true;
            } while (!flag);
            return fecha;
        }
        #endregion

        public Cliente BuscarCliente(string email)
        {
            if (String.IsNullOrEmpty(email)) throw new Exception("No se ha cargado el email en el parametro");
            foreach (Usuario unUsuario in _usuarios)
            {
                if (unUsuario.Email == email && unUsuario is Cliente)
                {
                    return (Cliente)unUsuario;
                }
            }
            return null!;
        }
        public Administrador BuscarAdministrador(string email)
        {
            if (String.IsNullOrEmpty(email)) throw new Exception("No se ha cargado el email en el parametro");
            foreach (Usuario unUsuario in _usuarios)
            {
                if (unUsuario.Email == email && unUsuario is Administrador)
                {
                    return (Administrador)unUsuario;
                }
            }
            return null!;
        }
        public Usuario Login(string mail, string password)
        {
            if (String.IsNullOrEmpty(mail)) throw new Exception("No se ha ingresado el email");
            if (String.IsNullOrEmpty(password)) throw new Exception("No se a ingresado el password");
            foreach (Usuario item in _usuarios)
            {
                if (item.Email == mail)
                {
                    if (item.ObtenerPassword()== password)
                    {
                        if (item is Cliente)
                        {
                            return (Cliente)item;
                        }
                        else
                        {
                            return (Administrador)item;
                        }
                    }
                    else
                    {
                        throw new Exception("Constraseña incorrecta");
                    }
                }
            }
            return null;
        }
        public Categoria BuscarCategoria(string categoria)
        {
            if (String.IsNullOrEmpty(categoria)) throw new Exception("No se ha cargado la categoria en el parametro");
            foreach (Categoria unaCategoria in _categorias)
            {
                if (unaCategoria.Nombre == categoria) return unaCategoria;
            }
            return null!;
        }
        public Articulo BuscarArticulo(int idArticulo)
        {
            if (!int.TryParse(idArticulo.ToString(), out _)) throw new Exception("No se ha pasado un número");
            foreach (Articulo unArticulo in _articulos)
            {
                if (unArticulo.Id == idArticulo) return unArticulo;
            }
            return null!;
        }
        public Subasta BuscarPublicacionSubasta(int idPublicacion)
        {
            if (!int.TryParse(idPublicacion.ToString(), out _)) throw new Exception("ingrese un id valido de publicacion");
            foreach (Publicacion unaPublicacion in _publicaciones)
            {
                if (unaPublicacion.Id == idPublicacion)
                {
                    if (unaPublicacion is not Subasta) throw new Exception("El id ingresado no es una subasta");
                    return (Subasta)unaPublicacion;
                }
            }
            throw new Exception("La publicación no es válida.");
        }
        public List<Usuario> MostrarUsuarios(bool admin)
        {
            List<Usuario> unaLista = new List<Usuario>();

            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente && !admin)
                {
                    unaLista.Add(usuario);
                }
                else if (usuario is Administrador && admin)
                {
                    unaLista.Add(usuario);
                }
            }
            return unaLista;
        }
        public List<Categoria> MostrarCategorias()
        {
            return _categorias;
        }
        public List<Publicacion> ListaPublicaciones(string tipo, Estado estado)
        {
            if (string.IsNullOrEmpty(tipo)) throw new Exception("No se ha cargado el tipo en el parametro");
            List<Publicacion> publicaciones = new List<Publicacion>();

            foreach (Publicacion unaPublicacion in _publicaciones)
            {
                if (tipo.ToUpper() == "TODOS")
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
                else if (tipo.ToUpper() == "VENTA" && unaPublicacion is Venta)
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
                else if (tipo.ToUpper() == "SUBASTA" && unaPublicacion is Subasta)
                {
                    if (estado == unaPublicacion.EstadoPublicacion)
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                    else if (estado.ToString() == "TODOS")
                    {
                        publicaciones.Add(unaPublicacion);
                    }
                }
            }
            return publicaciones;
        }
        public List<Publicacion> BuscarPublicacionEntreFecha(DateTime fecha1, DateTime fecha2)
        {
            DateTime fechaMayor = fecha1;
            if (fecha1> fecha2)
            {
                fecha1 = fecha2;
                fecha2 = fechaMayor;
            }
            List<Publicacion> publicaciones = new List<Publicacion>();
            foreach (Publicacion publicacion in _publicaciones)
            {
                if (publicacion.FechaPublicacion >= fecha1 && publicacion.FechaPublicacion <= fecha2)
                {
                    publicaciones.Add(publicacion);
                }
            }
            return publicaciones;
        }
        public List<Articulo> MostrarArticulos(string categoria)
        {
            List<Articulo> resultado = new List<Articulo>();
            if (categoria.ToUpper() == "TODOS")
            {
                foreach (Articulo unArticulo in _articulos) resultado.Add(unArticulo);
            }
            else
            {
                foreach (Articulo unArticulo in _articulos)
                {
                    if (unArticulo.UnaCategoria.Nombre == categoria) resultado.Add(unArticulo);
                }
            }
            return resultado;
        }


        //Bloque de Add en las listas
        public void AgregarArticulo(Articulo nuevoArticulo)
        {
            if (nuevoArticulo == null) throw new Exception("Valor nulo en el parametro de agregar artículo");
            nuevoArticulo.Validar();
            _articulos.Add(nuevoArticulo);
        }
        public void AgregarPublicacion(Publicacion nuevaPublicacion)
        {
            if (nuevaPublicacion == null) throw new Exception("Valor nulo en el parametro publicacion");
            nuevaPublicacion.Validar();
            _publicaciones.Add(nuevaPublicacion);
        }
        public void AgregarCategoria(Categoria nuevaCategoria)
        {
            if (nuevaCategoria == null) throw new Exception("Valor nulo en el parametro de agregar categoría");
            nuevaCategoria.Validar();
            _categorias.Add(nuevaCategoria);
        }
        public void AgregarCliente(Cliente nuevoUsuario)
        {
            if (nuevoUsuario == null) throw new Exception("Valor nulo en el parametro de agregar usuario");
            nuevoUsuario.Validar();
            if (BuscarCliente(nuevoUsuario.Email) != null) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
        }
        public void AgregarAdministrador(Administrador nuevoUsuario)
        {
            if (nuevoUsuario == null) throw new Exception("Valor nulo en el parametro de agregar usuario");
            nuevoUsuario.Validar();
            if (BuscarAdministrador(nuevoUsuario.Email) != null) throw new Exception("El usuario ya existe");
            _usuarios.Add(nuevoUsuario);
        }

        public void FinalizarSubasta(Subasta subasta)
        {
            if (subasta == null) throw new Exception("Sin el objeto subtasta para finalizar");
            subasta.Finalizar();
        }
    }
}
