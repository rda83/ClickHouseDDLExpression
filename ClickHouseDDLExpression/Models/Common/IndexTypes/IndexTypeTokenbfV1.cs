
namespace ClickHouseDDLExpression.Models.Common.IndexTypes
{
    public class IndexTypeTokenbfV1 : ClickHouseIndexTypeBase
    {
        private readonly uint _sizeOfBloomFilterInBytes;
        private readonly uint _numberOfHashFunctions;
        private readonly uint _randomSeed;

        public IndexTypeTokenbfV1(uint sizeOfBloomFilterInBytes, 
            uint numberOfHashFunctions, 
            uint randomSeed)
        {
            _sizeOfBloomFilterInBytes = sizeOfBloomFilterInBytes;
            _numberOfHashFunctions = numberOfHashFunctions;
            _randomSeed = randomSeed;
        }

        public override string GetViewSpecified()
        {
            return $"tokenbf_v1({_sizeOfBloomFilterInBytes}, {_numberOfHashFunctions}, {_randomSeed})";
        }
    }
}
