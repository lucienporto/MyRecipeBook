using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.Recipes
{
    public class RecipeValidator : AbstractValidator<RequestRecipeJson>
    {
        public RecipeValidator()
        {
            RuleFor(recipe => recipe.Title).NotEmpty().WithMessage(ResourceMessageException.RECIPE_TITLE_EMPTY);
            RuleFor(recipe => recipe.CookingTime).IsInEnum().WithMessage(ResourceMessageException.COOKING_TIME_NOT_SUPPORTED);
            RuleFor(recipe => recipe.Difficulty).IsInEnum().WithMessage(ResourceMessageException.DIFFICULTY_LEVEL_NOT_SUPPORTED);
        }
    }
}
