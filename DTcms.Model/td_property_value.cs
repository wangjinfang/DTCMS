using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class property_value
    {
        	
        private decimal _id;
        /// <summary>
        /// id
        /// </summary>	
        public decimal id
        {
            get{ return _id; }
            set{ _id = value; }
        }
        	
        private int _property_id;
        /// <summary>
        /// 属性ID
        /// </summary>	
        public int property_id
        {
            get{ return _property_id; }
            set{ _property_id = value; }
        }
        	
        private string _value;
        /// <summary>
        /// 值
        /// </summary>	
        public string value
        {
            get{ return _value; }
            set{ _value = value; }
        }
        	
        private DateTime _add_time;
        /// <summary>
        /// add_time
        /// </summary>	
        public DateTime add_time
        {
            get{ return _add_time; }
            set{ _add_time = value; }
        }
            }
}