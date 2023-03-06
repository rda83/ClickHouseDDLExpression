
using System.Collections.Generic;

namespace ClickHouseDDLExpression.Models.Common.Engines
{
    public abstract class TableEngineBase : ITableEngine
    {
        public IList<IEngineSetting> Settings { get; set; }

        public TableEngineBase()
        {
            Settings = new List<IEngineSetting>();
        }

        public string GetView()
        {
            return GetViewSpecified();
        }

        public virtual string GetViewSpecified()
        {
            return string.Empty;
        }
    }
}
