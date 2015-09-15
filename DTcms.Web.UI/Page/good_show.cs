using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using DTcms.Common;
using System.Data;

namespace DTcms.Web.UI.Page
{
    public partial class good_show : Web.UI.BasePage
    {
        protected int id;
        protected string page = string.Empty;
        protected Model.article model = new Model.article();
        protected decimal order_sum = 0;
        protected DataTable dt_unit=new DataTable();//单位表
        protected DataTable dt_meal_good = new DataTable();//套餐商品表
        protected DataTable dt_meal = new DataTable();//套餐表
        protected DataTable dt_standard = new DataTable();//规格表
        protected DataTable dt_property = new DataTable();//属性表
        protected DataTable dt_tag = new DataTable();//标签表
        protected DataTable dt_red_good = new DataTable();//搭配商品
        protected DataTable dt_red = new DataTable();//搭配
        protected string parent_category_title = "";//二级类别名
        protected DataTable dt_category = new DataTable();//三级类别表
        protected DataTable dt_other_goods = new DataTable();//其他商品表
        
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            id = DTRequest.GetQueryInt("id");
            page = DTRequest.GetQueryString("page");
            BLL.article bll = new BLL.article();

            if (id > 0) //如果ID获取到，将使用ID
            {
                if (!bll.Exists(id))
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                    return;
                }
                model = bll.GetModel(id);
            }
            else if (!string.IsNullOrEmpty(page)) //否则检查设置的别名
            {
                if (!bll.Exists(page))
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                    return;
                }
                model = bll.GetModel(page);
            }
            else
            {
                return;
            }
            //跳转URL
            if (model.link_url != null)
                model.link_url = model.link_url.Trim();
            if (!string.IsNullOrEmpty(model.link_url))
            {
                HttpContext.Current.Response.Redirect(model.link_url);
            }


            //销量
            DataTable dt_order_good_count = new BLL.orders().get_order_good_count(id).Tables[0];
            if (dt_order_good_count != null && dt_order_good_count.Rows.Count > 0)
            {
                order_sum = Convert.ToDecimal(dt_order_good_count.Rows[0]["quantity"]);
            }
            Model.article_category model_category = new BLL.article_category().GetModel(model.category_id);
            #region
            //规格表
            BLL.standard_price bll_standard_price = new BLL.standard_price();
            DataTable dt_standard_price = bll_standard_price.GetList("good_id=" + id).Tables[0];
            if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
            {
                BLL.standard bll_standard = new BLL.standard();
                
                if (model_category != null)
                {
                    DataTable dt_old_standard = bll_standard.GetList("'" + model_category.class_list + "' like '%,'+convert(nvarchar(10),category_id)+',%'").Tables[0];
                    
                    dt_standard.Columns.Add("id", typeof(int));
                    dt_standard.Columns.Add("title", typeof(string));
                    dt_standard.Columns.Add("value", typeof(string));
                    dt_standard.PrimaryKey = new DataColumn[] { dt_standard.Columns["id"] };

                    foreach (DataRow dr in dt_old_standard.Rows)
                    {
                        //if(Convert.ToInt32(dr[""]))
                        DataRow new_dr = dt_standard.NewRow();
                        new_dr["id"] = dr["id"];
                        new_dr["title"] = dr["title"];
                        DataTable dt_standard_value = new BLL.standard_value().GetList("standard_id=" + dr["id"].ToString()).Tables[0];
                        if (dt_standard_value != null || dt_standard_value.Rows.Count > 0)
                        {
                            string str_value = "";
                            foreach (DataRow dr_value in dt_standard_value.Rows)
                            {
                                str_value += dr_value["id"].ToString() + "|" + dr_value["value"].ToString() + ",";
                            }
                            new_dr["value"] = str_value.TrimEnd(',');
                            dt_standard.Rows.Add(new_dr);
                        } 
                    }
                }
               
                
            }
            #endregion

            //单位表
            BLL.unit bll_unit = new BLL.unit();
            dt_unit = bll_unit.GetList("good_id=" + id).Tables[0];


            //套餐()
            BLL.meal_good bll_meal_good = new BLL.meal_good();
            BLL.meal bll_meal = new BLL.meal(); 
            dt_meal = bll_meal.GetMealByGood(id, "jiejuefangan").Tables[0];

            dt_meal.TableName = "dt_meal";
            if (dt_meal != null && dt_meal.Rows.Count > 0)
            {
                
                //套餐商品
                DataTable old_dt_meal_good = bll_meal_good.GetList("meal_id=" + dt_meal.Rows[0]["id"].ToString()).Tables[0];
                 dt_meal_good = new DataTable();
                dt_meal_good.Columns.Add("meal_id");
                dt_meal_good.Columns.Add("good_standard_price");
                dt_meal_good.Columns.Add("title");
                dt_meal_good.Columns.Add("all_title");
                dt_meal_good.Columns.Add("img_url");
                dt_meal_good.Columns.Add("good_id");
                dt_meal_good.Columns.Add("price");
                string str_meal_good_ids = ",";
                if (old_dt_meal_good != null && old_dt_meal_good.Rows.Count > 0)
                {
                    foreach (DataRow dr in old_dt_meal_good.Rows)
                    {
                        if (str_meal_good_ids.IndexOf("," + dr["good_id"].ToString() + "_" + dr["standard_price_id"].ToString() + ",") > -1)
                        {
                            continue;
                        }
                        str_meal_good_ids += dr["good_id"].ToString() + "_" + dr["standard_price_id"].ToString() + ",";
                        Model.article modelt = bll.GetModel(Convert.ToInt32(dr["good_id"]));
                        if (modelt != null)
                        {
                            Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(dr["standard_price_id"]));
                            string str_standard_price = "";
                            string str_unit = "";
                            if (model_standard_price != null)
                            {
                                for (int i = 0; i < model_standard_price.standards.Split(',').Length; i++)
                                {
                                    if (!string.IsNullOrEmpty(model_standard_price.standards.Split(',')[i]))
                                    {
                                        str_standard_price += model_standard_price.standards.Split(',')[i];
                                        if (i < model_standard_price.standard_values.Split(',').Length)
                                        {
                                            str_standard_price += "：" + model_standard_price.standard_values.Split(',')[i];
                                        }
                                    }
                                }
                            }

                            Model.unit model_unit = bll_unit.GetModel(Convert.ToDecimal(dr["unit_id"]));
                            if (model_unit != null)
                            {
                                str_unit += "单位:" + model_unit.title + (string.IsNullOrEmpty(model_unit.content) ? "" : model_unit.content);
                            }


                            DataRow new_dr = dt_meal_good.NewRow();
                            new_dr["meal_id"] = dr["meal_id"];
                            new_dr["title"] = Utils.CutString(modelt.title, 10);
                            new_dr["good_standard_price"] = dr["good_id"].ToString() + dr["standard_price_id"].ToString();
                            new_dr["all_title"] = modelt.title + " " + str_standard_price + str_unit;
                            new_dr["img_url"] = modelt.img_url;
                            new_dr["price"] = dr["sell_price"];
                            new_dr["good_id"] = dr["good_id"];

                            dt_meal_good.Rows.Add(new_dr);
                        }
                    }
                    dt_meal_good.TableName = "dt_meal_good"; 
                }
            }


            //属性表
            BLL.property_good bll_property_good = new BLL.property_good();
            BLL.property bll_property = new BLL.property();
            BLL.property_value bll_property_value = new BLL.property_value();

            DataTable dt_old_property = bll_property_good.GetList("good_id=" + id).Tables[0];
            dt_property.Columns.Add("id");
            dt_property.Columns.Add("title");
            dt_property.Columns.Add("value");
            dt_property.PrimaryKey = new DataColumn[] { dt_property.Columns["id"] };

            foreach (DataRow dr in dt_old_property.Rows)
            {
                Model.property model_property = bll_property.GetModel(Convert.ToInt32(dr["property_id"]));
                Model.property_value model_property_value = bll_property_value.GetModel(Convert.ToDecimal(dr["property_value_id"]));
                if (model != null && model_property_value!=null)
                {

                    if (dt_property.Rows.Find(dr["property_id"]) != null)
                    {
                        dt_property.Rows.Find(dr["property_id"])["value"] = dt_property.Rows.Find(dr["property_id"])["value"].ToString() + "," + model_property_value.value;
                    }
                    else
                    {
                        DataRow new_dr = dt_property.NewRow();
                        new_dr["id"] = dr["property_id"];
                        new_dr["title"] = model_property.title;
                        new_dr["value"] = model_property_value.value;
                        dt_property.Rows.Add(new_dr);
                    }
                }
            }


            //标签
            BLL.tag_good bll_tag_good = new BLL.tag_good();
            DataTable dt_tag_good = bll_tag_good.GetList("good_id=" + id).Tables[0];
            dt_tag.Columns.Add("title");
            foreach (DataRow dr in dt_tag_good.Rows)
            {
                Model.tag model_tag = new BLL.tag().GetModel(Convert.ToInt32(dr["tag_id"]));
                if (model_tag != null)
                {
                    DataRow new_dr = dt_tag.NewRow();
                    new_dr["title"] = model_tag.title;
                    dt_tag.Rows.Add(new_dr);
                }
            }


            //推荐搭配 
           dt_red = bll_meal.GetMealByGood(id, "tuijiandapei").Tables[0];

            dt_red.TableName = "dt_red";
            if (dt_red != null && dt_red.Rows.Count > 0)
            {

                DataTable old_dt_red_good = bll_meal_good.GetList("meal_id=" + dt_red.Rows[0]["id"].ToString()).Tables[0];


                dt_red_good = new DataTable();
                dt_red_good.Columns.Add("meal_id");
                dt_red_good.Columns.Add("good_standard_price");
                dt_red_good.Columns.Add("title");
                dt_red_good.Columns.Add("all_title");
                dt_red_good.Columns.Add("good_id");
                dt_red_good.Columns.Add("img_url");
                dt_red_good.Columns.Add("price");
                string str_red_good_ids = ",";
                if (old_dt_red_good != null && old_dt_red_good.Rows.Count > 0)
                {
                    foreach (DataRow dr in old_dt_red_good.Rows)
                    {
                        if (str_red_good_ids.IndexOf("," + dr["good_id"].ToString() + "_" + dr["standard_price_id"].ToString() + ",") > -1)
                        {
                            continue;
                        }
                        str_red_good_ids += dr["good_id"].ToString() + "_" + dr["standard_price_id"].ToString() + ",";
                        Model.article modelt = bll.GetModel(Convert.ToInt32(dr["good_id"]));
                        if (modelt != null)
                        {
                            Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(dr["standard_price_id"]));
                            string str_standard_price = "";
                            string str_unit = "";
                            if (model_standard_price != null)
                            {
                                for (int i = 0; i < model_standard_price.standards.Split(',').Length; i++)
                                {
                                    if (!string.IsNullOrEmpty(model_standard_price.standards.Split(',')[i]))
                                    {
                                        str_standard_price += model_standard_price.standards.Split(',')[i];
                                        if (i < model_standard_price.standard_values.Split(',').Length)
                                        {
                                            str_standard_price += "：" + model_standard_price.standard_values.Split(',')[i];
                                        }
                                    }
                                }
                            }

                            Model.unit model_unit = bll_unit.GetModel(Convert.ToDecimal(dr["unit_id"]));
                            if (model_unit != null)
                            {
                                str_unit += "单位:" + model_unit.title + (string.IsNullOrEmpty(model_unit.content) ? "" : model_unit.content);
                            }


                            DataRow new_dr = dt_red_good.NewRow();
                            new_dr["meal_id"] = dr["meal_id"];
                            new_dr["title"] = Utils.CutString(modelt.title, 10);
                            new_dr["good_standard_price"] = dr["good_id"].ToString() + dr["standard_price_id"].ToString();
                            new_dr["all_title"] = modelt.title + " " + str_standard_price + str_unit;
                            new_dr["img_url"] = modelt.img_url;
                            new_dr["price"] = dr["sell_price"];
                            new_dr["good_id"] = dr["good_id"];

                            dt_red_good.Rows.Add(new_dr);
                        }
                    }
                    dt_red_good.TableName = "dt_red_good"; 
                }
            }

            //类别相关
            if (model_category != null)
            {
                if (new BLL.article_category().GetModel(model_category.parent_id) != null)
                {
                    parent_category_title = new BLL.article_category().GetModel(model_category.parent_id).title;
                    dt_category = new BLL.article_category().GetList(model_category.parent_id, "goods");
                }
                dt_other_goods = bll.get_order_buy_good(5, model_category.id).Tables[0];
            }

            

        }

        
        /// <summary>
        /// 获取上一条下一条的链接
        /// </summary>
        /// <param name="urlkey">urlkey</param>
        /// <param name="type">-1代表上一条，1代表下一条</param>
        /// <param name="defaultvalue">默认文本</param>
        /// <param name="callIndex">是否使用别名，0使用ID，1使用别名</param>
        /// <returns>A链接</returns>
        protected string get_prevandnext_article(string urlkey, int type, string defaultvalue, int callIndex)
        {
            string symbol = (type == -1 ? "<" : ">");
            BLL.article bll = new BLL.article();
            string str = string.Empty;
            str = " and category_id=" + model.category_id;

            string orderby = type == -1 ? "id desc" : "id asc";
            DataSet ds = bll.GetList(1, "channel_id=" + model.channel_id + " " + str + " and status=0 and Id" + symbol + id, orderby);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                return defaultvalue;
            }
            if (callIndex == 1 && !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["call_index"].ToString()))
            {
                return "<a href=\"" + linkurl(urlkey, ds.Tables[0].Rows[0]["call_index"].ToString()) + "\">" + ds.Tables[0].Rows[0]["title"] + "</a>";
            }
            return "<a href=\"" + linkurl(urlkey, ds.Tables[0].Rows[0]["id"].ToString()) + "\">" + ds.Tables[0].Rows[0]["title"] + "</a>";
        }
    }
}
