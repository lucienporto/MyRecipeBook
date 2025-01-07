using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.Recipes.Filter
{
    public interface IFilterRecipeUseCase
    {
        public Task<ResponseRecipesJson> Execute(RequestFilterRecipeJson request);
    }
}
