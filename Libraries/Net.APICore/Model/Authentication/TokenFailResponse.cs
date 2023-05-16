using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Model.Authentication
{
    sealed record TokenFailResponse
    {
        public string Message { get; set; } = "";
    }
}
