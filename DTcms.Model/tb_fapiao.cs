using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class fapiao
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
        	
        private int _type;
        /// <summary>
        /// 1普通发票2增值税发票
        /// </summary>	
        public int type
        {
            get{ return _type; }
            set{ _type = value; }
        }
        	
        private string _companyname;
        /// <summary>
        /// companyname
        /// </summary>	
        public string companyname
        {
            get{ return _companyname; }
            set{ _companyname = value; }
        }
        	
        private string _project;
        /// <summary>
        /// project
        /// </summary>	
        public string project
        {
            get{ return _project; }
            set{ _project = value; }
        }
        	
        private decimal _aomunt;
        /// <summary>
        /// aomunt
        /// </summary>	
        public decimal aomunt
        {
            get{ return _aomunt; }
            set{ _aomunt = value; }
        }
        	
        private string _danweiname;
        /// <summary>
        /// danweiname
        /// </summary>	
        public string danweiname
        {
            get{ return _danweiname; }
            set{ _danweiname = value; }
        }
        	
        private string _shibiehao;
        /// <summary>
        /// shibiehao
        /// </summary>	
        public string shibiehao
        {
            get{ return _shibiehao; }
            set{ _shibiehao = value; }
        }
        	
        private string _address;
        /// <summary>
        /// address
        /// </summary>	
        public string address
        {
            get{ return _address; }
            set{ _address = value; }
        }
        	
        private string _tel;
        /// <summary>
        /// tel
        /// </summary>	
        public string tel
        {
            get{ return _tel; }
            set{ _tel = value; }
        }
        	
        private string _bankname;
        /// <summary>
        /// bankname
        /// </summary>	
        public string bankname
        {
            get{ return _bankname; }
            set{ _bankname = value; }
        }
        	
        private string _bankaccount;
        /// <summary>
        /// bankaccount
        /// </summary>	
        public string bankaccount
        {
            get{ return _bankaccount; }
            set{ _bankaccount = value; }
        }
        	
        private int _userid;
        /// <summary>
        /// userid
        /// </summary>	
        public int userid
        {
            get{ return _userid; }
            set{ _userid = value; }
        }
            }
}