using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Enum
{
    public enum SqlProvider
    {
        [EnumMember(Value = "SqlServer")]
        SqlServer,

        [EnumMember(Value = "PostgreSQL")]
        PostgreSQL
    }
}
