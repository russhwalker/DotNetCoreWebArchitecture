using System;
using System.Linq;

namespace DotNetCoreWebArchitecture.Web
{
    public static class TestDataSeeder
    {
        public static void Seed(Data.DatabaseContext context, int orderCount = 20)
        {
            context.Widgets.RemoveRange(context.Widgets);
            context.SaveChanges();
            var random = new Random();

            context.OrderStatuses.AddRange(
                new Data.OrderStatus
                {
                    OrderStatusId = (int)Core.Enums.OrderStatus.Ordered,
                    StatusName = "Ordered"
                },
                new Data.OrderStatus
                {
                    OrderStatusId = (int)Core.Enums.OrderStatus.Shipped,
                    StatusName = "Shipped"
                },
                new Data.OrderStatus
                {
                    OrderStatusId = (int)Core.Enums.OrderStatus.Canceled,
                    StatusName = "Canceled"
                },
                new Data.OrderStatus
                {
                    OrderStatusId = (int)Core.Enums.OrderStatus.Refunded,
                    StatusName = "Refunded"
                }
                );
            context.Widgets.AddRange(
                new Data.Widget
                {
                    WidgetName = "widget1",
                    WidgetPrice = (decimal)(random.NextDouble() * random.Next(5, 100))
                },
                new Data.Widget
                {
                    WidgetName = "widget2",
                    WidgetPrice = (decimal)(random.NextDouble() * random.Next(5, 100))
                },
                new Data.Widget
                {
                    WidgetName = "widget3",
                    WidgetPrice = (decimal)(random.NextDouble() * random.Next(5, 100))
                },
                new Data.Widget
                {
                    WidgetName = "widget4",
                    WidgetPrice = (decimal)(random.NextDouble() * random.Next(5, 100))
                },
                new Data.Widget
                {
                    WidgetName = "widget5",
                    WidgetPrice = (decimal)(random.NextDouble() * random.Next(5, 100))
                }
            );
            context.SaveChanges();

            for (int i = 0; i < orderCount; i++)
            {
                var order = new Data.Order
                {
                    CustomerName = $"CustName{i + 1}",
                    OrderStatusId = random.Next(1, 5)
                };
                context.Orders.Add(order);
                for (int j = 0; j < random.Next(1, 10); j++)
                {
                    var widgetId = random.Next(1, 6);
                    var widget = context.Widgets.Single(w => w.WidgetId == widgetId);
                    context.OrderItems.Add(new Data.OrderItem
                    {
                        Order = order,
                        Widget = widget,
                        UnitPrice = widget.WidgetPrice
                    });
                }
                context.SaveChanges();
            }
        }
    }
}