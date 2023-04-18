using Net.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Configuration
{
    public class DatabaseSetting
    {
        public string ConnectionString { get; set; } = string.Empty;

        public DataProviderType DataProvider { get; set; } = DataProviderType.SqlServer;

        public bool DapperEnable { get; set; }  = true;
    }
}
