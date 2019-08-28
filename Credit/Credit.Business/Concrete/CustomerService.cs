using Credit.Business.Abstract;
using Credit.Business.DTOs.Customer;
using Credit.Business.DTOs.Sms;
using Credit.Core.Enums;
using Credit.Data.Abstract;
using Credit.Entities;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;

namespace Credit.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        #region Consts
        const int creditLimitMultiplier = 4;
        #endregion

        #region Variables
        Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        #endregion

        #region Fields
        private readonly ICustomerDal _customerDal;
        private readonly ICustomerScoreDal _customerScore;
        private readonly ICustomerHistoryDal _customerHistory;
        private readonly ISmsSender _smsSender;
        #endregion

        #region Ctor
        public CustomerService(ICustomerDal customerDal, ICustomerScoreDal customerScore, ICustomerHistoryDal customerHistory, ISmsSender smsSender)
        {
            _customerDal = customerDal;
            _customerScore = customerScore;
            _customerHistory = customerHistory;
            _smsSender = smsSender;
        }
        #endregion

        #region Methods
        public List<Customer> GetAllCustomers()
        {
            return _customerDal.GetAll();
        }
        public Customer AddCustomer(Customer customer)
        {
            return _customerDal.Add(customer);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            return _customerDal.Update(customer);
        }
        public Customer DeleteCustomer(int customerId)
        {
            return _customerDal.Delete(new Customer { Id = customerId });
        }

        public CustomerScore GetCustomerScore(string identityNumber)
        {
            return _customerScore.Get(x => x.IdentityNumber == identityNumber);
        }

        public CustomerHistory AddCustomerHistory(CustomerHistory customerHistory)
        {
            return _customerHistory.Add(customerHistory);
        }

        public GetCustomerCreditDto CheckCreditAvailibility(CustomerCreditDto dto)
        {
            var customerCredit = new GetCustomerCreditDto
            {
                CreditResult = CreditResultType.Reject,
                CreditLimit = 0,
                CreditResultReason = string.Empty
            };

            try
            {
                if (dto != null)
                {
                    // Normalde Kredi skoru bilgisi servisten gelmelidir.
                    var customerScore = _customerScore.Get(x => x.IdentityNumber == dto.IdentityNumber);
                    if (customerScore == null)
                    {
                        logger.Info($"Identity number could not found!");
                        return customerCredit;
                    }

                    customerCredit = GetCustomerCredit(customerScore, dto.MonthlyIncome);

                    CreateCustomer(dto, customerCredit.CreditLimit);
                    CreateCustomerHistory(dto.IdentityNumber, customerCredit.CreditResult, customerScore.Score);

                    //Sms gönderme işlemi
                    _smsSender.SendSms(new SendSmsDto());
                }

                return customerCredit;
            }
            catch (Exception ex)
            {
                logger.Error($"An error occurred : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Utilities
        private Customer CreateCustomer(CustomerCreditDto dto, decimal creditLimit)
        {
            // Customer bilgileri kaydedilir.
            var addedCustomer = AddCustomer(new Customer
            {
                IdentityNumber = dto.IdentityNumber,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MonthlyIncome = dto.MonthlyIncome,
                PhoneNumber = dto.PhoneNumber,
                CreationDate = DateTime.Now,
                CreditLimit = creditLimit
            });

            if (addedCustomer == null)
            {
                logger.Error("An error occurred while creating customer.!");
            }
            return addedCustomer;
        }
        private CustomerHistory CreateCustomerHistory(string identityNumber, CreditResultType creditResult, decimal score)
        {
            //Customer History bilgileri kaydedilir.
            var addedCustomerHistory = AddCustomerHistory(new CustomerHistory
            {
                IdentityNumber = identityNumber,
                CreditResult = (int)creditResult,
                ActualScore = score
            });

            if (addedCustomerHistory == null)
            {
                logger.Error("An error occurred while creating customer history.");
            }
            return addedCustomerHistory;
        }
        private GetCustomerCreditDto GetCustomerCredit(CustomerScore customerScore, decimal monthlyIncome)
        {
            var customerCredit = new GetCustomerCreditDto
            {
                CreditResult = CreditResultType.Reject,
                CreditLimit = 0,
                CreditResultReason = string.Empty
            };

            if (customerScore.Score < 500)
            {
                customerCredit.CreditResultReason = "Credit score is less than 500 points";
            }
            else if (customerScore.Score >= 500 && customerScore.Score < 1000 && monthlyIncome < 5000)
            {
                customerCredit.CreditResultReason = "Success";
                customerCredit.CreditResult = CreditResultType.Accept;
                customerCredit.CreditLimit = 10000;
            }
            else
            {
                customerCredit.CreditResultReason = "Success";
                customerCredit.CreditResult = CreditResultType.Accept;
                customerCredit.CreditLimit = monthlyIncome * creditLimitMultiplier;
            }

            return customerCredit;
        }
        #endregion
    }
}
