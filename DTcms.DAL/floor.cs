using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:floor
    /// </summary>
    public partial class floor
    {
        private string databaseprefix; //数据库表名前缀
        public floor(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "floors");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回楼层名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "floors");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.floor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "floors(");
            strSql.Append("belongchannel,floorname,title,color,remark,add_time,status)");
            strSql.Append(" values (");
            strSql.Append("@belongchannel,@floorname,@title,@color,@remark,@add_time,@status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@belongchannel", SqlDbType.TinyInt,1),
					new SqlParameter("@floorname", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
                    new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,255),					
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@status", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.belongchannel;
            parameters[1].Value = model.floorname;
            parameters[2].Value = model.title;
            parameters[3].Value = model.color;
            parameters[4].Value = model.remark;
            parameters[5].Value = model.add_time;
            parameters[6].Value = model.status;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.floor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "floors set ");
            strSql.Append("belongchannel=@belongchannel,");
            strSql.Append("floorname=@floorname,");
            strSql.Append("title=@title,");
            strSql.Append("color=@color,");
            strSql.Append("remark=@remark,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("status=@status");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@belongchannel", SqlDbType.TinyInt,1),
					new SqlParameter("@floorname", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@color", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,255),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.belongchannel;
            parameters[1].Value = model.floorname;
            parameters[2].Value = model.title;
            parameters[3].Value = model.color;
            parameters[4].Value = model.remark;
            parameters[5].Value = model.add_time;
            parameters[6].Value = model.status;
            parameters[7].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据及其子表
        /// </summary>
        public bool Delete(int id)
        {
            return false;
            //List<CommandInfo> sqllist = new List<CommandInfo>();
            //StringBuilder strSql2 = new StringBuilder();
            //strSql2.Append("delete from " + databaseprefix + "advertbanners ");
            //strSql2.Append(" where aid=@aid ");
            //SqlParameter[] parameters2 = {
            //        new SqlParameter("@aid", SqlDbType.Int,4)};
            //parameters2[0].Value = id;

            //CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            //sqllist.Add(cmd);
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from dt_adverts ");
            //strSql.Append(" where id=@id");
            //SqlParameter[] parameters = {
            //        new SqlParameter("@id", SqlDbType.Int,4)};
            //parameters[0].Value = id;

            //cmd = new CommandInfo(strSql.ToString(), parameters);
            //sqllist.Add(cmd);
            //int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.floor GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,belongchannel,floorname,title,color,remark,add_time,status from " + databaseprefix + "floors ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.floor model = new Model.floor();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["belongchannel"] != null && ds.Tables[0].Rows[0]["belongchannel"].ToString() != "")
                {
                    model.belongchannel = int.Parse(ds.Tables[0].Rows[0]["belongchannel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["floorname"] != null && ds.Tables[0].Rows[0]["floorname"].ToString() != "")
                {
                    model.floorname = ds.Tables[0].Rows[0]["floorname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["color"] != null && ds.Tables[0].Rows[0]["color"].ToString() != "")
                {
                    model.color = ds.Tables[0].Rows[0]["color"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = (ds.Tables[0].Rows[0]["status"].ToString());
                }
              
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,belongchannel,floorname,title,color,remark,add_time,status ");
            strSql.Append(" FROM " + databaseprefix + "floors ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,belongchannel,floorname,title,color,remark,add_time,status ");
            strSql.Append(" FROM " + databaseprefix + "floors ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "floors");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}