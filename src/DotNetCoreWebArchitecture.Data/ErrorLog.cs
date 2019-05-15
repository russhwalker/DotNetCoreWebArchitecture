using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebArchitecture.Data
{
    public class ErrorLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErrorLogId { get; set; }

        public string ErrorMessage { get; set; }
        public string ExceptionData { get; set; }
        public DateTime CreateDate { get; set; }
    }
}