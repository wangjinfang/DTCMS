using System;
using System.Collections.Generic;
using System.Text;
using DTcms.Common;
using System.Data;
using System.Web;

namespace DTcms.Web.UI.Page
{
    public class qyservicedetails : Web.UI.BasePage
    {
        protected int id = 0;
        protected Model.article model = new Model.article();
        protected int preid = 0;
        protected int nextid = 0;
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            id = DTRequest.GetQueryInt("id", 0);
            BLL.article abll = new BLL.article();
            if (id > 0)
            {
                model = abll.GetModel(id);
                if (model == null)
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                    return;
                }
                else
                {
                    abll.UpdateField(model.id, "click=click+1");
                }
            }
            DataTable pre_dt = get_article_list("bangongfuwu", model.category_id, 1, "id<" + model.id, "sort_id asc");
            if (pre_dt.Rows.Count > 0)
            {
                preid = int.Parse(pre_dt.Rows[0]["id"].ToString());
            }
            DataTable next_dt = get_article_list("bangongfuwu", model.category_id, 1, "id>" + model.id, "sort_id asc");
            if (next_dt.Rows.Count > 0)
            {
                nextid = int.Parse(next_dt.Rows[0]["id"].ToString());
            }
        }
    }
}
