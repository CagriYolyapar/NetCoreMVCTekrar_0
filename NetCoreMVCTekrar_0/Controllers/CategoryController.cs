using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreMVCTekrar_0.Models.ContextClasses;
using NetCoreMVCTekrar_0.Models.Entities;

namespace NetCoreMVCTekrar_0.Controllers
{
    public class CategoryController : Controller
    {
        //ViewBag
        //ViewData
        //TempData




        readonly MyContext _context;


        public CategoryController(MyContext context)
        {
            _context = context;



        }

        public async Task<IActionResult> CategoryList()
        {
            List<Category> categories = await _context.Categories.ToListAsync();


            ViewBag.Mesaj = "Elimizdeki kategoriler:"; //ViewBag icerisinde dinamik tipte veri tutar...
            ViewData["Mesaj"] = "Elimizdeki kategoriler"; //ViewData icerisinde object tipte veri tutar...

            //ViewBag.Products = await _context.Products.ToListAsync(); (tavsiye edilmez cünkü ViewBag,TempData ve ViewData gibi transfer nesneleri kompleks tiplerle calısmak icin tasarlanmamıstır)

            //Eger BackEnd'deki bir Action bir View'a model gönderiyorsa View, o modeli aynı tipte karsılamak zorundadır...
            return View(categories);


          

        }


        public IActionResult CreateCategory()
        {
            return View();
        }


        //Eger Front End size bir model gönderiyorsa bu sefer backend'de onu karsılayacak post action'inizin parametresinde o modeli karsılamalısınız...

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);   
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }


        public async Task<IActionResult> UpdateCategory(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            Category originalCategory = await _context.Categories.FindAsync(category.Id);
            originalCategory.CategoryName = category.CategoryName;
            originalCategory.Description = category.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category silinecekCategory =await _context.Categories.FindAsync(id);
            _context.Categories.Remove(silinecekCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");


         
           
        }
    }
}
