using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Command.CastCommand;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public CreateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _movieContext.Casts.Add(new Cast
            {
                Biography = request.Biography,
                Inageurl = request.Inageurl,
                Name = request.Name,
                Surname = request.Surname,
                Title = request.Title,
                Overview = request.Overview,
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
