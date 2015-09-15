using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //td_user_branch
    public partial class user_branch
    {
        public user_branch() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int user_id, int branch_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from td_user_branch");
            strSql.Append(" where ");
            strSql.Append(" user_id = @user_id and  ");
            strSql.Append(" branch_id = @branch_id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@branch_id", SqlDbType.Int,4)			};
            parameters[0].Value = user_id;
            parameters[1].Value = branch_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_branch model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into td_user_branch(");
            strSql.Append("user_id,branch_id,add_time");
            strSql.Append(") values (");
            strSql.Append("@user_id,@branch_id,@add_time");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@branch_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.user_id;
            parameters[1].Value = model.branch_id;
            parameters[2].Value = model.add_time;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_user_branch set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.user_branch model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_user_branch set ");

            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" branch_id = @branch_id , ");
            strSql.Append(" add_time = @add_time  ");
            strSql.Append(" where user_id=@user_id and branch_id=@branch_id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@branch_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.user_id;
            parameters[1].Value = model.branch_id;
            parameters[2].Value = model.add_time;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int user_id, int branch_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_user_branch ");
            strSql.Append(" where user_id=@user_id and branch_id=@branch_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@branch_id", SqlDbType.Int,4)			};
            parameters[0].Value = user_id;
            parameters[1].Value = branch_id;


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
        public Model.user_branch GetModel(int user_id, int branch_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select user_id, branch_id, add_time  ");
            strSql.Append("  from td_user_branch ");
            strSql.Append(" where user_id=@user_id and branch_id=@branch_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@branch_id", SqlDbType.Int,4)			};
            parameters[0].Value = user_id;
            parameters[1].Value = branch_id;


            Model.user_branch model = new Model.user_branch();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["branch_id"].ToString() != "")
                {
                    model.branch_id = int.Parse(ds.Tables[0].Rows[0]["branch_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
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
            strSql.Append(" FROM td_user_branch ");
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
                strSql.Append(" FROM td_user_branch ");
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
            strSql.Append(" FROM td_user_branch ");
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
                strSql.Append(" FROM td_user_branch ");
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
            strSql.Append("select * FROM td_user_branch ");
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
                strSql.Append("select " + strSelect + " FROM td_user_branch ");
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
