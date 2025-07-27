using System.Data;

namespace FlexQuery.Query
{
    public static class OrdersMetadata
    {
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

            public Column OrderID => OrdersMetadata.OrderID.WithAlias(_alias);
            public Column CustomerID => OrdersMetadata.CustomerID.WithAlias(_alias);
            public Column EmployeeID => OrdersMetadata.EmployeeID.WithAlias(_alias);
            public Column OrderDate => OrdersMetadata.OrderDate.WithAlias(_alias);
            public Column ShipperID => OrdersMetadata.ShipperID.WithAlias(_alias);
        }
    }
}
