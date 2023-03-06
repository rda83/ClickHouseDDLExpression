
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMinMergeBytesToUseDirectIo : EngineSettingBase
    {
        private readonly ulong _value;

        public MergeTreeSettingMinMergeBytesToUseDirectIo(ulong value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"min_merge_bytes_to_use_direct_io={_value}";
        }
    }

    public class MergeTreeSettingMinMergeBytesToUseDirectIoAttribute : EngineSettingBaseAttribute
    {
        private ulong Value { get; }

        public MergeTreeSettingMinMergeBytesToUseDirectIoAttribute(ulong value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMinMergeBytesToUseDirectIo(Value);
        }
    }
}
