using Dominio;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string correo)
        {
            if(_sistema.BuscarAdministrador(correo)!= null)
            {
                return RedirectToAction("Administrador", "Publicacion", new {correo});
            }
            else if (_sistema.BuscarCliente(correo) != null)
            {
                return RedirectToAction("Cliente", "Publicacion", new { correo });
            }
            string msj = "WTF...";
            return RedirectToAction("index", "index", new {msj});
        }

        public IActionResult Cliente(string correo)
        {
            Cliente usuario = _sistema.BuscarCliente(correo);
            List <Publicacion> publicaciones = _sistema.ListaPublicaciones("todos", Estado.TODOS);
            ViewBag.usuario = usuario;
            ViewBag.Publicaciones = publicaciones;
            return View("Publicaciones");
        }
        public IActionResult Administrador(string correo)
        {
            Administrador usuario = _sistema.BuscarAdministrador(correo);
            List<Publicacion> publicaciones = _sistema.ListaPublicaciones("subasta", Estado.TODOS);
            ViewBag.usuario = usuario;
            ViewBag.Publicaciones = publicaciones;
            return View("Publicaciones");
        }
    }
}
