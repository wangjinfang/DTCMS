using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class standard_value
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
        	
        private int _standard_id;
        /// <summary>
        /// standard_id
        /// </summary>	
        public int standard_id
        {
            get{ return _standard_id; }
            set{ _standard_id = value; }
        }
        	
        private string _value;
        /// <summary>
        /// value
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