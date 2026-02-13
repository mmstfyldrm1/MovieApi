using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommand
{
    public class CreateUserRegisterCommand
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Password { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }=DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

       
    }
}
