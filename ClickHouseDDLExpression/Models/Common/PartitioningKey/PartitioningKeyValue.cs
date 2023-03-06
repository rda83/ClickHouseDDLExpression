using System;

namespace ClickHouseDDLExpression.Models.Common.PartitioningKey
{
    public class PartitioningKeyValue
    {
        private readonly Func<string> _exprFunc;
        public PartitioningKeyValue(Func<string> exprFunc)
        {
            _exprFunc = exprFunc;
        }

        public string GetView()
        {
            var result = $"PARTITION BY {_exprFunc()}";
            return result;
        }
    }
}
