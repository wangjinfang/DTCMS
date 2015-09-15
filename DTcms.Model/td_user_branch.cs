using System; 
namespace DTcms.Model
{
    [Serializable]
    public partial class user_branch
    {
        	
        private int _user_id;
        /// <summary>
        /// 用户ID  （下属员工ID）
        /// </summary>	
        public int user_id
        {
            get{ return _user_id; }
            set{ _user_id = value; }
        }
        	
        private int _branch_id;
        /// <summary>
        /// 部门ID
        /// </summary>	
        public int branch_id
        {
            get{ return _branch_id; }
            set{ _branch_id = value; }
        }
        	
        private DateTime _add_time;
        /// <summary>
        /// add_time
        /// </summary>	
        public DateTime add_time
        {
            get{ return _add_time; }
            set{ _add_time = value; }
        }
            }
}