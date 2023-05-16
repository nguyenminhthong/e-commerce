using Net.Data;
using Net.Data.Repository;
using Net.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Services.Customers
{
    internal class CustomerService : ICustomerService
    {
        #region Field
        private readonly IReadRepository<Customer> _customerRepository;

        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public CustomerService(IReadRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region For check token
        public Task<bool> IsExistCustomerByEmailOrPhoneNumberAsync(string iEmailOrPhone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistCustomerByIdAsync(int iUserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistGuestCustomerAsync(string iUserGuid)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Get Customer Info
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(bool isAll)
        {
            var customers = new List<Customer>();

            return await Task.FromResult(customers);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = _customerRepository.GetByIdAsync(id);

            //return customer;
            return await Task.FromResult(new Customer());
        } 
        #endregion

        #region Storage Customer

        /// <summary>
        /// Insert new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task CreateCustomer(Customer customer)
        {
            using (var trans = await _unitOfWork.CreateTransactionAsync())
            {
                try
                {
                    await _unitOfWork.Repository<Customer>().CreateAsync(customer);

                    await trans.CommitAsync();
                }
                catch (Exception ex)
                {
                    await trans.RollbackAsync();
                }
            }

            await Task.CompletedTask;
        }

        #endregion
    }
}
