using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.Web.Plugin.LineService.BLL
{
    /// <summary>
    /// online_service_group
    /// </summary>
    public partial class online_service_group
    {
        private readonly DTcms.Model.siteconfig siteConfig = new DTcms.BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.online_service_group dal;
        public online_service_group()
        {
            dal = new DAL.online_service_group(siteConfig.sysdatabaseprefix);
        }

        #region  Method

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// �����������
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.online_service_group model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.online_service_group model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.online_service_group GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion  Method
    }
}