using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagByIdQueries:IRequest<GetTagByIdQueriesResult>
    {
        public GetTagByIdQueries(int tagId)
        {
            TagId = tagId;
        }

        public int TagId { get; set; }

        public string Title { get; set; }

    }
}
