using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.Web.UI;
using DTcms.Common;
using LitJson;

namespace DTcms.Web.tools
{
    /// <summary>
    /// AJAX提交处理
    /// </summary>
    public class data_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        Model.userconfig userConfig = new BLL.userconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetString("action");

            switch (action)
            {
                case "get_productdate_page":
                    get_productdate_page(context);
                    break;
                case "get_prop_page"://获取属性
                    get_prop_page(context);
                    break;
            }
        }
        private void get_productdate_page(HttpContext context)
        {
            try
            {

                int category = DTRequest.GetFormInt("category", 0);
                string keyword = DTRequest.GetFormString("keyword");
                int propty = DTRequest.GetFormInt("propty", 0);
                int page = DTRequest.GetFormInt("page", 1);
                int pagesize = DTRequest.GetFormInt("pagesize", 8);

                string _orderby = "sort_id asc,add_time desc";
                int _recordCount = 0;
                string pagelist = "";
                BLL.article bll = new BLL.article();

                string sqlwhere = "";

                if (keyword != "" && keyword.Length > 0 && DTcms.Common.Utils.IsSafeSqlString(keyword))
                {
                    sqlwhere = " id in (select good_id from td_property_good where property_value_id in ( select id from td_property_value where value like '%"+keyword+"%')) or id in (select good_id from td_tag_good where tag_id in( select id from td_tag where title like '%"+keyword+"%')) or id in (select good_id from td_alias_good where alias_id in( select id from td_alias where title like '%"+keyword+"%'))or title like '%"+keyword+"%'";
                    if (propty > 0)//属性筛选
                    {
                        sqlwhere += " and id in (select distinct good_id from dbo.td_property_good where property_value_id in(" + propty + "))";
                       
                    }
                }
                else
                {
                    if (propty > 0)//属性筛选
                    {
                        sqlwhere = "id in (select distinct good_id from dbo.td_property_good where property_value_id in(" + propty + "))";
                        if (keyword != "" && keyword.Length > 0 && DTcms.Common.Utils.IsSafeSqlString(keyword))
                        {
                            sqlwhere += " and id in select good_id from td_property_good where property_value_id in ( select id from td_property_value where value like '%" + keyword + "%'))orid in (select good_id from td_tag_good where tag_id in( select id from td_tag where title like '%" + keyword + "%'))or id in (select good_id from td_alias_good where alias_id in( select id from td_alias where title like '%" + keyword + "%'))or title like '%" + keyword + "%'";
                        }
                    }
                }
               
                //DataSet ds = bll.get_article_list(,pagesize, page, "*", _where + "and attr1='1' and id in", _orderby, out _recordCount);
                DataSet ds = bll.GetList("goods", category, pagesize, page, sqlwhere, _orderby, out _recordCount);
                DataTable dt = ds.Tables[0];
                BasePage _basepage = new BasePage();
                if (keyword.Length<=0)
                {
                    pagelist = _basepage.get_page_links(pagesize, page, _recordCount, "javascript:getpagedata(''," + propty + "," + category + ",__id__);");
                }
                else
                {
                    pagelist = _basepage.get_page_links(pagesize, page, _recordCount, "javascript:getpagedata(" + keyword + "," + propty + "," + category + ",__id__);");
                }
               
                StringBuilder strhtml = new StringBuilder();

                foreach (DataRow dr in dt.Rows)
                {


                    strhtml.Append("<li>");

                    strhtml.Append("<div class=\"Procurement_list_li_top\">");
                    strhtml.Append("<input type=\"checkbox\" class=\"select_buy\" name=\"computer\" /></div>");

                    strhtml.Append("<div class=\"img_describe\">");
                    strhtml.Append("<a href=\"/good_show.aspx?id="+dr["id"].ToString()+"\"><img  src=\"" + dr["img_url"].ToString() + "\" width=\"235\" height=\"229\" />");
                    strhtml.Append("" + dr["title"] + "&nbsp;" + get_category_title(int.Parse(dr["category_id"].ToString()), "") + "&nbsp;红色 </a> </div>");

                    strhtml.Append("<span><strong>￥" + dr["sell_price"] + "</strong></span>");
                    strhtml.Append("<div class=\"Procurement_list_li_bottom\">");
                    strhtml.Append("<img class=\"reduce_btn\" src=\"../../../../templates/ql/images/reduce.jpg\" width=\"14\" height=\"14\" />");
                    strhtml.Append("<input type=\"text\" id=\"inputCount\" value=\"1\" name=\"\" />");
                    strhtml.Append("<img class=\"add_btn\" src=\"../../../../templates/ql/images/add.jpg\" width=\"14\" height=\"14\" /><a href=\"/good_show.aspx?id="+dr["id"].ToString()+"\" class=\"enter_shoppingcar\">进购物车</a>");
                    strhtml.Append("<a href=\"javascript:;\" onclick=\"Submit4('" + dr["id"].ToString() + "')\">收藏</a></div>");


                    strhtml.Append("</li>");

                }
                context.Response.Write("{ \"info\":\"获取数据成功！\", \"status\":\"1\" ,\"html\":\"" + myJson.String2Json(strhtml.ToString()) + "\",\"pagelist\":\"" + myJson.String2Json(pagelist) + "\"}");
                return;
            }
            catch (Exception ex)
            {
                context.Response.Write("{ \"info\":\"获取数据失败！\", \"status\":\"0\" }");
                return;
            }
        }


        private void get_prop_page(HttpContext context)
        {
            try
            {
                StringBuilder strhtml = new StringBuilder();
                int category = DTRequest.GetFormInt("category", 0);
                int page = DTRequest.GetFormInt("page", 1);

                BLL.property pro = new BLL.property();
                BLL.property_value pro_value = new BLL.property_value();

                BLL.article_category catgory = new BLL.article_category();
                string category_ids = "";
                DataTable dt_pro = null;
                if (category == 0)
                    dt_pro = pro.GetList("").Tables[0];
                else
                {
                    DataTable cat_dt = catgory.GetList(0, 2, category.ToString());//查找类别下的所有类别
                    if (cat_dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < cat_dt.Rows.Count; i++)
                        {
                            category_ids += cat_dt.Rows[i][0].ToString() + ",";
                        }
                        category_ids = category_ids.Substring(0, category_ids.Length - 1);
                    }
                    dt_pro = pro.GetList("category_id in(" + category_ids + ")").Tables[0];
                }
                if (dt_pro.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_pro.Rows.Count; i++)
                    {
                        strhtml.Append("<dl>");
                        strhtml.Append("<dt>" + dt_pro.Rows[i]["title"] + "</dt>");
                        DataTable dt_pro_value = pro_value.GetList("property_id='" + dt_pro.Rows[i][0] + "'").Tables[0];
                        if (dt_pro_value.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt_pro_value.Rows.Count; j++)
                            {
                                strhtml.Append("<dd><a style=\"cursor:pointer;\" onclick='getpagedata(" + dt_pro_value.Rows[j][0] + "," + category + "," + page + ")'>" + dt_pro_value.Rows[j]["value"] + "</a><span></span></dd>");
                            }
                        }
                        strhtml.Append("</dl>");
                    }
                    context.Response.Write("{ \"info\":\"获取数据成功！\", \"status\":\"1\" ,\"html\":\"" + myJson.String2Json(strhtml.ToString()) + "\",\"pagelist\":\"\"}");
                    return;
                }
                context.Response.Write("{ \"info\":\"该类别暂未添加属性！\", \"status\":\"0\" }");
            }
            catch (Exception ex)
            {
                context.Response.Write("{ \"info\":\"该类别暂未添加属性！\", \"status\":\"0\" }");
                return;
            }
        }
        /// <summary>
        /// 返回当前类别名称
        /// </summary>
        /// <param name="category_id">类别ID</param>
        /// <returns>String</returns>
        protected string get_category_title(int category_id, string default_value)
        {
            BLL.article_category bll = new BLL.article_category();
            if (bll.Exists(category_id))
            {
                return bll.GetTitle(category_id);
            }
            return default_value;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}