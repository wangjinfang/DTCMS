using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DTcms.Common
{
    public class myJson
    {
        #region=============把datatable转换成Json字符串NAN==========================
        /// <summary>
        /// 把datatable转换成Json字符串分页
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <returns>Json</returns>
        public static string getJson(DataTable dt, int pagesize, int pageindex, int totalcount, int pagecount)
        {
            StringBuilder strJson = new StringBuilder();
            strJson.Append("{\"TableName\":\"" + dt.TableName + "\",\"Rows\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strJson.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    strJson.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\'", "\\\'").Replace("\t", " ").Replace("\r", " ").Replace("\n", "<br/>").Replace("\"", "'") + "\",");
                }
                strJson.Remove(strJson.Length - 1, 1);
                strJson.Append("},");
            }
            strJson.Remove(strJson.Length - 1, 1);
            strJson.Append("],\"pageParameter\":[{\"pagesize\":\"" + pagesize + "\",\"pageindex\":\"" + pageindex + "\",\"totalcount\":\"" + totalcount + "\",\"pagecount\":\"" + pagecount + "\"}]}");
            return strJson.ToString();
        }
        /// <summary>
        /// 把datatable转换成Json字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string getJson(DataTable dt)
        {
            StringBuilder strJson = new StringBuilder();
            strJson.Append("{\"TableName\":\"" + dt.TableName + "\",\"Rows\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strJson.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    strJson.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + dt.Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\'", "\\\'").Replace("\t", " ").Replace("\r", " ").Replace("\n", "<br/>").Replace("\"", "'") + "\",");
                }
                strJson.Remove(strJson.Length - 1, 1);
                strJson.Append("},");
            }
            strJson.Remove(strJson.Length - 1, 1);
            strJson.Append("]}");
            return strJson.ToString();
        }
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 获取dataset的JSON字符串
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string getJson(DataSet ds)
        {
            StringBuilder jsonStr = new StringBuilder();
            jsonStr.Append("{");
            for (int d = 0; d < ds.Tables.Count; d++)
            {
                jsonStr.Append("\"" + ds.Tables[d].TableName + "\":[");
                for (int i = 0; i < ds.Tables[d].Rows.Count; i++)
                {
                    jsonStr.Append("{");
                    for (int j = 0; j < ds.Tables[d].Columns.Count; j++)
                    {
                        jsonStr.Append("\"" + ds.Tables[d].Columns[j].ColumnName.ToString() + "\":\"" + ds.Tables[d].Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\'", "\\\'").Replace("\t", " ").Replace("\r", " ").Replace("\n", "<br/>").Replace("\"", "'") + "\",");
                    }
                    jsonStr.Remove(jsonStr.Length - 1, 1);
                    jsonStr.Append("},");
                }
                jsonStr.Remove(jsonStr.Length - 1, 1);
                jsonStr.Append("],");
            }
            jsonStr.Remove(jsonStr.Length - 1, 1);
            jsonStr.Append("}");
            return jsonStr.ToString();
        }
        #endregion
    }
}
