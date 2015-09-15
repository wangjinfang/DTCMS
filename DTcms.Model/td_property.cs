using System;
using System.Collections.Generic;
namespace DTcms.Model
{
    [Serializable]
    public partial class property
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
        /// 属性名称
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

        private List<Model.property_value> _property_values;
        /// <summary>
        /// 属性值列表
        /// </summary>
        public List<Model.property_value> property_values
        {
            get { return _property_values; }
            set { _property_values = value; }
        }

       
    }
}