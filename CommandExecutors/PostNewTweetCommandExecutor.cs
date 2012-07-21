using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution;
using Commands;
using Domain;

namespace CommandExecutors
{
    public class PostNewTweetCommandExecutor : CommandExecutorBase<PostNewTweetCommand>
    {
        protected override void ExecuteInContext(Ncqrs.Domain.IUnitOfWorkContext context, PostNewTweetCommand command)
        {
            var newTweet = new Tweet(command.Message, command.Who);
            context.Accept();
        }
    }
}
