namespace AuctionManagement.Application.Contract
{
    public class PlaceBidCommand
    {
        public long AuctionId { get; set; }
        public long BidAmout { get; set; }
        public long BidderId { get; set; }
    }
}