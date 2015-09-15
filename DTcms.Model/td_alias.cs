using System;
using System.Collections.Generic;
namespace DTcms.Model
{
    [Serializable]
    public partial class alias
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

        private int _category_id;
        /// <summary>
        /// 类别ID
        /// </summary>	
        public int category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
        }

        private string _title;
        /// <summary>
        /// 别名名称
        /// </summary>	
        public string title
        {
            get { return _title; }
            set { _title = value; }
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

       
    }
}