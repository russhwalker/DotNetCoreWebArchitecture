using DotNetCoreWebArchitecture.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}