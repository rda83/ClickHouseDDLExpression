namespace ClickHouseDDLExpression.Models.Common.Engines
{
    public abstract class EngineSettingBase : IEngineSetting
    {
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
