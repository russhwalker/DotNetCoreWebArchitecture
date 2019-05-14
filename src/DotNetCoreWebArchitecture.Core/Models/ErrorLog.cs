using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Core.Models
{
    public class ErrorLog
    {
        public int ErrorLogId { get; set; }
        public string ExceptionData { get; set; }
        public DateTime CreateDate { get; set; }
    }
}