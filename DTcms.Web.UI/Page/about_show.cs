using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DTcms.Common;

namespace DTcms.Web.UI.Page
{
    public partial class about_show : Web.UI.BasePage
    {
        protected  Model.article model = new Model.article();
        protected Model.article model_bk = new Model.article();
        protected int help_id = 0;
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            help_id = DTRequest.GetQueryInt("help_id");
            BLL.article bll = new BLL.article();
            model = bll.GetModel("about");
            if (model == null)
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                return;
            }

            if (help_id > 0)
            {
                model_bk = bll.GetModel(help_id);
                if (model_bk == null)
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                    return;
                }
            }
        }
    }

}
