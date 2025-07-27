using System;
using FlexQuery.Query;

namespace FlexQuery.Examples
{
    public class OrderSummary
    {
        public int OrderID { get; set; }
        public int TotalQuantity { get; set; }
    }

    public static class OrderSummaryExample
    {
        public static void Run()
        {
            var o = Orders.Alias("o");
            var od = OrderDetails.Alias("od");

            var q = QueryBuilder
                .From(Orders.TableName, "o")
                .Join(OrderDetails.TableName, "od").On(o.OrderID, od.OrderID)
                .Select(o.OrderID, $"SUM({od.Quantity}) AS TotalQuantity")
                .GroupBy(o.OrderID)
                .OrderBy(o.OrderID);

            Console.WriteLine("Generated SQL:");
            Console.WriteLine(q.ToSql());
        }
    }
}
