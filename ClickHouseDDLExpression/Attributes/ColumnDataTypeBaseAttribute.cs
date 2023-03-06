using ClickHouseDDLExpression.Models.Common.DataTypes;
using System;

namespace ClickHouseDDLExpression.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ColumnDataTypeBaseAttribute : Attribute
    {
        public IClickHouseDataType GetDataType()
        {
            return GetDataTypeSpecified();
        }

        public virtual IClickHouseDataType GetDataTypeSpecified()
        {
            throw new NotImplementedException();
        }
    }
}
