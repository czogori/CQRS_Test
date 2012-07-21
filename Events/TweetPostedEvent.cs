using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;

namespace Events
{
    [Serializable]
    public class TweetPostedEvent : DomainEvent
    {
        public string Message { get; set; }
        public string Who { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
