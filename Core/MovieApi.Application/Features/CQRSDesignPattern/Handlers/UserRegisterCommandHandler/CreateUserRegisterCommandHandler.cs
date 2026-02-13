using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommand;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterCommandHandler
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly MovieContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateUserRegisterCommandHandler(MovieContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Handle(CreateUserRegisterCommand _createUserRegisterCommmand)
        {
            try
            {
                var user = new AppUser()
                {
                    CreatedDate = DateTime.Now,
                    Name = _createUserRegisterCommmand.Name,
                    UserName=_createUserRegisterCommmand.Name,
                    SurName = _createUserRegisterCommmand.SurName,
                    ImageUrl = _createUserRegisterCommmand.ImageUrl,
                };
                var result = await _userManager.CreateAsync(user, _createUserRegisterCommmand.Password);

                if (!result.Succeeded)
                {
                    Console.WriteLine(result.Errors);
                }

            }
            catch (Exception ex)
            {

              Console.WriteLine(ex.Message);
            }
           
        }
    }
}
