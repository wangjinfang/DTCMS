using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //td_standard_price
    public partial class standard_price
    {
        public standard_price() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from td_standard_price");
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
        public decimal Add(Model.standard_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into td_standard_price(");
            strSql.Append("good_id,standard_ids,standards,standard_value_ids,standard_values,market_price,sell_price,stock_quantity,add_time,action_price,user_price,good_no");
            strSql.Append(") values (");
            strSql.Append("@good_id,@standard_ids,@standards,@standard_value_ids,@standard_values,@market_price,@sell_price,@stock_quantity,@add_time,@action_price,@user_price,@good_no");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@standard_ids", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@standards", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@standard_value_ids", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@standard_values", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("@market_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@sell_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@stock_quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@action_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@user_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@good_no",SqlDbType.NVarChar,100)
            };

            parameters[0].Value = model.good_id;
            parameters[1].Value = model.standard_ids;
            parameters[2].Value = model.standards;
            parameters[3].Value = model.standard_value_ids;
            parameters[4].Value = model.standard_values;
            parameters[5].Value = model.market_price;
            parameters[6].Value = model.sell_price;
            parameters[7].Value = model.stock_quantity;
            parameters[8].Value = model.add_time;
            parameters[9].Value = model.action_price;
            parameters[10].Value = model.user_price;
            parameters[11].Value = model.good_no;

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
            strSql.Append("update td_standard_price set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.standard_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_standard_price set ");

            strSql.Append(" good_id = @good_id , ");
            strSql.Append(" standard_ids = @standard_ids , ");
            strSql.Append(" standards = @standards , ");
            strSql.Append(" standard_value_ids = @standard_value_ids , ");
            strSql.Append(" standard_values = @standard_values , ");
            strSql.Append(" market_price = @market_price , ");
            strSql.Append(" sell_price = @sell_price , ");
            strSql.Append(" stock_quantity = @stock_quantity , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" action_price = @action_price , ");
            strSql.Append(" user_price = @user_price , ");
            strSql.Append(" good_no=@good_no ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@standard_ids", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@standards", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@standard_value_ids", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@standard_values", SqlDbType.NVarChar,300) ,            
                        new SqlParameter("@market_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@sell_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@stock_quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@action_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@user_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@good_no",SqlDbType.NVarChar,100)
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.good_id;
            parameters[2].Value = model.standard_ids;
            parameters[3].Value = model.standards;
            parameters[4].Value = model.standard_value_ids;
            parameters[5].Value = model.standard_values;
            parameters[6].Value = model.market_price;
            parameters[7].Value = model.sell_price;
            parameters[8].Value = model.stock_quantity;
            parameters[9].Value = model.add_time;
            parameters[10].Value = model.action_price;
            parameters[11].Value = model.user_price;
            parameters[12].Value = model.good_no;
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
            strSql.Append("delete from td_standard_price ");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.standard_price GetModel(decimal id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, good_id, standard_ids, standards, standard_value_ids, standard_values, market_price, sell_price, stock_quantity, add_time, action_price, user_price ,good_no ");
            strSql.Append("  from td_standard_price ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Decimal)
			};
            parameters[0].Value = id;


            Model.standard_price model = new Model.standard_price();
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
                model.standard_ids = ds.Tables[0].Rows[0]["standard_ids"].ToString();
                model.standards = ds.Tables[0].Rows[0]["standards"].ToString();
                model.standard_value_ids = ds.Tables[0].Rows[0]["standard_value_ids"].ToString();
                model.standard_values = ds.Tables[0].Rows[0]["standard_values"].ToString();
                if (ds.Tables[0].Rows[0]["market_price"].ToString() != "")
                {
                    model.market_price = decimal.Parse(ds.Tables[0].Rows[0]["market_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sell_price"].ToString() != "")
                {
                    model.sell_price = decimal.Parse(ds.Tables[0].Rows[0]["sell_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stock_quantity"].ToString() != "")
                {
                    model.stock_quantity = int.Parse(ds.Tables[0].Rows[0]["stock_quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["action_price"].ToString() != "")
                {
                    model.action_price = decimal.Parse(ds.Tables[0].Rows[0]["action_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_price"].ToString() != "")
                {
                    model.user_price = decimal.Parse(ds.Tables[0].Rows[0]["user_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["good_no"].ToString() != "")
                {
                    model.good_no = "";
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
            strSql.Append(" FROM td_standard_price ");
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
                strSql.Append(" FROM td_standard_price ");
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
            strSql.Append(" FROM td_standard_price ");
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
                strSql.Append(" FROM td_standard_price ");
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
            strSql.Append("select * FROM td_standard_price ");
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
                strSql.Append("select " + strSelect + " FROM td_standard_price ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
                return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            else return GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public DataSet get_dcer_list(string strwhere, string strorder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from " + strwhere + " order by " + strorder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public bool Delete(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_standard_price where " + strwhere);
            if (DbHelperSQL.ExecuteSql(strSql.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  Method
    }

}
