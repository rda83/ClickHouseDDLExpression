using ClickHouseDDLExpression.Models.Common.Engines;
using System;


namespace ClickHouseDDLExpression.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public abstract class EngineSettingBaseAttribute : Attribute
    {

        public IEngineSetting GetSetting()
        {
            return GetSettingSpecified();
        }

        public virtual IEngineSetting GetSettingSpecified()
        {
            throw new NotImplementedException();
        }
    }
}
