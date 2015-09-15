using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class browse_goods
    {
        	
        private int _id;
        /// <summary>
        /// id
        /// </summary>	
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }
        	
        private int _user_id;
        /// <summary>
        /// user_id
        /// </summary>	
        public int user_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }
        	
        private int _goods_id;
        /// <summary>
        /// goods_id
        /// </summary>	
        public int goods_id
        {
            get{ return _goods_id; }
            set{ _goods_id = value; }
        }
        	
        private string _img_url;
        /// <summary>
        /// img_url
        /// </summary>	
        public string img_url
        {
            get{ return _img_url; }
            set{ _img_url = value; }
        }
        	
        private string _goods_name;
        /// <summary>
        /// goods_name
        /// </summary>	
        public string goods_name
        {
            get{ return _goods_name; }
            set{ _goods_name = value; }
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
        	
        private string _time;
        /// <summary>
        /// time
        /// </summary>	
        public string time
        {
            get{ return _time; }
            set{ _time = value; }
        }
            }
}