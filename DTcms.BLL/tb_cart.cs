using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
	 	//tb_cart
	public partial class cart
    {
    private readonly DAL.cart dal=new DAL.cart();
    public cart()
	{}
    #region  Method
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int id)
    {
            return dal.Exists(id);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add(Model.cart model)
	{
                return dal.Add(model);
        			
    }
    /// <summary>
    /// 修改一列数据
    /// </summary>
    public void UpdateField(int id, string strValue)
    {
    	dal.UpdateField(id,strValue);
    }
    /// <summary>
    /// 更新一条数据
    /// </summary>
    public bool Update(Model.cart model)
    {
        return dal.Update(model);
    }
    /// <summary>
	/// 删除一条数据
	/// </summary>
	public bool Delete(int ID)
	{
			return dal.Delete(ID);	
	}
    /// <summary>
    /// 删除会员指定的购物车
    /// </summary>
    public void Delete(int ID,string productname)
    {
         dal.dele_Cart(ID, productname);
    }
    /// <summary>
    /// 条件删除数据
    /// </summary>
    public bool Delete_user(int ID)
    {
        return dal.Delete_user(ID);
    }
	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public Model.cart GetModel(int ID)
	{
    	return dal.GetModel(ID);
	}
	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList(string strWhere)
	{
		return dal.GetList(strWhere);
	}
	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList(string strSelect,string strWhere)
	{
		return dal.GetList(strSelect,strWhere);
	}
	/// <summary>
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top,string strWhere,string filedOrder)
	{
		return dal.GetList(Top,strWhere,filedOrder);
	}
	/// <summary>
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top,string strSelect,string strWhere,string filedOrder)
	{
		return dal.GetList(Top,strSelect,strWhere,filedOrder);
	}
	/// <summary>
	/// 获得查询分页数据
	/// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		return dal.GetList(pageSize,pageIndex,strWhere,filedOrder,out recordCount);
	}
	/// <summary>
	/// 获得查询分页数据
	/// </summary>
    public DataSet GetList(int pageSize, int pageIndex,string strSelect, string strWhere, string filedOrder, out int recordCount)
	{
		return dal.GetList(pageSize,pageIndex,strSelect,strWhere,filedOrder,out recordCount);
	}
    #endregion  Method
    }
    
}