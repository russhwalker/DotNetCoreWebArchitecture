using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreWebArchitecture.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Widget> Widgets { get; set; }
        public DbSet<WidgetType> WidgetTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}