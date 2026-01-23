using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandler
{
    public class GetCategoriesByIdQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetCategoriesByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetCategoryByIdQueryResults> Handle(GetCategoryByIdQuery command)
        {
            var values = await _movieContext.Categories.FindAsync(command.CategoryId);
            return new GetCategoryByIdQueryResults
            {
                CategoryId = values.CategoryId,
                CategoryName = values.CategoryName
            };
        }
    }
}
     