using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.DTO.Dtos.RegisterDtos
{
    public class CreateRegisterDto
    {
        public string Name { get; set; }

        public string? SurName { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public string? ImageUrl { get; set; }
    }
}
