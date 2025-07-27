using System;
using System.Collections.Generic;
using System.Text;

namespace FlexQuery.Query
{
    public class SelectClause
    {
        private readonly List<string> _columns = new();

        public void Add(string sqlExpression)
        {
            _columns.Add(sqlExpression);
        }

        public string ToSql()
        {
            return string.Join(", ", _columns);
        }
    }
}
