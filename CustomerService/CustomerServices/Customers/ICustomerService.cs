using CustomerDomain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServices.Customers
{
    public interface ICustomerService
    {
        #region For check token
        Task<bool> IsExistCustomerByEmailOrPhoneNumberAsync(string iEmailOrPhone);

        Task<bool> IsExistCustomerByIdAsync(int iUserId);

        Task<bool> IsExistGuestCustomerAsync(string iUserGuid);
        #endregion

        Task<Customer> GetCustomerByIdAsync(int id);

        Task<Customer> GetCustomerByUserNameOrEmailAsync(string iUserName);

        Task<IEnumerable<Customer>> GetAllCustomersAsync(bool isAll);
    }
}
