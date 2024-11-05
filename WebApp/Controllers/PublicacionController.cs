using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string msj)
        {
            ViewBag.msj = msj;           
            try
            {
                string correo = HttpContext.Session.GetString("mail");
                if (_sistema.BuscarAdministrador(correo) != null)
                {
                    return RedirectToAction("Administrador", "Publicacion");
                }
                else if (_sistema.BuscarCliente(correo) != null)
                {
                    return RedirectToAction("Cliente", "Publicacion");
                }

            }
            catch (Exception e)
            {
                msj = e.Message;
                return RedirectToAction("index", "index", new { msj });
            }
            return RedirectToAction("index", "index", new { msj });
        }

        public IActionResult Cliente()
        {
            Cliente usuario = _sistema.BuscarCliente(HttpContext.Session.GetString("mail"));
            List<Publicacion> publicaciones = _sistema.ListaPublicaciones("todos", Estado.TODOS);
            ViewBag.usuario = usuario;
            ViewBag.Publicaciones = publicaciones;
            return View("Publicaciones");
        }
        public IActionResult Administrador()
        {
            Administrador usuario = _sistema.BuscarAdministrador(HttpContext.Session.GetString("mail"));
            List<Publicacion> publicaciones = _sistema.ListaPublicaciones("subasta", Estado.TODOS);
            ViewBag.usuario = usuario;
            ViewBag.Publicaciones = publicaciones;
            return View("Publicaciones");
        }
        
        public IActionResult OfertarSubasta(int Id)
        {
            Cliente usuario = _sistema.BuscarCliente(HttpContext.Session.GetString("mail"));
            Subasta subasta = _sistema.BuscarPublicacionSubasta(Id);
            ViewBag.usuario = usuario;
            ViewBag.subasta = subasta;
            return View();
        }
        [HttpGet]
        public IActionResult FinalizarSubasta(int Id)
        {
            ViewBag.Subasta = _sistema.BuscarPublicacionSubasta(Id);
            return View("FinalizarSubasta");
        }
        [HttpPost]
        public IActionResult FinalizarSubasta(Subasta subasta)
        {
            try
            {
                _sistema.FinalizarSubasta(subasta);
            }
            catch (Exception e)
            {
                ViewBag.msj = e.Message;
                return View();
            }          
            return RedirectToAction("Index", new { msj = "Subasta finalizada con éxito" });
        }
    }
}
