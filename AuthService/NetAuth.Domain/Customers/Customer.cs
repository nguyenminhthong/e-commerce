using Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.Domain.Customers
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            CustomerGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the customer GUID
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone
        /// </summary>
        public string PhoneNumber { get; set; }


    }
}
