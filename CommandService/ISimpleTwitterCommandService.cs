using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Commands;

namespace CommandService
{    
    [ServiceContract]
    public interface ISimpleTwitterCommandService
    {
        [OperationContract]
        void Execute(PostNewTweetCommand command);
    }
}
