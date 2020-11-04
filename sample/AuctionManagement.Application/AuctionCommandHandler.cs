using AuctionManagement.Application.Contract;
using AuctionManagement.Domain.Repository;
using Framework.Application;
using System;

namespace AuctionManagement.Application
{
    public class AuctionCommandHandler : ICommandHandler<OpenAuctionCommand>
               , ICommandHandler<PlaceBidCommand>

    {
        private IAuctionRepository auctionRepository;

        public AuctionCommandHandler(IAuctionRepository auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }

        public void Handle(OpenAuctionCommand command)
        {
            throw new NotImplementedException();
        }

        public void Handle(PlaceBidCommand command)
        {
            throw new NotImplementedException();
        }
    }
    
}
