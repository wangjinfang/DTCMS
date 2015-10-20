using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// 楼层:实体类
    /// </summary>
    [Serializable]
    public partial class floor
    {
        public floor()
        { }
        #region Model
        private int _id;
        private int _belongchannel;
        private string _floorname;
        private string _title;
        private string _color;
        private string _remark;       
        private DateTime _add_time = DateTime.Now;
        private string _status;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属频道
        /// </summary>
        public int belongchannel
        {
            set { _belongchannel = value; }
            get { return _belongchannel; }
        }
        /// <summary>
        /// 楼层名称
        /// </summary>
        public string floorname
        {
            set { _floorname = value; }
            get { return _floorname; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// 颜色
        /// </summary>
        public string color
        {
            set { _color = value; }
            get { return _color; }
        }
       
       
       
        /// <summary>
        /// 备注说明
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        
        /// <summary>
        /// 状态 正常 暂停
        /// </summary>
        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model
    }
}
