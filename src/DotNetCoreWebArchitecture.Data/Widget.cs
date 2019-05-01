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

        public int WidgetTypeId { get; set; }
        public int OrderId { get; set; }
        public string WidgetName { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual WidgetType WidgetType { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}