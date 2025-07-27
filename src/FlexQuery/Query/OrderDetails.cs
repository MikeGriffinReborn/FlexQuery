using System.Data;

namespace FlexQuery.Query
{
    public static class OrderDetails
    {
        public static string TableName => "Order Details";

        public static Column OrderDetailID => new("OrderDetailID", SqlDbType.Int, isNullable: false, isPrimaryKey: true);
        public static Column OrderID => new("OrderID", SqlDbType.Int, isNullable: true);
        public static Column ProductID => new("ProductID", SqlDbType.Int, isNullable: true);
        public static Column Quantity => new("Quantity", SqlDbType.Int, isNullable: true);

        public static OrderDetailsTable Alias(string alias) => new(alias);

        public class OrderDetailsTable
        {
            private readonly string _alias;
            public OrderDetailsTable(string alias) { _alias = alias; }

            public Column OrderDetailID => OrderDetails.OrderDetailID.WithAlias(_alias);
            public Column OrderID => OrderDetails.OrderID.WithAlias(_alias);
            public Column ProductID => OrderDetails.ProductID.WithAlias(_alias);
            public Column Quantity => OrderDetails.Quantity.WithAlias(_alias);
        }
    }
}
