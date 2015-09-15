using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
	 	//td_property_good
	public partial class property_good
    {
    private readonly DAL.property_good dal=new DAL.property_good();
    public property_good()
	{}
    #region  Method
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int good_id, int property_value_id)
    {
            return dal.Exists(good_id,property_value_id);
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void Add(Model.property_good model)
	{
                dal.Add(model);
        			
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
    public bool Update(Model.property_good model)
    {
        return dal.Update(model);
    }
    /// <summary>
	/// 删除一条数据
	/// </summary>
	public bool Delete(int good_id,decimal property_value_id)
	{
			return dal.Delete(good_id,property_value_id);	
	}

        /// <summary>
        /// 删除一条数据
        /// </summary>
    public bool Delete(int good_id)
    {
        return dal.Delete(good_id);
    }
	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public Model.property_good GetModel(int good_id,decimal property_value_id)
	{
    	return dal.GetModel(good_id,property_value_id);
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