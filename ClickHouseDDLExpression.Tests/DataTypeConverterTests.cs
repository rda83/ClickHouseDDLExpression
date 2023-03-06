using ClickHouseDDLExpression.Helpers;
using ClickHouseDDLExpression.Tests.Common;
using ClickHouseDDLExpression.Tests.TestData;
using System.Reflection;


namespace ClickHouseDDLExpression.Tests
{
    public class DataTypeConverterTests
    {
        private readonly DataTypeConverter _dataTypeConverter = new DataTypeConverter();
        private readonly Type _testType = typeof(TestEntityAutomaticDataTypeDetection);

        [Theory]
        [MemberData("TestData", MemberType = typeof(DataTypeConverterTestData))]
        public void DataTypeDetect_Should(PropertyInfo property, Type expectedType, bool Nullable)
        {
            var result = _dataTypeConverter.GetClickHouseDataType(property);
            
            Assert.IsType(expectedType, result.ClickHouseDataType);
            Assert.Equal(result.Nullable, Nullable);
        }

        [Theory]
        [MemberData("TestDataNotAllow", MemberType = typeof(DataTypeConverterTestData))]
        public void NotAllowDataType_Should(PropertyInfo property)
        {
            Assert.Throws<ArgumentException>(() => _dataTypeConverter.GetClickHouseDataType(property));
        }
    }
}