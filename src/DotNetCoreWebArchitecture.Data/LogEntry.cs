using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreWebArchitecture.Data
{
    public class LogEntry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogEntryId { get; set; }

        public string UserName { get; set; }
        public string Host { get; set; }
        public string IpAddress { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string RequestUrl { get; set; }
        public string FormRequestData { get; set; }
        public DateTime CreateDate { get; set; }
    }
}