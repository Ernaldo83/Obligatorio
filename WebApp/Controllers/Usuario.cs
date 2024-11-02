using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{

    public class Usuario : Controller
    {
        Sistema _sistema = Sistema.Instancia;


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string pass)
        {
            string msj = string.Empty;
            try
            {
                if (_sistema.Login(correo, pass) != null)
                {
                    HttpContext.Session.SetString("mail", correo);
                    HttpContext.Session.SetString("pass", pass);
                    return RedirectToAction("index", "Publicacion");
                }
            }
            catch (Exception e)
            {
                msj = e.Message;
                return RedirectToAction("index", "index", new { msj });
            }
            msj = "El usuario no esta registrado";
            return RedirectToAction("index", "index", new { msj });
        }
        public IActionResult Registro()
        {
            return View(new Cliente());
        }
        [HttpPost]
        public IActionResult NuevoCliente(string Nombre, string Apellido, string Email, string Password, decimal SaldoBilletera)
        {
            _sistema.AgregarCliente(new Cliente(Nombre, Apellido, Email, Password, SaldoBilletera));
            string msj = "Usuario Registrado Correctamente";
            return RedirectToAction("index", "index", new { msj });
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("mail");
            HttpContext.Session.Remove("pass");
            return RedirectToAction("index", "index");
        }
        public IActionResult Saldo(string msj)
        {
            try
            {
                string mail = HttpContext.Session.GetString("mail");
                Cliente cliente = _sistema.BuscarCliente(mail);
                if (cliente == null) { throw new Exception("Error al buscar cliente en carga de saldo"); }
                ViewBag.usuario = cliente;
                ViewBag.msj = msj;
                return View("AgregarSaldo");
            }
            catch (Exception e)
            {
                msj = e.Message;
                return RedirectToAction("index", "index", new { msj });
            }
        }
        public ActionResult CargarSaldo(decimal Monto)
        {
            string msj = String.Empty;
            try
            {
                Cliente usuario = _sistema.BuscarCliente(HttpContext.Session.GetString("mail"));
                if(Monto > 0)
                {
                    usuario.SaldoBilletera += Monto;
                    msj = "Carga de saldo efectuada correctamente";
                    return RedirectToAction("Saldo", "usuario", new {msj});
                }
            }
            catch (Exception e)
            {
                msj = e.Message;
            }
            return RedirectToAction("Saldo", "usuario", new { msj });
        }
    }
}
