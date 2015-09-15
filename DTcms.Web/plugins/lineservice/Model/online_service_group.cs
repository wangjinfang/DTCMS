using System;
namespace DTcms.Web.Plugin.LineService.Model
{
    /// <summary>
    /// online_service_group:ʵ����
    /// </summary>
    [Serializable]
    public partial class online_service_group
    {
        public online_service_group()
        { }
        #region Model
        private int _id;
        private string _title;
        private int _default_view = 0;
        private int _sort_id = 99;
        private int _is_lock = 0;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// Ĭ��չ��
        /// </summary>
        public int default_view
        {
            set { _default_view = value; }
            get { return _default_view; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        #endregion Model

    }
}