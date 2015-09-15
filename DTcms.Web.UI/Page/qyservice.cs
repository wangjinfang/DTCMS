using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.UI.Page
{
    public class qyservice : Web.UI.BasePage
    {
        protected int categoryid = 0;
        protected DataTable category_dt = new DataTable();
        protected DataTable qyservice_dt = new DataTable();
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            categoryid = DTRequest.GetQueryInt("category_id");
            category_dt = get_category_list("bangongfuwu", 0);
            if (categoryid == 0 && category_dt.Rows.Count > 0)
            {
                categoryid = int.Parse(category_dt.Rows[0]["id"].ToString());
            }
            qyservice_dt = get_article_list("bangongfuwu", categoryid, 11, "id>0", "sort_id asc");
        }
    }
}
