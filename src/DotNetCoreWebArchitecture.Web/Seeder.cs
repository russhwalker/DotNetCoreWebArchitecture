using System;

namespace DotNetCoreWebArchitecture.Web
{
    public static class Seeder
    {
        public static void SeedData(Data.DatabaseContext context, int orderCount)
        {
            context.Widgets.RemoveRange(context.Widgets);
            context.SaveChanges();
            var random = new Random();

            for (int i = 0; i < orderCount; i++)
            {
                var order = new Data.Order
                {
                    CustomerName = $"CustName{i}",
                    TotalPrice = (decimal)(random.NextDouble() * random.Next(5, 500))
                };
                context.Orders.Add(order);
                for (int j = 0; j < random.Next(1, 3); j++)
                {
                    context.Widgets.Add(new Data.Widget
                    {
                        Order = order,
                        WidgetName = $"wid{j}",
                        WidgetTypeId = random.Next(1, 4),
                    });
                }
                context.SaveChanges();
            }
        }

        public static void SeedTypeData(Data.DatabaseContext context)
        {
            var wt1 = new Data.WidgetType
            {
                WidgetTypeId = (int)Core.Enums.WidgetType.Type1,
                WidgetTypeName = "type1"
            };
            var wt2 = new Data.WidgetType
            {
                WidgetTypeId = (int)Core.Enums.WidgetType.Type2,
                WidgetTypeName = "type2"
            };
            var wt3 = new Data.WidgetType
            {
                WidgetTypeId = (int)Core.Enums.WidgetType.Type3,
                WidgetTypeName = "type3"
            };
            context.WidgetTypes.AddRange(new[] { wt1, wt2, wt3 });
            context.SaveChanges();
        }
    }
}