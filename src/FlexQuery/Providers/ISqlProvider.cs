namespace FlexQuery.Providers
{
    public interface ISqlProvider
    {
        string QuoteIdentifier(string name);
        string QuoteTable(string name);
        string QuoteString(string literal);
        string ParamPrefix { get; }
        string RenderFunction(string functionName, params string[] args);
        string RenderLimitOffset(int? limit, int? offset);
    }
}
