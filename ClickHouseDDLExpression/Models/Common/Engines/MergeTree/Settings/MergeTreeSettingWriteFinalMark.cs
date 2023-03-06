
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingWriteFinalMark : EngineSettingBase
    {
        private readonly uint _value;

        public MergeTreeSettingWriteFinalMark(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"write_final_mark={_value}";
        }
    }

    public class MergeTreeSettingWriteFinalMarkAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingWriteFinalMarkAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingWriteFinalMark(Value);
        }
    }
}
