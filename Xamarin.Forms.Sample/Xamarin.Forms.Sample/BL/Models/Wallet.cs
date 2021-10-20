namespace Xamarin.Forms.Sample.BL.Models
{
    public class Wallet
    {
        public MoneyAmount MoneyAmount { get; set; }
    }

    public class MoneyAmount
    {
        public string Type { get; set; }
        
        public int Amount { get; set; }
    }
}