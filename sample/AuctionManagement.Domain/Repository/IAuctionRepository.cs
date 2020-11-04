using AuctionManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Repository
{
    public interface IAuctionRepository
    {
        Auction Get(long id);
        void Add(Auction auction);
    }
}
