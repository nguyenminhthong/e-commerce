using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Configuration
{
    public interface IConfig
    {
        string Name => GetType().Name;

        public int GetOrder() => 1;
    }
}
