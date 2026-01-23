using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommand;
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
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateMovieCommands movieCommand)
        {
            var values = await _movieContext.Movies.FindAsync(movieCommand.MovieId);
            values.Title = movieCommand.Title;
            values.CoverImageUrl = movieCommand.CoverImageUrl;
            values.CreatedYear = movieCommand.CreatedYear;
            values.Description = movieCommand.Description;
            values.Duration = movieCommand.Duration;
            values.Rating = movieCommand.Rating;
            values.ReleaseDate = movieCommand.ReleaseDate;
            values.Status = movieCommand.Status;
            await _movieContext.SaveChangesAsync();
        }
    }
}
