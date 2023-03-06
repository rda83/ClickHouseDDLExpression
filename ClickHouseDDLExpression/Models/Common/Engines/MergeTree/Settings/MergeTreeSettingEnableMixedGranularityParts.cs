
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingEnableMixedGranularityParts : EngineSettingBase
    {
        public override string GetViewSpecified()
        {
            return "enable_mixed_granularity_parts";
        }
    }

    public class MergeTreeSettingEnableMixedGranularityPartsAttribute : EngineSettingBaseAttribute
    {
        public MergeTreeSettingEnableMixedGranularityPartsAttribute()
        {
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingEnableMixedGranularityParts();
        }
    }
}
