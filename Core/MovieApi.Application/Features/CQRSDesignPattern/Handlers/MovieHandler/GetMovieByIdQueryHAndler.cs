using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandler
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery command)
        {
            var values = await _context.Movies.FindAsync(command.MovieId);
            return new GetMovieByIdQueryResult
            {
                MovieId = values.MovieId,
                CoverImageUrl=values.CoverImageUrl,
                CreatedYear = values.CreatedYear,   
                Description = values.Description,
                Duration = values.Duration,
                Rating = values.Rating,
                ReleaseDate = values.ReleaseDate,   
                Status = values.Status,
                Title = values.Title
              
            };
        }
    }
}
