﻿using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.Recipes.Filter
{
    public class FilterRecipeValidator : AbstractValidator<RequestFilterRecipeJson>
    {
        public FilterRecipeValidator()
        {
            RuleForEach(r => r.CookingTime).IsInEnum().WithMessage(ResourceMessageException.COOKING_TIME_NOT_SUPPORTED);
            RuleForEach(r => r.Difficulty).IsInEnum().WithMessage(ResourceMessageException.DIFFICULTY_LEVEL_NOT_SUPPORTED);
            RuleForEach(r => r.DishTypes).IsInEnum().WithMessage(ResourceMessageException.DISH_TYPE_NOT_SUPPORTED);
        }
    }
}
