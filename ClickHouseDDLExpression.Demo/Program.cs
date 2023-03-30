using ClickHouseDDLExpression.Demo.Models;
using ClickHouseDDLExpression.Features.CreateTable;
using ClickHouseDDLExpression.Models.Common.CompressionCodecs;
using ClickHouseDDLExpression.Models.Common.DataTypes;
using ClickHouseDDLExpression.Models.Common.PartitioningKey;
using ClickHouseDDLExpression.Models.ExpressionBuilderParameters;

namespace ClickHouseDDLExpression.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            case_1();
            case_2();

        }

        /// <summary>
        /// Ключ партиционирования не указан
        /// </summary>
        static void case_1()
        {

            #region DTO

            //public class Event
            //{
            //    [ClickHouseColumn(PrimaryKey = 1, NotNull = true)]
            //    public DateTime Period { get; set; }
            //    public string Description { get; set; }
            //    public int Source { get; set; }
            //    public int Status { get; set; }
            //}

            #endregion

            var builder = new CreateTableBuilder();
            var e = builder.Build<Event>(
                new CreateExpressionParameters()
                {
                    DataBaseName = "TestDB",
                });

            Console.WriteLine(e);

            #region Output

            //CREATE TABLE TESTDB.EVENT(
            //    Period DateTime NOT NULL,
            //    Description String NOT NULL,
            //    Source Int32 NOT NULL,
            //    Status Int32 NOT NULL
            //    ) ENGINE = MergeTree() PRIMARY KEY Period

            #endregion
        }

        /// <summary>
        /// Ключ партиционирования указан через параметры
        /// </summary>
        static void case_2()
        {

            #region DTO

            //public class Event
            //{
            //    [ClickHouseColumn(PrimaryKey = 1, NotNull = true)]
            //    public DateTime Period { get; set; }
            //    public string Description { get; set; }
            //    public int Source { get; set; }
            //    public int Status { get; set; }
            //}

            #endregion

            var builder = new CreateTableBuilder();
            var e = builder.Build<Event>(
                new CreateExpressionParameters()
                {
                    DataBaseName = "TestDB",
                    PartitioningKey = () => "toYYYYMM(Period)"
                });

            Console.WriteLine(e);

            #region Output

            //CREATE TABLE TestDB.Event
            //(
            //    Period DateTime NOT NULL,
            //    Description String NOT NULL,
            //    Source Int32 NOT NULL,
            //    Status Int32 NOT NULL
            //) ENGINE = MergeTree()
            //PRIMARY KEY Period
            //PARTITION BY toYYYYMM(Period)

            #endregion
        }
    }
}