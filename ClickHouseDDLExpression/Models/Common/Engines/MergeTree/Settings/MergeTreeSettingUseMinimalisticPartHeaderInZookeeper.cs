
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingUseMinimalisticPartHeaderInZookeeper : EngineSettingBase
    {
        private readonly uint _value;
        public MergeTreeSettingUseMinimalisticPartHeaderInZookeeper(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"use_minimalistic_part_header_in_zookeeper={_value}";
        }
    }

    public class MergeTreeSettingUseMinimalisticPartHeaderInZookeeperAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingUseMinimalisticPartHeaderInZookeeperAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingUseMinimalisticPartHeaderInZookeeper(Value);
        }
    }
}
