using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
	 	//td_meal
	public partial class meal
    {
    private readonly DAL.meal dal=new DAL.meal();
    public meal()
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
    public int Add(Model.meal model)
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
    public bool Update(Model.meal model)
    {
        return dal.Update(model);
    }
    /// <summary>
	/// 删除一条数据
	/// </summary>
	public bool Delete(int id)
	{
			return dal.Delete(id);	
	}
	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public Model.meal GetModel(int id)
	{
    	return dal.GetModel(id);
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

        /// <summary>
        /// 根据商品ID和类别别名获取套餐列表
        /// </summary>
        /// <param name="good_id"></param>
        /// <param name="category_call_index"></param>
        /// <returns></returns>
    public DataSet GetMealByGood(int good_id, string category_call_index)
    {
        return dal.GetMealByGood(good_id, category_call_index);
    }
    #endregion  Method
    }
    
}