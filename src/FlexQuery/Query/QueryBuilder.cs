using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlexQuery.Query
{
    public class QueryBuilder
    {
        private string _fromTable = "";
        private string _fromAlias = "";
        private readonly List<string> _joins = new();
        private readonly SelectClause _select = new();
        private readonly List<string> _groupBy = new();
        private readonly List<string> _orderBy = new();

        public static QueryBuilder From(string table, string alias)
        {
            var qb = new QueryBuilder();
            qb._fromTable = table;
            qb._fromAlias = alias;
            return qb;
        }

        public QueryBuilder Join(string table, string alias)
        {
            _joins.Add($"INNER JOIN [{table}] {alias}");
            return this;
        }

        public QueryBuilder On(string left, string right)
        {
            if (_joins.Count == 0)
                throw new InvalidOperationException("Join must precede On");
            _joins[^1] += $" ON {left} = {right}";
            return this;
        }

        public QueryBuilder Select(params string[] columns)
        {
            foreach (var col in columns)
                _select.Add(col);
            return this;
        }

        public QueryBuilder GroupBy(params string[] columns)
        {
            _groupBy.AddRange(columns);
            return this;
        }

        public QueryBuilder OrderBy(params string[] columns)
        {
            _orderBy.AddRange(columns);
            return this;
        }

        public string ToSql()
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT " + _select.ToSql());
            sb.AppendLine($"FROM [{_fromTable}] {_fromAlias}");
            foreach (var join in _joins)
                sb.AppendLine(join);
            if (_groupBy.Count > 0)
                sb.AppendLine("GROUP BY " + string.Join(", ", _groupBy));
            if (_orderBy.Count > 0)
                sb.AppendLine("ORDER BY " + string.Join(", ", _orderBy));
            return sb.ToString();
        }
    }
}
