
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Demo.Models
{
    public class Event
    {
        [ClickHouseColumn(PrimaryKey = 1, NotNull = true)]
        public DateTime Period { get; set; }
        public string Description { get; set; }
        public int Source { get; set; }
        public int Status { get; set; }

    }
}
