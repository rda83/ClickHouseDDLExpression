
namespace ClickHouseDDLExpression.Models.Common.IndexTypes
{
    public class IndexTypeNgrambfV1 : ClickHouseIndexTypeBase
    {
        private readonly uint _sizeNgramm;
        private readonly uint _sizeOfBloomFilterInBytes;
        private readonly uint _numberOfHashFunctions;
        private readonly uint _randomSeed;

        public IndexTypeNgrambfV1(uint sizeNgramm, 
            uint sizeOfBloomFilterInBytes, 
            uint numberOfHashFunctions, 
            uint randomSeed)
        {
            _sizeNgramm = sizeNgramm;
            _sizeOfBloomFilterInBytes = sizeOfBloomFilterInBytes;
            _numberOfHashFunctions = numberOfHashFunctions;
            _randomSeed = randomSeed;   
        }

        public override string GetViewSpecified()
        {
            return $"ngrambf_v1({_sizeNgramm}, {_sizeOfBloomFilterInBytes}, {_numberOfHashFunctions}, {_randomSeed})";
        }
    }
}
