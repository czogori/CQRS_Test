using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Commands;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;

namespace CommandService
{    
    public class SimpleTwitterCommandService : ISimpleTwitterCommandService
    {
        public SimpleTwitterCommandService()
        {
            Bootstrapper.BootUp();
        }
        public void Execute(PostNewTweetCommand command)
        {
            var service = NcqrsEnvironment.Get<ICommandService>();
            service.Execute(command);
        }
    }
}
