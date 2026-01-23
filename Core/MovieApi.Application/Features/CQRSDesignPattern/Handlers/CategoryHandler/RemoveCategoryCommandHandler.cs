using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommand;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandler
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCategoryCommand command)
        {

            var value = await _context.Categories.FindAsync(command.CategoryId);
            _context.Remove(value);
            await _context.SaveChangesAsync();

           

        }
    }
}
