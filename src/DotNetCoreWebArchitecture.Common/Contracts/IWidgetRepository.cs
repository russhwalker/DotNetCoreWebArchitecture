using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Common.Contracts
{
    public interface IWidgetRepository
    {
        int GetWidgetCount();
        Task<int> GetWidgetCountAsync(Common.Enums.WidgetType widgetType);
        //Task<List<Data.Widget>> GetWidgetsAsync(int widgetTypeId);
    }
}