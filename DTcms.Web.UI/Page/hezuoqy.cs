using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.Common;
using DTcms.Model;

namespace DTcms.Web.UI.Page
{
    public class hezuoqy : Web.UI.BasePage
    {
        protected DataTable category_dt = new DataTable();
        protected int categoryid = 0;
        protected int next_categoryid = 0;
        protected article_category categorymodel = new article_category();
        protected article_category next_categorymodel = new article_category();
        protected DataTable hezuoqy_dt = new DataTable();
        protected DataTable next_hezuoqy_dt = new DataTable();
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            BLL.article_category cbll = new BLL.article_category();
            categoryid = DTRequest.GetQueryInt("category_id", 0);
            if (categoryid > 0)
            {
                categorymodel = cbll.GetModel(categoryid);
            }
            
            category_dt = get_category_list("hezuomingqi", 0);
            
            int j = 0;
            int k = 0;
            foreach (DataRow dr in category_dt.Rows)
            {
                if (categoryid == 0 && k == 0)
                {
                    int.TryParse(dr["id"].ToString(), out categoryid);
                    categorymodel = cbll.GetModel(categoryid);
                }
                if (j == 1)
                {
                    int.TryParse(dr["id"].ToString(), out next_categoryid);
                    break;
                }
                if (dr["id"].ToString() == categoryid.ToString())
                    j++;
            }
            if (next_categoryid > 0)
            {
                next_categorymodel = cbll.GetModel(next_categoryid);
            }
            hezuoqy_dt = get_article_list("hezuomingqi", 25, "category_id=" + categoryid);
            next_hezuoqy_dt = get_article_list("hezuomingqi", 25, "category_id=" + next_categoryid);
        }
    }
}
