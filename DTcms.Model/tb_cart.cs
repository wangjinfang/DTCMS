using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class cart
    {
        	
        private int _id;
        /// <summary>
        /// ID
        /// </summary>	
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }
        	
        private string _productname;
        /// <summary>
        /// ProductName
        /// </summary>	
        public string ProductName
        {
            get{ return _productname; }
            set{ _productname = value; }
        }
        	
        private string _counts;
        /// <summary>
        /// Counts
        /// </summary>	
        public string Counts
        {
            get{ return _counts; }
            set{ _counts = value; }
        }
        	
        private int _userid;
        /// <summary>
        /// UserID
        /// </summary>	
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }
            }
}