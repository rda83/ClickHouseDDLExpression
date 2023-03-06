
using System.Drawing;

namespace ClickHouseDDLExpression.Tests.Common
{
    public class TestEntityAutomaticDataTypeDetection
    {
        #region LongDataTypeTestFields

        public long Test_long { get; set; }
        public long? Test_longNullable { get; set; }
        public ulong Test_ulong { get; set; }
        public ulong? Test_ulongNullable { get; set; }

        #endregion

        #region IntDataTypeTestFields

        public int Test_int { get; set; }
        public int? Test_intNullable { get; set; }
        public uint Test_uint { get; set; }
        public uint? Test_uintNullable { get; set; }

        #endregion

        #region ShortDataTypeTestFields

        public short Test_short { get; set; }
        public short? Test_shortNullable { get; set; }
        public ushort Test_ushort { get; set; }
        public ushort? Test_ushortNullable { get; set; }

        #endregion

        #region ByteDataTypeTestFields

        public sbyte Test_sbyte { get; set; }
        public sbyte? Test_sbyteNullable { get; set; }
        public byte Test_byte { get; set; }
        public byte? Test_byteNullable { get; set; }

        #endregion

        #region DateTimeDataTypeTestFields

        public DateTime Test_DateTime { get; set; }
        public DateTime? Test_DateTimeNullable { get; set; }

        #endregion

        #region StringDataTypeTestFields

        public string Test_String { get; set; }
        public string? Test_stringNullable { get; set; }

        #endregion

        #region BooleanDataTypeTestFields

        public bool Test_Boolean { get; set; }
        public bool? Test_BooleanNullable { get; set; }

        #endregion

        #region ErrorTypeTestFields

        public Point Error_Field { get; set; }

        #endregion


    }
}
