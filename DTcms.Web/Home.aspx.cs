namespace DTcms.Web
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Text;
    using System.Data;
    using System.Data.Sql;
    /// <summary>
    /// 官网首页
    /// </summary>
    public partial class Home : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNav();
            }
        }

        /// <summary>
        /// 导航区域绑定
        /// </summary>
        protected void BindNav()
        {
            StringBuilder strnav = new StringBuilder();
            BLL.article_category bll = new BLL.article_category();
            DataTable dtCategory = bll.GetList(0, 2);
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                //一级类目
                DataRow[] drFirsts = dtCategory.Select(" parent_id=0 ");
                foreach (DataRow dr in drFirsts)
                {
                    strnav.Append(@"<li class='mod_cate'>");
                    strnav.Append("<h2><a href='#'>" + dr["title"].ToString() + "</a></h2>");
                    DataRow[] drRems = dtCategory.Select(" class_list like '%," + dr["id"].ToString() + ",%' and IsRecommended='1' ");
                    if (drRems != null && drRems.Length > 0)
                    {
                        strnav.Append("<p class='mod_cate_r'>");
                        foreach (DataRow drRem in drRems)
                        {
                            strnav.Append("<a href='#'>"+drRem["title"].ToString()+"</a>");
                        }
                        strnav.Append("</p>");
                    }
                    //推荐类目绑定
                    //<p class="mod_cate_r"><a href="#">计算器</a><a href="#">文件夹</a><a href="#">文件柜</a><a href="#">推荐类目</a></p>
                    strnav.Append(@"<div class='mod_subcate'>");
                    strnav.Append(" <div class='mod_subcate_main'>");
                    strnav.Append(" <div class='inBox'>");
                    strnav.Append(" <div class='inHd'>");
                    strnav.Append("  <ul>");
                    //二级类目绑定
                    //二级类目查找
                    DataRow[] drSeconds = dtCategory.Select(" class_list like '%," + dr["id"].ToString() + ",%' and class_layer=2 ");
                    if (drSeconds != null && drSeconds.Length > 0)
                    {
                        foreach (DataRow drSecond in drSeconds)
                        {
                            strnav.Append("<li>");
                            //<span class='s-m1'></span>
                            strnav.Append("  <a href='#'><img src='" + drSecond["img_url"].ToString() + "' width='30px' height='30px'  ></img>" + drSecond["title"].ToString() + "</a>");
                            strnav.Append(" </li>");

                        }
                        strnav.Append("</ul>");
                        //活动内容待添加
                        strnav.Append(" </div>");
                        strnav.Append("  <div class='inBd'> ");
                        strnav.Append("   <ul> ");
                        int i = 0;
                        foreach (DataRow drSecond in drSeconds)
                        {
                            DataRow[] drThirds = dtCategory.Select(" class_list like '%," + drSecond["id"].ToString() + ",%' and class_layer=3 ");
                            if (drThirds != null && drThirds.Length > 0)
                            {

                                foreach (DataRow drThird in drThirds)
                                {
                                    if (i < 24)
                                    {
                                        strnav.Append("<li>");
                                        strnav.Append("<div class='pic'>");
                                        strnav.Append(" <a href='#'>");
                                        strnav.Append("  <img src='" + drThird["img_url"].ToString() + "'  width='90px' height='90px'/></a>");
                                        strnav.Append(" </div>");
                                        strnav.Append("     <div class='title'><a href='#'>" + drThird["title"].ToString() + "</a></div>");
                                        strnav.Append("</li>");
                                    }
                                    i++;
                                }

                            }
                        }

                        strnav.Append("</ul>");
                        strnav.Append(" </div>");
                        strnav.Append(" </div>");
                        strnav.Append(" </div>");
                        strnav.Append(" </li>");
                    }
                }
            }

            ltNav.Text = strnav.ToString();
        }
    }
}