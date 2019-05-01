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
        public string Url { get; set; }
        public string RequestData { get; set; }
        public DateTime CreatDate { get; set; }
    }
}