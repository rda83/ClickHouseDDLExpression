using System;

namespace ClickHouseDDLExpression.Models.Common.ColumnTTL
{
    public class ColumnTTL
    {
        private readonly Func<string> _exprFunc;
        public ColumnTTL(Func<string> exprFunc)
        {
            _exprFunc = exprFunc;
        }

        public string GetView()
        {
            var result = $"TTL {_exprFunc()}";
            return result;
        }
    }
}
