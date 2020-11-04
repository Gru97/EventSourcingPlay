using System;
using System.Collections.Generic;
using Xunit;

namespace Framework.Domain.Tests
{
    public class AggregateFactoryTest
    {
        [Fact]
        public void Create_Aggregate_By_Applying_Events()
        {
            var @events = new List<DomainEvent>()
            {
                new UserRegistered(1,"fatemeh76","fatemeh","shahidani"),
                new UserAccountActivated(1)

            };

            var aggregateFactory = new AggregateFactory();
            var aggregate = aggregateFactory.Reconstruct<User>(@events);

            Assert.Equal("fatemeh", aggregate.FirstName);
            Assert.Equal("shahidani", aggregate.LastName);
            Assert.Equal("fatemeh76", aggregate.Username);
        }
    }

    public class User : AggregateRoot<long>
    {
        public string Username { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsActive { get; set; }

        private User() { }
        public void Activate()
        {
            var @event = new UserAccountActivated(Id);
            Apply(@event);
        }

        public void When(UserAccountActivated @event)
        {
            IsActive = true;
        }
        public void When(UserRegistered @event)
        {
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            Username = @event.UserName;
        }

        public override void Apply(dynamic @event)
        {
            When(@event);
        }
    }

    public class UserAccountActivated : DomainEvent
    {
        public long UserId { get; private set; }

        public UserAccountActivated(long userId)
        {
            UserId = userId;
        }
    }
    public class UserRegistered : DomainEvent
    {
        public long UserId { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public UserRegistered(long userId, string userName, string firstName, string lastName)
        {
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
