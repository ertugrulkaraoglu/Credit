using Credit.Business.DTOs.Customer;
using Credit.Entities;
using System.Collections.Generic;

namespace Credit.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomer(int customerId);
        CustomerScore GetCustomerScore(string identityNumber);
        CustomerHistory AddCustomerHistory(CustomerHistory customerHistory);
        GetCustomerCreditDto CheckCreditAvailibility(CustomerCreditDto dto);
    }
}
