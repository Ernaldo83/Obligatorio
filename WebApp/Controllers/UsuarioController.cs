using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;


namespace WebApp.Controllers
{

    public class UsuarioController : Controller
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
                return RedirectToAction("Index", "Index", new { msj });
            }
            msj = "El usuario no esta registrado";
            return RedirectToAction("Index", "Index", new { msj });
        }
        public IActionResult Registro()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult Registro(Cliente cliente) //string Nombre, string Apellido, string Email, string Password, decimal SaldoBilletera
        {
            string msj = string.Empty;
            try
            {
                _sistema.AgregarCliente(cliente);
                msj = "Usuario Registrado Correctamente";
            }
            catch (Exception e)
            {
               ViewBag.msj = e.Message;
                return View(cliente);
            }
            return RedirectToAction("index", "index", new { msj });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("mail");
            HttpContext.Session.Remove("pass");
            return RedirectToAction("Index", "Index");
        }
        [Logueado]
        public IActionResult Saldo(string msj)
        {
            try
            {
                string mail = HttpContext.Session.GetString("mail");
                Cliente cliente = _sistema.BuscarCliente(mail);
                if (cliente == null)
                {
                    throw new Exception("Error al buscar cliente en carga de saldo");
                }
                ViewBag.usuario = cliente;
                ViewBag.msj = msj;
                return View("AgregarSaldo");
            }
            catch (Exception e)
            {
                //msj = ;
                return RedirectToAction("Index", new { msj = e.Message });
            }
        }

        [Logueado]
        public ActionResult CargarSaldo(decimal Monto)
        {
            string msj = String.Empty;
            try
            {
                Cliente usuario = _sistema.BuscarCliente(HttpContext.Session.GetString("mail"));
                usuario.CargarSaldo(Monto);
                return RedirectToAction("Saldo", new { msj = "Carga de saldo efectuada correctamente" });
            }
            catch (Exception e)
            {
				return RedirectToAction("Saldo", new { msj = e.Message });
			}
           
        }
    }
}
