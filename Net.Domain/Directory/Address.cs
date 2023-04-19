using Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Domain.Directory
{
    public class Address : BaseEntity
    {
        public string ContactName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int? CountryId { get; set; }

        public int? ProvinceId { get; set; }

        public int?DistrictId { get; set; }

        public int? WardId { get; set; }

        public string Street { get; set; } = string.Empty;

        public string Description { get; set;} = string.Empty; 

        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsDefault { get; set; }
    }
}
