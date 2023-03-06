using ClickHouseDDLExpression.Models.Common;
using ClickHouseDDLExpression.Models.Common.ColumnTTL;
using ClickHouseDDLExpression.Models.Common.CompressionCodecs;
using ClickHouseDDLExpression.Models.Common.DataTypes;
using ClickHouseDDLExpression.Models.Common.DefaultValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClickHouseDDLExpression.Models.CreateTable
{
    public class ColumnDescription : IExpressionElement
    {
        public string ColumnName { get; set; }
        public IClickHouseDataType DataType { get; set; }
        public bool IsNotNull { get; set; }
        public List<IClickHouseCompressionCodec> Codecs { get; set; }
        public ColumnDefaultValue? ColumnDefaultValue { get; set; }
        public ColumnTTL? ColumnTTL { get; set; }
        public uint? OrderBy { get; set; }
        public uint? PrimaryKey { get; set; }

        public ColumnDescription()
        {
            Codecs = new List<IClickHouseCompressionCodec>();
        }

        #region IExpressionElementMembers
        public string GetView()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.ColumnName} ");
            sb.Append($"{this.DataType.GetView()} ");

            if (this.ColumnDefaultValue != null)
            {
                sb.Append($"{this.ColumnDefaultValue.GetView()} ");
            }

            sb.Append($"{GetNullNotNullFlag(this.IsNotNull)} ");
            sb.Append($"{GetCodecInfo(this.Codecs)} ");

            if (this.ColumnTTL != null)
            {
                sb.Append(this.ColumnTTL.GetView());
            }

            var result = sb.ToString();
            return result;
        }
        private string GetCodecInfo(IList<IClickHouseCompressionCodec> codecs)
        {
            if (codecs == null || codecs.Count == 0)
                return String.Empty;

            var sb = new StringBuilder();
            sb.Append("CODEC(");

            var maxIndex = codecs.Count - 1;
            for (int idx = 0; idx <= maxIndex; idx++)
            {
                var codec = codecs[idx];
                var lineDivider = idx == maxIndex ? string.Empty : ",";
                sb.Append($"{codec.GetView()}{lineDivider}");
            }
            sb.Append(")");

            return sb.ToString();
        }
        private string GetNullNotNullFlag(bool parametrFlag) =>
            parametrFlag ? "NOT NULL" : "NULL";
        #endregion
    }
}
