using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //td_standard
    public partial class standard
    {
        public standard() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from td_standard");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.standard model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into td_standard(");
            strSql.Append("category_id,title,add_time");
            strSql.Append(") values (");
            strSql.Append("@category_id,@title,@add_time");
            strSql.Append(") ");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@category_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReturnValue",SqlDbType.Int)
            };

            parameters[0].Value = model.category_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.add_time;
            parameters[3].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            if (model.standard_values.Count > 0)
            {
                StringBuilder strSql1;
                foreach (Model.standard_value standard_value in model.standard_values)
                {
                    strSql1 = new StringBuilder();
                    strSql1.Append("insert td_standard_value(standard_id,value,add_time) values(@standard_id,@value,@add_time)");
                    SqlParameter[] parameters1 ={
                                               new SqlParameter("@standard_id", SqlDbType.Int,4) ,            
                                               new SqlParameter("@value", SqlDbType.NVarChar,200) ,            
                                               new SqlParameter("@add_time", SqlDbType.DateTime)      
                                               };
                    parameters1[0].Direction = ParameterDirection.InputOutput;
                    parameters1[1].Value = standard_value.value;
                    parameters1[2].Value = standard_value.add_time;

                    cmd = new CommandInfo(strSql1.ToString(), parameters1);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[3].Value;
        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_standard set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.standard model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update td_standard set ");

                        strSql.Append(" category_id = @category_id , ");
                        strSql.Append(" title = @title , ");
                        strSql.Append(" add_time = @add_time  ");
                        strSql.Append(" where id=@id ");

                        SqlParameter[] parameters = {
			                                        new SqlParameter("@id", SqlDbType.Int,4) ,            
                                                    new SqlParameter("@category_id", SqlDbType.Int,4) ,            
                                                    new SqlParameter("@title", SqlDbType.NVarChar,50) ,            
                                                    new SqlParameter("@add_time", SqlDbType.DateTime)      
                                                    };

                        parameters[0].Value = model.id;
                        parameters[1].Value = model.category_id;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.add_time;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        DbHelperSQL.ExecuteSql(conn, trans, "delete from td_standard_value where standard_id="+model.id);
                        if (model.standard_values.Count > 0)
                        {
                            StringBuilder strSql1;
                            foreach (Model.standard_value standard_value in model.standard_values)
                            {
                                strSql1 = new StringBuilder();
                                strSql1.Append("insert td_standard_value(standard_id,value,add_time) values(@standard_id,@value,@add_time)");
                                SqlParameter[] parameters1 ={
                                               new SqlParameter("@standard_id", SqlDbType.Int,4) ,            
                                               new SqlParameter("@value", SqlDbType.NVarChar,200) ,            
                                               new SqlParameter("@add_time", SqlDbType.DateTime)      
                                               };
                                parameters1[0].Value = model.id;
                                parameters1[1].Value = standard_value.value;
                                parameters1[2].Value = standard_value.add_time;

                                DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString(), parameters1);
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_standard ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


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
        /// 得到一个对象实体
        /// </summary>
        public Model.standard GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, category_id, title, add_time  ");
            strSql.Append("  from td_standard ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.standard model = new Model.standard();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }


                DataSet ds1 = new DAL.standard_value().GetList("standard_id=" + id);
                List<Model.standard_value> lst = new List<Model.standard_value>();
                if (ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                {
                    Model.standard_value model_value;
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        model_value = new Model.standard_value();
                        if (dr["id"] != null && dr["id"].ToString() != "")
                        {
                            model_value.id = int.Parse(dr["id"].ToString());
                        }
                        if (dr["standard_id"] != null && dr["standard_id"].ToString() != "")
                        {
                            model_value.standard_id = int.Parse(dr["standard_id"].ToString());
                        }
                        if (dr["value"] != null && dr["value"].ToString() != "")
                        {
                            model_value.value = dr["value"].ToString();
                        }
                        if (dr["add_time"] != null && dr["add_time"].ToString() != "")
                        {
                            model_value.add_time = DateTime.Parse(dr["add_time"].ToString());
                        }

                        lst.Add(model_value);
                    }
                }

                if (lst.Count > 0)
                {
                    model.standard_values = lst;
                }
                else
                {
                    model.standard_values = null;
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
            strSql.Append("select * ");
            strSql.Append(" FROM td_standard ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strSelect, string strWhere)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select " + strSelect);
                strSql.Append(" FROM td_standard ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return DbHelperSQL.Query(strSql.ToString());
            }
            else
                return GetList(strWhere);
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
            strSql.Append(" * ");
            strSql.Append(" FROM td_standard ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strSelect, string strWhere, string filedOrder)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(strSelect);
                strSql.Append(" FROM td_standard ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
                return DbHelperSQL.Query(strSql.ToString());
            }
            else return GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM td_standard ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strSelect, string strWhere, string filedOrder, out int recordCount)
        {
            if (strSelect != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select " + strSelect + " FROM td_standard ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
                return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            else return GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method
    }

}
