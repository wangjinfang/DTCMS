using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //td_standard_group_price
    public partial class standard_group_price
    {
        public standard_group_price() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from td_standard_group_price");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Decimal)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(Model.standard_group_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into td_standard_group_price(");
            strSql.Append("good_id,group_id,standard_price_id,group_price,add_time");
            strSql.Append(") values (");
            strSql.Append("@good_id,@group_id,@standard_price_id,@group_price,@add_time");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@group_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@standard_price_id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@group_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.good_id;
            parameters[1].Value = model.group_id;
            parameters[2].Value = model.standard_price_id;
            parameters[3].Value = model.group_price;
            parameters[4].Value = model.add_time;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToDecimal(obj);

            }

        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_standard_group_price set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.standard_group_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_standard_group_price set ");

            strSql.Append(" good_id = @good_id , ");
            strSql.Append(" group_id = @group_id , ");
            strSql.Append(" standard_price_id = @standard_price_id , ");
            strSql.Append(" group_price = @group_price , ");
            strSql.Append(" add_time = @add_time  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@group_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@standard_price_id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@group_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.good_id;
            parameters[2].Value = model.group_id;
            parameters[3].Value = model.standard_price_id;
            parameters[4].Value = model.group_price;
            parameters[5].Value = model.add_time;
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
        public bool Delete(decimal id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_standard_group_price ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Decimal)
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int good_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_standard_group_price ");
            strSql.Append(" where good_id=@good_id");
            SqlParameter[] parameters = {
					new SqlParameter("@good_id", SqlDbType.Int,4)
			};
            parameters[0].Value = good_id;


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
        public Model.standard_group_price GetModel(decimal id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, good_id, group_id, standard_price_id, group_price, add_time  ");
            strSql.Append("  from td_standard_group_price ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Decimal)
			};
            parameters[0].Value = id;


            Model.standard_group_price model = new Model.standard_group_price();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["good_id"].ToString() != "")
                {
                    model.good_id = int.Parse(ds.Tables[0].Rows[0]["good_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["group_id"].ToString() != "")
                {
                    model.group_id = int.Parse(ds.Tables[0].Rows[0]["group_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["standard_price_id"].ToString() != "")
                {
                    model.standard_price_id = decimal.Parse(ds.Tables[0].Rows[0]["standard_price_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["group_price"].ToString() != "")
                {
                    model.group_price = decimal.Parse(ds.Tables[0].Rows[0]["group_price"].ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public Model.standard_group_price GetModel(int good_id,int group_id,decimal standard_price_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, good_id, group_id, standard_price_id, group_price, add_time  ");
            strSql.Append("  from td_standard_group_price ");
            strSql.Append(" where good_id=@good_id and group_id=@group_id and standard_price_id=@standard_price_id");
            SqlParameter[] parameters = {
					new SqlParameter("@good_id", SqlDbType.Int,4),
                    new SqlParameter("@group_id", SqlDbType.Int,4),
                    new SqlParameter("@standard_price_id", SqlDbType.Decimal,9)
			};
            parameters[0].Value = good_id;
            parameters[1].Value = group_id;
            parameters[2].Value = standard_price_id;


            Model.standard_group_price model = new Model.standard_group_price();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["good_id"].ToString() != "")
                {
                    model.good_id = int.Parse(ds.Tables[0].Rows[0]["good_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["group_id"].ToString() != "")
                {
                    model.group_id = int.Parse(ds.Tables[0].Rows[0]["group_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["standard_price_id"].ToString() != "")
                {
                    model.standard_price_id = decimal.Parse(ds.Tables[0].Rows[0]["standard_price_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["group_price"].ToString() != "")
                {
                    model.group_price = decimal.Parse(ds.Tables[0].Rows[0]["group_price"].ToString());
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
            strSql.Append(" FROM td_standard_group_price ");
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
                strSql.Append(" FROM td_standard_group_price ");
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
            strSql.Append(" FROM td_standard_group_price ");
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
                strSql.Append(" FROM td_standard_group_price ");
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
            strSql.Append("select * FROM td_standard_group_price ");
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
                strSql.Append("select " + strSelect + " FROM td_standard_group_price ");
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
