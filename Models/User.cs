using System;
namespace HoldPlease.Models
{
    public class User
    {
        private int id;
        private string name;
        private string username;
        private string password;
        // TODO Do we really need cost availability?
        private string costAvailability;

        public User()
        {
        }

        public Boolean UpdateCostAvailability(string newCostAvailability)
        {
            return true;    
        }
    }
}
