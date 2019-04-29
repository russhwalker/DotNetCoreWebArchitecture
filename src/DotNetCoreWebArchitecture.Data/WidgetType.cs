using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreWebArchitecture.Data
{
    public class WidgetType
    {
        [Key]
        public int WidgetTypeId { get; set; }

        public string WidgetTypeName { get; set; }
    }
}