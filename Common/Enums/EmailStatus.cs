using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Enums
{
    public enum EmailStatus
    {
        None,
        Pending = 0,
        Send = 1
    }
}
