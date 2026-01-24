using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastQueryById, GetCastByIdQueryResult>
    {
        private readonly MovieContext _movieContext;

        public GetCastByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastQueryById request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = values.CastId,
                Biography = values.Biography,
                Inageurl = values.Inageurl,
                Name = values.Name,
                Overview = values.Overview,
                Surname = values.Surname,
                Title = values.Title,

            };
        }
    }
}
