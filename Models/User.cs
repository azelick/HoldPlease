using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HoldPlease.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string name {get; set;}
        public string costAvailability {get; set;}

        public Boolean UpdateCostAvailability(string newCostAvailability)
        {
            return true;
        }
    }
}
