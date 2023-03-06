
namespace ClickHouseDDLExpression.Models.Common.IndexTypes
{
    public abstract class ClickHouseIndexTypeBase : IClickHouseIndexType
    {
        public string GetView()
        {
            return GetViewSpecified();
        }

        public virtual string GetViewSpecified()
        {
            return string.Empty;
        }
    }
}
