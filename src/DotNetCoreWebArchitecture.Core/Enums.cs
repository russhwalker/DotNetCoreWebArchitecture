using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core
{
    public static class Enums
    {
        public enum OrderStatus
        {
            Ordered = 1,
            Shipped = 2,
            Canceled = 3,
            Refunded = 4
        }
    }
}