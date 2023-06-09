﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.JsonResult
{
    public enum ApiStatus
    {
        [EnumMember(Value = "success")]
        SUCCESS,

        [EnumMember(Value = "error")]
        ERROR,

        [EnumMember(Value = "warning")]
        WARNING,

        [EnumMember(Value = "invalid")]
        INVALID,

        [EnumMember(Value = "bad-request")]
        BADREQUEST
    }
}
