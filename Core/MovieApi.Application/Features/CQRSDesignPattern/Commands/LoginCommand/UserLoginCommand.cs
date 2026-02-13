using MovieApi.Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.LoginCommand
{
    public class UserLoginCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
