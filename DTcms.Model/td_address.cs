using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class address
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
        /// 用户ID
        /// </summary>	
        public int user_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }
        	
        private int _province;
        /// <summary>
        /// 省
        /// </summary>	
        public int province
        {
            get{ return _province; }
            set{ _province = value; }
        }
        	
        private int _city;
        /// <summary>
        /// 市
        /// </summary>	
        public int city
        {
            get{ return _city; }
            set{ _city = value; }
        }
        	
        private int _distract;
        /// <summary>
        /// 区
        /// </summary>	
        public int distract
        {
            get{ return _distract; }
            set{ _distract = value; }
        }
        	
        private string _content;
        /// <summary>
        /// 详细地址
        /// </summary>	
        public string content
        {
            get{ return _content; }
            set{ _content = value; }
        }
        	
        private DateTime _add_time;
        /// <summary>
        /// 时间
        /// </summary>	
        public DateTime add_time
        {
            get{ return _add_time; }
            set{ _add_time = value; }
        }
        	
        private int _is_default;
        /// <summary>
        /// 是否默认  1否  2是
        /// </summary>	
        public int is_default
        {
            get{ return _is_default; }
            set{ _is_default = value; }
        }
        	
        private string _zipcode;
        /// <summary>
        /// zipcode
        /// </summary>	
        public string zipcode
        {
            get{ return _zipcode; }
            set{ _zipcode = value; }
        }
        	
        private string _consignee;
        /// <summary>
        /// consignee
        /// </summary>	
        public string consignee
        {
            get{ return _consignee; }
            set{ _consignee = value; }
        }
        	
        private string _consignee_mobile;
        /// <summary>
        /// consignee_mobile
        /// </summary>	
        public string consignee_mobile
        {
            get{ return _consignee_mobile; }
            set{ _consignee_mobile = value; }
        }
        	
        private string _consignee_phone;
        /// <summary>
        /// consignee_phone
        /// </summary>	
        public string consignee_phone
        {
            get{ return _consignee_phone; }
            set{ _consignee_phone = value; }
        }

        private string _company_address = "";
        /// <summary>
        /// 公司地址
        /// </summary>
        public string company_address
        {
            get { return _company_address; }
            set { _company_address = value; }
        }

            }
}