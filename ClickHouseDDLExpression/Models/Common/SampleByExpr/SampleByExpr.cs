using System;

namespace ClickHouseDDLExpression.Models.Common.SampleByExpr
{
    public class SampleByExpr
    {
        private readonly Func<string> _exprFunc;

        public SampleByExpr(Func<string> exprFunc)
        {
            _exprFunc = exprFunc;
        }

        public string GetView()
        {
            var result = $"SAMPLE BY {_exprFunc()}";
            return result;
        }
    }
}
