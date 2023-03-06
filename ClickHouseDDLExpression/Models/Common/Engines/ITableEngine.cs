
using System.Collections.Generic;

namespace ClickHouseDDLExpression.Models.Common.Engines
{
    public interface ITableEngine
    {
        public IList<IEngineSetting> Settings { get; set; }
        string GetView();
    }
}
