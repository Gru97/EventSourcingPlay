using Framework.Domain;

namespace AuctionManagement.Domain.Events
{
    public class BidPlaced: DomainEvent
    {
        public long AuctionId { get; set; }
        public long BidAmout { get; set; }
        public long BidderId { get; set; }

        public BidPlaced(long auctionId, long bidAmout, long bidderId)
        {
            AuctionId = auctionId;
            BidAmout = bidAmout;
            BidderId = bidderId;
        }
    }
}