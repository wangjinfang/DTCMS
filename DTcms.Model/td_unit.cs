using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class unit
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
        	
        private int _good_id;
        /// <summary>
        /// good_id
        /// </summary>	
        public int good_id
        {
            get{ return _good_id; }
            set{ _good_id = value; }
        }
        	
        private string _title;
        /// <summary>
        /// 单位名称
        /// </summary>	
        public string title
        {
            get{ return _title; }
            set{ _title = value; }
        }
        	
        private int _quantity;
        /// <summary>
        /// 数量
        /// </summary>	
        public int quantity
        {
            get{ return _quantity; }
            set{ _quantity = value; }
        }
        	
        private string _content;
        /// <summary>
        /// 备注
        /// </summary>	
        public string content
        {
            get{ return _content; }
            set{ _content = value; }
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
        	
        private decimal _rate;
        /// <summary>
        /// 比率 %
        /// </summary>	
        public decimal rate
        {
            get{ return _rate; }
            set{ _rate = value; }
        }
            }
}