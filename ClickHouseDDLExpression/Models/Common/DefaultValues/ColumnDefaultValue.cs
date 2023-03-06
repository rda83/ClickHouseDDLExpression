using System;

namespace ClickHouseDDLExpression.Models.Common.DefaultValues
{
    public class ColumnDefaultValue
    {
        private readonly TypeDefaultValue _typeDefaultValue;
        private readonly Func<string> _exprFunc;

        public ColumnDefaultValue(TypeDefaultValue typeDefaultValue, 
            Func<string> exprFunc)
        {
            _typeDefaultValue = typeDefaultValue;
            _exprFunc = exprFunc;   
        }

        public string GetView()
        {
            string _typeDefaultValueExpr;

            switch (_typeDefaultValue)
            {
                case TypeDefaultValue.DEFAULT:
                    _typeDefaultValueExpr = "DEFAULT";
                    break;
                case TypeDefaultValue.MATERIALIZED:
                    _typeDefaultValueExpr = "MATERIALIZED";
                    break;
                case TypeDefaultValue.EPHEMERAL:
                    _typeDefaultValueExpr = "EPHEMERAL";
                    break;
                case TypeDefaultValue.ALIAS:
                    _typeDefaultValueExpr = "ALIAS";
                    break;
                default:
                    _typeDefaultValueExpr = "DEFAULT";
                    break;
            }

            var result = $"{_typeDefaultValueExpr} {_exprFunc()}";
            return result;
        }
    }
}
