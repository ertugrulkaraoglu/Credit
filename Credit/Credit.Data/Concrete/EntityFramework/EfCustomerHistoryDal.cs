using Credit.Core.Data.EntityFramework;
using Credit.Data.Abstract;
using Credit.Entities;

namespace Credit.Data.Concrete.EntityFramework
{
    public class EfCustomerHistoryDal : BaseEntityRepository<CustomerHistory, CreditContext>, ICustomerHistoryDal
    {
    }
}
