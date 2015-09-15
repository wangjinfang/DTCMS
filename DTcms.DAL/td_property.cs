using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //td_property
    public partial class property
    {
        public property() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from td_property");
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
        public int Add(Model.property model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into td_property(");
            strSql.Append("category_id,title,add_time");
            strSql.Append(") values (");
            strSql.Append("@category_id,@title,@add_time");
            strSql.Append(") ");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@category_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,100) ,            
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

            StringBuilder strSql1;

            if (model.property_values != null && model.property_values.Count > 0)
            {
                foreach (Model.property_value model_value in model.property_values)
                {
                    strSql1 = new StringBuilder();
                    strSql1.Append("insert into td_property_value(property_id,value,add_time) values");
                    strSql1.Append("(@property_id,@value,@add_time)");
                    SqlParameter[] parameters1 = {
                                                new SqlParameter("@property_id",SqlDbType.Int,4),
                                                new SqlParameter("@value",SqlDbType.NVarChar,100),
                                                new SqlParameter("@add_time",SqlDbType.DateTime)
                                                };
                    parameters1[0].Direction = ParameterDirection.InputOutput;
                    parameters1[1].Value = model_value.value;
                    parameters1[2].Value = model_value.add_time;

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
            strSql.Append("update td_property set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.property model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update td_property set ");

                        strSql.Append(" category_id = @category_id , ");
                        strSql.Append(" title = @title , ");
                        strSql.Append(" add_time = @add_time  ");
                        strSql.Append(" where id=@id ");

                        SqlParameter[] parameters = {
			                                        new SqlParameter("@id", SqlDbType.Decimal,9) ,            
                                                    new SqlParameter("@category_id", SqlDbType.Int,4) ,            
                                                    new SqlParameter("@title", SqlDbType.NVarChar,100) ,            
                                                    new SqlParameter("@add_time", SqlDbType.DateTime)             
              
                                                    };

                        parameters[0].Value = model.id;
                        parameters[1].Value = model.category_id;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.add_time;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除
                        string str_del_id = "";
                        foreach (Model.property_value model_value in model.property_values)
                        {
                            if (model_value.id > 0)
                            {
                                str_del_id += model_value.id + ",";
                            }
                        }
                        if (!string.IsNullOrEmpty(str_del_id))
                        {
                            StringBuilder strSql_del = new StringBuilder();
                            strSql_del.Append("delete from td_property_value where property_id=" + model.id + " and id not in(" + str_del_id + ")");
                        }

                        if (model.property_values != null && model.property_values.Count > 0)
                        {
                            StringBuilder strSql1;
                            foreach (Model.property_value model_value in model.property_values)
                            {
                                //更新
                                if (model_value.id > 0)
                                {
                                    strSql1 = new StringBuilder();
                                    strSql1.Append("update td_property_value set ");
                                    strSql1.Append("property_id=@property_id,");
                                    strSql1.Append("value=@value,");
                                    strSql1.Append("add_time=@add_time");
                                    strSql1.Append(" where id=" + model_value.id);
                                    SqlParameter[] parameters1 = { 
                                                                 new SqlParameter("@property_id",SqlDbType.Int,4),
                                                                 new SqlParameter("@value",SqlDbType.NVarChar,100),
                                                                 new SqlParameter("@add_time",SqlDbType.DateTime)
                                                                 };
                                    parameters1[0].Value = model.id;
                                    parameters1[1].Value = model_value.value;
                                    parameters1[2].Value = model_value.add_time;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString(), parameters1);
                                }
                                else
                                {
                                    //添加
                                    strSql1 = new StringBuilder();
                                    strSql1.Append("insert into td_property_value(property_id,value,add_time) values(@property_id,@value,@add_time)");
                                    SqlParameter[] parameters1 ={
                                                                new SqlParameter("@property_id",SqlDbType.Int,4),
                                                                 new SqlParameter("@value",SqlDbType.NVarChar,100),
                                                                 new SqlParameter("@add_time",SqlDbType.DateTime)
                                                             };
                                    parameters1[0].Value = model.id;
                                    parameters1[1].Value = model_value.value;
                                    parameters1[2].Value = model_value.add_time;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString(), parameters1);
                                }
                            }
                        }
                        else
                        {
                            StringBuilder strSql_del = new StringBuilder();
                            strSql_del.Append("delete from td_property_value where property_id=" + model.id);
                            DbHelperSQL.ExecuteSql(conn, trans, strSql_del.ToString());
                        }


                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_property ");
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
        public Model.property GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, category_id, title, add_time  ");
            strSql.Append("  from td_property ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.property model = new Model.property();
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

                List<Model.property_value> lst = new List<Model.property_value>();
                DataTable dt = new DAL.property_value().GetList("property_id=" + id).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.property_value model_value = new Model.property_value();
                        model_value.id = Convert.ToDecimal(dr["id"]);
                        model_value.property_id = Convert.ToInt32(dr["property_id"]);
                        model_value.value = dr["value"].ToString();
                        model_value.add_time = Convert.ToDateTime(dr["add_time"]);

                        lst.Add(model_value);
                    }

                }
                else
                {
                    lst = null;
                }
                model.property_values = lst;
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
            strSql.Append(" FROM td_property ");
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
                strSql.Append(" FROM td_property ");
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
            strSql.Append(" FROM td_property ");
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
                strSql.Append(" FROM td_property ");
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
            strSql.Append("select * FROM td_property ");
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
                strSql.Append("select " + strSelect + " FROM td_property ");
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
