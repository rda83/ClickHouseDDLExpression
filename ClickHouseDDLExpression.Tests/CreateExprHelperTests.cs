using ClickHouseDDLExpression.Attributes;
using ClickHouseDDLExpression.Models.Common.PartitioningKey;
using ClickHouseDDLExpression.Models.ExpressionBuilderParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickHouseDDLExpression.Tests
{
    public class CreateExprHelperTests
    {

        //GetDbName - возможные способы указания имени базы


        /// <summary>
        /// Ключ партиционирования не указан
        /// </summary>
        [Fact]
        public void PartitioningKeyNotSpecified()
        {
            var sut = new CreateExprHelper(
                typeof(TestDtoCreateExprHelperPartitioningKeyNotSpecified), 
                new CreateExpressionParameters() { });

            var needPartitioningKey = sut.GetPartitioningKeyValue();

            Assert.Null(needPartitioningKey);
        }

        /// <summary>
        /// Ключ партиционирования указан через параметры 
        /// </summary>
        [Fact]
        public void PartitioningKeySpecifiedViaCreateExpr()
        {
            string partitioningKey = "toYYYYMM(Period)";

            var sut = new CreateExprHelper(
                typeof(TestDtoCreateExprHelperPartitioningKeyNotSpecified),
                new CreateExpressionParameters() 
                {
                    PartitioningKey = () => partitioningKey
                });

            var needPartitioningKey = sut.GetPartitioningKeyValue();

            Assert.IsType<PartitioningKeyValue>(needPartitioningKey);
            Assert.Equal($"PARTITION BY {partitioningKey}", needPartitioningKey?.GetView());
        }

        /// <summary>
        /// Ключ партиционирования указан через атрибут DTO класса 
        /// </summary>
        [Fact]
        public void PartitioningKeySpecifiedViaClassAttr()
        {
            // параметры ключа партиционирования указыны только атрибуте класса

            string partitioningKey = "toYYYYMM(DateEvent)";

            var sut = new CreateExprHelper(
                typeof(TestDtoCreateExprHelperPartitioningKeySpecified), null);

            var needPartitioningKey = sut.GetPartitioningKeyValue();

            Assert.IsType<PartitioningKeyValue>(needPartitioningKey);
            Assert.Equal($"PARTITION BY {partitioningKey}", needPartitioningKey?.GetView());

        }

        /// <summary>
        /// Ключ партиционирования указан через параметры и через атрибут DTO класса 
        /// </summary>
        [Fact]
        public void PartitioningKeySpecifiedViaCreateExprAndClassAttr()
        {
            string partitioningKey = "toYYYYMM(Period)";

            var sut = new CreateExprHelper(
                typeof(TestDtoCreateExprHelperPartitioningKeyNotSpecified),
                new CreateExpressionParameters()
                {
                    PartitioningKey = () => partitioningKey
                });

            var needPartitioningKey = sut.GetPartitioningKeyValue();

            Assert.IsType<PartitioningKeyValue>(needPartitioningKey);
            Assert.Equal($"PARTITION BY {partitioningKey}", needPartitioningKey?.GetView());
        }
    }

    public class TestDtoCreateExprHelperPartitioningKeyNotSpecified
    {
        public DateTime Period { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    [ClickHouseTable(PartitioningKey = "toYYYYMM(DateEvent)")]
    public class TestDtoCreateExprHelperPartitioningKeySpecified
    {
        public DateTime Period { get; set; }
        public DateTime DateEvent { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
