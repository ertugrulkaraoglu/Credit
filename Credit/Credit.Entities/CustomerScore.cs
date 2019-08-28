namespace Credit.Entities
{
    public class CustomerScore : IBaseEntity
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public decimal Score { get; set; }
    }
}
