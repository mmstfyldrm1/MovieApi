using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandler
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQueries, List<GetTagQueriesResult>>
    {
        private readonly MovieContext _context;

        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQueriesResult>> Handle(GetTagQueries request, CancellationToken cancellationToken)
        {
            var values = await _context.Tags.ToListAsync();
           return values.Select(x=>new GetTagQueriesResult
           {
               TagId=x.TagId,
               Title=x.Title,   
           }).ToList(); 
        }
    }
}
