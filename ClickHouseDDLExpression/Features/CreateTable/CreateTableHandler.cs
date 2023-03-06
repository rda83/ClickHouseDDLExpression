using ClickHouseDDLExpression.Models.Common;
using ClickHouseDDLExpression.Models.Common.Engines;
using ClickHouseDDLExpression.Models.CreateTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickHouseDDLExpression.Features.CreateTable
{
    public class CreateTableHandler
    {
        public string GetCommand(CreateTableCommand command)
        {
            var sb = new StringBuilder();

            var ifNotExist = GetIfNotExistsFlag(command.IfNotExists);
            sb.Append($"CREATE TABLE{ifNotExist} {command.DbName}.{command.TableName}");
            sb.AppendLine();
            sb.AppendLine("(");

            var expressionElements = new List<IExpressionElement>();
            expressionElements.AddRange(command.ColumnDescriptions);
            expressionElements.AddRange(command.IndexDescriptions);

            var expressionElementsBlock = GetElementsBlock(expressionElements, 4);
            sb.AppendLine(expressionElementsBlock);

            sb.AppendLine($") ENGINE = {command.TableEngine.GetView()}");
            
            var orderByExpression = GetOrderByExpression(command.ColumnDescriptions);
            if (orderByExpression != string.Empty)
            {
                sb.AppendLine(orderByExpression);
            }

            var primaryKeyExpression = GetPrimaryKeyExpression(command.ColumnDescriptions);
            if (primaryKeyExpression != string.Empty)
            {
                sb.AppendLine(primaryKeyExpression);
            }

            if (command.PartitioningKey != null)
            {
                var partitioning = command.PartitioningKey.GetView();
                sb.AppendLine(partitioning);
            }

            if(command.SampleByExpr != null)
            {
                var sampleByExpr = command.SampleByExpr.GetView();
                sb.AppendLine(sampleByExpr);
            }

            var engineSettingsExpression 
                = GetEngineSettingsExpression(command.TableEngine.Settings);

            if (engineSettingsExpression != string.Empty)
            {
                sb.AppendLine(engineSettingsExpression);
            }
            
            var result = sb.ToString();
            return result;
        }

        private string GetEngineSettingsExpression(IList<IEngineSetting> elements)
        {
            int idx = 0;
            var sb = new StringBuilder();
            var maxIndex = elements.Count() - 1;
            foreach (var item in elements)
            {
                if (idx == 0)
                    sb.Append("SETTINGS ");

                var lineDivider = idx == maxIndex ? string.Empty : ", ";
                sb.Append(item.GetView())
                    .Append(lineDivider);

                idx++;
            }

            var result = sb.ToString();
            return result;
        }

        private string GetOrderByExpression(IList<ColumnDescription> elements)
        {
            var sortedElements = elements.Where(el => el.OrderBy != null)
                .OrderBy(el => el.OrderBy);

            var result = MergeFieldNames("ORDER BY", sortedElements);
            return result;
        }

        private string GetPrimaryKeyExpression(IList<ColumnDescription> elements)
        {
            var sortedElements = elements.Where(el => el.PrimaryKey != null)
                .OrderBy(el => el.PrimaryKey);

            var result = MergeFieldNames("PRIMARY KEY", sortedElements);

            return result;
        }

        private string GetElementsBlock(IList<IExpressionElement> elements,
            int level = 0)
        {
            var indent = new String(' ', level);
            var sb = new StringBuilder();

            var maxIndex = elements.Count - 1;
            for (int idx = 0; idx <= maxIndex; idx++)
            {
                var column = elements[idx];
                var lineDivider = idx == maxIndex ? string.Empty : ",\n";

                sb.Append($"{indent}");
                sb.Append(column.GetView());
                sb.Append($"{lineDivider}");
            }
            var result = sb.ToString();
            return result;
        }

        private string GetIfNotExistsFlag(bool parametrFlag) =>
            parametrFlag ? " IF NOT EXISTS" : string.Empty;

        private string MergeFieldNames(string funcName, IOrderedEnumerable<ColumnDescription> elements)
        {
            int idx = 0;
            var sb = new StringBuilder();
            var maxIndex = elements.Count() - 1;
            foreach (var item in elements)
            {
                if (idx == 0)
                    sb.Append($"{funcName} ");

                var lineDivider = idx == maxIndex ? string.Empty : ", ";
                sb.Append(item.ColumnName)
                    .Append(lineDivider);

                idx++;
            }

            var result = sb.ToString();
            return result;
        }
    }
}
