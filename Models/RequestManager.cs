using System;

namespace HoldPlease.Models
{
    public class RequestManager
    {
        public RequestManager()
        {
        }

        // TODO 
        public Service GetRequest(int serviceId)
        {
            return null; 
        }

		// TODO 
		public Service[] GetRequests(int userId)
        {
            return null;            
        }

		// TODO 
		public bool AcceptRequest(User user, Service service)
        {

			return true;
		}

		// TODO
        public bool CreateRequest(User user)
		{

			return true;
		}

		// TODO
        public bool CancelRequest(Service service)
		{

			return true;
		}

		// TODO
        public bool CompleteRequest(Service service)
		{

			return true;
		}

        // TODO
        public bool StartService(string newStatus)
        {
            return true;
        }

	}
}
