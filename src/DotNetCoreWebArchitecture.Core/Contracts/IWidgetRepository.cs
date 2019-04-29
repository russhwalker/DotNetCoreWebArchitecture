using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Core.Contracts
{
    public interface IWidgetRepository
    {
        int GetWidgetCount();
        Task<int> GetWidgetCountAsync(Enums.WidgetType widgetType);
        //Task<List<Data.Widget>> GetWidgetsAsync(int widgetTypeId);
    }
}