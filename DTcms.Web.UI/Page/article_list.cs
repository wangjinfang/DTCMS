using System;
using System.Collections.Generic;
using System.Text;
using DTcms.Common;

namespace DTcms.Web.UI.Page
{
    public partial class article_list : Web.UI.BasePage
    {
        protected int page;         //当前页码
        protected int category_id;  //类别ID
        protected int totalcount;   //OUT数据总数
        protected string pagelist;  //分页页码

        protected int parent_category_id;
        protected string parent_category_title="";

        protected string str_order = "";
        protected string strorder = "default";
        protected string keyword = "";
        protected string flag = "";
     
        protected Model.article_category model = new Model.article_category();
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            page = DTRequest.GetQueryInt("page", 1);
            category_id = DTRequest.GetQueryInt("category_id"); 
            strorder = DTRequest.GetQueryString("strorder");
            keyword = DTRequest.GetQueryString("keyword");
            flag = DTRequest.GetQueryString("flag");
            if (string.IsNullOrEmpty(flag))
            {
                flag = "default";
            }

            if (string.IsNullOrEmpty(strorder) || strorder == "default")
            {
                strorder = "default";
                str_order = "sort_id asc,add_time desc";
            }
            else
            {
                switch (strorder)
                { 
                    case "moneya":
                        str_order = "sell_price asc";
                        break;
                    case "moneyd":
                        str_order = "sell_price desc";
                        break; 
                }
            }

            BLL.article_category bll = new BLL.article_category();
            model.title = "所有信息";
            if (category_id > 0) //如果ID获取到，将使用ID
            {
                if (bll.Exists(category_id))
                    model = bll.GetModel(category_id);
                parent_category_id = model.parent_id;

                if (bll.Exists(parent_category_id))
                {
                    parent_category_title = bll.GetModel(parent_category_id).title;
                }
            }


            
            //if (hot_search.Contains(","))
            //{
            //    for (int i = 0; i < hot_search.Split(',').Length; i++)
            //    {
                    
            //    }
            //}
          
        }
    }
}
