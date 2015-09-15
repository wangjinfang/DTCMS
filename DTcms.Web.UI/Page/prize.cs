using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DTcms.Web.UI.Page
{
    public class prize : Web.UI.BasePage
    {
        protected int num = 3;//摇奖次数
        protected DataTable p_dt = new DataTable();
        protected Model.users model = new Model.users();
        protected DataTable jp_dt = new DataTable();
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            BLL.prizes pbll = new BLL.prizes();            
            DataSet ds = pbll.GetList(30, "*", "id>0", "id desc");
            if (ds != null && ds.Tables.Count > 0)
            {
                p_dt = ds.Tables[0];
            }
        }
    }
}
