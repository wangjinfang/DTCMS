using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class city
    {
        	
        private long _cityid;
        /// <summary>
        /// CityID
        /// </summary>	
        public long CityID
        {
            get{ return _cityid; }
            set{ _cityid = value; }
        }
        	
        private string _cityname;
        /// <summary>
        /// CityName
        /// </summary>	
        public string CityName
        {
            get{ return _cityname; }
            set{ _cityname = value; }
        }
        	
        private string _zipcode;
        /// <summary>
        /// ZipCode
        /// </summary>	
        public string ZipCode
        {
            get{ return _zipcode; }
            set{ _zipcode = value; }
        }
        	
        private long _provinceid;
        /// <summary>
        /// ProvinceID
        /// </summary>	
        public long ProvinceID
        {
            get{ return _provinceid; }
            set{ _provinceid = value; }
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