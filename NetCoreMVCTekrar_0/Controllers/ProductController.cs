using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreMVCTekrar_0.Models.ContextClasses;
using NetCoreMVCTekrar_0.Models.Entities;
using NetCoreMVCTekrar_0.Models.PageVMs;

namespace NetCoreMVCTekrar_0.Controllers
{
    public class ProductController : Controller
    {
        readonly MyContext _context;

        public ProductController(MyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateProduct()
        {
            CategoryPageVm cpVm = new()
            {
                Categories = await _context.Categories.ToListAsync()
               

            };

            
            return View(cpVm);
        }
    }
}
