using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebArchitecture.Data
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        public string StatusName { get; set; }
    }
}