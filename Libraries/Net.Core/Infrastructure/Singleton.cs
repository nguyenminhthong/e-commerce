using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Infrastructure
{
    public class Singleton<T>
    {
        public static T Instance { get; set; }
    }
}
