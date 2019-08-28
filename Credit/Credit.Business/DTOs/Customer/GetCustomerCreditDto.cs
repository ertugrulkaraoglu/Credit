using Credit.Core.Enums;

namespace Credit.Business.DTOs.Customer
{
    public class GetCustomerCreditDto
    {
        public CreditResultType CreditResult { get; set; }
        public string CreditResultReason { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
