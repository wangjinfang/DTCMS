using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//td_unit
		public partial class unit
	{
   		public unit(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(decimal id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from td_unit");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Decimal)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Model.unit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into td_unit(");			
            strSql.Append("good_id,title,quantity,content,add_time,rate");
			strSql.Append(") values (");
            strSql.Append("@good_id,@title,@quantity,@content,@add_time,@rate");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@rate", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.good_id;                        
            parameters[1].Value = model.title;                        
            parameters[2].Value = model.quantity;                        
            parameters[3].Value = model.content;                        
            parameters[4].Value = model.add_time;                        
            parameters[5].Value = model.rate;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
            strSql.Append("update td_unit set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.unit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update td_unit set ");
			                                                
            strSql.Append(" good_id = @good_id , ");                                    
            strSql.Append(" title = @title , ");                                    
            strSql.Append(" quantity = @quantity , ");                                    
            strSql.Append(" content = @content , ");                                    
            strSql.Append(" add_time = @add_time , ");                                    
            strSql.Append(" rate = @rate  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@title", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@content", SqlDbType.NVarChar,500) ,            
                        new SqlParameter("@add_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@rate", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.good_id;                        
            parameters[2].Value = model.title;                        
            parameters[3].Value = model.quantity;                        
            parameters[4].Value = model.content;                        
            parameters[5].Value = model.add_time;                        
            parameters[6].Value = model.rate;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from td_unit ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Decimal)
			};
			parameters[0].Value = id;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
            /// 根据商品ID删除单位
            /// </summary>
            /// <param name="good_id"></param>
            /// <returns></returns>
        public bool Delete(int good_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_unit where good_id=" + good_id);
            if (DbHelperSQL.ExecuteSql(strSql.ToString()) > 0)
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
		public Model.unit GetModel(decimal id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, good_id, title, quantity, content, add_time, rate  ");			
			strSql.Append("  from td_unit ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Decimal)
			};
			parameters[0].Value = id;

			
			Model.unit model=new Model.unit();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=decimal.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["good_id"].ToString()!="")
				{
					model.good_id=int.Parse(ds.Tables[0].Rows[0]["good_id"].ToString());
				}
																																				model.title= ds.Tables[0].Rows[0]["title"].ToString();
																												if(ds.Tables[0].Rows[0]["quantity"].ToString()!="")
				{
					model.quantity=int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
				}
																																				model.content= ds.Tables[0].Rows[0]["content"].ToString();
																												if(ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["rate"].ToString()!="")
				{
					model.rate=decimal.Parse(ds.Tables[0].Rows[0]["rate"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM td_unit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strSelect,string strWhere)
		{
		if(strSelect!=""){
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select "+strSelect);
			strSql.Append(" FROM td_unit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
			}
			else
			return GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM td_unit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strSelect,string strWhere,string filedOrder)
		{
		if(strSelect!="")
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(strSelect);
			strSql.Append(" FROM td_unit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
			}
			else return GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得查询分页数据
		/// </summary>
		public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM td_unit ");
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
		public DataSet GetList(int pageSize, int pageIndex,string strSelect, string strWhere, string filedOrder, out int recordCount)
		{
		if(strSelect!="")
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+strSelect+" FROM td_unit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            else return GetList( pageSize,  pageIndex,  strWhere, filedOrder,out recordCount);
		}
        #endregion  Method		
	}

}
