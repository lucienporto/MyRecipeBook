using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.Recipes.Register
{
    public interface IRegisterRecipeUseCase
    {
        public Task<ResponseRegisteredRecipeJson> Execute(RequestRecipeJson request);
    }
}
