using System;
namespace HoldPlease.Models
{
    public class Service
    {
        private int id;
        private string name;
        private User client;
        private User serviceProvider;
        private string status;
        private string location;
        private DateTime createdAt;
        private DateTime endAt;

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
