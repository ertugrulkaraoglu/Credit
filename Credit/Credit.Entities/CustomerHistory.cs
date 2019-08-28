namespace Credit.Entities
{
    public class CustomerHistory : IBaseEntity
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public int CreditResult { get; set; }
        public decimal ActualScore { get; set; }
    }
}
