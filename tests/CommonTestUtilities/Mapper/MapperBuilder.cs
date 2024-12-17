using AutoMapper;
using CommonTestUtilities.IdEncripter;
using MyRecipeBook.Application.Services.Automapper;

namespace CommonTestUtilities.Mapper
{
    public class MapperBuilder
    {
        public static IMapper Buid()
        {
            var idEncripter = IdEncripterBuilder.Build();

            return new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping(idEncripter));
            }).CreateMapper();
        }
    }
}
