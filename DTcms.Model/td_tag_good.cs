using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class tag_good
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
        	
        private int _tag_id;
        /// <summary>
        /// tag_id
        /// </summary>	
        public int tag_id
        {
            get{ return _tag_id; }
            set{ _tag_id = value; }
        }
            }
}