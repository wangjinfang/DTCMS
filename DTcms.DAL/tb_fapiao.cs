using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//tb_fapiao
		public partial class fapiao
	{
   		public fapiao(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_fapiao");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.fapiao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_fapiao(");			
            strSql.Append("type,companyname,project,aomunt,danweiname,shibiehao,address,tel,bankname,bankaccount,userid");
			strSql.Append(") values (");
            strSql.Append("@type,@companyname,@project,@aomunt,@danweiname,@shibiehao,@address,@tel,@bankname,@bankaccount,@userid");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@type", SqlDbType.Int,4) ,            
                        new SqlParameter("@companyname", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@project", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@aomunt", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@danweiname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shibiehao", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@bankname", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@bankaccount", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.type;                        
            parameters[1].Value = model.companyname;                        
            parameters[2].Value = model.project;                        
            parameters[3].Value = model.aomunt;                        
            parameters[4].Value = model.danweiname;                        
            parameters[5].Value = model.shibiehao;                        
            parameters[6].Value = model.address;                        
            parameters[7].Value = model.tel;                        
            parameters[8].Value = model.bankname;                        
            parameters[9].Value = model.bankaccount;                        
            parameters[10].Value = model.userid;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
            strSql.Append("update tb_fapiao set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.fapiao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_fapiao set ");
			                                                
            strSql.Append(" type = @type , ");                                    
            strSql.Append(" companyname = @companyname , ");                                    
            strSql.Append(" project = @project , ");                                    
            strSql.Append(" aomunt = @aomunt , ");                                    
            strSql.Append(" danweiname = @danweiname , ");                                    
            strSql.Append(" shibiehao = @shibiehao , ");                                    
            strSql.Append(" address = @address , ");                                    
            strSql.Append(" tel = @tel , ");                                    
            strSql.Append(" bankname = @bankname , ");                                    
            strSql.Append(" bankaccount = @bankaccount , ");                                    
            strSql.Append(" userid = @userid  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@type", SqlDbType.Int,4) ,            
                        new SqlParameter("@companyname", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@project", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@aomunt", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@danweiname", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@shibiehao", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@address", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@tel", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@bankname", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@bankaccount", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@userid", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.type;                        
            parameters[2].Value = model.companyname;                        
            parameters[3].Value = model.project;                        
            parameters[4].Value = model.aomunt;                        
            parameters[5].Value = model.danweiname;                        
            parameters[6].Value = model.shibiehao;                        
            parameters[7].Value = model.address;                        
            parameters[8].Value = model.tel;                        
            parameters[9].Value = model.bankname;                        
            parameters[10].Value = model.bankaccount;                        
            parameters[11].Value = model.userid;                        
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_fapiao ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
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
		/// 得到一个对象实体
		/// </summary>
		public Model.fapiao GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, type, companyname, project, aomunt, danweiname, shibiehao, address, tel, bankname, bankaccount, userid  ");			
			strSql.Append("  from tb_fapiao ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			Model.fapiao model=new Model.fapiao();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
				}
																																				model.companyname= ds.Tables[0].Rows[0]["companyname"].ToString();
																																model.project= ds.Tables[0].Rows[0]["project"].ToString();
																												if(ds.Tables[0].Rows[0]["aomunt"].ToString()!="")
				{
					model.aomunt=decimal.Parse(ds.Tables[0].Rows[0]["aomunt"].ToString());
				}
																																				model.danweiname= ds.Tables[0].Rows[0]["danweiname"].ToString();
																																model.shibiehao= ds.Tables[0].Rows[0]["shibiehao"].ToString();
																																model.address= ds.Tables[0].Rows[0]["address"].ToString();
																																model.tel= ds.Tables[0].Rows[0]["tel"].ToString();
																																model.bankname= ds.Tables[0].Rows[0]["bankname"].ToString();
																																model.bankaccount= ds.Tables[0].Rows[0]["bankaccount"].ToString();
																												if(ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
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
			strSql.Append(" FROM tb_fapiao ");
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
			strSql.Append(" FROM tb_fapiao ");
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
			strSql.Append(" FROM tb_fapiao ");
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
			strSql.Append(" FROM tb_fapiao ");
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
            strSql.Append("select * FROM tb_fapiao ");
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
            strSql.Append("select "+strSelect+" FROM tb_fapiao ");
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
