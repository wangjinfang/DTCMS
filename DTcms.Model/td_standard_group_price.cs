using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class standard_group_price
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
        /// 商品ID
        /// </summary>	
        public int good_id
        {
            get{ return _good_id; }
            set{ _good_id = value; }
        }
        	
        private int _group_id;
        /// <summary>
        /// 用户组ID
        /// </summary>	
        public int group_id
        {
            get{ return _group_id; }
            set{ _group_id = value; }
        }
        	
        private decimal _standard_price_id;
        /// <summary>
        /// standard_price_id
        /// </summary>	
        public decimal standard_price_id
        {
            get{ return _standard_price_id; }
            set{ _standard_price_id = value; }
        }
        	
        private decimal _group_price;
        /// <summary>
        /// 用户组价格
        /// </summary>	
        public decimal group_price
        {
            get{ return _group_price; }
            set{ _group_price = value; }
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