using FlexQuery.Providers;

namespace FlexQuery
{
    public static class FlexQueryOptions
    {
        public static ISqlProvider DefaultProvider { get; set; } = new SqlServerProvider();
    }
}
