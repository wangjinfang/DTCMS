using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class branch
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
        /// 用户ID   （公司ID）
        /// </summary>	
        public int user_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }
        	
        private string _title;
        /// <summary>
        /// 部门名称
        /// </summary>	
        public string title
        {
            get{ return _title; }
            set{ _title = value; }
        }
        	
        private DateTime _add_time;
        /// <summary>
        /// 添加时间
        /// </summary>	
        public DateTime add_time
        {
            get{ return _add_time; }
            set{ _add_time = value; }
        }
            }
}