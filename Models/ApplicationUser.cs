using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HoldPlease.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string name {get; set;}
        public string costAvailability {get; set;}

        public Boolean UpdateCostAvailability(string newCostAvailability)
        {
            return true;
        }

        public string GetPayPerHour()
        {
            Dictionary<string, string> availabilityDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(costAvailability);
            return availabilityDict["payPerHour"];
        }

        public string GetName()
        {
            return name;
        }
    }
}
