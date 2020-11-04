using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Events
{
    public class AuctionOpened:DomainEvent
    {
        public long AuctionId { get; set; }
        public long SellerId { get; set; }
        public long StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public AuctionOpened(long id, long sellerId, 
            long startingPrice, DateTime endDate)
        {
            AuctionId = id;
            SellerId = sellerId;
            StartingPrice = startingPrice;
            EndDate = endDate;
        }
    }

    public class AuctionClosed
    {
    }
    public class WinnerIsChosen
    {
    }
   
}
