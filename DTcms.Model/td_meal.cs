using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class meal
    {

        private int _id;
        /// <summary>
        /// id
        /// </summary>	
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;
        /// <summary>
        /// 套餐名称
        /// </summary>	
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        private int _category_id;
        /// <summary>
        /// 类别ID
        /// </summary>	
        public int category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
        }

        private string _img_url;
        /// <summary>
        /// 图片路径
        /// </summary>	
        public string img_url
        {
            get { return _img_url; }
            set { _img_url = value; }
        }

        private DateTime _add_time;
        /// <summary>
        /// add_time
        /// </summary>	
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }

        private string _index_url;
        /// <summary>
        /// 首页图片
        /// </summary>
        public string index_url
        {
            get { return _index_url; }
            set { _index_url = value; }
        }

        private int _sort_id;
        /// <summary>
        /// 排序
        /// </summary>
        public int sort_id
        {
            get { return _sort_id; }
            set { _sort_id = value; }
        }

        
    }
}