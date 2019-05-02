using DotNetCoreWebArchitecture.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Data
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly DatabaseContext databaseContext;

        public WidgetRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int GetWidgetCount()
        {
            return databaseContext.Widgets.Count();
        }

        //public Task<int> GetWidgetCountAsync(Core.Enums.WidgetType widgetType)
        //{
        //    return databaseContext.Widgets.Where(w => w.WidgetTypeId == (int)widgetType).CountAsync();
        //}

        //public Task<List<Widget>> GetWidgetsAsync(int widgetTypeId)
        //{
        //    return databaseContext.Widgets.Where(w => w.WidgetTypeId == widgetTypeId).ToListAsync();
        //}
    }
}