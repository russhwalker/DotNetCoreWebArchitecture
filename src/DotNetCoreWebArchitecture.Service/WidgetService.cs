using DotNetCoreWebArchitecture.Core;
using DotNetCoreWebArchitecture.Core.Contracts;
using DotNetCoreWebArchitecture.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebArchitecture.Service
{
    public class WidgetService : IWidgetService
    {
        private readonly IWidgetRepository widgetRepository;

        public WidgetService(IWidgetRepository widgetRepository)
        {
            this.widgetRepository = widgetRepository;
        }

        public GetWidgetCountsResponse GetWidgetCounts()
        {
            //var count1Task = widgetRepository.GetWidgetCountAsync(Enums.WidgetType.Type1);
            //var count2Task = widgetRepository.GetWidgetCountAsync(Enums.WidgetType.Type2);
            //var count3Task = widgetRepository.GetWidgetCountAsync(Enums.WidgetType.Type3);
            //Task.WaitAll(count1Task, count2Task, count3Task);
            //return new GetWidgetCountsResponse
            //{
            //    Widget1Count = count1Task.Result,
            //    Widget2Count = count2Task.Result,
            //    Widget3Count = count3Task.Result
            //};
            return new GetWidgetCountsResponse
            {
            };
        }
    }
}