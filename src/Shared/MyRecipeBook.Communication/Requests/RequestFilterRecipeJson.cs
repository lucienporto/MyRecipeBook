using MyRecipeBook.Communication.Enums;

namespace MyRecipeBook.Communication.Requests
{
    public class RequestFilterRecipeJson
    {
        public string? RecipeTitle_Ingredient { get; set; }
        public IList<CookingTime> CookingTime { get; set; } = [];
        public IList<Difficulty> Difficulty { get; set; } = [];
        public IList<DishTypes> DishTypes { get; set; } = [];
    }
}
