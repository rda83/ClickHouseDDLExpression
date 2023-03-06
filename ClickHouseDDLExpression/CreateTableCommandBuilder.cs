using ClickHouseDDLExpression.Models.Common.Engines;
using ClickHouseDDLExpression.Models.Common.PartitioningKey;
using ClickHouseDDLExpression.Models.Common.SampleByExpr;
using ClickHouseDDLExpression.Models.CreateTable;
using System.Collections.Generic;

namespace ClickHouseDDLExpression
{
    public class CreateTableCommandBuilder
    {
        private List<ColumnDescription> _columnDescriptions;
        private List<IndexDescription> _indexDescriptions;

        private bool _ifNotExists;
        private string _dbName;
        private string _tableName;
        private PartitioningKeyValue? _partitioningKey;
        private SampleByExpr? _sampleByExpr;
        private ITableEngine _tableEngine;

        public CreateTableCommandBuilder()
        {
            _columnDescriptions = new List<ColumnDescription>();
            _indexDescriptions = new List<IndexDescription>();
            _ifNotExists = false;
            _dbName = string.Empty;
            _tableName = string.Empty;
        }

        public CreateTableCommandBuilder SetIsNotExists(bool val)
        {
            _ifNotExists = val;
            return this;
        }

        public CreateTableCommandBuilder SetDbName(string val)
        {
            _dbName = val;
            return this;
        }

        public CreateTableCommandBuilder SetTableName(string val)
        {
            _tableName = val;
            return this;
        }

        public CreateTableCommandBuilder SetPartitioningKey(PartitioningKeyValue val)
        {
            _partitioningKey = val;
            return this;
        }

        public CreateTableCommandBuilder SetSampleByExpr(SampleByExpr val)
        {
            _sampleByExpr = val;
            return this;
        }

        public CreateTableCommandBuilder SetTableEngine(ITableEngine val)
        {
            _tableEngine = val;
            return this;
        }

        public CreateTableCommandBuilder AddColumn(ColumnDescription columnDescription)
        {
            _columnDescriptions.Add(columnDescription);
            return this;
        }

        public CreateTableCommandBuilder AddIndex(IndexDescription indexDescription)
        {
            _indexDescriptions.Add(indexDescription);
            return this;
        }

        public CreateTableCommand Build()
        {
            var result = new CreateTableCommand();
            result.IfNotExists = _ifNotExists;
            result.DbName = _dbName;
            result.TableName = _tableName;
            result.ColumnDescriptions = _columnDescriptions;
            result.PartitioningKey = _partitioningKey;
            result.SampleByExpr = _sampleByExpr;
            result.IndexDescriptions = _indexDescriptions;
            result.TableEngine = _tableEngine;

            return result;
        }
    }
}
