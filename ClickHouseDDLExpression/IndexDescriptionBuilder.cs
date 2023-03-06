using ClickHouseDDLExpression.Models.Common.IndexExpr;
using ClickHouseDDLExpression.Models.Common.IndexTypes;
using ClickHouseDDLExpression.Models.CreateTable;
using System;

namespace ClickHouseDDLExpression
{
    public class IndexDescriptionBuilder
    {
        private string _indexName;
        private IndexExpr _expression;
        private IClickHouseIndexType _indexType;
        private UInt16 _granularity;

        public IndexDescriptionBuilder()
        {
            _indexName = string.Empty;
        }

        public IndexDescriptionBuilder SetIndexName(string val)
        {
            _indexName = val;
            return this;
        }

        public IndexDescriptionBuilder SetExpression(IndexExpr val)
        {
            _expression = val;
            return this;
        }

        public IndexDescriptionBuilder SetIndexType(IClickHouseIndexType val)
        {
            _indexType = val;
            return this;
        }

        public IndexDescriptionBuilder SetGranularity(UInt16 val)
        {
            _granularity = val;
            return this;
        }

        public IndexDescription Build()
        {
            var result = new IndexDescription();
            result.IndexName = _indexName;
            result.Expression = _expression;
            result.IndexType = _indexType;
            result.Granularity = _granularity;

            return result;
        }
    }
}
