using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyPayment
{
    public interface IAnyPay
    {
        Dictionary<string, object> ReqParameters { get; }
    }
}
