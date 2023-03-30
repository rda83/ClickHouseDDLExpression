using System;
using System.Collections.Generic;
using ClickHouseDDLExpression.Attributes;
using ClickHouseDDLExpression.Features.CreateTable;
using ClickHouseDDLExpression.Helpers;
using ClickHouseDDLExpression.Models.Common.DataTypes;
using ClickHouseDDLExpression.Models.Common.Engines;
using ClickHouseDDLExpression.Models.Common.PartitioningKey;
using ClickHouseDDLExpression.Models.ExpressionBuilderParameters;

namespace ClickHouseDDLExpression
{
    public class CreateTableBuilder
    {
        private readonly DataTypeConverter _dataTypeConverter = new DataTypeConverter();

        public string Build<T>(CreateExpressionParameters? parameters = null)
        {
            Type type = typeof(T);
            var helper = new CreateExprHelper(type, parameters);

            var engineMergeTreeBuilder = new TableEngineMergeTreeBuilder();
            foreach (var item in helper.EngineSettings)
            {
                engineMergeTreeBuilder.AddSetting(item);
            }

            var createTableCommandBuilder = new CreateTableCommandBuilder();

            createTableCommandBuilder
                .SetDbName(helper.GetDbName())
                .SetTableName(helper.GetTableName())
                .SetIsNotExists(helper.IsNotExistsSign())
                .SetTableEngine(engineMergeTreeBuilder.Build());

            var partitioningKeyValue = helper.GetPartitioningKeyValue();
            if (partitioningKeyValue != null)
                createTableCommandBuilder.SetPartitioningKey(partitioningKeyValue);

           var properties = type.GetProperties();
           foreach (var property in properties)
           {
               var newColumn = new ColumnDescriptionBuilder();

               var columnAttribute = (ClickHouseColumnAttribute?) Attribute.
                   GetCustomAttribute(property, typeof(ClickHouseColumnAttribute));

                if (columnAttribute != null)
                {
                    newColumn = newColumn.SetColumnName(
                        string.IsNullOrEmpty(columnAttribute.Name) ? property.Name
                            : columnAttribute.Name);

                    

                    if (columnAttribute.OrderBy > 0)
                        newColumn = newColumn.SetOrderBy(columnAttribute.OrderBy);

                    if (columnAttribute.PrimaryKey > 0)
                        newColumn = newColumn.SetPrimaryKey(columnAttribute.PrimaryKey);
                }
                else
                {
                    newColumn = newColumn.SetColumnName(property.Name);
                }

                var dataTypeAttribute = (ColumnDataTypeBaseAttribute?)Attribute.
                    GetCustomAttribute(property, typeof(ColumnDataTypeBaseAttribute));

                if (dataTypeAttribute != null)
                {
                    newColumn = newColumn.SetDataType(
                        dataTypeAttribute.GetDataType());

                    if (columnAttribute != null)
                        newColumn = newColumn.SetIsNotNull(columnAttribute.NotNull);
                }
                else
                {
                    var t = _dataTypeConverter.GetClickHouseDataType(property);

                    newColumn = newColumn.SetDataType(t.ClickHouseDataType);

                    if (columnAttribute != null)
                    {
                        newColumn = newColumn.SetIsNotNull(columnAttribute.NotNull);
                    }
                    else
                    {
                        newColumn = newColumn.SetIsNotNull(!t.Nullable);
                    }
                }

                var columnCompressionCodecs = (IEnumerable<ColumnCompressionCodecBaseAttribute?>)Attribute.
                    GetCustomAttributes(property, typeof(ColumnCompressionCodecBaseAttribute));

                foreach (var codec in columnCompressionCodecs)
                {
                    if (codec == null)
                        continue;

                    newColumn = newColumn.AddFieldCodec(
                        codec.GetCompressionCodec());
                }
                createTableCommandBuilder.AddColumn(newColumn.Build());
            }

           var createTableHandler = new CreateTableHandler();
           return createTableHandler.GetCommand(createTableCommandBuilder.Build());
        }
   
    }

    #region Service

    public class ClickHouseDataTypeDescription
    {
        public bool Nullable { get; set; }
        public IClickHouseDataType ClickHouseDataType { get; set; }
    }
    public class PropertyDescription
    {
        public bool Nullable { get; set; }
        public string TypeFullName { get; set; }

        public PropertyDescription()
        {
            TypeFullName = string.Empty;
        }
    }
    public class CreateExprHelper
    {
        public List<IEngineSetting> EngineSettings { get; } = new List<IEngineSetting>();

        private Type _type;
        private ClickHouseTableAttribute? _clickHouseTableAttribute;
        private CreateExpressionParameters? _parameters;
        private Func<string>? _partitioningKeyFunc;

        public CreateExprHelper(Type type, CreateExpressionParameters? parameters)
        {
            _type = type;

            _clickHouseTableAttribute =
                (ClickHouseTableAttribute?)Attribute.GetCustomAttribute(type, typeof(ClickHouseTableAttribute));

            var engineSettingBaseAttribute =
                Attribute.GetCustomAttributes(type, typeof(EngineSettingBaseAttribute));

            foreach (EngineSettingBaseAttribute item in engineSettingBaseAttribute)
            {
                EngineSettings.Add(item.GetSetting());
            }

            _parameters = parameters;

            if(_parameters?.PartitioningKey != null)
            {
                _partitioningKeyFunc = _parameters.PartitioningKey;
            }
            else
            {
                if (!String.IsNullOrEmpty(_clickHouseTableAttribute?.PartitioningKey))
                {
                    _partitioningKeyFunc = () => _clickHouseTableAttribute?.PartitioningKey;
                }
            }
        }

        public string GetDbName()
        {
            var result = "DefaultDbName";

            if (_parameters != null &&
                !String.IsNullOrEmpty(_parameters.DataBaseName))
            {
                result = _parameters.DataBaseName;
            }
            else if (_clickHouseTableAttribute != null
                && !String.IsNullOrEmpty(_clickHouseTableAttribute.DbName))
            {
                result = _clickHouseTableAttribute.DbName;
            }

            return result;
        }

        public string GetTableName()
        {
            var result = _type.Name;

            if (_parameters != null &&
                !String.IsNullOrEmpty(_parameters.TableName))
            {
                result = _parameters.TableName;
            }
            else if (_clickHouseTableAttribute != null
                && !String.IsNullOrEmpty(_clickHouseTableAttribute.TableName))
            {
                result = _clickHouseTableAttribute.TableName;
            }

            return result;
        }

        public bool IsNotExistsSign()
        {
            var result = false;

            if (_clickHouseTableAttribute != null)
            {
                result = _clickHouseTableAttribute.IsNotExists;
            }

            return result;
        }

        public PartitioningKeyValue? GetPartitioningKeyValue()
        {
            if (_partitioningKeyFunc != null)
            {
                return new PartitioningKeyValue(() => _partitioningKeyFunc());
            }
            else
            {
                return null;
            }
        }
    }

    #endregion
}
