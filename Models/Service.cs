using System;
namespace HoldPlease.Models
{
    public class Service
    {
        public int ID {get;set;}
        public string name {get;set;}
        public User client {get;set;}
        public User serviceProvider {get;set;}
        public string status {get;set;}
        public string location {get;set;}
        public DateTime createdAt {get;set;}
        public DateTime endAt {get;set;}

        public Service()
        {
        }

        // TODO
        public Boolean CancelService()
        {
            return true;
        }

		// TODO
		public Boolean CompleteService()
        {
			return true;
		}

		// TODO
		public Boolean StartService()
        {
			return true;
		}
    }
}
