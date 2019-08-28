using Credit.Core.Data.EntityFramework;
using Credit.Data.Abstract;
using Credit.Entities;

namespace Credit.Data.Concrete.EntityFramework
{
    public class EfCustomerDal : BaseEntityRepository<Customer, CreditContext>, ICustomerDal
    {
    }
}
