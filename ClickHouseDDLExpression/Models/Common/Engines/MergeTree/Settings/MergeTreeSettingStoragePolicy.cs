
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingStoragePolicy : EngineSettingBase
    {
        private readonly string _policyName;
        public MergeTreeSettingStoragePolicy(string policyName)
        {
            _policyName = policyName;
        }

        public override string GetViewSpecified()
        {
            return $"storage_policy={_policyName}";
        }
    }

    public class MergeTreeSettingStoragePolicyAttribute : EngineSettingBaseAttribute
    {
        private string PolicyName { get;  }

        public MergeTreeSettingStoragePolicyAttribute(string policyName)
        {
            PolicyName = policyName;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingStoragePolicy(PolicyName);
        }
    }
}
