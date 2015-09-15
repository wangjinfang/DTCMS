using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class alias_good
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
        	
        private int _alias_id;
        /// <summary>
        /// alias_id
        /// </summary>	
        public int alias_id
        {
            get{ return _alias_id; }
            set{ _alias_id = value; }
        }
            }
}