namespace Credit.API.Models.Request
{
    public class CustomerCreditRequest
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string PhoneNumber { get; set; }
    }
}
