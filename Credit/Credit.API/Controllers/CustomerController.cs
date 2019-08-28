using Credit.API.Models.Request;
using Credit.API.Models.Response;
using Credit.Business.Abstract;
using Credit.Business.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Credit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// This method gets credit availibility by identity number and credit score.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("credit/availibility")]
        public CustomerCreditResponse GetCreditAvailibility([FromQuery]CustomerCreditRequest request)
        {
            var response = _customerService.CheckCreditAvailibility(new CustomerCreditDto
            {
                IdentityNumber = request.IdentityNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MonthlyIncome = request.MonthlyIncome,
                PhoneNumber = request.PhoneNumber
            });

            return new CustomerCreditResponse { CreditResult = response.CreditResult.ToString(), CreditLimit = response.CreditLimit, CreditResultReason = response.CreditResultReason };
        }
    }
}
