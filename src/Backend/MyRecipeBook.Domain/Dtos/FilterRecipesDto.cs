using MyRecipeBook.Domain.Enums;

namespace MyRecipeBook.Domain.Dtos
{
    public record FilterRecipesDto
    {
        public string? RecipeTitle_Ingredient { get; init; }
        public IList<CookingTime> CookingTime { get; init; } = [];
        public IList<Difficulty> Difficulty { get; init; } = [];
        public IList<DishTypes> DishTypes { get; init; } = [];

    }
}
