using System;
using System.Collections.Generic;
using System.Linq;

namespace DXSample5
{
    public class DataRow : List<DataField>
    {
        public object this[string column]
        {
            get
            {
                return this.First(x => x.Name.Equals(column, StringComparison.OrdinalIgnoreCase)).Value;
            }
        }
    }

    public class DataField
    {
        public DataField(string name, Type type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public String Name { get; }

        public Type Type { get; }

        public object Value { get; }

        public override String ToString()
        {
            return $"{Name} ({Type.Name}): {Value}";
        }
    }
}