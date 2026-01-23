using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommand;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandler
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            _movieContext.Add(new Category
            {
                CategoryName = command.CategoryName,
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
