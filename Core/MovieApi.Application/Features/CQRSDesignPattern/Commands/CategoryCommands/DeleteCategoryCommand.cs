using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommand
{
    public class DeleteCategoryCommand
    {
        public int CategoryId { get; set; }
    }
}
