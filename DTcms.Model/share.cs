using System;
namespace DTcms.Model
{
    [Serializable]
    public partial class share
    {

        private int _id;
        /// <summary>
        /// ID
        /// </summary>	
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _user_id;
        /// <summary>
        /// 用户ID
        /// </summary>	
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private string _user_name;
        /// <summary>
        /// 用户名
        /// </summary>	
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }

        private string _type;
        /// <summary>
        /// 分享类型
        /// </summary>	
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private DateTime _add_time;
        /// <summary>
        /// 分享时间
        /// </summary>	
        public DateTime add_time
        {
            get { return _add_time; }
            set { _add_time = value; }
        }
    }
}