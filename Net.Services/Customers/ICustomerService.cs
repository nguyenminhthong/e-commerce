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
        Task<Customer> GetCustomerByIdAsync(int id);

        Task<IEnumerable<Customer>> GetAllCustomersAsync(bool isAll);
    }
}
