﻿using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Dtos;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Repositories.Recipe;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories
{
    public class RecipeRepository : IRecipeWriteOnlyRepository, IRecipeReadOnlyRepository
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public RecipeRepository(MyRecipeBookDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Recipe recipe) => await _dbContext.Recipes.AddAsync(recipe);

        public async Task<IList<Recipe>> Filter(User user, FilterRecipesDto filters)
        {
            var query = _dbContext.Recipes.AsNoTracking().Where(recipe => recipe.Active && recipe.UserId == user.Id);

            if(filters.Difficulty.Any())
            {
                query = query.Where(recipe => recipe.Difficulty.HasValue && filters.Difficulty.Contains(recipe.Difficulty.Value));
            }

            if (filters.CookingTime.Any())
            {
                query = query.Where(recipe => recipe.CookingTime.HasValue && filters.CookingTime.Contains(recipe.CookingTime.Value));
            }

            if (filters.DishTypes.Any())
            {
                query = query.Where(recipe => recipe.DishTypes.Any(dishType => filters.DishTypes.Contains(dishType.Type)));
            }

            if (filters.RecipeTitle_Ingredient.NotEmpty())
            {
                query = query.Where(
                    recipe => recipe.Title.Contains(filters.RecipeTitle_Ingredient) 
                    || recipe.Ingredients.Any(ingredient => ingredient.Item.Contains(filters.RecipeTitle_Ingredient)));
            }

            return await query.ToListAsync();
        }
    }
}
