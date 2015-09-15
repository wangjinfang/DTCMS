using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
    //td_meal_good
    public partial class meal_good
    {
        private readonly DAL.meal_good dal = new DAL.meal_good();
        public meal_good()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int meal_id, int group_id, int good_id, decimal standard_price_id, int unit_id)
        {
            return dal.Exists(meal_id, group_id, good_id, standard_price_id, unit_id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.meal_good model)
        {
            dal.Add(model);

        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.meal_good model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int meal_id, int group_id, int good_id, decimal standard_price_id, int unit_id)
        {
            return dal.Delete(meal_id, group_id, good_id, standard_price_id, unit_id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int meal_id)
        {
            return dal.Delete(meal_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.meal_good GetModel(int meal_id, int group_id, int good_id, decimal standard_price_id, int unit_id)
        {
            return dal.GetModel(meal_id, group_id, good_id, standard_price_id, unit_id);
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
        public DataSet GetList(string strSelect, string strWhere)
        {
            return dal.GetList(strSelect, strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strSelect, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strSelect, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strSelect, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strSelect, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method

        /// <summary>
        /// 修改同个商品的套餐价格
        /// </summary>
        /// <param name="goodID"></param>
        /// <param name="sell_price"></param>
        /// <param name="standard_price"></param>
        /// <param name="standard_group_price"></param>
        /// <param name="action_price"></param>
        /// <returns></returns>
        public bool UpdateMealGoodPrice(int goodID, decimal sell_price, decimal standard_price, decimal standard_group_price, decimal action_price)
        {
            return dal.UpdateMealGoodPrice(goodID, sell_price, standard_price, standard_group_price, action_price);
        }
    }

}