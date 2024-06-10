using Microsoft.AspNetCore.Mvc;
using MenuApp.Data;
using MenuApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;

        public Menu(MenuContext context)
        {
            _context = context;
        }

        // GET: Menu
        // This action method returns a view with a list of dishes.
        // The list of dishes is retrieved from the database.
        public async Task<IActionResult> Index()
        {
            return View( await _context.Dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }
        
    }
}
