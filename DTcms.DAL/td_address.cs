using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    //td_address
    public partial class address
    {
        public address() { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from td_address");
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
        public int Add(Model.address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into td_address(");
            strSql.Append("user_id,province,city,distract,content,add_time,is_default,zipcode,consignee,consignee_mobile,consignee_phone,company_address");
            strSql.Append(") values (");
            strSql.Append("@user_id,@province,@city,@distract,@content,@add_time,@is_default,@zipcode,@consignee,@consignee_mobile,@consignee_phone,@company_address");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@province", SqlDbType.Int,4) ,            
                        new SqlParameter("@city", SqlDbType.Int,4) ,            
                        new SqlParameter("@distract", SqlDbType.Int,4) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@is_default", SqlDbType.Int,4) ,            
                        new SqlParameter("@zipcode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@consignee", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@consignee_mobile", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@consignee_phone", SqlDbType.NVarChar,50)  ,           
                        new SqlParameter("@company_address",SqlDbType.NVarChar,100)
            };

            parameters[0].Value = model.user_id;
            parameters[1].Value = model.province;
            parameters[2].Value = model.city;
            parameters[3].Value = model.distract;
            parameters[4].Value = model.content;
            parameters[5].Value = model.add_time;
            parameters[6].Value = model.is_default;
            parameters[7].Value = model.zipcode;
            parameters[8].Value = model.consignee;
            parameters[9].Value = model.consignee_mobile;
            parameters[10].Value = model.consignee_phone;
            parameters[11].Value = model.company_address;

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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_address set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_address set ");

            strSql.Append(" user_id = @user_id , ");
            strSql.Append(" province = @province , ");
            strSql.Append(" city = @city , ");
            strSql.Append(" distract = @distract , ");
            strSql.Append(" content = @content , ");
            strSql.Append(" add_time = @add_time , ");
            strSql.Append(" is_default = @is_default , ");
            strSql.Append(" zipcode = @zipcode , ");
            strSql.Append(" consignee = @consignee , ");
            strSql.Append(" consignee_mobile = @consignee_mobile , ");
            strSql.Append(" consignee_phone = @consignee_phone , ");
            strSql.Append(" company_address=@company_address ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@user_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@province", SqlDbType.Int,4) ,            
                        new SqlParameter("@city", SqlDbType.Int,4) ,            
                        new SqlParameter("@distract", SqlDbType.Int,4) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@is_default", SqlDbType.Int,4) ,            
                        new SqlParameter("@zipcode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@consignee", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@consignee_mobile", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@consignee_phone", SqlDbType.NVarChar,50)  ,
                        new SqlParameter("@company_address",SqlDbType.NVarChar,100)
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.user_id;
            parameters[2].Value = model.province;
            parameters[3].Value = model.city;
            parameters[4].Value = model.distract;
            parameters[5].Value = model.content;
            parameters[6].Value = model.add_time;
            parameters[7].Value = model.is_default;
            parameters[8].Value = model.zipcode;
            parameters[9].Value = model.consignee;
            parameters[10].Value = model.consignee_mobile;
            parameters[11].Value = model.consignee_phone;
            parameters[12].Value = model.company_address;
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_address ");
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
        public Model.address GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, user_id, province, city, distract, content, add_time, is_default, zipcode, consignee, consignee_mobile, consignee_phone,company_address  ");
            strSql.Append("  from td_address ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.address model = new Model.address();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["province"].ToString() != "")
                {
                    model.province = int.Parse(ds.Tables[0].Rows[0]["province"].ToString());
                }
                if (ds.Tables[0].Rows[0]["city"].ToString() != "")
                {
                    model.city = int.Parse(ds.Tables[0].Rows[0]["city"].ToString());
                }
                if (ds.Tables[0].Rows[0]["distract"].ToString() != "")
                {
                    model.distract = int.Parse(ds.Tables[0].Rows[0]["distract"].ToString());
                }
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_default"].ToString() != "")
                {
                    model.is_default = int.Parse(ds.Tables[0].Rows[0]["is_default"].ToString());
                }
                model.zipcode = ds.Tables[0].Rows[0]["zipcode"].ToString();
                model.consignee = ds.Tables[0].Rows[0]["consignee"].ToString();
                model.consignee_mobile = ds.Tables[0].Rows[0]["consignee_mobile"].ToString();
                model.consignee_phone = ds.Tables[0].Rows[0]["consignee_phone"].ToString();
                model.company_address = ds.Tables[0].Rows[0]["company_address"].ToString();

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
            strSql.Append(" FROM td_address ");
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
                strSql.Append(" FROM td_address ");
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
            strSql.Append(" FROM td_address ");
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
                strSql.Append(" FROM td_address ");
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
            strSql.Append("select * FROM td_address ");
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
                strSql.Append("select " + strSelect + " FROM td_address ");
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
