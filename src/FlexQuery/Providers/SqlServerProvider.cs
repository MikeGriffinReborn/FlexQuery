namespace FlexQuery.Providers
{
    public class SqlServerProvider : ISqlProvider
    {
        public string QuoteIdentifier(string name) => $"[{name}]";
        public string QuoteTable(string name) => $"[{name}]";
        public string QuoteString(string literal) => $"'{literal.Replace("'", "''")}'";
        public string ParamPrefix => "@";

        public string RenderFunction(string name, params string[] args)
        {
            return $"{name}({string.Join(", ", args)})";
        }

        public string RenderLimitOffset(int? limit, int? offset)
        {
            if (limit.HasValue && offset.HasValue)
                return $"OFFSET {offset.Value} ROWS FETCH NEXT {limit.Value} ROWS ONLY";
            if (limit.HasValue)
                return $"TOP {limit.Value}";
            return string.Empty;
        }
    }
}
