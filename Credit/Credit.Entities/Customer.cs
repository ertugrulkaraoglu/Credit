using System;

namespace Credit.Entities
{
    public class Customer : IBaseEntity
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
