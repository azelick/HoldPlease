using System;
using System.Linq;
using System.Collections.Generic;
namespace HoldPlease.Models
{
    public class Service
    {
        public int ID {get;set;}
        public string name {get;set;}
        public string clientId {get;set;}
        public string serviceProviderId {get;set;}
        public string status {get;set;}
        public string location {get;set;}
        public DateTime startAt {get;set;}
        public DateTime endAt {get;set;}
        public string notified {get;set;}

        public Service()
        {
        }

        public string[] GetNotified()
        {
            if (notified == null)
            {
                return new string[0];
            }

            return notified.Split(',');
        }

        public Boolean HasNotified(string email)
        {
            if (notified == null)
            {
                return false;
            }

            var notifiedList = notified.Split(',');
            return notifiedList.Any(str => str.Contains(email));
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
