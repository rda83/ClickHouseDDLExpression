
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{

    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingTryFetchRecompressedPartTimeout : EngineSettingBase
    {
        private readonly uint _value;

        public MergeTreeSettingTryFetchRecompressedPartTimeout(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"try_fetch_recompressed_part_timeout={_value}";
        }
    }

    public class MergeTreeSettingTryFetchRecompressedPartTimeoutAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingTryFetchRecompressedPartTimeoutAttribute(uint value)
        {
            Value = value; 
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingTryFetchRecompressedPartTimeout(Value);
        }
    }
}
