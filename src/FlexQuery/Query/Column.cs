using System;
using System.Data;

namespace FlexQuery.Query
{
    public class Column
    {
        public string Name { get; }
        public SqlDbType Type { get; }
        public int? Length { get; }
        public byte? Precision { get; }
        public byte? Scale { get; }
        public bool IsNullable { get; }
        public bool IsPrimaryKey { get; }
        public string? Alias { get; }

        public Column(string name, SqlDbType type, int? length = null, byte? precision = null, byte? scale = null, bool isNullable = true, bool isPrimaryKey = false, string? alias = null)
        {
            Name = name;
            Type = type;
            Length = length;
            Precision = precision;
            Scale = scale;
            IsNullable = isNullable;
            IsPrimaryKey = isPrimaryKey;
            Alias = alias;
        }

        public Column WithAlias(string alias)
        {
            return new Column(Name, Type, Length, Precision, Scale, IsNullable, IsPrimaryKey, alias);
        }

        public override string ToString()
        {
            return Alias != null ? $"{Alias}.[{Name}]" : $"[{Name}]";
        }

        public static implicit operator string(Column column)
        {
            return column.ToString();
        }
    }
}
