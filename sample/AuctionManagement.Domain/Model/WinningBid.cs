namespace AuctionManagement.Domain.Model
{
    public class WinningBid
    {
        public long BidderId { get; set; }
        public long Amount { get; set; }

        public WinningBid(long bidderId, long amount)
        {
            BidderId = bidderId;
            Amount = amount;
        }
    }
}