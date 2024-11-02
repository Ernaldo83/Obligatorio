using Dominio;

namespace ConsolaApp
{
    public class Program
    {
        public static Sistema _sistema = new Sistema();
        static void Main(string[] args)
        {
            try
            {
                Vistas.MenuInicio(); //MENU DEL PROGRAMA
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }

    }
}
