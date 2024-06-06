namespace MenuApp.Models
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<DishIngredient>? DishIngredients { get; set; }
    }
}
