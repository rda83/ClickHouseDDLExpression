
namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public abstract class ClickHouseDataTypeBase : IClickHouseDataType
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
