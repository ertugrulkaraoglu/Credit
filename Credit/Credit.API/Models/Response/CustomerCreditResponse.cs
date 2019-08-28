namespace Credit.API.Models.Response
{
    public class CustomerCreditResponse
    {
        public string CreditResult { get; set; }
        public string CreditResultReason { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
