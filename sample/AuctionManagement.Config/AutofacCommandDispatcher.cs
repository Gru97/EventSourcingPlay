using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Framework.Application;

namespace AuctionManagement.Config
{
    public class AutofacCommandDispatcher: ICommandDispatcher
    {
        private readonly ILifetimeScope _scope;

        public AutofacCommandDispatcher(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Dispatch<T>(T command)
        {
            var handler = _scope.Resolve<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}
