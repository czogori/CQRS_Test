using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Denormalization;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace ReadModel.Denormalizers
{
    public class TweetIndexItemDenormalizer : IEventHandler<TweetPostedEvent>
    {
        public void Handle(TweetPostedEvent evnt)
        {
            var context = new ReadModelDataContext();

            var newItem = new TweetIndexItem();
            newItem.Id = evnt.AggregateRootId;
            newItem.Message = evnt.Message;
            newItem.Who = evnt.Who;
            newItem.TimeStamp = evnt.Timestamp;

            context.TweetIndexItems.InsertOnSubmit(newItem);
            context.SubmitChanges();
        }
    }
}
