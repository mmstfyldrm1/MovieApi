using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommand;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandler
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext movieContext;

        public UpdateCategoryCommandHandler(MovieContext movieContext)
        {
            this.movieContext = movieContext;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {

            var movie = await movieContext.Categories.FindAsync(command.CategoryId);
            movie.CategoryName = command.CategoryName;
            await movieContext.SaveChangesAsync();




        }
    }
}
