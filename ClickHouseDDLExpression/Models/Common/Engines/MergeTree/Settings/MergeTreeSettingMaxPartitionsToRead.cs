
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMaxPartitionsToRead : EngineSettingBase
    {
        private readonly uint _value;
        public MergeTreeSettingMaxPartitionsToRead(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"max_partitions_to_read={_value}";
        }
    }

    public class MergeTreeSettingMaxPartitionsToReadAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMaxPartitionsToReadAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMaxPartitionsToRead(Value);
        }
    }
}
