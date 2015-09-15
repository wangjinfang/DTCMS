using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //td_meal_good
    public partial class meal_good
    {
        public meal_good() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int meal_id, int group_id, int good_id, decimal standard_price_id, int unit_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from td_meal_good");
            strSql.Append(" where ");
            strSql.Append(" meal_id = @meal_id and  ");
            strSql.Append(" group_id = @group_id and  ");
            strSql.Append(" good_id = @good_id and  ");
            strSql.Append(" standard_price_id = @standard_price_id and  ");
            strSql.Append(" unit_id = @unit_id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@meal_id", SqlDbType.Int,4),
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@good_id", SqlDbType.Int,4),
					new SqlParameter("@standard_price_id", SqlDbType.Decimal,9),
					new SqlParameter("@unit_id", SqlDbType.Int,4)			};
            parameters[0].Value = meal_id;
            parameters[1].Value = group_id;
            parameters[2].Value = good_id;
            parameters[3].Value = standard_price_id;
            parameters[4].Value = unit_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.meal_good model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into td_meal_good(");
            strSql.Append("meal_id,group_id,good_id,standard_price_id,unit_id,sell_price,standard_price,standard_group_price,add_time,action_price,quantity");
            strSql.Append(") values (");
            strSql.Append("@meal_id,@group_id,@good_id,@standard_price_id,@unit_id,@sell_price,@standard_price,@standard_group_price,@add_time,@action_price,@quantity");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@meal_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@group_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@standard_price_id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@unit_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@sell_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@standard_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@standard_group_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime)  ,           
                        new SqlParameter("@action_price",SqlDbType.Decimal,9),
                        new SqlParameter("@quantity",SqlDbType.Int,4)
              
            };

            parameters[0].Value = model.meal_id;
            parameters[1].Value = model.group_id;
            parameters[2].Value = model.good_id;
            parameters[3].Value = model.standard_price_id;
            parameters[4].Value = model.unit_id;
            parameters[5].Value = model.sell_price;
            parameters[6].Value = model.standard_price;
            parameters[7].Value = model.standard_group_price;
            parameters[8].Value = model.add_time;
            parameters[9].Value=model.action_price;
            parameters[10].Value = model.quantity;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_meal_good set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.meal_good model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_meal_good set ");

            strSql.Append(" meal_id = @meal_id , ");
            strSql.Append(" group_id = @group_id , ");
            strSql.Append(" good_id = @good_id , ");
            strSql.Append(" standard_price_id = @standard_price_id , ");
            strSql.Append(" unit_id = @unit_id , ");
            strSql.Append(" sell_price = @sell_price , ");
            strSql.Append(" standard_price = @standard_price , ");
            strSql.Append(" standard_group_price = @standard_group_price , ");
            strSql.Append(" add_time = @add_time,  ");
            strSql.Append(" action_price=@action_price, ");
            strSql.Append(" quantity=@quantity ");
            strSql.Append(" where meal_id=@meal_id and group_id=@group_id and good_id=@good_id and standard_price_id=@standard_price_id and unit_id=@unit_id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@meal_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@group_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@standard_price_id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@unit_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@sell_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@standard_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@standard_group_price", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,
                        new SqlParameter("@action_price",SqlDbType.Decimal,9),
                        new SqlParameter("@quantity",SqlDbType.Int,4)
            };

            parameters[0].Value = model.meal_id;
            parameters[1].Value = model.group_id;
            parameters[2].Value = model.good_id;
            parameters[3].Value = model.standard_price_id;
            parameters[4].Value = model.unit_id;
            parameters[5].Value = model.sell_price;
            parameters[6].Value = model.standard_price;
            parameters[7].Value = model.standard_group_price;
            parameters[8].Value = model.add_time;
            parameters[9].Value=model.action_price;
            parameters[10].Value = model.quantity;
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
        public bool Delete(int meal_id, int group_id, int good_id, decimal standard_price_id, int unit_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_meal_good ");
            strSql.Append(" where meal_id=@meal_id and group_id=@group_id and good_id=@good_id and standard_price_id=@standard_price_id and unit_id=@unit_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@meal_id", SqlDbType.Int,4),
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@good_id", SqlDbType.Int,4),
					new SqlParameter("@standard_price_id", SqlDbType.Decimal,9),
					new SqlParameter("@unit_id", SqlDbType.Int,4)			};
            parameters[0].Value = meal_id;
            parameters[1].Value = group_id;
            parameters[2].Value = good_id;
            parameters[3].Value = standard_price_id;
            parameters[4].Value = unit_id;


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
        public bool Delete(int meal_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_meal_good ");
            strSql.Append(" where meal_id=@meal_id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@meal_id", SqlDbType.Int,4)		};
            parameters[0].Value = meal_id; 


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
        public Model.meal_good GetModel(int meal_id, int group_id, int good_id, decimal standard_price_id, int unit_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select meal_id, group_id, good_id, standard_price_id, unit_id, sell_price, standard_price, standard_group_price, add_time ,action_price,quantity ");
            strSql.Append("  from td_meal_good ");
            strSql.Append(" where meal_id=@meal_id and group_id=@group_id and good_id=@good_id and standard_price_id=@standard_price_id and unit_id=@unit_id");
            SqlParameter[] parameters = {
					new SqlParameter("@meal_id", SqlDbType.Int,4),
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@good_id", SqlDbType.Int,4),
					new SqlParameter("@standard_price_id", SqlDbType.Decimal,9),
					new SqlParameter("@unit_id", SqlDbType.Int,4)			};
            parameters[0].Value = meal_id;
            parameters[1].Value = group_id;
            parameters[2].Value = good_id;
            parameters[3].Value = standard_price_id;
            parameters[4].Value = unit_id;


            Model.meal_good model = new Model.meal_good();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["meal_id"].ToString() != "")
                {
                    model.meal_id = int.Parse(ds.Tables[0].Rows[0]["meal_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["group_id"].ToString() != "")
                {
                    model.group_id = int.Parse(ds.Tables[0].Rows[0]["group_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["good_id"].ToString() != "")
                {
                    model.good_id = int.Parse(ds.Tables[0].Rows[0]["good_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["standard_price_id"].ToString() != "")
                {
                    model.standard_price_id = decimal.Parse(ds.Tables[0].Rows[0]["standard_price_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["unit_id"].ToString() != "")
                {
                    model.unit_id = int.Parse(ds.Tables[0].Rows[0]["unit_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sell_price"].ToString() != "")
                {
                    model.sell_price = decimal.Parse(ds.Tables[0].Rows[0]["sell_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["standard_price"].ToString() != "")
                {
                    model.standard_price = decimal.Parse(ds.Tables[0].Rows[0]["standard_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["standard_group_price"].ToString() != "")
                {
                    model.standard_group_price = decimal.Parse(ds.Tables[0].Rows[0]["standard_group_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["action_price"].ToString() != "")
                {
                    model.action_price = decimal.Parse(ds.Tables[0].Rows[0]["action_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
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
            strSql.Append(" FROM td_meal_good ");
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
                strSql.Append(" FROM td_meal_good ");
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
            strSql.Append(" FROM td_meal_good ");
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
                strSql.Append(" FROM td_meal_good ");
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
            strSql.Append("select * FROM td_meal_good ");
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
                strSql.Append("select " + strSelect + " FROM td_meal_good ");
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


        /// <summary>
        /// 修改同个商品的套餐价格
        /// </summary>
        /// <param name="goodID"></param>
        /// <param name="sell_price"></param>
        /// <param name="standard_price"></param>
        /// <param name="action_price"></param>
        /// <returns></returns>
        public bool UpdateMealGoodPrice(int goodID, decimal sell_price, decimal standard_price,decimal standard_group_price, decimal action_price)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_meal_good set sell_price=" + sell_price + ",standard_price=" + standard_price + ",standard_group_price=" + standard_group_price + ",action_price=" + action_price + " where good_id=" + goodID);
            if (DbHelperSQL.ExecuteSql(strSql.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
