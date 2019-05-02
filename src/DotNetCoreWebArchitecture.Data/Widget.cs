using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreWebArchitecture.Data
{
    public class Widget
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WidgetId { get; set; }

        public string WidgetName { get; set; }
        public decimal WidgetPrice { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}