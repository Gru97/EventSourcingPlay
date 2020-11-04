using AuctionManagement.Domain.Events;
using Framework.Domain;
using System;

namespace AuctionManagement.Domain.Model
{
    public class Auction : AggregateRoot<long>
    {
        public long AuctionId { get; set; }
        public long SellerId { get; set; }
        public long StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WinningBid WinningBid { get; set; }

        public Auction(long auctionId, long sellerId, long startingPrice, DateTime endDate)
        {
            var @event = new AuctionOpened(auctionId, sellerId, startingPrice, endDate);
            Apply(@event);
        }

    

        public void PlaceBid(long bidderId, long amount)
        {
            if (WinningBid == default && amount < StartingPrice)
                throw new Exception("Invalid bid amount");

            if (SellerId == bidderId)
                throw new Exception("You can't place bid on your own auction");

            Apply(new BidPlaced(this.Id, amount, bidderId));
        }

        public override void Apply(dynamic @event)
        {
            When(@event);
        }

        public void When (BidPlaced @event)
        {
            WinningBid = new WinningBid(@event.BidderId, @event.BidAmout);
        }
        public void When(AuctionOpened @event)
        {
            EndDate = @event.EndDate;
            StartDate = @event.StartDate;
            StartingPrice = @event.StartingPrice;
            SellerId = @event.SellerId;
        }
    }
}
