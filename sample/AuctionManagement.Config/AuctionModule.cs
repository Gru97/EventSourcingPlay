using System;
using System.Linq;
using AuctionManagement.Application;
using AuctionManagement.Domain.Repository;
using Autofac;
using EventStore.ClientAPI;
using Framework.Application;
using Framework.Domain;
using Framework.Persistence.ES;

namespace AuctionManagement.Config
{
    public class AuctionModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventStoreDb>().As<IEventStore>().SingleInstance();
            builder.Register<IEventStoreConnection>(CreateEventStoreConnection).SingleInstance();

            //builder.RegisterType<InMemoryEventStore>().As<IEventStore>().SingleInstance();
            builder.RegisterType<AutofacCommandDispatcher>().As<ICommandDispatcher>().SingleInstance();
            builder.RegisterType<AggregateFactory>().As<IAggregateFactory>().SingleInstance();

            builder.RegisterGeneric(typeof(EventSourceRepository<,>)).As(typeof(IEventSourceRepository<,>))
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(AuctionCommandHandler).Assembly).As(type => type.GetInterfaces()
                .Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))));
            
            builder.RegisterType<IAuctionRepository>().As<IAuctionRepository>().SingleInstance();
        }

        public static IEventStoreConnection CreateEventStoreConnection(IComponentContext ctx)
        {
            var connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@127.0.0.1:1113"));
            connection.ConnectAsync().Wait();
            return connection;
        }
    }
}
