using ClickHouseDDLExpression.Models.Common.DataTypes;
using ClickHouseDDLExpression.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClickHouseDDLExpression.Tests.TestData
{
    public class DataTypeConverterTestData
    {
        private static readonly PropertyInfo[] properties = typeof(TestEntityAutomaticDataTypeDetection).GetProperties();

        public static IEnumerable<object[]> TestData
        {
            get
            {
                #region LongDataTypeTestFields

                yield return new object[] 
                { 
                    properties.Where(i => i.Name == "Test_long").FirstOrDefault(), 
                    typeof(ClickHouseDataTypeInt64),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_longNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeInt64),
                    true
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_ulong").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt64),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_ulongNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt64),
                    true
                };

                #endregion

                #region IntDataTypeTestFields

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_int").FirstOrDefault(),
                    typeof(ClickHouseDataTypeInt32),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_intNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeInt32),
                    true
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_uint").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt32),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_uintNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt32),
                    true
                };

                #endregion

                #region ShortDataTypeTestFields

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_short").FirstOrDefault(),
                    typeof(ClickHouseDataTypeInt16),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_shortNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeInt16),
                    true
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_ushort").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt16),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_ushortNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt16),
                    true
                };

                #endregion

                #region ByteDataTypeTestFields

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_sbyte").FirstOrDefault(),
                    typeof(ClickHouseDataTypeInt8),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_sbyteNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeInt8),
                    true
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_byte").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt8),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_byteNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt8),
                    true
                };

                #endregion

                #region DateTimeDataTypeTestFields

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_DateTime").FirstOrDefault(),
                    typeof(ClickHouseDataTypeDateTime),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_DateTimeNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeDateTime),
                    true
                };

                #endregion

                #region StringDataTypeTestFields

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_String").FirstOrDefault(),
                    typeof(ClickHouseDataTypeString),
                    false
                };

                //yield return new object[]
                //{
                //    properties.Where(i => i.Name == "Test_stringNullable").FirstOrDefault(),
                //    typeof(ClickHouseDataTypeString),
                //    true
                //};

                #endregion

                #region BooleanDataTypeTestFields

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_Boolean").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt8),
                    false
                };

                yield return new object[]
                {
                    properties.Where(i => i.Name == "Test_BooleanNullable").FirstOrDefault(),
                    typeof(ClickHouseDataTypeUInt8),
                    true
                };

                #endregion

            }
        }

        public static IEnumerable<object[]> TestDataNotAllow
        {
            get
            {
                yield return new object[]
                {
                    properties.Where(i => i.Name == "Error_Field").FirstOrDefault()
                };
            }
        }
    }
}
