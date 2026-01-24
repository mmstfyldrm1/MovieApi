using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Command.CastCommand;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public UpdateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.FindAsync(request.CastId);
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Overview = request.Overview;
            values.Biography = request.Biography;
            values.Inageurl = request.Inageurl;
            values.Title = request.Title;
            await _movieContext.SaveChangesAsync();

        }
    }
}
