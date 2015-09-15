using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class province
    {
        	
        private long _provinceid;
        /// <summary>
        /// ProvinceID
        /// </summary>	
        public long ProvinceID
        {
            get{ return _provinceid; }
            set{ _provinceid = value; }
        }
        	
        private string _provincename;
        /// <summary>
        /// ProvinceName
        /// </summary>	
        public string ProvinceName
        {
            get{ return _provincename; }
            set{ _provincename = value; }
        }
        	
        private DateTime _datecreated;
        /// <summary>
        /// DateCreated
        /// </summary>	
        public DateTime DateCreated
        {
            get{ return _datecreated; }
            set{ _datecreated = value; }
        }
        	
        private DateTime _dateupdated;
        /// <summary>
        /// DateUpdated
        /// </summary>	
        public DateTime DateUpdated
        {
            get{ return _dateupdated; }
            set{ _dateupdated = value; }
        }
            }
}