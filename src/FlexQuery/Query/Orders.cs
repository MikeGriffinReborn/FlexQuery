using System.Data;

namespace FlexQuery.Query
{
    public static class Orders
    {
        public static string TableName => "Orders";

        public static Column OrderID => new("OrderID", SqlDbType.Int, isNullable: false, isPrimaryKey: true);
        public static Column CustomerID => new("CustomerID", SqlDbType.Int, isNullable: true);
        public static Column EmployeeID => new("EmployeeID", SqlDbType.Int, isNullable: true);
        public static Column OrderDate => new("OrderDate", SqlDbType.DateTime, isNullable: true);
        public static Column ShipperID => new("ShipperID", SqlDbType.Int, isNullable: true);

        public static OrdersTable Alias(string alias) => new(alias);

        public class OrdersTable
        {
            private readonly string _alias;
            public OrdersTable(string alias) { _alias = alias; }

            public Column OrderID => Orders.OrderID.WithAlias(_alias);
            public Column CustomerID => Orders.CustomerID.WithAlias(_alias);
            public Column EmployeeID => Orders.EmployeeID.WithAlias(_alias);
            public Column OrderDate => Orders.OrderDate.WithAlias(_alias);
            public Column ShipperID => Orders.ShipperID.WithAlias(_alias);
        }
    }
}
