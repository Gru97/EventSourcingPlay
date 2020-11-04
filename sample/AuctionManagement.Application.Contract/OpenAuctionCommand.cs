using System;

namespace AuctionManagement.Application.Contract
{
    public class OpenAuctionCommand
    {
        public long AuctionId { get; set; }
        public long SellerId { get; set; }
        public long StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
