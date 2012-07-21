using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;

namespace Commands
{
    public class PostNewTweetCommand : CommandBase
    {
        public string Message { get; set; }
        public string Who { get; set; }
    }
}
