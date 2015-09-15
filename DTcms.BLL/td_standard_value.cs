using System;
using System.Data;
using System.Collections.Generic;
namespace DTcms.BLL
{
    //td_standard_value
    public partial class standard_value
    {
        private readonly DAL.standard_value dal = new DAL.standard_value();
        public standard_value()
        { }
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
        public int Add(Model.standard_value model)
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
        public bool Update(Model.standard_value model)
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
        public Model.standard_value GetModel(int id)
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

        public string get_standrad(string strandrad)
        {
            string[] strandrads = strandrad.Split(',');
            string str_standard = "";
            BLL.standard_value blls = new standard_value();
            BLL.standard bll1 = new standard();

            for (int i = 0; i < strandrads.Length; i++)
            {
                if (!string.IsNullOrEmpty(strandrads[i]))
                {
                    Model.standard_value model = blls.GetModel(Convert.ToInt32(strandrads[i].Split(':')[1]));



                    str_standard += strandrads[i].Split(':')[0] + ":" + model.value + ",";


                }
                else
                {
                    return "";
                }
            }
            return str_standard;
        }
        #endregion  Method


    }





}