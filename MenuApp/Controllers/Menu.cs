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

        // The searchString parameter is used to filter the list of dishes.
        // If the searchString parameter is not null or empty, the list of dishes is filtered by the Name property.
        // The list of dishes is then returned to the view.
        // If the searchString parameter is null or empty, the list of dishes is returned to the view.
        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes
                         select d;

            if(!string.IsNullOrEmpty(searchString) )
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());
            }

            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> ProductDetails(int? id)
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
