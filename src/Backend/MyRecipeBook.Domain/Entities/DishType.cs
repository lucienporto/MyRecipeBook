namespace MyRecipeBook.Domain.Entities
{
    public  class DishType : EntityBase
    {
        public Enums.DishTypes Type { get; set; }
        public long RecipeId { get; set; }
    }
}
