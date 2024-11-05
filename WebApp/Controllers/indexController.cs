using Microsoft.AspNetCore.Mvc;
using Dominio;


namespace WebApp.Controllers
{
    public class indexController : Controller
    {
        
        static Sistema _sistema= Sistema.Instancia;
        
        
        public IActionResult Index(string msj)
        {
            ViewBag.msj = msj;
            return View();
        }
    }
    
}
