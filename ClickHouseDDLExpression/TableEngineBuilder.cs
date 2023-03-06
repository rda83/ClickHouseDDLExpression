using ClickHouseDDLExpression.Models.Common.Engines;
using ClickHouseDDLExpression.Models.Common.Engines.MergeTree;
using System.Collections.Generic;

namespace ClickHouseDDLExpression
{
    public class TableEngineMergeTreeBuilder
    {
        private IList<IEngineSetting> _settings;

        public TableEngineMergeTreeBuilder()
        {
            _settings = new List<IEngineSetting>();
        }

        public TableEngineMergeTreeBuilder AddSetting(IEngineSetting val)
        {
            _settings.Add(val);
            return this;
        }

        public MergeTreeTableEngine Build()
        {
            var result = new MergeTreeTableEngine();
            result.Settings = _settings;
            return result;
        }
    }
}
