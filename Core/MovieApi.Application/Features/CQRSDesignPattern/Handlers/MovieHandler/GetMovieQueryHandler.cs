using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandler
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }


        public async Task<List<GetMovieQueryResult>> Handler()
        {
            var result = await _movieContext.Movies.ToListAsync();
            return result.Select(x => new GetMovieQueryResult
            {
                CoverImageUrl = x.CoverImageUrl,
                CreatedYear = x.CreatedYear,
                Description = x.Description,
                Duration = x.Duration,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                Status = x.Status,
                Title = x.Title,

            }).ToList();

        }
    }
}
