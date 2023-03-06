using System;

namespace ClickHouseDDLExpression.Models.Common.IndexExpr
{
    public class IndexExpr
    {
        private readonly Func<string> _exprFunc;

        public IndexExpr(Func<string> exprFunc)
        {
            _exprFunc = exprFunc;
        }

        public string GetView()
        {
            var result = $"{_exprFunc()}";
            return result;
        }
    }
}
