using System;
namespace HoldPlease.Models
{
    public class User
    {
        public int ID {get; set;}
        public string name {get; set;}
        public string username {get; set;}
        public string costAvailability {get; set;}
        private string password {get; set;}
        // TODO Do we really need cost availability?
        public User()
        {
        }

        public Boolean UpdateCostAvailability(string newCostAvailability)
        {
            return true;
        }
    }
}
