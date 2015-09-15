using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using DTcms.Web.UI;
using DTcms.Common;

namespace DTcms.Web.tools
{
    /// <summary>
    /// 管理后台AJAX处理页
    /// </summary>
    public class admin_ajax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "attribute_field_validate": //验证扩展字段是否重复
                    attribute_field_validate(context);
                    break;
                case "channel_category_validate": //验证频道分类目录是否重复
                    channel_category_validate(context);
                    break;
                case "channel_validate": //验证频道名称是否重复
                    channel_validate(context);
                    break;
                case "urlrewrite_name_validate": //验证URL调用名称是否重复
                    urlrewrite_name_validate(context);
                    break;
                case "navigation_validate": //验证导航菜单ID是否重复
                    navigation_validate(context);
                    break;
                case "manager_validate": //验证管理员用户名是否重复
                    manager_validate(context);
                    break;
                case "get_remote_fileinfo": //获取远程文件的信息
                    get_remote_fileinfo(context);
                    break;
                case "get_navigation_list": //获取后台导航字符串
                    get_navigation_list(context);
                    break;
                case "edit_order_status": //修改订单信息和状态
                    edit_order_status(context);
                    break;
                case "validate_username": //验证会员用户名是否重复
                    validate_username(context);
                    break;
                case "sms_message_post": //发送手机短信
                    sms_message_post(context);
                    break;
                case "get_builder_urls": //获取要生成静态的地址
                    get_builder_urls(context);
                    break;
                case "get_builder_html": //生成静态页面
                    get_builder_html(context);
                    break;
                case "change_standard": //获取选中规格生成规格值列表NAN
                    change_standard(context);
                    break;
                case "get_category_list"://获取类别列表NAN
                    get_category_list(context);
                    break;
                case "get_good_list"://获取商品列表NAN
                    get_good_list(context);
                    break;
                case "get_good_info"://获取商品信息NAN
                    get_good_info(context);
                    break;
                case "into_meal"://添加商品到套餐NAN
                    into_meal(context);
                    break;
                case "get_good_unit"://获取商品单位NAN
                    get_good_unit(context);
                    break;
            }

        }

        private void get_good_unit(HttpContext context)
        {
            int good_id = DTRequest.GetQueryInt("good_id");
            BLL.article bll_good = new BLL.article();
            Model.article model_good = bll_good.GetModel(good_id);
            if (model_good == null)
            {
                context.Response.Write("Erorr");
                return;
            }

            BLL.unit bll_unit = new BLL.unit();
            DataTable dt_unit = bll_unit.GetList("good_id=" + model_good.id).Tables[0];
            if (dt_unit != null && dt_unit.Rows.Count > 0)
            {
                context.Response.Write(myJson.getJson(dt_unit));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }
        }

        private void into_meal(HttpContext context)
        {
            int good_id = DTRequest.GetQueryInt("good_id");
            decimal standard_value_price_id = DTRequest.GetQueryInt("standard_value_price_id");
            int unit_id = DTRequest.GetQueryInt("unit_id");
            int quantity = DTRequest.GetQueryInt("quantity");
            BLL.article bll_good = new BLL.article();
            Model.article model_good = bll_good.GetModel(good_id);
            if (model_good == null)
            {
                context.Response.Write("Erorr");
                return;
            }
            string str_quantity = ",数量：" + quantity;
            string unit = "";
            string standard = "";
            BLL.unit bll_unit = new BLL.unit();
            DataTable dt_unit = bll_unit.GetList("id=" + unit_id).Tables[0];
            if (dt_unit != null && dt_unit.Rows.Count > 0)
            {
                unit = ",单位：" + dt_unit.Rows[0]["title"].ToString();
                if (!string.IsNullOrEmpty(dt_unit.Rows[0]["content"].ToString()))
                {
                    unit += "(" + dt_unit.Rows[0]["content"].ToString() + ")";
                }
            }
            string str_ret = "";

            BLL.standard_price bll_standard_price = new BLL.standard_price();
            Model.standard_price model_standard_price = bll_standard_price.GetModel(standard_value_price_id);
            if (model_standard_price != null)
            {
                if (!string.IsNullOrEmpty(model_standard_price.standards))
                {
                    string[] arr_standard = model_standard_price.standards.Split(',');
                    string[] arr_standard_value = model_standard_price.standard_values.Split(',');

                    for (int i = 0; i < arr_standard.Length; i++)
                    {
                        standard += arr_standard[i] + ":";
                        if (i < arr_standard_value.Length)
                        {
                            standard += arr_standard_value[i];
                        }
                        standard += ",";
                    }
                }
            }
            if (!string.IsNullOrEmpty(standard))
            {
                standard = standard.Substring(0, standard.Length - 1);
            }
            str_ret = "<span onclick='ck_goods(this)'>" + model_good.title + str_quantity + unit + " " + standard + "<input type='checkbox' name='ck_good'  style='display:none;' value='" + good_id + "_" + standard_value_price_id + "_" + unit_id + "_" + quantity + "' checked='checked'/></span>";
            context.Response.Write(str_ret);
            return;
        }

        private void get_good_info(HttpContext context)
        {
            int good_id = DTRequest.GetQueryInt("good_id");
            BLL.article bll_article = new BLL.article();
            Model.article model_article = bll_article.GetModel(good_id);
            if (model_article == null)
            {
                context.Response.Write("NotFind");
                return;
            }


            string str_header = "";
            string str_body = "";
            //会员组
            BLL.user_groups bll_groups = new BLL.user_groups();
            DataTable dt_groups = bll_groups.GetList(0, "", "grade asc,id desc").Tables[0];
            string str_groups_header = "";
            string str_groups_body = "";



            BLL.standard_price bll_standard_price = new BLL.standard_price();
            DataTable dt_standard_price = bll_standard_price.GetList("good_id=" + good_id).Tables[0];
            if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
            {
                //有规格价格
                foreach (DataRow dr in dt_standard_price.Rows)
                {
                    decimal sell_price = Convert.ToDecimal(model_article.fields["sell_price"]);
                    string str_standard = "";
                    string str_standard_value = "";

                    sell_price = Convert.ToDecimal(dr["sell_price"]);
                    if (dr["standards"] != null && !string.IsNullOrEmpty(dr["standards"].ToString()))
                    {
                        string[] standard_arr = dr["standards"].ToString().Split(',');//规格名
                        string[] standard_value_arr = dr["standard_values"].ToString().Split(',');//规格值
                        string[] standard_value_id_arr = dr["standard_value_ids"].ToString().Split(',');//规格值ID
                        for (int i = 0; i < standard_arr.Length; i++)
                        {
                            str_standard += "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>" + standard_arr[i] + "</td>";
                            if (i < standard_value_arr.Length)
                            {
                                str_standard_value += "<td style='padding-right: 20px;'>" + standard_value_arr[i] + "</td>";
                                foreach (DataRow dr_group in dt_groups.Rows)
                                {
                                    BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();
                                    DataTable dt_standard_group_price = bll_standard_group_price.GetList("good_id=" + model_article.id + " and group_id=" + Convert.ToInt32(dr_group["id"]) + " and standard_price_id=" + standard_value_id_arr[i]).Tables[0];
                                    if (dt_standard_group_price != null && dt_standard_group_price.Rows.Count > 0)
                                    {
                                        str_groups_body += "<td style='padding-right: 20px;'>" + Convert.ToDecimal(dt_standard_group_price.Rows[0]["group_price"]) + "</td>";
                                    }
                                }
                            }
                            else
                            {
                                str_standard_value += "<td style='padding-right: 20px;'>&nbsp;</td>";



                            }
                        }
                    }
                    str_header = "<table>"
                    + "<thead><tr>"
                    + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>名称</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>售价</td>"
                    + str_standard
                    + str_groups_header
                    + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>数量</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>操作</td>"
                    + "</tr></thead>";

                    str_body += "<tbody><tr>"
                    + "<td style='padding-right: 20px;'>" + model_article.title + "</td>"
                    + "<td style='padding-right: 20px;'>" + sell_price + "</td>"
                    + str_groups_body
                    + str_standard_value
                    + "<td style='padding-right: 20px;'><input type='text' class='input small' id='quantity_" + model_article.id + "_" + dr["id"].ToString() + "'></td>"
                    + "<td style='padding-right: 20px;'><a href='javascript:;' onclick='into_meal(" + model_article.id + "," + dr["id"].ToString() + ",this)'>选择</a></td>"
                    + "</tr></tbody>"
                    + "<table>";
                }
            }
            else
            {
                //无规格价格

                if (dt_groups != null && dt_groups.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_groups.Rows.Count; i++)
                    {
                        str_groups_header += "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>" + dt_groups.Rows[i]["title"].ToString() + "</td>";
                        str_groups_body += "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>" + bll_article.GetGroupPrice(model_article.id, Convert.ToInt32(dt_groups.Rows[i]["id"])) + "</td>";
                    }
                }

                str_header = "<table>"
                    + "<thead><tr>"
                    + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>名称</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>售价</td>"
                    + str_groups_header
                     + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>数量</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>操作</td>"
                    + "</tr></thead>";

                str_body += "<tbody><tr>"
                + "<td style='padding-right: 20px;'>" + model_article.title + "</td>"
                + "<td style='padding-right: 20px;'>" + model_article.fields["sell_price"] + "</td>"
                + str_groups_body
                + "<td style='padding-right: 20px;'><input type='text' class='input small' id='quantity_" + model_article.id + "_0'></td>"
                + "<td style='padding-right: 20px;'><a href='javascript:;' onclick='into_meal(" + model_article.id + ",0,this)'>选择</a></td>"
                + "</tr></tbody>"
                + "<table>";
            }

            context.Response.Write(str_header + str_body);
            return;
        }

        private void get_good_list(HttpContext context)
        {
            int category_id = DTRequest.GetQueryInt("category_id");
            string ret_str = "<option value=''>请选择商品...</option>";
            BLL.article bll = new BLL.article();
            DataTable dt = bll.GetList(0, "category_id=" + category_id, "sort_id asc,add_time desc").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ret_str += "<option value='" + dr["id"].ToString() + "'>" + dr["title"].ToString() + "</option>";
                }
            }
            context.Response.Write(ret_str);
            return;
        }

        private void get_category_list(HttpContext context)
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, 2);
            string ret_str = "<option value=''>请选择类别...</option>";
            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["id"].ToString();
                    int ClassLayer = int.Parse(dr["class_layer"].ToString());
                    string Title = dr["title"].ToString().Trim();

                    if (ClassLayer == 1)
                    {
                        //this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                        ret_str += "<option value='" + Id + "'>" + Title + "</option>";
                    }
                    else
                    {
                        Title = "├ " + Title;
                        Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                        //this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                        ret_str += "<option value='" + Id + "'>" + Title + "</option>";
                    }
                }
            }

            context.Response.Write(ret_str);
            return;
        }

        private void change_standard(HttpContext context)
        {
            string standard_ids = DTRequest.GetQueryString("standard_ids");

            int quntity = DTRequest.GetQueryInt("quntity");
            decimal market_price = DTRequest.GetQueryDecimal("market_price", 0);
            decimal sell_price = DTRequest.GetQueryDecimal("sell_price", 0);
            string groups_price = DTRequest.GetQueryString("groups_price");

            BLL.standard bll = new BLL.standard();
            BLL.standard_price bll_standard_price = new BLL.standard_price();
            string rest_header = "";
            string rest_body = "";
            string strSql = "";
            string strorder = "";
            //会员组
            BLL.user_groups bll_groups = new BLL.user_groups();
            DataTable dt_groups = bll_groups.GetList(0, "", "grade asc,id desc").Tables[0];
            string str_groups_header = "";


            if (dt_groups != null && dt_groups.Rows.Count > 0)
            {
                for (int i = 0; i < dt_groups.Rows.Count; i++)
                {
                    str_groups_header += "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>" + dt_groups.Rows[i]["title"].ToString() + "</td>";
                }

            }
            string[] arr_group_price = groups_price.Split(',');//前台会员等级价格
            //表头部分
            DataTable dt = bll.GetList(0, "id in (" + standard_ids + ")", "id asc").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                rest_header += "<tr><td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>商品编号</td>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rest_header += "<td style='font-weight:bold;color:#33B5E5;padding-right:10px;'>" + dt.Rows[i]["title"].ToString() + "</td>";

                    //规格值列表
                    strSql += "(select id as id_" + dt.Rows[i]["id"].ToString() + ",value as value_" + dt.Rows[i]["id"].ToString() + " from td_standard_value where standard_id=" + dt.Rows[i]["id"].ToString() + ") as t_" + dt.Rows[i]["id"].ToString() + ",";
                    if (i == 0)
                    {
                        strorder = "id_" + dt.Rows[i]["id"].ToString() + " asc";
                    }

                }
                rest_header += "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>库存</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>市场价</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>销售价</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>活动价</td>"
                    + str_groups_header
                    + "</tr>";

                DataTable dt_price = bll_standard_price.get_dcer_list(strSql.Substring(0, strSql.Length - 1), strorder).Tables[0];
                rest_body += "<tr>";
                foreach (DataRow dr in dt_price.Rows)
                {
                    string str = "";
                    rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;width: 100px;' type='text' class='input normal small' name='good_no_" + str.Substring(0, str.Length - 1) + "' value=''/></td>";
                    for (int i = 0; i < dr.ItemArray.Length; i += 2)
                    {
                        rest_body += "<td style='padding-right: 20px;'>" + dr[i + 1].ToString() + "</td>";
                        str += dr[i].ToString() + "_";
                    }
                    rest_body += "<td style='padding-right: 20px;'><input type='checkbox' value='" + str.Substring(0, str.Length - 1) + "'  name='ck_standard_value' checked='checked' style='display:none;'/>";
                    rest_body += "<input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='stock_quantity_" + str.Substring(0, str.Length - 1) + "' value='" + quntity + "'/></td>";
                    rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='market_price_" + str.Substring(0, str.Length - 1) + "' value='" + market_price + "'/></td>";
                    rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='sell_price_" + str.Substring(0, str.Length - 1) + "' value='" + sell_price + "'/></td>";
                    rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='action_price_" + str.Substring(0, str.Length - 1) + "' value='" + sell_price + "'/></td>";

                    for (int j = 0; j < dt_groups.Rows.Count; j++)
                    {
                        if (j < arr_group_price.Length)
                        {
                            //会员价格文本框NAME=user_price_用户组id_规格值
                            rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='user_price_" + dt_groups.Rows[j]["id"].ToString() + "_" + str.Substring(0, str.Length - 1) + "' value='" + arr_group_price[j] + "'/></td>";
                        }
                    }


                    rest_body += "</tr>";
                }

            }

            context.Response.Write("{\"status\":\"y\",\"info\":\"" + "<table>" + rest_header + rest_body + "</table>" + "\"}");
            return;



            ////DataTable dt = bll.GetList("standard_id=" + item.Value).Tables[0];

            ////dt.TableName = "dt_" + item.Value; 
            //strSql += "(select id as id_" + item.Value + ",value as value_" + item.Value + " from td_standard_value where standard_id=" + item.Value + ") as t_" + item.Value + ",";
            //if (sel_count == 0)
            //{
            //    strorder = "id_" + item.Value+" asc";
            //}
        }

        #region 验证扩展字段是否重复============================
        private void attribute_field_validate(HttpContext context)
        {
            string column_name = DTRequest.GetString("param");
            if (string.IsNullOrEmpty(column_name))
            {
                context.Response.Write("{ \"info\":\"名称不可为空\", \"status\":\"n\" }");
                return;
            }
            BLL.article_attribute_field bll = new BLL.article_attribute_field();
            if (bll.Exists(column_name))
            {
                context.Response.Write("{ \"info\":\"该名称已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证频道分类生成目录名是否可用==================
        private void channel_category_validate(HttpContext context)
        {
            string build_path = DTRequest.GetString("param");
            string old_build_path = DTRequest.GetString("old_build_path");
            if (string.IsNullOrEmpty(build_path))
            {
                context.Response.Write("{ \"info\":\"该目录名不可为空！\", \"status\":\"n\" }");
                return;
            }
            if (build_path.ToLower() == old_build_path.ToLower())
            {
                context.Response.Write("{ \"info\":\"该目录名可使用\", \"status\":\"y\" }");
                return;
            }
            BLL.channel_category bll = new BLL.channel_category();
            if (bll.Exists(build_path))
            {
                context.Response.Write("{ \"info\":\"该目录名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该目录名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证频道名称是否是否可用========================
        private void channel_validate(HttpContext context)
        {
            string channel_name = DTRequest.GetString("param");
            string old_channel_name = DTRequest.GetString("old_channel_name");
            if (string.IsNullOrEmpty(channel_name))
            {
                context.Response.Write("{ \"info\":\"频道名称不可为空！\", \"status\":\"n\" }");
                return;
            }
            if (channel_name.ToLower() == old_channel_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
                return;
            }
            BLL.channel bll = new BLL.channel();
            if (bll.Exists(channel_name))
            {
                context.Response.Write("{ \"info\":\"该名称已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证URL调用名称是否重复=========================
        private void urlrewrite_name_validate(HttpContext context)
        {
            string new_name = DTRequest.GetString("param");
            string old_name = DTRequest.GetString("old_name");
            if (string.IsNullOrEmpty(new_name))
            {
                context.Response.Write("{ \"info\":\"名称不可为空！\", \"status\":\"n\" }");
                return;
            }
            if (new_name.ToLower() == old_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
                return;
            }
            BLL.url_rewrite bll = new BLL.url_rewrite();
            if (bll.Exists(new_name))
            {
                context.Response.Write("{ \"info\":\"该名称已被使用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该名称可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证导航菜单ID是否重复==========================
        private void navigation_validate(HttpContext context)
        {
            string navname = DTRequest.GetString("param");
            string old_name = DTRequest.GetString("old_name");
            if (string.IsNullOrEmpty(navname))
            {
                context.Response.Write("{ \"info\":\"该导航菜单ID不可为空！\", \"status\":\"n\" }");
                return;
            }
            if (navname.ToLower() == old_name.ToLower())
            {
                context.Response.Write("{ \"info\":\"该导航菜单ID可使用\", \"status\":\"y\" }");
                return;
            }
            //检查保留的名称开头
            if (navname.ToLower().StartsWith("channel_"))
            {
                context.Response.Write("{ \"info\":\"该导航菜单ID系统保留，请更换！\", \"status\":\"n\" }");
                return;
            }
            BLL.navigation bll = new BLL.navigation();
            if (bll.Exists(navname))
            {
                context.Response.Write("{ \"info\":\"该导航菜单ID已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该导航菜单ID可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 验证管理员用户名是否重复========================
        private void manager_validate(HttpContext context)
        {
            string user_name = DTRequest.GetString("param");
            if (string.IsNullOrEmpty(user_name))
            {
                context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
                return;
            }
            BLL.manager bll = new BLL.manager();
            if (bll.Exists(user_name))
            {
                context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"用户名可使用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 获取远程文件的信息==============================
        private void get_remote_fileinfo(HttpContext context)
        {
            string filePath = DTRequest.GetFormString("remotepath");
            if (string.IsNullOrEmpty(filePath))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"没有找到远程附件地址！\"}");
                return;
            }
            if (!filePath.ToLower().StartsWith("http://"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"不是远程附件地址！\"}");
                return;
            }
            try
            {
                HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(filePath);
                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                int fileSize = (int)_response.ContentLength;
                string fileName = filePath.Substring(filePath.LastIndexOf("/") + 1);
                string fileExt = filePath.Substring(filePath.LastIndexOf(".") + 1).ToUpper();
                context.Response.Write("{\"status\": 1, \"msg\": \"获取远程文件成功！\", \"name\": \"" + fileName + "\", \"path\": \"" + filePath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}");
            }
            catch
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"远程文件不存在！\"}");
                return;
            }
        }
        #endregion

        #region 获取后台导航字符串==============================
        private void get_navigation_list(HttpContext context)
        {
            Model.manager adminModel = new ManagePage().GetAdminInfo(); //获得当前登录管理员信息
            if (adminModel == null)
            {
                return;
            }
            Model.manager_role roleModel = new BLL.manager_role().GetModel(adminModel.role_id); //获得管理角色信息
            if (roleModel == null)
            {
                return;
            }
            DataTable dt = new BLL.navigation().GetDataList(0, DTEnums.NavigationEnum.System.ToString());
            this.get_navigation_childs(context, dt, 0, "", roleModel.role_type, roleModel.manager_role_values);

        }
        private void get_navigation_childs(HttpContext context, DataTable oldData, int parent_id, string parent_name, int role_type, List<Model.manager_role_value> ls)
        {
            DataRow[] dr = oldData.Select("parent_id=" + parent_id);
            bool isWrite = false;
            for (int i = 0; i < dr.Length; i++)
            {
                //检查是否显示在界面上====================
                bool isActionPass = true;
                if (int.Parse(dr[i]["is_lock"].ToString()) == 1)
                {
                    isActionPass = false;
                }
                //检查管理员权限==========================
                if (isActionPass && role_type > 1)
                {
                    string[] actionTypeArr = dr[i]["action_type"].ToString().Split(',');
                    foreach (string action_type_str in actionTypeArr)
                    {
                        //如果存在显示权限资源，则检查是否拥有该权限
                        if (action_type_str == "Show")
                        {
                            Model.manager_role_value modelt = ls.Find(p => p.nav_name == dr[i]["name"].ToString() && p.action_type == "Show");
                            if (modelt == null)
                            {
                                isActionPass = false;
                            }
                        }
                    }
                }
                //如果没有该权限则不显示
                if (!isActionPass)
                {
                    if (isWrite && i == (dr.Length - 1) && parent_id > 0 && parent_name != "sys_contents")
                    {
                        context.Response.Write("</ul>\n");
                    }
                    continue;
                }
                //输出开始标记
                if (i == 0 && parent_id > 0 && parent_name != "sys_contents")
                {
                    isWrite = true;
                    context.Response.Write("<ul>\n");
                }
                //以下是输出选项内容=======================
                if (int.Parse(dr[i]["class_layer"].ToString()) == 1)
                {
                    context.Response.Write("<div class=\"list-group\" name=\"" + dr[i]["sub_title"].ToString() + "\">\n");
                    if (dr[i]["name"].ToString() != "sys_contents")
                    {
                        context.Response.Write("<h2>" + dr[i]["title"].ToString() + "<i></i></h2>\n");
                    }
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), dr[i]["name"].ToString(), role_type, ls);
                    context.Response.Write("</div>\n");
                }
                else if (int.Parse(dr[i]["class_layer"].ToString()) == 2 && parent_name == "sys_contents")
                {
                    context.Response.Write("<h2>" + dr[i]["title"].ToString() + "<i></i></h2>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), dr[i]["name"].ToString(), role_type, ls);
                }
                else
                {
                    context.Response.Write("<li>\n");
                    context.Response.Write("<a navid=\"" + dr[i]["name"].ToString() + "\"");
                    if (!string.IsNullOrEmpty(dr[i]["link_url"].ToString()))
                    {
                        if (int.Parse(dr[i]["channel_id"].ToString()) > 0)
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "?channel_id=" + dr[i]["channel_id"].ToString() + "\" target=\"mainframe\"");
                        }
                        else
                        {
                            context.Response.Write(" href=\"" + dr[i]["link_url"].ToString() + "\" target=\"mainframe\"");
                        }
                    }
                    context.Response.Write(" class=\"item\">\n");
                    context.Response.Write("<span>" + dr[i]["title"].ToString() + "</span>\n");
                    context.Response.Write("</a>\n");
                    //调用自身迭代
                    this.get_navigation_childs(context, oldData, int.Parse(dr[i]["id"].ToString()), dr[i]["name"].ToString(), role_type, ls);
                    context.Response.Write("</li>\n");
                }
                //以上是输出选项内容=======================
                //输出结束标记
                if (i == (dr.Length - 1) && parent_id > 0 && parent_name != "sys_contents")
                {
                    context.Response.Write("</ul>\n");
                }
            }
        }
        #endregion

        #region 修改订单信息和状态==============================
        private void edit_order_status(HttpContext context)
        {
            //取得管理员登录信息
            Model.manager adminInfo = new Web.UI.ManagePage().GetAdminInfo();
            if (adminInfo == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"未登录或已超时，请重新登录！\"}");
                return;
            }
            //取得站点配置信息
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            //取得订单配置信息
            Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();

            string order_no = DTRequest.GetString("order_no");
            string edit_type = DTRequest.GetString("edit_type");
            if (order_no == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"传输参数有误，无法获取订单号！\"}");
                return;
            }
            if (edit_type == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"无法获取修改订单类型！\"}");
                return;
            }

            BLL.orders bll = new BLL.orders();
            Model.orders model = bll.GetModel(order_no);
            if (model == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"订单号不存在或已被删除！\"}");
                return;
            }
            switch (edit_type.ToLower())
            {
                case "order_confirm": //确认订单
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Confirm.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有确认订单的权限！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认，不能重复处理！\"}");
                        return;
                    }
                    model.status = 2;
                    model.confirm_time = DateTime.Now;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单确认失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Confirm.ToString(), "确认订单号:" + model.order_no); //记录日志
                    #region 发送短信或邮件
                    if (orderConfig.confirmmsg > 0)
                    {
                        switch (orderConfig.confirmmsg)
                        {
                            case 1: //短信通知
                                if (string.IsNullOrEmpty(model.mobile))
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >对方未填写手机号码！\"}");
                                    return;
                                }
                                Model.sms_template smsModel = new BLL.sms_template().GetModel(orderConfig.confirmcallindex); //取得短信内容
                                if (smsModel == null)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >短信通知模板不存在！\"}");
                                    return;
                                }
                                //替换标签
                                string msgContent = smsModel.content;
                                msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                                msgContent = msgContent.Replace("{username}", model.accept_name);
                                msgContent = msgContent.Replace("{orderno}", model.order_no);
                                msgContent = msgContent.Replace("{amount}", model.order_amount.ToString());
                                //发送短信
                                string tipMsg = string.Empty;
                                bool sendStatus = new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
                                if (!sendStatus)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >" + tipMsg + "\"}");
                                    return;
                                }
                                break;
                            case 2: //邮件通知
                                //取得用户的邮箱地址
                                if (model.user_id > 0)
                                {
                                    Model.users userModel = new BLL.users().GetModel(model.user_id);
                                    if (userModel == null || string.IsNullOrEmpty(userModel.email))
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >该用户不存在或没有填写邮箱地址。\"}");
                                        return;
                                    }
                                    //取得邮件模板内容
                                    Model.mail_template mailModel = new BLL.mail_template().GetModel(orderConfig.confirmcallindex);
                                    if (mailModel == null)
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >邮件通知模板不存在。\"}");
                                        return;
                                    }
                                    //替换标签
                                    string mailTitle = mailModel.maill_title;
                                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                                    string mailContent = mailModel.content;
                                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                                    mailContent = mailContent.Replace("{username}", model.user_name);
                                    mailContent = mailContent.Replace("{orderno}", model.order_no);
                                    mailContent = mailContent.Replace("{amount}", model.order_amount.ToString());
                                    //发送邮件
                                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                                        siteConfig.emailfrom, userModel.email, mailTitle, mailContent);
                                }
                                break;
                        }
                    }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功！\"}");
                    break;
                case "order_payment": //确认付款
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Confirm.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有确认付款的权限！\"}");
                        return;
                    }
                    if (model.status > 1 || model.payment_status == 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已确认，不能重复处理！\"}");
                        return;
                    }
                    model.payment_status = 2;
                    model.payment_time = DateTime.Now;
                    model.status = 2;
                    model.confirm_time = DateTime.Now;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单确认付款失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Confirm.ToString(), "确认付款订单号:" + model.order_no); //记录日志
                    #region 发送短信或邮件
                    if (orderConfig.confirmmsg > 0)
                    {
                        switch (orderConfig.confirmmsg)
                        {
                            case 1: //短信通知
                                if (string.IsNullOrEmpty(model.mobile))
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >对方未填写手机号码！\"}");
                                    return;
                                }
                                Model.sms_template smsModel = new BLL.sms_template().GetModel(orderConfig.confirmcallindex); //取得短信内容
                                if (smsModel == null)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >短信通知模板不存在！\"}");
                                    return;
                                }
                                //替换标签
                                string msgContent = smsModel.content;
                                msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                                msgContent = msgContent.Replace("{username}", model.user_name);
                                msgContent = msgContent.Replace("{orderno}", model.order_no);
                                msgContent = msgContent.Replace("{amount}", model.order_amount.ToString());
                                //发送短信
                                string tipMsg = string.Empty;
                                bool sendStatus = new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
                                if (!sendStatus)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >" + tipMsg + "\"}");
                                    return;
                                }
                                break;
                            case 2: //邮件通知
                                //取得用户的邮箱地址
                                if (model.user_id > 0)
                                {
                                    Model.users userModel = new BLL.users().GetModel(model.user_id);
                                    if (userModel == null || string.IsNullOrEmpty(userModel.email))
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >该用户不存在或没有填写邮箱地址。\"}");
                                        return;
                                    }
                                    //取得邮件模板内容
                                    Model.mail_template mailModel = new BLL.mail_template().GetModel(orderConfig.confirmcallindex);
                                    if (mailModel == null)
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >邮件通知模板不存在。\"}");
                                        return;
                                    }
                                    //替换标签
                                    string mailTitle = mailModel.maill_title;
                                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                                    string mailContent = mailModel.content;
                                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                                    mailContent = mailContent.Replace("{username}", model.user_name);
                                    mailContent = mailContent.Replace("{orderno}", model.order_no);
                                    mailContent = mailContent.Replace("{amount}", model.order_amount.ToString());
                                    //发送邮件
                                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                                        siteConfig.emailfrom, userModel.email, mailTitle, mailContent);
                                }
                                break;
                        }
                    }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认付款成功！\"}");
                    break;
                case "order_express": //确认发货
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Confirm.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有确认发货的权限！\"}");
                        return;
                    }
                    if (model.status > 2 || model.express_status == 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已完成或已发货，不能重复处理！\"}");
                        return;
                    }
                    int express_id = DTRequest.GetFormInt("express_id");
                    string express_no = DTRequest.GetFormString("express_no");
                    if (express_id == 0)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"请选择配送方式！\"}");
                        return;
                    }
                    model.express_id = express_id;
                    model.express_no = express_no;
                    model.express_status = 2;
                    model.express_time = DateTime.Now;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单发货失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Confirm.ToString(), "确认发货订单号:" + model.order_no); //记录日志
                    #region 发送短信或邮件
                    if (orderConfig.expressmsg > 0)
                    {
                        switch (orderConfig.expressmsg)
                        {
                            case 1: //短信通知
                                if (string.IsNullOrEmpty(model.mobile))
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >对方未填写手机号码！\"}");
                                    return;
                                }
                                Model.sms_template smsModel = new BLL.sms_template().GetModel(orderConfig.expresscallindex); //取得短信内容
                                if (smsModel == null)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >短信通知模板不存在！\"}");
                                    return;
                                }
                                //替换标签
                                string msgContent = smsModel.content;
                                msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                                msgContent = msgContent.Replace("{username}", model.user_name);
                                msgContent = msgContent.Replace("{orderno}", model.order_no);
                                msgContent = msgContent.Replace("{amount}", model.order_amount.ToString());
                                //发送短信
                                string tipMsg = string.Empty;
                                bool sendStatus = new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
                                if (!sendStatus)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >" + tipMsg + "\"}");
                                    return;
                                }
                                break;
                            case 2: //邮件通知
                                //取得用户的邮箱地址
                                if (model.user_id > 0)
                                {
                                    Model.users userModel = new BLL.users().GetModel(model.user_id);
                                    if (userModel == null || string.IsNullOrEmpty(userModel.email))
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >该用户不存在或没有填写邮箱地址。\"}");
                                        return;
                                    }
                                    //取得邮件模板内容
                                    Model.mail_template mailModel = new BLL.mail_template().GetModel(orderConfig.expresscallindex);
                                    if (mailModel == null)
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >邮件通知模板不存在。\"}");
                                        return;
                                    }
                                    //替换标签
                                    string mailTitle = mailModel.maill_title;
                                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                                    string mailContent = mailModel.content;
                                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                                    mailContent = mailContent.Replace("{username}", model.user_name);
                                    mailContent = mailContent.Replace("{orderno}", model.order_no);
                                    mailContent = mailContent.Replace("{amount}", model.order_amount.ToString());
                                    //发送邮件
                                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                                        siteConfig.emailfrom, userModel.email, mailTitle, mailContent);
                                }
                                break;
                        }
                    }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"订单发货成功！\"}");
                    break;
                case "order_complete": //完成订单=========================================
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Confirm.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有确认完成订单的权限！\"}");
                        return;
                    }
                    if (model.status > 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能重复处理！\"}");
                        return;
                    }
                    model.status = 3;
                    model.complete_time = DateTime.Now;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"确认订单完成失败！\"}");
                        return;
                    }
                    //给会员增加积分检查升级
                    if (model.user_id > 0 && model.point > 0)
                    {
                        new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "购物获得积分，订单号：" + model.order_no, true);
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Confirm.ToString(), "确认交易完成订单号:" + model.order_no); //记录日志
                    #region 发送短信或邮件
                    if (orderConfig.completemsg > 0)
                    {
                        switch (orderConfig.completemsg)
                        {
                            case 1: //短信通知
                                if (string.IsNullOrEmpty(model.mobile))
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >对方未填写手机号码！\"}");
                                    return;
                                }
                                Model.sms_template smsModel = new BLL.sms_template().GetModel(orderConfig.completecallindex); //取得短信内容
                                if (smsModel == null)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >短信通知模板不存在！\"}");
                                    return;
                                }
                                //替换标签
                                string msgContent = smsModel.content;
                                msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                                msgContent = msgContent.Replace("{username}", model.user_name);
                                msgContent = msgContent.Replace("{orderno}", model.order_no);
                                msgContent = msgContent.Replace("{amount}", model.order_amount.ToString());
                                //发送短信
                                string tipMsg = string.Empty;
                                bool sendStatus = new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
                                if (!sendStatus)
                                {
                                    context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送短信<br/ >" + tipMsg + "\"}");
                                    return;
                                }
                                break;
                            case 2: //邮件通知
                                //取得用户的邮箱地址
                                if (model.user_id > 0)
                                {
                                    Model.users userModel = new BLL.users().GetModel(model.user_id);
                                    if (userModel == null || string.IsNullOrEmpty(userModel.email))
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >该用户不存在或没有填写邮箱地址。\"}");
                                        return;
                                    }
                                    //取得邮件模板内容
                                    Model.mail_template mailModel = new BLL.mail_template().GetModel(orderConfig.completecallindex);
                                    if (mailModel == null)
                                    {
                                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功，但无法发送邮件<br/ >邮件通知模板不存在。\"}");
                                        return;
                                    }
                                    //替换标签
                                    string mailTitle = mailModel.maill_title;
                                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                                    string mailContent = mailModel.content;
                                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                                    mailContent = mailContent.Replace("{username}", model.user_name);
                                    mailContent = mailContent.Replace("{orderno}", model.order_no);
                                    mailContent = mailContent.Replace("{amount}", model.order_amount.ToString());
                                    //发送邮件
                                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                                        siteConfig.emailfrom, userModel.email, mailTitle, mailContent);
                                }
                                break;
                        }
                    }
                    #endregion
                    context.Response.Write("{\"status\": 1, \"msg\": \"确认订单完成成功！\"}");
                    break;
                case "order_cancel": //取消订单==========================================
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Cancel.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有取消订单的权限！\"}");
                        return;
                    }
                    if (model.status > 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能取消订单！\"}");
                        return;
                    }
                    model.status = 4;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"取消订单失败！\"}");
                        return;
                    }
                    int check_revert1 = DTRequest.GetFormInt("check_revert");
                    if (check_revert1 == 1)
                    {
                        //如果存在积分换购则返还会员积分
                        if (model.user_id > 0 && model.point < 0)
                        {
                            new BLL.user_point_log().Add(model.user_id, model.user_name, (model.point * -1), "取消订单返还积分，订单号：" + model.order_no, false);
                        }
                        //如果已支付则退还金额到会员账户
                        if (model.user_id > 0 && model.payment_status == 2 && model.order_amount > 0)
                        {
                            new BLL.user_amount_log().Add(model.user_id, model.user_name, DTEnums.AmountTypeEnum.BuyGoods.ToString(), model.order_amount, "取消订单退还金额，订单号：" + model.order_no);
                        }
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Cancel.ToString(), "取消订单号:" + model.order_no); //记录日志
                    context.Response.Write("{\"status\": 1, \"msg\": \"取消订单成功！\"}");
                    break;
                case "order_invalid": //作废订单==========================================
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Invalid.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有作废订单的权限！\"}");
                        return;
                    }
                    if (model.status != 3)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单尚未完成，不能作废订单！\"}");
                        return;
                    }
                    model.status = 5;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"作废订单失败！\"}");
                        return;
                    }
                    int check_revert2 = DTRequest.GetFormInt("check_revert");
                    if (check_revert2 == 1)
                    {
                        //扣除购物赠送的积分
                        if (model.user_id > 0 && model.point > 0)
                        {
                            new BLL.user_point_log().Add(model.user_id, model.user_name, (model.point * -1), "作废订单扣除积分，订单号：" + model.order_no, false);
                        }
                        //退还金额到会员账户
                        if (model.user_id > 0 && model.order_amount > 0)
                        {
                            new BLL.user_amount_log().Add(model.user_id, model.user_name, DTEnums.AmountTypeEnum.BuyGoods.ToString(), model.order_amount, "取消订单退还金额，订单号：" + model.order_no);
                        }
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Invalid.ToString(), "作废订单号:" + model.order_no); //记录日志
                    context.Response.Write("{\"status\": 1, \"msg\": \"作废订单成功！\"}");
                    break;
                case "edit_accept_info": //修改收货信息====================================
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有修改收货信息的权限！\"}");
                        return;
                    }
                    if (model.express_status == 2)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已经发货，不能修改收货信息！\"}");
                        return;
                    }
                    string accept_name = DTRequest.GetFormString("accept_name");
                    string province = DTRequest.GetFormString("province");
                    string city = DTRequest.GetFormString("city");
                    string area = DTRequest.GetFormString("area");
                    string address = DTRequest.GetFormString("address");
                    string post_code = DTRequest.GetFormString("post_code");
                    string mobile = DTRequest.GetFormString("mobile");
                    string telphone = DTRequest.GetFormString("telphone");

                    if (accept_name == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"请填写收货人姓名！\"}");
                        return;
                    }
                    if (area == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"请选择所在地区！\"}");
                        return;
                    }
                    if (address == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"请填写详细的送货地址！\"}");
                        return;
                    }
                    if (mobile == "" && telphone == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"联系手机或电话至少填写一项！\"}");
                        return;
                    }

                    model.accept_name = accept_name;
                    model.area = province + "," + city + "," + area;
                    model.address = address;
                    model.post_code = post_code;
                    model.mobile = mobile;
                    model.telphone = telphone;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改收货人信息失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Edit.ToString(), "修改收货信息，订单号:" + model.order_no); //记录日志
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改收货人信息成功！\"}");
                    break;
                case "edit_order_remark": //修改订单备注=================================
                    string remark = DTRequest.GetFormString("remark");
                    if (remark == "")
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"请填写订单备注内容！\"}");
                        return;
                    }
                    model.remark = remark;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改订单备注失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Edit.ToString(), "修改订单备注，订单号:" + model.order_no); //记录日志
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改订单备注成功！\"}");
                    break;
                case "edit_real_amount": //修改商品总金额================================
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有修改商品金额的权限！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认，不能修改金额！\"}");
                        return;
                    }
                    decimal real_amount = DTRequest.GetFormDecimal("real_amount", 0);
                    model.real_amount = real_amount;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改商品总金额失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Edit.ToString(), "修改商品金额，订单号:" + model.order_no); //记录日志
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改商品总金额成功！\"}");
                    break;
                case "edit_express_fee": //修改配送费用==================================
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有配送费用的权限！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认，不能修改金额！\"}");
                        return;
                    }
                    decimal express_fee = DTRequest.GetFormDecimal("express_fee", 0);
                    model.express_fee = express_fee;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改配送费用失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Edit.ToString(), "修改配送费用，订单号:" + model.order_no); //记录日志
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改配送费用成功！\"}");
                    break;
                case "edit_payment_fee": //修改支付手续费=================================
                    //检查权限
                    if (!new BLL.manager_role().Exists(adminInfo.role_id, "order_list", DTEnums.ActionEnum.Edit.ToString()))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"您没有修改支付手续费的权限！\"}");
                        return;
                    }
                    if (model.status > 1)
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认，不能修改金额！\"}");
                        return;
                    }
                    decimal payment_fee = DTRequest.GetFormDecimal("payment_fee", 0);
                    model.payment_fee = payment_fee;
                    if (!bll.Update(model))
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"修改支付手续费失败！\"}");
                        return;
                    }
                    new BLL.manager_log().Add(adminInfo.id, adminInfo.user_name, DTEnums.ActionEnum.Edit.ToString(), "修改支付手续费，订单号:" + model.order_no); //记录日志
                    context.Response.Write("{\"status\": 1, \"msg\": \"修改支付手续费成功！\"}");
                    break;
            }

        }
        #endregion

        #region 验证用户名是否可用==============================
        private void validate_username(HttpContext context)
        {
            string user_name = DTRequest.GetString("param");
            //如果为Null，退出
            if (string.IsNullOrEmpty(user_name))
            {
                context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
                return;
            }
            Model.userconfig userConfig = new BLL.userconfig().loadConfig();
            //过滤注册用户名字符
            string[] strArray = userConfig.regkeywords.Split(',');
            foreach (string s in strArray)
            {
                if (s.ToLower() == user_name.ToLower())
                {
                    context.Response.Write("{ \"info\":\"用户名不可用\", \"status\":\"n\" }");
                    return;
                }
            }
            BLL.users bll = new BLL.users();
            //查询数据库
            if (bll.Exists(user_name.Trim()))
            {
                context.Response.Write("{ \"info\":\"用户名已重复\", \"status\":\"n\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"用户名可用\", \"status\":\"y\" }");
            return;
        }
        #endregion

        #region 发送手机短信====================================
        private void sms_message_post(HttpContext context)
        {
            //检查管理员是否登录
            if (!new ManagePage().IsAdminLogin())
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"尚未登录或已超时，请登录后操作！\"}");
                return;
            }
            string mobiles = DTRequest.GetFormString("mobiles");
            string content = DTRequest.GetFormString("content");
            if (mobiles == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"手机号码不能为空！\"}");
                return;
            }
            if (content == "")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"短信内容不能为空！\"}");
                return;
            }
            //开始发送
            string msg = string.Empty;
            bool result = new BLL.sms_message().Send(mobiles, content, 2, out msg);
            if (result)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"" + msg + "\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"" + msg + "\"}");
            return;
        }
        #endregion

        #region 获取要生成静态的地址============================
        private void get_builder_urls(HttpContext context)
        {
            int state = GetIsLoginAndIsStaticstatus();
            if (state == 1)
                new HtmlBuilder().getpublishsite(context);
            else
                context.Response.Write(state);
        }
        #endregion

        #region 生成静态页面====================================
        private void get_builder_html(HttpContext context)
        {
            int state = GetIsLoginAndIsStaticstatus();
            if (state == 1)
                new HtmlBuilder().handleHtml(context);
            else
                context.Response.Write(state);


        }
        #endregion

        #region 判断是否登陆以及是否开启静态====================
        private int GetIsLoginAndIsStaticstatus()
        {
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            //取得管理员登录信息
            Model.manager adminInfo = new Web.UI.ManagePage().GetAdminInfo();
            if (adminInfo == null)
                return -1;
            else if (!new BLL.manager_role().Exists(adminInfo.role_id, "app_builder_html", DTEnums.ActionEnum.Build.ToString()))
                return -2;
            else if (siteConfig.staticstatus != 2)
                return -3;
            else
                return 1;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}