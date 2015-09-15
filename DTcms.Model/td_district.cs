using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class district
    {
        	
        private long _districtid;
        /// <summary>
        /// DistrictID
        /// </summary>	
        public long DistrictID
        {
            get{ return _districtid; }
            set{ _districtid = value; }
        }
        	
        private string _districtname;
        /// <summary>
        /// DistrictName
        /// </summary>	
        public string DistrictName
        {
            get{ return _districtname; }
            set{ _districtname = value; }
        }
        	
        private long _cityid;
        /// <summary>
        /// CityID
        /// </summary>	
        public long CityID
        {
            get{ return _cityid; }
            set{ _cityid = value; }
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