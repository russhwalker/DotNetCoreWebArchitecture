using DotNetCoreWebArchitecture.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Data
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly StoreContext db;

        public WidgetRepository(StoreContext myContext)
        {
            this.db = myContext;
        }

        public int GetWidgetCount()
        {
            return db.Widgets.Count();
        }

        public Task<int> GetWidgetCountAsync(Common.Enums.WidgetType widgetType)
        {
            return db.Widgets.Where(w => w.WidgetTypeId == (int)widgetType).CountAsync();
        }

        public Task<List<Widget>> GetWidgetsAsync(int widgetTypeId)
        {
            return db.Widgets.Where(w => w.WidgetTypeId == widgetTypeId).ToListAsync();
        }
    }
}