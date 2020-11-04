using AuctionManagement.Domain.Model;
using AuctionManagement.Domain.Repository;
using System;
using Framework.Domain;

namespace AuctionManagement.Persistence.ES
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly IEventSourceRepository<Auction,long> eventSourceRepository;
        public void Add(Auction auction)
        {
            eventSourceRepository.AppendEvents(auction);
        }

        public Auction Get(long id)
        {
            return eventSourceRepository.GetById(id);
        }
    }
}
