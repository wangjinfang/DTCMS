using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//td_district
		public partial class district
	{
   		public district(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(long DistrictID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from td_district");
			strSql.Append(" where ");
			                                       strSql.Append(" DistrictID = @DistrictID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt,8)			};
			parameters[0].Value = DistrictID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Model.district model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into td_district(");			
            strSql.Append("DistrictID,DistrictName,CityID,DateCreated,DateUpdated");
			strSql.Append(") values (");
            strSql.Append("@DistrictID,@DistrictName,@CityID,@DateCreated,@DateUpdated");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@DistrictID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@DistrictName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CityID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@DateCreated", SqlDbType.DateTime) ,            
                        new SqlParameter("@DateUpdated", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.DistrictID;                        
            parameters[1].Value = model.DistrictName;                        
            parameters[2].Value = model.CityID;                        
            parameters[3].Value = model.DateCreated;                        
            parameters[4].Value = model.DateUpdated;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_district set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.district model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update td_district set ");
			                        
            strSql.Append(" DistrictID = @DistrictID , ");                                    
            strSql.Append(" DistrictName = @DistrictName , ");                                    
            strSql.Append(" CityID = @CityID , ");                                    
            strSql.Append(" DateCreated = @DateCreated , ");                                    
            strSql.Append(" DateUpdated = @DateUpdated  ");            			
			strSql.Append(" where DistrictID=@DistrictID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@DistrictID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@DistrictName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CityID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@DateCreated", SqlDbType.DateTime) ,            
                        new SqlParameter("@DateUpdated", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.DistrictID;                        
            parameters[1].Value = model.DistrictName;                        
            parameters[2].Value = model.CityID;                        
            parameters[3].Value = model.DateCreated;                        
            parameters[4].Value = model.DateUpdated;                        
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
		public bool Delete(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from td_district ");
			strSql.Append(" where DistrictID=@DistrictID ");
						SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt,8)			};
			parameters[0].Value = DistrictID;


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
		public Model.district GetModel(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DistrictID, DistrictName, CityID, DateCreated, DateUpdated  ");			
			strSql.Append("  from td_district ");
			strSql.Append(" where DistrictID=@DistrictID ");
						SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.BigInt,8)			};
			parameters[0].Value = DistrictID;

			
			Model.district model=new Model.district();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["DistrictID"].ToString()!="")
				{
					model.DistrictID=long.Parse(ds.Tables[0].Rows[0]["DistrictID"].ToString());
				}
																																				model.DistrictName= ds.Tables[0].Rows[0]["DistrictName"].ToString();
																												if(ds.Tables[0].Rows[0]["CityID"].ToString()!="")
				{
					model.CityID=long.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
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
			strSql.Append(" FROM td_district ");
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
			strSql.Append(" FROM td_district ");
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
			strSql.Append(" FROM td_district ");
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
			strSql.Append(" FROM td_district ");
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
            strSql.Append("select * FROM td_district ");
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
            strSql.Append("select "+strSelect+" FROM td_district ");
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
