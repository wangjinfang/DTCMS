using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//td_city
		public partial class city
	{
   		public city(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(long CityID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from td_city");
			strSql.Append(" where ");
			                                       strSql.Append(" CityID = @CityID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.BigInt,8)			};
			parameters[0].Value = CityID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Model.city model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into td_city(");			
            strSql.Append("CityID,CityName,ZipCode,ProvinceID,DateCreated,DateUpdated");
			strSql.Append(") values (");
            strSql.Append("@CityID,@CityName,@ZipCode,@ProvinceID,@DateCreated,@DateUpdated");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@CityID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@CityName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ZipCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ProvinceID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@DateCreated", SqlDbType.DateTime) ,            
                        new SqlParameter("@DateUpdated", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.CityID;                        
            parameters[1].Value = model.CityName;                        
            parameters[2].Value = model.ZipCode;                        
            parameters[3].Value = model.ProvinceID;                        
            parameters[4].Value = model.DateCreated;                        
            parameters[5].Value = model.DateUpdated;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_city set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.city model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update td_city set ");
			                        
            strSql.Append(" CityID = @CityID , ");                                    
            strSql.Append(" CityName = @CityName , ");                                    
            strSql.Append(" ZipCode = @ZipCode , ");                                    
            strSql.Append(" ProvinceID = @ProvinceID , ");                                    
            strSql.Append(" DateCreated = @DateCreated , ");                                    
            strSql.Append(" DateUpdated = @DateUpdated  ");            			
			strSql.Append(" where CityID=@CityID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@CityID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@CityName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ZipCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ProvinceID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@DateCreated", SqlDbType.DateTime) ,            
                        new SqlParameter("@DateUpdated", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.CityID;                        
            parameters[1].Value = model.CityName;                        
            parameters[2].Value = model.ZipCode;                        
            parameters[3].Value = model.ProvinceID;                        
            parameters[4].Value = model.DateCreated;                        
            parameters[5].Value = model.DateUpdated;                        
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
		public bool Delete(long CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from td_city ");
			strSql.Append(" where CityID=@CityID ");
						SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.BigInt,8)			};
			parameters[0].Value = CityID;


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
		/// 得到一个对象实体
		/// </summary>
		public Model.city GetModel(long CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CityID, CityName, ZipCode, ProvinceID, DateCreated, DateUpdated  ");			
			strSql.Append("  from td_city ");
			strSql.Append(" where CityID=@CityID ");
						SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.BigInt,8)			};
			parameters[0].Value = CityID;

			
			Model.city model=new Model.city();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["CityID"].ToString()!="")
				{
					model.CityID=long.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
				}
																																				model.CityName= ds.Tables[0].Rows[0]["CityName"].ToString();
																																model.ZipCode= ds.Tables[0].Rows[0]["ZipCode"].ToString();
																												if(ds.Tables[0].Rows[0]["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=long.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["DateCreated"].ToString()!="")
				{
					model.DateCreated=DateTime.Parse(ds.Tables[0].Rows[0]["DateCreated"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["DateUpdated"].ToString()!="")
				{
					model.DateUpdated=DateTime.Parse(ds.Tables[0].Rows[0]["DateUpdated"].ToString());
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
			strSql.Append(" FROM td_city ");
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
			strSql.Append(" FROM td_city ");
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
			strSql.Append(" FROM td_city ");
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
			strSql.Append(" FROM td_city ");
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
            strSql.Append("select * FROM td_city ");
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
            strSql.Append("select "+strSelect+" FROM td_city ");
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
