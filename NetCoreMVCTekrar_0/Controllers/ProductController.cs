using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCTekrar_0.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
