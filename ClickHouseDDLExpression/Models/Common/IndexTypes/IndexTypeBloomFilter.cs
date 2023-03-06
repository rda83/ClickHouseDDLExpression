
namespace ClickHouseDDLExpression.Models.Common.IndexTypes
{
    public class IndexTypeBloomFilter : ClickHouseIndexTypeBase
    {
        private readonly float _falsePositive;

        public IndexTypeBloomFilter(float falsePositive)
        {
            _falsePositive = falsePositive;
        }

        public override string GetViewSpecified()
        {
            return $"bloom_filter({_falsePositive})";
        }
    }
}
