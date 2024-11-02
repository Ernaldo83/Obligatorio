using Dominio;
using Dominio.Entidades;
using System;
using System.Drawing;
namespace ConsolaApp
{
    public class Vistas : Program
    {
        private delegate void Parametro1();
        private static List<Parametro1> lista = new List<Parametro1>();
        public static void MenuInicio()
        {
            Console.Clear();
            ImprimirLogo();
            int opcion = ConstructorMenu(["Ingresar PRECARGAS", "Listar Clientes", "Publicaciones entre fechas", "Articulos por categorìa", "Alta de artìculo", "Salir"]);
            lista.Clear();
            lista.Add(PreCargar);
            lista.Add(ListarClientes);
            lista.Add(ListarEntreFechas);
            lista.Add(ListarArticulosFiltrado);
            lista.Add(AgregarArticulos);
            lista.Add(Salir);
            lista[opcion]();
        }

        private static void PreCargar()
        {
            _sistema.PreCargar();
            TextoColor("green", "Precargas ingresadas. Presione cualquier tecla para continuar...");
            Console.ReadKey();
            MenuInicio();
        }

        private static void ListarEntreFechas()
        {
            Console.Clear();
            Console.WriteLine("Filtrar Publicaciones entre dos fechas.");
            Console.WriteLine("Ingrese una fecha de inicio (DD/MM/YYYY).");
            DateTime fechaIncio = ObtenerFecha();
            Console.WriteLine("Ingrese una fecha final (DD/MM/YYYY).");
            DateTime fechaFinal = ObtenerFecha();
            List<Publicacion> publicaciones = new List<Publicacion>(_sistema.BuscarPublicacionEntreFecha(fechaIncio, fechaFinal));
            if (publicaciones.Count == 0)
            {
                TextoColor("yellow", $"No hay Publicaciones entre {fechaIncio.ToShortDateString()} y " +
                $"{fechaFinal.ToShortDateString()}");
            }
            else
            {
                foreach (Publicacion publicacion in publicaciones)
                {
                    string tipo = publicacion.GetType().Name;
                    Console.WriteLine($"ID: {publicacion.Id}\nTIPO: {tipo}\nESTADO: {publicacion.EstadoPublicacion}\n" +
                        $"FECHA DE PUBLICACION: {publicacion.FechaPublicacion.ToShortDateString()}\n");
                }
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            MenuInicio();
        }

        private static DateTime ObtenerFecha()
        {
            DateTime fecha = DateTime.Now;
            bool flag = false;
            do
            {
                try
                {
                    fecha = DateTime.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese un fecha válida en formato DD/MM/YYYY");
                }
            } while (!flag);
            return fecha;
        }

        private static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("CLIENTES\n");
            List<Usuario> listaUsuarios = new(_sistema.MostrarUsuarios(false));
            if (listaUsuarios.Count == 0)
            {
                TextoColor("yellow", "No hay Clientes para mostrar.");
            }
            else
            {
                foreach (Usuario usuario in listaUsuarios)
                {
                    Console.WriteLine(usuario.ToString() + "\n");
                }
            }
            TextoColor("yellow", "Presione cualquier tecla para continuar...");
            Console.ReadKey();
            MenuInicio();
        }

        private static void ListarArticulosFiltrado()
        {
            Console.Clear();
            Console.WriteLine("LISTAR ARTICULOS POR CATEGORIA");
            Console.WriteLine("Seleccione una categoria");
            List<string> categorias = new List<string>(MostrarCategoriasNombre());
            if (categorias.Count == 0)
            {
                TextoColor("yellow", "No hay Categorìas para mostrar.");
                Console.ReadKey();
                MenuInicio();
            }
            else
            {
            categorias.Add("Volver");
            int opcion = ConstructorMenu(categorias.ToArray());
            categorias = MostrarCategoriasNombre();
                List<Articulo> articulos = new List<Articulo>(_sistema.MostrarArticulos(categorias[opcion]));
                Console.Clear();
                if (articulos.Count == 0)
                {
                    TextoColor("yellow", "No hay Artículos para mostrar.");
                    Console.ReadKey();
                    MenuInicio();
                }
                else
                {
                    foreach (Articulo articulo in articulos)
                    {
                        Console.WriteLine(articulo.ToString());
                    }
                    TextoColor("yellow", "Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    MenuInicio();
                }
            }
        }
        private static void AgregarArticulos()
        {
            Console.Clear();
            Console.WriteLine("AGREGAR ARTICULO NUEVO");
            string categoria = SeleccionarCategorias(_sistema.MostrarCategorias());
            if (categoria != "Cancelar")
            {
                TextoColor("yellow", $"Categoría elegida: {categoria}");
                Console.WriteLine("Ingrese un nombre para el artículo:");
                string nombre = Console.ReadLine()!;
                decimal precio = PedirPrecio();
                AceptarArticulo(categoria, nombre, precio);
            }
            else
            {
                MenuInicio();
            }
        }

        private static decimal PedirPrecio()
        {
            decimal precio = 0;
            bool flag = false;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese el precio para el artículo:");
                    precio = decimal.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese solo números.");
                }
            } while (!flag);
            return precio;
        }

        private static void AceptarArticulo(string categoria, string nombre, decimal precio)
        {
            Console.Clear();
            Console.WriteLine("CONFIRMAR ARTICULO NUEVO");
            TextoColor("yellow", $"\nNOMBRE : {nombre.ToUpper()}\nPRECIO : {precio}\nCATEGORIA : {categoria}\n");
            int opcion = ConstructorMenu(["ACEPTAR", "CANCELAR"]);
            if (opcion == 0 && !string.IsNullOrEmpty(nombre) && precio > 0)
            {
                _sistema.AgregarArticulo(new Articulo(nombre, _sistema.BuscarCategoria(categoria), precio));
                Console.WriteLine("Producto agregado correctamente. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                MenuInicio();
            }
            else if (opcion != 0 && !string.IsNullOrEmpty(nombre) && precio > 0)
            {
                TextoColor("yellow", "Cancelado. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                MenuInicio();
            }
            else if (opcion == 0 || string.IsNullOrEmpty(nombre) || precio <= 0)
            {
                TextoColor("yellow", "Cancelado. Campo Categorias/Nombre vacias o precio incorrecto. Presione cualquier tecla para continuar...");
                Console.ReadKey();
                MenuInicio();
            }
        }
        private static string SeleccionarCategorias(List<Categoria> categorias)
        {
            int opcion;
            List<string> listaCategorias = new List<String>(MostrarCategoriasNombre());
            listaCategorias.Add("Cancelar");
            Console.Clear();
            Console.WriteLine("Seleccione una categoria para agregar al nuevo artículo");
            opcion = ConstructorMenu(listaCategorias.ToArray());
            string categoria = listaCategorias[opcion];
            return categoria;
        }
        //Bloque de muestra de listas como strings
        private static List<string> MostrarCategoriasNombre()
        {
            List<string> listaCategorias = new List<string>();
            foreach (Categoria item in _sistema.MostrarCategorias())
            {
                listaCategorias.Add(item.Nombre.ToString());
            }
            return listaCategorias;
        }

        private static void Salir()
        {
            TextoColor("green", "Has salido del sistema...\n-> Presiona cualquier tecla para cerrar esta ventanta");
            lista.Clear();
        }

        private static int ConstructorMenu(string[] opciones)
        {
            string menu = string.Empty;
            for (int i = 0; i < opciones.Length - 1; i++)
            {
                menu += $"\n({i + 1})_{opciones[i]}";
            }
            menu += $"\n(0)_{opciones[opciones.Length - 1]}\n";
            Console.WriteLine(menu);
            return SelectorMenu(opciones.Length);
        }
        private static int SelectorMenu(int opciones)
        {
            int opcion = 0;
            bool flag = false;
            do
            {
                opcion = PedirNumero("Seleccione una opcion del menú", opciones);
                flag = true;
                if (opcion > opciones - 1) flag = false;
            }
            while (!flag);
            if (opcion == 0) return opciones - 1;
            return opcion - 1;
        }
        private static void ImprimirLogo()
        {
            string C = "█";//alt+219
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t=============================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\t{C}{C}{C}{C}  {C}{C}{C}   {C}{C}{C}  {C}   {C}   {C}{C}{C}{C}");
            Console.WriteLine($"\t{C}    {C}   {C} {C}     {C}   {C}  {C}");
            Console.WriteLine($"\t{C}{C}   {C}   {C} {C}     {C}   {C}   {C}{C}{C}");
            Console.WriteLine($"\t{C}    {C}   {C} {C}     {C}   {C}      {C}");
            Console.WriteLine($"\t{C}     {C}{C}{C}   {C}{C}{C}   {C}{C}{C}   {C}{C}{C}{C}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t=============Tu Tienda Online\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void TextoColor(string color, string mensaje)
        {
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
            Console.WriteLine("\n" + mensaje);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static int PedirNumero(string titulo, int opciones)
        {
            bool flag = false;
            int numero = 0;
            do
            {
                try
                {
                    if (opciones > 10)
                    {
                        Console.WriteLine(titulo);
                        numero = int.Parse(Console.ReadLine()!);
                    }
                    else
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        numero = int.Parse($"{key.KeyChar}");
                    }
                    flag = true;
                }
                catch (Exception)
                {
                    TextoColor("red", "Ingrese solo numeros!!! Presione cualquier tecla para continuar...");
                }
            } while (!flag);
            return numero;
        }
    }
}
