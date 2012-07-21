using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Events;

namespace Domain
{
    public class Tweet : AggregateRootMappedByConvention
    {
        private string message;
        private string who;
        private DateTime timestamp;

        public Tweet(string message, string who)
        {
            var @event = new TweetPostedEvent()
            {
                Message = message,
                Who = who,
                Timestamp = DateTime.UtcNow
            };
            ApplyEvent(@event);
        }

        protected void OnTweetPosted(TweetPostedEvent e)
        {
            message = e.Message;
            who = e.Who;
            timestamp = e.Timestamp;
        }
    }
}
