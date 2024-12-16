using CommonTestUtilities.Requests;
using FluentAssertions;
using MyRecipeBook.Application.UseCases.Recipes;
using MyRecipeBook.Exceptions;

namespace Validators.Test.Recipes
{
    public class RecipeValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new RecipeValidator();

            var request = RequestRecipeJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("                        ")]
        [InlineData("")]

        public void Error_Invalid_Title(string title)
        {
            var validator = new RecipeValidator();

            var request = RequestRecipeJsonBuilder.Build();
            request.Title = title;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.RECIPE_TITLE_EMPTY));
        }

        [Fact]
        public void Error_Invalid_CookinTime()
        {
            var validator = new RecipeValidator();

            var request = RequestRecipeJsonBuilder.Build();
            request.CookingTime = (MyRecipeBook.Communication.Enums.CookingTime?)100;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.COOKING_TIME_NOT_SUPPORTED));
        }

        [Fact]
        public void Error_Invalid_Difficulty()
        {
            var validator = new RecipeValidator();

            var request = RequestRecipeJsonBuilder.Build();
            request.Difficulty = (MyRecipeBook.Communication.Enums.Difficulty?)100;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.DIFFICULTY_LEVEL_NOT_SUPPORTED));
        }

        [Fact]
        public void Success_CookingTime_Null()
        {
            var validator = new RecipeValidator();

            var request = RequestRecipeJsonBuilder.Build();
            request.CookingTime = null;

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Success_Difficulty_Null()
        {
            var validator = new RecipeValidator();

            var request = RequestRecipeJsonBuilder.Build();
            request.Difficulty = null;

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }
    }
}
