using Net.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Services.Customers
{
    public interface ICustomerService
    {

        #region For check token
        Task<bool> IsExistCustomerByEmailOrPhoneNumberAsync(string iEmailOrPhone);

        Task<bool> IsExistCustomerByIdAsync(int iUserId);

        Task<bool> IsExistGuestCustomerAsync(string iUserGuid);
        #endregion

        Task<Customer> GetCustomerByIdAsync(int id);

        Task<IEnumerable<Customer>> GetAllCustomersAsync(bool isAll);
    }
}
