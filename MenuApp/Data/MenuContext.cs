using MenuApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configuring the primary key for the DishIngredient entity.
            // The primary key is composed of two properties: DishId and IngredientId.
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            
            // Configuring the relationship between Dish and DishIngredient.    
            // The relationship is one-to-many.
            modelBuilder.Entity<DishIngredient>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DishId);

            // Configuring the relationship between Ingredient and DishIngredient.
            // The Ingredient entity has a collection of DishIngredient entities.
            // The DishIngredient entity has a reference to an Ingredient entity.
            // The relationship is one-to-many
            modelBuilder.Entity<DishIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.IngredientId);

            base.OnModelCreating(modelBuilder);
        }

        // DbSet properties for the entities that will be used in the application.
        public DbSet<Dish> Dishes { get; set; } // DbSet property for the Dish entity
        public DbSet<Ingredient> Ingredients { get; set; } // DbSet property for the Ingredient entity
        public DbSet<DishIngredient> DishIngredients { get; set; } // DbSet property for the DishIngredient entity
    }
}
