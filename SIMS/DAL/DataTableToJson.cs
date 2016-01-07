using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.DAL
{
    public static class DataTableToJson
    {
        public static string DataTableToJsonString(DataTable dt)
        {
            StringBuilder result = new StringBuilder();
            result.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                result.Append("{");
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Append("\"");
                    result.Append(dc.ColumnName);
                    result.Append("\"");
                    result.Append(":");
                    result.Append("\"");
                    result.Append(dr[dc]);
                    result.Append("\"");
                    result.Append(",");
                }
                result.Remove(result.Length - 1, 1);
                result.Append("},");
            }
            if (result.Length > 1)
            {
                result.Remove(result.Length - 1, 1);
            }
            result.Append("]");
            return result.ToString();
        }
    }
}
