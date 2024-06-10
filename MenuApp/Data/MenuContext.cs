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

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Salatpizza",
                    ImageUrl = "https://images.arla.com/recordid/028FC826-276D-42A7-8E2E5E1E6F5F13B7/pizza-margherita-med-burrata.jpg?format=jpg&width=1200&height=630&mode=crop&crop=(0,1568,0,-54)",
                    Price = 10.99
                },
                new Dish
                {
                    Id = 2,
                    Name = "Seafood Boil",
                    ImageUrl = "https://www.allrecipes.com/thmb/XDFvpo7BXQ7_s920fAp28qox0PY=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/279460-Old-Bay-Seafood-Boil-ddmfs-139-4x3-aa189a5c09104659957fe6fcb715c4bd.jpg",
                    Price = 20.99
                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "Cheese"
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Tomato Sauce"
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Kebab"
                },
                new Ingredient
                {
                    Id = 4,
                    Name = "Shrimp"
                },
                new Ingredient
                {
                    Id = 5,
                    Name = "Crab"
                },
                new Ingredient
                {
                    Id = 6,
                    Name = "Corn"
                }
            );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient
                {
                    DishId = 1,
                    IngredientId = 1
                },
                new DishIngredient
                {
                    DishId = 1,
                    IngredientId = 2
                },
                new DishIngredient
                {
                    DishId = 1,
                    IngredientId = 3
                },
                new DishIngredient
                {
                    DishId = 2,
                    IngredientId = 4
                },
                new DishIngredient
                {
                    DishId = 2,
                    IngredientId = 5
                },
                new DishIngredient
                {
                    DishId = 2,
                    IngredientId = 6
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        // DbSet properties for the entities that will be used in the application.
        public DbSet<Dish> Dishes { get; set; } // DbSet property for the Dish entity
        public DbSet<Ingredient> Ingredients { get; set; } // DbSet property for the Ingredient entity
        public DbSet<DishIngredient> DishIngredients { get; set; } // DbSet property for the DishIngredient entity
    }
}
