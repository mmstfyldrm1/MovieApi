using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Persistence.Identity
{
	public class AppUser:IdentityUser
	{
        public string Name { get; set; }

        public string SurName { get; set; }
        

        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }= DateTime.Now;    

        public DateTime? UpdatedDate { get; set;}



    }
}
