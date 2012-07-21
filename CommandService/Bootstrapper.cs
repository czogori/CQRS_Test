using CommandExecutors;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;
using Ncqrs.Eventing.ServiceModel.Bus;
using ReadModel.Denormalizers;    

namespace CommandService
{
    public static class Bootstrapper
    {
        public static void BootUp()
        {
            NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
            NcqrsEnvironment.SetDefault<IEventStore>(InitializeEventStore());
            NcqrsEnvironment.SetDefault<IEventBus>(InitializeEventBus());
        }

        private static IEventBus InitializeEventBus()
        {
            var bus = new InProcessEventBus();
            bus.RegisterHandler(new TweetIndexItemDenormalizer());
            return bus;
        }

        private static IEventStore InitializeEventStore()
        {
            return new SimpleMicrosoftSqlServerEventStore(@"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=EventStore;Integrated Security=False;User ID=sa;Password=sql12345;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        }

        private static ICommandService InitializeCommandService()
        {
            var service = new InProcessCommandService();
            service.RegisterExecutor(new PostNewTweetCommandExecutor());
            return service;
        }
    }
}