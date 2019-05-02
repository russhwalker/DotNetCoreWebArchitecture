using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreWebArchitecture.Data
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public int OrderStatusId { get; set; }
        public string CustomerName { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}