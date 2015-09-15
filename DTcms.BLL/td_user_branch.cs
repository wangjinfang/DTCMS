using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
    //td_user_branch
    public partial class user_branch
    {
        private readonly DAL.user_branch dal = new DAL.user_branch();
        public user_branch()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int user_id, int branch_id)
        {
            return dal.Exists(user_id, branch_id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_branch model)
        {
            return dal.Add(model);

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
        public bool Update(Model.user_branch model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int user_id, int branch_id)
        {
            return dal.Delete(user_id, branch_id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_branch GetModel(int user_id, int branch_id)
        {
            return dal.GetModel(user_id, branch_id);
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
    }

}