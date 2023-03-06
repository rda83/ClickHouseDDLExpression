
namespace ClickHouseDDLExpression.Models.Common.IndexTypes
{
    public class IndexTypeSet : ClickHouseIndexTypeBase
    {
        private readonly uint _maxRows;
        public IndexTypeSet(uint MaxRows)
        {
            _maxRows = MaxRows;
        }

        public override string GetViewSpecified()
        {
            return $"set({_maxRows})";
        }
    }
}
