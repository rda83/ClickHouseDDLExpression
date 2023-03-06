
namespace ClickHouseDDLExpression.Models.Common.IndexTypes
{
    public class IndexTypeMinMax : ClickHouseIndexTypeBase
    {
        public override string GetViewSpecified()
        {
            return "minmax";
        }
    }
}
