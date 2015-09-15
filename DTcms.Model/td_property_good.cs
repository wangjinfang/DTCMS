using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class property_good
    {
        	
        private int _good_id;
        /// <summary>
        /// good_id
        /// </summary>	
        public int good_id
        {
            get{ return _good_id; }
            set{ _good_id = value; }
        }
        	
        private decimal _property_value_id;
        /// <summary>
        /// property_value_id
        /// </summary>	
        public decimal property_value_id
        {
            get{ return _property_value_id; }
            set{ _property_value_id = value; }
        }
        	
        private int _property_id;
        /// <summary>
        /// property_id
        /// </summary>	
        public int property_id
        {
            get{ return _property_id; }
            set{ _property_id = value; }
        }
            }
}