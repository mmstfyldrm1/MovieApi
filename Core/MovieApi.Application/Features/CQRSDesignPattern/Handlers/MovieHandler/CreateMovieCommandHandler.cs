using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandler
{
    public class CreateMovieCommandHandler
    {
        private readonly  MovieContext _movieContext;

        public CreateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateMovieCommand movieCommand)
        {
            _movieContext.Add(new Movie 
            {
               Title = movieCommand.Title,
               CoverImageUrl = movieCommand.CoverImageUrl,
               CreatedYear = movieCommand.CreatedYear,
               Description = movieCommand.Description,
               Duration = movieCommand.Duration,
               Rating = movieCommand.Rating,
               ReleaseDate = movieCommand.ReleaseDate,
               Status = movieCommand.Status


            });
           await _movieContext.SaveChangesAsync();   
        }
    }
}
