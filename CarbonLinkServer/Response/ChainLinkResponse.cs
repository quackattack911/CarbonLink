namespace CarbonLinkServer.Response
{
    public class ChainLinkResponse
    {
        public BalanceInfo data { get; set; }
    }

    public class BalanceInfo
    {
        public double tokensToMint { get; set; }
    }
}
