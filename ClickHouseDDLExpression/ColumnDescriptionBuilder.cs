
using ClickHouseDDLExpression.Models.Common.ColumnTTL;
using ClickHouseDDLExpression.Models.Common.CompressionCodecs;
using ClickHouseDDLExpression.Models.Common.DataTypes;
using ClickHouseDDLExpression.Models.Common.DefaultValues;
using ClickHouseDDLExpression.Models.CreateTable;
using System.Collections.Generic;

namespace ClickHouseDDLExpression
{
    public class ColumnDescriptionBuilder
    {
        private string _columnName;
        private IClickHouseDataType _dataType;
        private bool _isNotNull;
        private ColumnDefaultValue _columnDefaultValue;
        private ColumnTTL _columnTTL;
        private uint? _orderBy;
        private uint? _primaryKey;

        private List<IClickHouseCompressionCodec> _codecs = 
            new List<IClickHouseCompressionCodec>();

        public ColumnDescriptionBuilder()
        {
            _columnName = string.Empty;
            _isNotNull = false;
        }

        public ColumnDescriptionBuilder SetColumnName(string val)
        {
            _columnName = val;
            return this;
        }

        public ColumnDescriptionBuilder SetDataType(IClickHouseDataType val)
        {
            _dataType = val;
            return this;
        }

        public ColumnDescriptionBuilder SetIsNotNull(bool val)
        {
            _isNotNull = val;
            return this;
        }

        public ColumnDescriptionBuilder AddFieldCodec(IClickHouseCompressionCodec val)
        {
            _codecs.Add(val);
            return this;
        }

        public ColumnDescriptionBuilder SetColumnDefaultValue(ColumnDefaultValue val)
        {
            _columnDefaultValue = val;
            return this;
        }

        public ColumnDescriptionBuilder SetColumnTTL(ColumnTTL val)
        {
            _columnTTL = val;
            return this;
        }
        
        public ColumnDescriptionBuilder SetOrderBy(uint? val)
        {
            _orderBy = val;
            return this;
        }

        public ColumnDescriptionBuilder SetPrimaryKey(uint? val)
        {
            _primaryKey = val;
            return this;
        }

        public ColumnDescription Build()
        {
            var result = new ColumnDescription();
            result.ColumnName = _columnName ;
            result.DataType = _dataType;
            result.IsNotNull = _isNotNull;
            result.Codecs = _codecs;
            result.ColumnDefaultValue = _columnDefaultValue;
            result.ColumnTTL = _columnTTL;
            result.OrderBy = _orderBy;
            result.PrimaryKey = _primaryKey;

            return result;
        }
    }
}
