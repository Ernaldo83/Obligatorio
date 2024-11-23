using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Filtros;

namespace WebApp.Controllers
{
    [Logueado]
    public class PublicacionController : Controller
    {
        Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            string msj = string.Empty;

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
            IEnumerable<Publicacion> publicaciones = _sistema.ListaPublicaciones("todos", Estado.TODOS);
            ViewBag.usuario = usuario;
            ViewBag.Publicaciones = publicaciones;
            return View("Publicaciones");
        }
        public IActionResult Administrador(string msj)
        {
            ViewBag.msj = msj;
            Administrador usuario = _sistema.BuscarAdministrador(HttpContext.Session.GetString("mail"));
            IEnumerable<Publicacion> publicaciones = _sistema.ListaPublicaciones("subasta", Estado.TODOS);
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
        public IActionResult FinalizarSubasta(int Id, string msj)
        {
            Subasta subasta = _sistema.BuscarPublicacionSubasta(Id);
            ViewBag.Subasta = subasta;
            ViewBag.msj = msj;
            return View("FinalizarSubasta");
        }
        [HttpPost]
        public IActionResult FinalizarSubasta(Subasta subasta)
        {
            Subasta _subasta;
            
            try
            {
                Administrador usuario = _sistema.BuscarAdministrador(HttpContext.Session.GetString("mail"));
                _subasta = _sistema.BuscarPublicacionSubasta(subasta.Id);
                _sistema.FinalizarSubasta(_subasta, usuario);
            }
            catch (Exception e)
            {
                return RedirectToAction("Administrador", new { msj = e.Message });
            }
            return RedirectToAction("Administrador", new { msj = "Subasta finalizada con éxito" });
        }
        [HttpPost]
        public IActionResult ValidarOfertaSubasta(int Id, int oferta)
        {
            ViewBag.msj = String.Empty;
            try
            {
                Subasta subasta = _sistema.BuscarPublicacionSubasta(Id);
                Cliente unCliente = _sistema.BuscarCliente(HttpContext.Session.GetString("mail"));
                ViewBag.subasta = subasta;
                ViewBag.usuario = unCliente;

                subasta.CargarOferta(unCliente, oferta);
                ViewBag.msj = "Oferta cargada correctamente";
                return View("OfertarSubasta");
            }
            catch (Exception e)
            {
                ViewBag.msj = e.Message;
                return View("OfertarSubasta");
            }
        }
        [HttpGet]
        public IActionResult CompraPublicacion(int Id, string msj)
        {
            try
            {
                ViewBag.msj = msj;
                ViewBag.venta = _sistema.BuscarVenta(Id);
            }
            catch (Exception e)
            {
                ViewBag.msj = e.Message;
                return RedirectToAction("Cliente");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CompraPublicacion(Venta venta)
        {
            try
            {
                _sistema.FinalizarVenta(_sistema.BuscarVenta(venta.Id), _sistema.BuscarCliente(HttpContext.Session.GetString("mail")!));
                ViewBag.msj = "Compra exitosa";
            }
            catch (Exception e)
            {
                ViewBag.msj = e.Message;
                return RedirectToAction("CompraPublicacion", new { msj = e.Message });
            }
            return RedirectToAction("Cliente");
        }
    }
}

