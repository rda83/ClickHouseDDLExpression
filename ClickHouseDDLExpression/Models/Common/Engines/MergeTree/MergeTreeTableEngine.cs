
namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree
{
    public class MergeTreeTableEngine : TableEngineBase
    {
        public MergeTreeTableEngine() 
            : base()
        { }

        public override string GetViewSpecified()
        {
            return "MergeTree()";
        }
    }
}
