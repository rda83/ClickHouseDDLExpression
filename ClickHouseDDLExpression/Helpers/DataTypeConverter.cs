using ClickHouseDDLExpression.Models.Common.DataTypes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ClickHouseDDLExpression.Helpers
{
    public class DataTypeConverter
    {
        private readonly Dictionary<string, Func<IClickHouseDataType>> _matchingDataTypes
            = new Dictionary<string, Func<IClickHouseDataType>>();

        public DataTypeConverter()
        {
            _matchingDataTypes.Add("System.Int64", () => new ClickHouseDataTypeInt64());
            _matchingDataTypes.Add("System.UInt64", () => new ClickHouseDataTypeUInt64());
            _matchingDataTypes.Add("System.Int32", () => new ClickHouseDataTypeInt32());
            _matchingDataTypes.Add("System.UInt32", () => new ClickHouseDataTypeUInt32());
            _matchingDataTypes.Add("System.Int16", () => new ClickHouseDataTypeInt16());
            _matchingDataTypes.Add("System.UInt16", () => new ClickHouseDataTypeUInt16());
            _matchingDataTypes.Add("System.SByte", () => new ClickHouseDataTypeInt8());
            _matchingDataTypes.Add("System.Byte", () => new ClickHouseDataTypeUInt8());
            _matchingDataTypes.Add("System.DateTime", () => new ClickHouseDataTypeDateTime());
            _matchingDataTypes.Add("System.String", () => new ClickHouseDataTypeString());
            _matchingDataTypes.Add("System.Boolean", () => new ClickHouseDataTypeUInt8());
        }

        public ClickHouseDataTypeDescription GetClickHouseDataType(PropertyInfo property)
        {
            var description = GetPropertyDescription(property);

            var result = new ClickHouseDataTypeDescription();
            result.Nullable = description.Nullable;

            _matchingDataTypes.TryGetValue(description.TypeFullName, out Func<IClickHouseDataType> f);
            if (f != null)
            {
                result.ClickHouseDataType = f();
            }
            else
            {
                throw new ArgumentException(
                    $"Not exist ClickHouse type for property: {property.Name}, type of:{description.TypeFullName}.");
            }

            return result;
        }

        private PropertyDescription GetPropertyDescription(PropertyInfo property)
        {
            var result = new PropertyDescription();

            if (property.PropertyType.IsGenericType &&
                property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                result.TypeFullName = property.PropertyType.GetGenericArguments()[0].FullName;
                result.Nullable = true;
            }
            else
            {
                result.TypeFullName = property.PropertyType.FullName;
                result.Nullable = false;
            }
            return result;
        }
    }
}
