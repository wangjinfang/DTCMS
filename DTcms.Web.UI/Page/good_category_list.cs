using System;
using System.Collections.Generic;
using System.Text;
using DTcms.Common;
using System.Web;

namespace DTcms.Web.UI.Page
{
    public partial class good_category_list : Web.UI.BasePage
    {
        protected int category_id;
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            category_id = DTRequest.GetQueryInt("category_id");
            if (!new BLL.article_category().Exists(category_id))
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                return;
            }
        }
    }
}
