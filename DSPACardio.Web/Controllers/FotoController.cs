using Microsoft.AspNetCore.Mvc;

namespace DSPACardio.Web.Controllers
{
    //un controlador es una clase que es publica y lleva nombre y el apellido controller
    //
    public class FotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
