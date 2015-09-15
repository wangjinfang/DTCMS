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
    public class submit_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        Model.userconfig userConfig = new BLL.userconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "comment_add": //提交评论
                    comment_add(context);
                    break;
                case "comment_list": //评论列表
                    comment_list(context);
                    break;
                case "validate_username": //验证用户名
                    validate_username(context);
                    break;
                case "user_register": //用户注册
                    user_register(context);
                    break;
                case "user_invite_code": //申请邀请码
                    user_invite_code(context);
                    break;
                case "user_register_smscode": //发送注册短信
                    user_register_smscode(context);
                    break;
                case "user_verify_email": //发送注册验证邮件
                    user_verify_email(context);
                    break;
                case "user_login": //用户登录
                    user_login(context);
                    break;
                case "user_check_login": //检查用户是否登录
                    user_check_login(context);
                    break;
                case "user_oauth_bind": //绑定第三方登录账户
                    user_oauth_bind(context);
                    break;
                case "user_oauth_register": //注册第三方登录账户
                    user_oauth_register(context);
                    break;
                case "user_info_edit": //修改用户信息
                    user_info_edit(context);
                    break;
                case "user_avatar_crop": //确认裁剪用户头像
                    user_avatar_crop(context);
                    break;
                case "user_password_edit": //修改密码
                    user_password_edit(context);
                    break;
                case "user_getpassword": //邮箱取回密码
                    user_getpassword(context);
                    break;
                case "user_repassword": //邮箱重设密码
                    user_repassword(context);
                    break;
                case "user_message_delete": //删除短信息
                    user_message_delete(context);
                    break;
                case "user_message_add": //发布站内短消息
                    user_message_add(context);
                    break;
                case "user_point_convert": //用户兑换积分
                    user_point_convert(context);
                    break;
                case "user_point_delete": //删除用户积分明细
                    user_point_delete(context);
                    break;
                case "user_amount_recharge": //用户在线充值
                    user_amount_recharge(context);
                    break;
                case "user_amount_delete": //删除用户收支明细
                    user_amount_delete(context);
                    break;
                case "cart_goods_add": //购物车加入商品
                    cart_goods_add(context);
                    break;
                case "cart_goods_update": //购物车修改商品
                    cart_goods_update(context);
                    break;
                case "cart_goods_delete": //购物车删除商品
                    cart_goods_delete(context);
                    break;
                case "order_save": //保存订单
                    order_save(context);
                    break;
                case "order_cancel": //用户取消订单
                    order_cancel(context);
                    break;
                case "view_article_click": //统计及输出阅读次数
                    view_article_click(context);
                    break;
                case "view_comment_count": //输出评论总数
                    view_comment_count(context);
                    break;
                case "view_attach_count": //输出附件下载总数
                    view_attach_count(context);
                    break;
                case "view_cart_count": //输出当前购物车总数
                    view_cart_count(context);
                    break;
                case "get_city_list"://获取市列表NAN
                    get_city_list(context);
                    break;
                case "get_district_list"://获取区列表NAN
                    get_district_list(context);
                    break;
                case "save_user_info"://保存用户信息NAN
                    save_user_info(context);
                    break;
                case "dealing_users"://分配账户hang
                    dealing_users(context);
                    break;

                case "add_branch"://添加部门NAN
                    add_branch(context);
                    break;
                case "save_branch"://修改部门NAN
                    save_branch(context);
                    break;
                case "del_branch"://删除部门NAN
                    del_branch(context);
                    break;
                case "edit_dealing_users":
                    edit_dealing_users(context);//修改分配账户资料
                    break;
                case "user_status"://hang启用禁用
                    user_status(context);
                    break;
                case "add_address"://新增收货地址NAN
                    add_address(context);
                    break;
                case "edit_userpsd"://hang修改企业用户密码
                    edit_userpsd(context);
                    break;
                case "save_address"://修改收货地址NAN
                    save_address(context);
                    break;
                case "get_goods"://获取商品信息NAN
                    get_goods(context);
                    break;
                case "get_collect"://收藏商品
                    get_collect(context);
                    break;
                case "get_browse_goods"://浏览商品 hang
                    get_browse_goods(context);
                    break;

                case "add_car"://加入购物车NAN
                    add_car(context);
                    break;
                case "get_car_list"://获取购物车列表NAN
                    get_car_list(context);
                    break;
                case "change_car_count"://改变购物车数量NAN
                    change_car_count(context);
                    break;
                case "del_car"://删除购物车NAN
                    del_car(context);
                    break;
                case "get_address"://获取地址列表NAN
                    get_address(context);
                    break;
                case "car_add_address"://购物车添加地址NAN
                    car_add_address(context);
                    break;
                case "add_order"://下单NAN
                    add_order(context);
                    break;
                case "order_pay"://支付NAN
                    order_pay(context);
                    break;
                case "check_standard_unit_price"://获取规格价格NAN
                    check_standard_unit_price(context);
                    break;
                case "user_get_prize"://用户抽奖AN
                    user_get_prize(context);
                    break;
                case "meal_into_shopping"://套餐加入购物车NAN
                    meal_into_shopping(context);
                    break;
                case "get_category"://获取
                    get_category(context);
                    break;
                case "get_meal_good"://获取套餐商品列表NAN
                    get_meal_good(context);
                    break;
                case "get_good_list"://获取商品列表NAN
                    get_good_list(context);
                    break;
                case "batch_to_shopping"://批量加入购物车NAN
                    batch_to_shopping(context);
                    break;
                case "pay_now"://会员中心订单立即支付NAN
                    pay_now(context);
                    break;
                case "cancel_order"://取消订单NAN
                    cancel_order(context);
                    break;
                case "del_address"://会员中心删除地址NAN
                    del_address(context);
                    break;
                case "batch_to_collect"://批量加入收藏夹
                    batch_to_collect(context);
                    break;
                case "new_meal_into_shopping"://商品详情页套餐加入购物车NAN
                    new_meal_into_shopping(context);
                    break;
                case "save_fapiao_info_putong"://普通发票
                    save_fapiao_info_putong(context);
                    break;
                case "save_fapiao_info_zengzhi"://增值税发票
                    save_fapiao_info_zengzhi(context);
                    break;
            }
        }
        private void save_fapiao_info_zengzhi(HttpContext context)
        {
            Model.users model_user = new BasePage().GetUserInfo();
            if (model_user == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请先登录！\"}");
                return;
            }
            string danweiname = DTRequest.GetFormString("danwei");
            string shibiehao = DTRequest.GetFormString("shibiehao");
            string address = DTRequest.GetFormString("address");
            string tel = DTRequest.GetFormString("tel");
            string bankname = DTRequest.GetFormString("bank");
            string bankaccount = DTRequest.GetFormString("bankaccount");

            BLL.fapiao bll = new BLL.fapiao();
            Model.fapiao model = new Model.fapiao();

            model.type = 2;
            model.danweiname = danweiname;
            model.shibiehao = shibiehao;
            model.address = address;
            model.tel = tel;
            model.bankname = bankname;
            model.bankaccount = bankaccount;
            model.userid = model_user.id;
            if (bll.Add(model) != 0)
            {

                context.Response.Write("{\"status\":1, \"msg\":\"保存成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"保存失败！\"}");
                return;
            }

        }
        private void save_fapiao_info_putong(HttpContext context)
        {
            Model.users model_user = new BasePage().GetUserInfo();
            if (model_user == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请先登录！\"}");
                return;
            }
            string companyname = DTRequest.GetFormString("companyname");
            string project = DTRequest.GetFormString("project");
            string money = DTRequest.GetFormString("money");
            BLL.fapiao bll = new BLL.fapiao();
            Model.fapiao model = new Model.fapiao();

            model.type = 1;
            model.companyname = companyname;
            model.project = project;
            model.aomunt = decimal.Parse(money);
            model.userid = model_user.id;
            if (bll.Add(model) != 0)
            {

                context.Response.Write("{\"status\":1, \"msg\":\"保存成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"保存失败！\"}");
                return;
            }

        }
        private void new_meal_into_shopping(HttpContext context)
        {
            string good_info = DTRequest.GetQueryString("good_info");//套餐ID|商品ID
            if (string.IsNullOrEmpty(good_info))
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请选择您要购买的商品！\"}");
                return;
            }

            BLL.meal_good bll_meal_good = new BLL.meal_good();
            BLL.standard_price bll_standard_price = new BLL.standard_price();

            string[] str_meal = good_info.Substring(0, good_info.Length - 1).Split(',');
            foreach (string str in str_meal)
            {
                string str_standard_value = "";
                int unit_id = 0;
                int quantity = 1;
                if (!string.IsNullOrEmpty(str))
                {
                    if (str.Split('|').Length == 2)
                    {
                        DataTable dt_meal_good = bll_meal_good.GetList(1, "meal_id=" + str.Split('|')[0] + " and good_id=" + str.Split('|')[1], "group_id asc").Tables[0];
                        unit_id = Convert.ToInt32(dt_meal_good.Rows[0]["unit_id"]);
                        quantity = Convert.ToInt32(dt_meal_good.Rows[0]["quantity"]);
                        if (dt_meal_good != null && dt_meal_good.Rows.Count > 0)
                        {
                            if (dt_meal_good.Rows[0]["standard_price_id"] != null && Convert.ToDecimal(dt_meal_good.Rows[0]["standard_price_id"]) != 0)
                            {
                                //有规格
                                Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(dt_meal_good.Rows[0]["standard_price_id"]));
                                if (model_standard_price != null)
                                {
                                    string[] arr_standard = model_standard_price.standard_ids.Split(',');
                                    string[] arr_standard_value = model_standard_price.standard_value_ids.Split(',');
                                    if (arr_standard.Length == arr_standard_value.Length)
                                    {
                                        for (int i = 0; i < arr_standard.Length; i++)
                                        {
                                            str_standard_value += arr_standard[i] + "|" + arr_standard_value[i] + ",";
                                        }
                                        if (!string.IsNullOrEmpty(str_standard_value))
                                        {
                                            str_standard_value = str_standard_value.Substring(0, str_standard_value.Length - 1);
                                        }
                                    }
                                    else
                                    {
                                        //Error
                                        context.Response.Write("{\"status\":\"0\", \"msg\":\"参数错误加入购物车失败！\"}");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //haven't standard

                                str_standard_value = 0 + "|" + 0;

                            }
                        }
                        else
                        {
                            //Error
                            context.Response.Write("{\"status\":\"0\", \"msg\":\"参数错误加入购物车失败！\"}");
                            return;
                        }
                    }
                }

                //add to shopping
                //商品ID-规格ID|规格值ID,规格ID|规格值ID-单位ID
                Web.UI.ShopCart.Add(str.Split('|')[1] + "-" + str_standard_value + "-" + unit_id, quantity);
            }
            context.Response.Write("{\"status\":\"1\", \"msg\":\"加入购物车成功！\"}");
            return;
        }

        private void batch_to_collect(HttpContext context)
        {
            string ids = DTRequest.GetQueryString("ids");
            Model.users model_user = new BasePage().GetUserInfo();
            if (model_user == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请先登录！\"}");
                return;
            }
            BLL.article bll_article = new BLL.article();
            BLL.collect bll_collect = new BLL.collect();
            string[] arr_id = ids.Split(',');
            foreach (string str in arr_id)
            {
                Model.article model_article = bll_article.GetModel(Convert.ToInt32(str));
                DataTable dt = bll_collect.GetList("user_id=" + model_user.id + " and goods_id=" + str).Tables[0];
                if (dt != null && dt.Rows.Count <= 0)
                {
                    if (model_article != null)
                    {
                        Model.collect model_collect = new Model.collect();

                        model_collect.goods_id = model_article.id;
                        model_collect.goods_name = model_article.title;
                        model_collect.img_url = model_article.img_url;
                        model_collect.price = Convert.ToDecimal(model_article.fields["sell_price"]);
                        model_collect.user_id = model_user.id;
                        model_collect.add_time = DateTime.Now;

                        bll_collect.Add(model_collect);
                    }
                }
            }

            context.Response.Write("{\"status\":\"1\", \"msg\":\"加入收藏成功！\"}");
            return;
        }

        private void del_address(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            if (!new BasePage().IsUserLogin())
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请先登录！\"}");
                return;
            }
            BLL.address bll_address = new BLL.address();
            if (!bll_address.Exists(id))
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"该地址不存在或已删除！\"}");
                return;
            }

            if (bll_address.Delete(id))
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"删除成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"删除失败！\"}");
                return;
            }
        }

        private void cancel_order(HttpContext context)
        {
            int order_id = DTRequest.GetQueryInt("order_id");
            BLL.orders bll_order = new BLL.orders();
            Model.users model_user = new BasePage().GetUserInfo();
            if (model_user == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请先登录！\"}");
                return;
            }

            Model.orders model_order = bll_order.GetModel(order_id);
            if (model_order == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"该订单不存在或已删除！\"}");
                return;
            }

            if (!bll_order.UpdateField(model_order.order_no, "status=4"))
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"取消订单失败！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"取消订单成功！\"}");
                return;
            }
        }

        private void pay_now(HttpContext context)
        {
            int order_id = DTRequest.GetQueryInt("order_id");
            BLL.orders bll_order = new BLL.orders();

            Model.users model_user = new BasePage().GetUserInfo();
            if (model_user == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请先登录！\"}");
                return;
            }


            Model.orders model_order = bll_order.GetModel(order_id);
            if (model_order == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"参数传输错误！\"}");
                return;
            }



            context.Response.Write("{\"status\":1, \"msg\":\"提交订单成功！\",\"order_no\":\"" + model_order.order_no + "\",\"order_money\":\"" + model_order.order_amount + "\",\"user_money\":\"" + model_user.amount + "\",\"order_id\":\"" + model_order.id + "\"}");
            return;
        }

        private void batch_to_shopping(HttpContext context)
        {
            string id_quantitys = DTRequest.GetQueryString("ids");
            if (string.IsNullOrEmpty(id_quantitys))
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请选择您要购买的商品！\"}");
                return;
            }
            int group_id = 0;

            Model.users model_user = new BasePage().GetUserInfo();
            if (model_user != null)
            {
                group_id = model_user.group_id;
            }

            //商品ID-规格ID|规格值ID,规格ID|规格值ID-单位ID
            string[] arr_id_quantity = id_quantitys.Split(',');
            BLL.standard_price bll_standard_price = new BLL.standard_price();
            int flag = 0;

            BLL.unit bll_unit = new BLL.unit();

            Dictionary<string, int> dn = new Dictionary<string, int>();

            foreach (string str in arr_id_quantity)
            {

                if (!string.IsNullOrEmpty(str))
                {
                    if (new BLL.article().Exists(Convert.ToInt32(str.Split('_')[0])))
                    {
                        DataTable dt = bll_standard_price.GetList("good_id=" + str.Split('_')[0]).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //有规格
                            flag++;
                        }
                        else
                        {
                            //无规格  127--198
                            string car_id = str.Split('_')[0] + "--";
                            DataTable dt_unit = bll_unit.GetList(1, "good_id=" + str.Split('_')[0], "quantity asc").Tables[0];
                            if (dt_unit != null && dt_unit.Rows.Count > 0)
                            {
                                car_id += dt_unit.Rows[0]["id"].ToString();
                            }
                            else
                            {
                                car_id += "0";
                            }

                            //Web.UI.ShopCart.Add(car_id, Convert.ToInt32(str.Split('_')[1]));
                            dn.Add(car_id, Convert.ToInt32(str.Split('_')[1]));
                        }
                    }
                    else
                    {
                        context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，您购买的商品中有些不存在或已下架，请重新选择！\"}");
                        return;
                    }
                }
            }

            foreach (var item in dn)
            {
                Web.UI.ShopCart.Add(item.Key, item.Value);
            }


            Model.cart_total cartModel = Web.UI.ShopCart.GetTotal(group_id);
            if (flag > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"商品成功加入购物车，还有部分商品需要选择规格！\", \"quantity\":" + cartModel.total_quantity + ", \"amount\":" + cartModel.real_amount + "}");
            }
            else
            {
                context.Response.Write("{\"status\":1, \"msg\":\"商品成功加入购物车！\", \"quantity\":" + cartModel.total_quantity + ", \"amount\":" + cartModel.real_amount + "}");
            }
            return;

        }

        private void get_good_list(HttpContext context)
        {
            int page = DTRequest.GetQueryInt("page", 1);
            string flag = DTRequest.GetQueryString("flag");
            int pagesize = DTRequest.GetQueryInt("pagesize", 12);
            string order = DTRequest.GetQueryString("order");
            string keyword = DTRequest.GetQueryString("keyword");
            int category = DTRequest.GetQueryInt("category");
            string property = DTRequest.GetQueryString("property");

            string strwhere = " is_put=1 ";
            string strorder = "sort_id asc ,add_time desc";
            int totalcount = 0;

            DataSet ds = new DataSet();


            if (!string.IsNullOrEmpty(property))
            {
                //strwhere += " and id in ( select good_id from td_property_good where property_value_id in (" + property + ")) ";
                string where_pro = "";
                string[] str_arr = property.Split(',');
                for (int i = 0; i < str_arr.Length; i++)
                {
                    if (i == 0)
                    {
                        where_pro += " select good_id from td_property_good where property_value_id in(" + str_arr[i] + ") ";
                    }
                    else
                    {
                        where_pro = "select good_id from td_property_good where good_id in (" + where_pro + ") and   property_value_id=" + str_arr[i];
                    }
                }

                strwhere += " and id in (" + where_pro + ")";
            }



            if (!string.IsNullOrEmpty(keyword))
            {
                strwhere += " and (id in (select good_id from td_property_good where property_value_id in ( select id from td_property_value where value like '%" + keyword + "%')) or id in (select good_id from td_tag_good where tag_id in( select id from td_tag where title like '%" + keyword + "%')) or id in (select good_id from td_alias_good where alias_id in( select id from td_alias where title like '%" + keyword + "%'))or title like '%" + keyword + "%') ";
            }



            if (order == "moneya")
            {
                strorder = "sell_price asc";
            }
            if (order == "moneyd")
            {
                strorder = "sell_price desc";
            }

            BLL.article bll = new BLL.article();
            DataTable dt = bll.GetList("goods", category, pagesize, page, strwhere, strorder, out totalcount).Tables[0];

            DataTable dt_goods = new DataTable();
            dt_goods.Columns.Add("id");
            dt_goods.Columns.Add("title");
            dt_goods.Columns.Add("sell_price");
            dt_goods.Columns.Add("img_url");
            dt_goods.Columns.Add("standard");

            foreach (DataRow dr in dt.Rows)
            {
                DataRow new_dr = dt_goods.NewRow();
                new_dr["id"] = dr["id"];
                new_dr["title"] = dr["title"];
                new_dr["sell_price"] = dr["sell_price"];
                new_dr["img_url"] = dr["img_url"];

                BLL.standard_price bll_standard_price = new BLL.standard_price();
                DataTable dt_standard_price = bll_standard_price.GetList("good_id=" + Convert.ToInt32(dr["id"])).Tables[0];
                if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
                {
                    //有库存
                    new_dr["standard"] = 1;
                }
                else
                {
                    //没库存
                    new_dr["standard"] = 2;
                }

                dt_goods.Rows.Add(new_dr);
            }


            dt_goods.TableName = "dt_good";
            if (dt_goods != null && dt_goods.Rows.Count > 0)
            {
                ds.Tables.Add(dt_goods.Copy());
            }
            //刷新属性列表  单个类别绑定属性
            if (flag == "default" || flag == "self_category" || flag == "self")
            {
                DataTable dt_property = new DataTable();
                dt_property.Columns.Add("id");
                dt_property.Columns.Add("title");
                dt_property.Columns.Add("parent_id");

                dt_property.TableName = "dt_property";

                BLL.property bll_property = new BLL.property();
                DataTable old_dt_property = bll_property.GetList(0, "category_id in (select id from dt_article_category where class_list like '%," + category + ",%')", "add_time desc").Tables[0];
                foreach (DataRow dr in old_dt_property.Rows)
                {
                    DataRow new_dr = dt_property.NewRow();
                    new_dr["id"] = 0;
                    new_dr["title"] = dr["title"];
                    new_dr["parent_id"] = 0;

                    dt_property.Rows.Add(new_dr);
                    BLL.property_value bll_value = new BLL.property_value();
                    DataTable dt_property_value = bll_value.GetList(0, "property_id=" + dr["id"].ToString(), "add_time desc").Tables[0];
                    foreach (DataRow dr_value in dt_property_value.Rows)
                    {
                        DataRow new_dr_value = dt_property.NewRow();
                        new_dr_value["id"] = dr_value["id"];
                        new_dr_value["title"] = dr_value["value"];
                        new_dr_value["parent_id"] = dr["id"];
                        dt_property.Rows.Add(new_dr_value);
                    }
                }

                if (dt_property != null && dt_property.Rows.Count > 0)
                {
                    ds.Tables.Add(dt_property.Copy());
                }
            }
            //多个类别绑定属性
            if (flag == "other")
            {

                DataTable dt_good = bll.GetList(0, " id in (select good_id from td_property_good where property_value_id in ( select id from td_property_value where value like '%" + keyword + "%')) or id in (select good_id from td_tag_good where tag_id in( select id from td_tag where title like '%" + keyword + "%')) or id in (select good_id from td_alias_good where alias_id in( select id from td_alias where title like '%" + keyword + "%'))or title like '%" + keyword + "%' ", "sort_id asc,add_time desc").Tables[0];

                DataTable dt_category = new DataTable();
                dt_category.Columns.Add("id");
                dt_category.Columns.Add("title");
                BLL.article_category bll_category = new BLL.article_category();
                Model.article_category model_category;
                string category_ids = ",";
                foreach (DataRow dr in dt_good.Rows)
                {
                    if (category_ids.IndexOf("," + dr["category_id"].ToString() + ",") <= -1)
                    {
                        category_ids += dr["category_id"].ToString() + ",";
                        model_category = bll_category.GetModel(Convert.ToInt32(dr["category_id"]));
                        if (model_category != null)
                        {
                            DataRow new_dr = dt_category.NewRow();
                            new_dr["id"] = model_category.id;
                            new_dr["title"] = model_category.title;
                            dt_category.Rows.Add(new_dr);
                        }
                    }
                }
                if (dt_category != null && dt_category.Rows.Count > 0)
                {
                    dt_category.TableName = "dt_category";
                    ds.Tables.Add(dt_category.Copy());
                }


                if (!string.IsNullOrEmpty(category_ids.Trim(',')))
                {
                    DataTable dt_property = new DataTable();
                    dt_property.Columns.Add("id");
                    dt_property.Columns.Add("title");
                    dt_property.Columns.Add("parent_id");

                    dt_property.TableName = "dt_property";

                    BLL.property bll_property = new BLL.property();
                    DataTable old_dt_property = bll_property.GetList(0, "category_id in (" + category_ids.Substring(1, category_ids.Length - 2) + ")", "add_time desc").Tables[0];

                    foreach (DataRow dr in old_dt_property.Rows)
                    {
                        DataRow new_dr = dt_property.NewRow();
                        new_dr["id"] = 0;
                        new_dr["title"] = dr["title"];
                        new_dr["parent_id"] = 0;

                        dt_property.Rows.Add(new_dr);
                        BLL.property_value bll_value = new BLL.property_value();
                        DataTable dt_property_value = bll_value.GetList(0, "property_id=" + dr["id"].ToString(), "add_time desc").Tables[0];
                        foreach (DataRow dr_value in dt_property_value.Rows)
                        {
                            DataRow new_dr_value = dt_property.NewRow();
                            new_dr_value["id"] = dr_value["id"];
                            new_dr_value["title"] = dr_value["value"];
                            new_dr_value["parent_id"] = dr["id"];
                            dt_property.Rows.Add(new_dr_value);
                        }
                    }

                    if (dt_property != null && dt_property.Rows.Count > 0)
                    {
                        ds.Tables.Add(dt_property.Copy());
                    }


                }
            }


            DataTable dt_page = new DataTable();
            dt_page.Columns.Add("page");
            dt_page.TableName = "dt_page";
            BasePage _basepage = new BasePage();//(page, pagesize, category, property, order, keyword, flag)
            DataRow dr_page = dt_page.NewRow();
            dr_page["page"] = myJson.String2Json(_basepage.get_page_links(pagesize, page, totalcount, "javascript:get_good_list(__id__,12,'" + category + "','" + property + "','" + order + "','" + keyword + "','" + flag + "')"));
            dt_page.Rows.Add(dr_page);

            if (dt_page != null && dt_page.Rows.Count > 0)
            {
                ds.Tables.Add(dt_page);
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                context.Response.Write(myJson.getJson(ds));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }

        }

        private void get_meal_good(HttpContext context)
        {
            int meal_id = DTRequest.GetQueryInt("meal_id");
            //套餐()
            BLL.article bll = new BLL.article();
            BLL.meal bll_meal = new BLL.meal();
            BLL.meal_good bll_meal_good = new BLL.meal_good();
            BLL.unit bll_unit = new BLL.unit();
            BLL.standard_price bll_standard_price = new BLL.standard_price();
            DataTable dt_meal = bll_meal.GetList("id=" + meal_id).Tables[0];
            if (dt_meal != null && dt_meal.Rows.Count > 0)
            {

                //套餐商品
                DataTable old_dt_meal_good = bll_meal_good.GetList("meal_id=" + dt_meal.Rows[0]["id"].ToString()).Tables[0];
                DataTable dt_meal_good = new DataTable();
                dt_meal_good.Columns.Add("meal_id");
                dt_meal_good.Columns.Add("good_standard_price");
                dt_meal_good.Columns.Add("title");
                dt_meal_good.Columns.Add("all_title");
                dt_meal_good.Columns.Add("img_url");
                dt_meal_good.Columns.Add("price");
                dt_meal_good.Columns.Add("good_id");
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
                    context.Response.Write(myJson.getJson(dt_meal_good));
                    return;
                }
                else
                {
                    context.Response.Write("Null");
                    return;
                }
            }
        }

        private void get_category(HttpContext context)
        {
            int parent_category = DTRequest.GetQueryInt("category_id");
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(parent_category, "goods");
            if (dt != null && dt.Rows.Count > 0)
            {
                context.Response.Write(myJson.getJson(dt));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }
        }

        private void meal_into_shopping(HttpContext context)
        {
            int meal_id = DTRequest.GetQueryInt("meal_id");
            BLL.meal bll_meal = new BLL.meal();
            Model.meal model_meal = bll_meal.GetModel(meal_id);
            if (model_meal == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"该套餐不存在或已删除！\"}");
                return;
            }
            List<string> shopping_key = new List<string>();
            bool quantity_ture = true;
            bool good_true = true;

            //查找会员组

            decimal unit_id = 0;

            int group_id = 0;
            Model.users user_model = new Web.UI.BasePage().GetUserInfo();
            if (user_model != null)
            {
                group_id = user_model.group_id;
            }
            string str_standard_good_price_ids = ",";
            DataTable dt_meal_good = new BLL.meal_good().GetList("meal_id=" + meal_id).Tables[0];
            foreach (DataRow dr_meal_good in dt_meal_good.Rows)
            {
                if (str_standard_good_price_ids.IndexOf("," + (Convert.ToInt32(dr_meal_good["meal_id"]) + "-" + Convert.ToInt32(dr_meal_good["good_id"]) + "-" + Convert.ToDecimal(dr_meal_good["standard_price_id"]) + "-" + Convert.ToDecimal(dr_meal_good["unit_id"])) + ",") > -1)
                {
                    continue;
                }
                str_standard_good_price_ids += Convert.ToInt32(dr_meal_good["meal_id"]) + "-" + Convert.ToInt32(dr_meal_good["good_id"]) + "-" + Convert.ToDecimal(dr_meal_good["standard_price_id"]) + "-" + Convert.ToDecimal(dr_meal_good["unit_id"]) + ",";

                int goods_id = Convert.ToInt32(dr_meal_good["good_id"]);
                Model.article model_good = new BLL.article().GetModel(goods_id);
                if (model_good != null)
                {



                    //商品ID-规格ID|规格值ID,规格ID|规格值ID-单位ID
                    string standard = "";
                    DataTable dt_standard_price = new BLL.standard_price().GetList("id=" + Convert.ToDecimal(dr_meal_good["standard_price_id"])).Tables[0];
                    foreach (DataRow dr_standard_price in dt_standard_price.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr_standard_price["standard_ids"].ToString()))
                        {
                            string[] arr_standard = dr_standard_price["standard_ids"].ToString().Split(',');
                            string[] arr_standard_value = dr_standard_price["standard_value_ids"].ToString().Split(',');
                            for (int i = 0; i < arr_standard.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(arr_standard[i]))
                                {
                                    standard += arr_standard[i] + "|" + ((i < arr_standard_value.Length) ? arr_standard_value[i] : "0");
                                }
                            }
                        }
                    }
                    int goods_quantity = Convert.ToInt32(dr_meal_good["quantity"]);
                    Model.unit model_unit = new BLL.unit().GetModel(Convert.ToInt32(dr_meal_good["unit_id"]));
                    if (model_unit != null)
                    {
                        unit_id = model_unit.id;
                        goods_quantity = goods_quantity * model_unit.quantity;
                    }

                    //统计购物车
                    shopping_key.Add(goods_id + "-" + standard + "-" + unit_id + "&" + goods_quantity);
                }
                else
                {
                    quantity_ture = false;
                    good_true = false;
                }
            }
            if (!quantity_ture || !good_true)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"库存不足，添加购物车失败\"}");
                return;
            }
            foreach (string str in shopping_key)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    Web.UI.ShopCart.Add(str.Split('&')[0], Convert.ToInt32(str.Split('&')[1]));
                }

            }



            Model.cart_total cartModel = Web.UI.ShopCart.GetTotal(group_id);






            context.Response.Write("{\"status\":1, \"msg\":\"商品已成功添加到购物车！\", \"quantity\":" + cartModel.total_quantity + ", \"amount\":" + cartModel.real_amount + "}");
            return;


        }

        /// <summary>
        /// 用户抽奖
        /// </summary>
        /// <param name="context"></param>
        private void user_get_prize(HttpContext context)
        {
            Model.users model = new BasePage().GetUserInfo();
            if (model != null && model.id > 0)
            {
                int num = 3;//默认3次抽奖机会
                BLL.share sbll = new BLL.share();
                DataSet sds = sbll.GetList("user_id=" + model.id);
                if (sds != null && sds.Tables[0].Rows.Count > 0)
                {
                    num = 4;//分享过之后4次抽奖机会
                }
                //获取抽奖次数
                BLL.prizes pbll = new BLL.prizes();
                DataSet ds = pbll.GetList("user_id=" + model.id);
                if (ds != null && ds.Tables[0].Rows.Count >= num)
                {
                    context.Response.Write("{\"status\":\"0\", \"msg\":\"您的抽奖次数已用尽！\"}");
                }
                else
                {
                    //抽奖操作
                    //抽奖概率：
                    //1.iphone6 小米4       0%
                    //2.100元话费  3%
                    //3.10元体验包  80%
                    //4.50元抵用券   50%
                    //5.100元抵用券  80%
                    //6.免费送货券  50%

                    Random rd = new Random();
                    int result = 0;
                    int prize = rd.Next(0, 3 + 80 + 50 + 80 + 50);
                    if (prize <= 3)
                    {
                        result = 5;
                        add_prize(model.id, model.user_name, "100元话费");
                    }
                    else if (prize <= 83)
                    {
                        result = 2;
                        add_prize(model.id, model.user_name, "10元体验包");
                    }
                    else if (prize <= 133)
                    {
                        result = 8;
                        add_prize(model.id, model.user_name, "50元抵用券");
                    }
                    else if (prize <= 213)
                    {
                        result = 4;
                        add_prize(model.id, model.user_name, "100元抵用券");
                    }
                    else if (prize <= 263)
                    {
                        result = 7;
                        add_prize(model.id, model.user_name, "免费送货劵");
                    }
                    context.Response.Write("{\"status\":\"" + result + "\", \"msg\":\"抽奖成功！\"}");
                }
            }
            else
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"请先登录！\"}");
            }

        }

        /// <summary>
        /// 添加中间记录
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="user_name"></param>
        /// <param name="prize"></param>
        private void add_prize(int user_id, string user_name, string prize)
        {
            Model.prizes model = new Model.prizes();
            model.add_time = DateTime.Now;
            model.prize = prize;
            model.user_id = user_id;
            model.user_name = user_name;
            BLL.prizes pbll = new BLL.prizes();
            pbll.Add(model);
        }


        private void check_standard_unit_price(HttpContext context)
        {
            int goods_id = DTRequest.GetQueryInt("goods_id");
            string standard_value_id = DTRequest.GetQueryString("standard_value_id");
            decimal unit_id = DTRequest.GetQueryDecimal("unit_id", 0);

            if (goods_id <= 0)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"参数错误！\"}");
                return;
            }
            Model.article model_article = new BLL.article().GetModel(goods_id);
            if (model_article == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"商品不存在或已删除！\"}");
                return;
            }

            BLL.unit bll_unit = new BLL.unit();
            Model.unit model_unit = bll_unit.GetModel(unit_id);

            string real_standard_value_id = "";
            if (!string.IsNullOrEmpty(standard_value_id))
            {
                string[] str = standard_value_id.Split(',');
                foreach (string s in str)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        real_standard_value_id += s.Split('|')[1] + ",";
                    }
                }
            }
            if (!string.IsNullOrEmpty(real_standard_value_id))
            {
                real_standard_value_id = real_standard_value_id.Substring(0, real_standard_value_id.Length - 1);
            }
            BLL.standard_price bll_standard_price = new BLL.standard_price();
            DataTable dt_standard_price = bll_standard_price.GetList("good_id=" + goods_id + " and standard_value_ids='" + real_standard_value_id + "'").Tables[0];
            if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
            {
                decimal sell_price = Convert.ToDecimal(dt_standard_price.Rows[0]["sell_price"]);//原价

                Model.users model_user = new BasePage().GetUserInfo();

                if (model_user != null)
                {
                    //会员价
                    BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();
                    DataTable dt_standard_group_price = bll_standard_group_price.GetList("good_id=" + goods_id + " and group_id=" + model_user.group_id + " and standard_price_id='" + dt_standard_price.Rows[0]["id"].ToString().Trim() + "'").Tables[0];
                    if (dt_standard_group_price != null && dt_standard_group_price.Rows.Count > 0)
                    {
                        sell_price = Convert.ToDecimal(dt_standard_group_price.Rows[0]["group_price"]);
                    }

                    if (model_unit != null)
                    {
                        sell_price = sell_price * model_unit.quantity * (model_unit.rate / 100);
                    }
                }
                else
                {
                    //非会员价

                    if (model_unit != null)
                    {
                        sell_price = sell_price * model_unit.quantity * (model_unit.rate / 100);
                    }
                }
                //if (sell_price <= 0)
                //{
                //    context.Response.Write("{\"status\":\"0\", \"msg\":\"库存不足！\"}");
                //    return;
                //}
                context.Response.Write("{\"status\":\"1\", \"msg\":\"" + sell_price + "\"}");
                return;
            }
            else
            {
                //没规格价格
                //if (Convert.ToInt32(model_article.fields["stock_quantity"]) <= 0 || Convert.ToDecimal(model_article.fields["sell_price"]) <= 0)
                //{
                //    context.Response.Write("{\"status\":\"0\", \"msg\":\"库存不足！\"}");
                //    return;
                //}
                //else
                //{
                decimal sell_price = Convert.ToDecimal(model_article.fields["sell_price"]) * model_unit.quantity * (model_unit.rate / 100);
                context.Response.Write("{\"status\":\"1\", \"msg\":\"" + sell_price + "\"}");
                return;
                //}

            }
        }

        private void order_pay(HttpContext context)
        {
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }


            string pay_type = DTRequest.GetQueryString("pay_type");//支付类型
            int pay_ment = DTRequest.GetQueryInt("pay_ment");//支付方式
            int order_id = DTRequest.GetQueryInt("order_id");

            BLL.orders bll = new BLL.orders();
            Model.orders model_order = bll.GetModel(order_id);
            if (model_order == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"订单不存在！\"}");
                return;
            }




            switch (pay_type)
            {
                case "month":
                    model_order.is_up = 3;
                    break;
                case "is_up":
                    model_order.is_up = 2;
                    break;
                case "payno":
                    model_order.is_up = 1;
                    break;
            }

            //直接支付
            BLL.payment bll_pay = new BLL.payment();
            Model.payment model_pay = new Model.payment();
            string url = "";
            if (pay_type == "payno")
            {
                model_pay = bll_pay.GetModel(pay_ment);
                if (model_pay == null)
                {
                    context.Response.Write("{\"status\":\"0\", \"msg\":\"支付方式不存在或已删除！\"}");
                    return;
                }
                model_order.payment_id = model_pay.id;
                if (model_pay.type == 1)
                {
                    //用户余额
                    if (model_pay.api_path == "balance")
                    {
                        if (model.amount < model_order.order_amount)
                        {
                            context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，您的用户余额不足请充值！\"}");
                            return;
                        }
                        decimal user_amount = model.amount - model_order.order_amount;
                        if (new BLL.users().UpdateField(model.id, "amount=" + user_amount) <= 0)
                        {
                            context.Response.Write("{\"status\":\"0\", \"msg\":\"扣除余额失败，支付失败！\"}");
                            return;
                        }
                        model_order.status = 2;
                        model_order.payment_status = 2;
                    }
                    else
                    {
                        url = siteConfig.webpath + "api/payment/" + model_pay.api_path + "/index.aspx?action=pay&pay_user_name=" + model.nick_name.Trim()
                                  + "&pay_order_type=" + DTEnums.AmountTypeEnum.BuyGoods.ToString() + "&pay_order_no=" + model_order.order_no + "&pay_order_amount=" + model_order.order_amount + "&pay_subject=商品订单";
                    }
                }
                else
                {
                    //货到付款
                }
            }


            if (!bll.Update(model_order))
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"支付方式保存失败！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"支付成功！\",\"url\":\"" + url + "\"}");
                return;
            }

        }



        private void add_order(HttpContext context)
        {


            int address_id = DTRequest.GetQueryInt("address");
            int freight_id = DTRequest.GetQueryInt("freight");
            string car_ids = DTRequest.GetQueryString("car_ids");


            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }

            //统计购物车
            BLL.express bll_express = new BLL.express();
            Model.express model_express = bll_express.GetModel(freight_id);
            if (model_express == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，该配送方式不存在或已删除！\"}");
                return;
            }

            BLL.address bll_address = new BLL.address();
            Model.address model_address = bll_address.GetModel(address_id);
            if (model_address == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，该收货信息不存在或已删除！\"}");
                return;
            }

            IList<Model.cart_items> iList = DTcms.Web.UI.ShopCart.GetList(model.group_id);
            if (iList == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，购物车为空，无法结算！\"}");
                return;
            }

            //保存订单=======================================================================
            Model.orders model_order = new Model.orders();

            model_order.order_no = "B" + Utils.GetOrderNumber(); //订单号B开头为商品订单
            model_order.user_id = model.id;
            model_order.user_name = model.user_name;
            model_order.payment_id = 0;
            model_order.express_id = model_express.id;
            model_order.accept_name = model_address.consignee;
            model_order.post_code = model_address.zipcode;
            model_order.telphone = model_address.consignee_phone;
            model_order.mobile = model_address.consignee_mobile;
            model_order.address = new BLL.province().GetModel(model_address.province).ProvinceName + "|" + new BLL.city().GetModel(model_address.city).CityName + "|" + new BLL.district().GetModel(model_address.distract).DistrictName + "|" + model_address.content;
            model_order.message = "";


            model_order.express_status = 1;
            model_order.express_fee = model_express.express_fee; //物流费用
            //如果是先款后货的话


            //购物积分,可为负数

            model_order.add_time = DateTime.Now;
            //商品详细列表
            decimal real_amount = 0;
            decimal payable_amount = 0;
            int total_point = 0;
            List<Model.order_goods> gls = new List<Model.order_goods>();
            BLL.standard bll_standard = new BLL.standard();
            foreach (Model.cart_items item in iList)
            {
                string[] arr_car_id = car_ids.Split('_');
                foreach (string str in arr_car_id)
                {

                    if ((item.id + "-" + item.standard + "-" + item.unit_id).Trim() == str)
                    {
                        //{   //40-1|红色,2|黑色_10-1|红色,2|黑色      商品ID-规格ID|规格值ID,规格ID|规格值ID-单位ID 
                        //    string[] arr_good_standard=str.Split('-');
                        //    string str_standard = "";
                        //    foreach (string str1 in arr_good_standard)
                        //    {
                        //        BLL.standard bll_standard = new BLL.standard();
                        //        Model.standard model_standard = bll_standard.GetModel(Convert.ToInt32(str1.Split('|')[0]));
                        //        if (model_standard != null)
                        //        {
                        //            str_standard += model_standard.title + ":" + str1.Split('|')[1];
                        //        }
                        //    }
                        string str_standard = "";
                        //190-14|41-4650
                        string standard_title_id = "";
                        string standard_value_id = "";
                        Model.article model_good = new BLL.article().GetModel(item.id);
                        if (model_good == null)
                        {
                            return;
                        }
                        string good_no = model_good.fields["goods_no"];
                        //规格
                        if (!string.IsNullOrEmpty(item.standard))
                        {
                            string[] arr_standard = item.standard.Split(',');
                            for (int i = 0; i < arr_standard.Length; i++)
                            {
                                Model.standard model_standard = bll_standard.GetModel(Convert.ToInt32(arr_standard[i].Split('|')[0]));
                                Model.standard_value model_standard_value = new BLL.standard_value().GetModel(Convert.ToInt32(arr_standard[i].Split('|')[1]));
                                if (model_standard != null && model_standard_value != null)
                                {

                                    str_standard += model_standard.title + ":" + arr_standard[i].Split('|')[1] + ",";
                                    standard_title_id += model_standard.id + ",";
                                    standard_value_id += model_standard_value.id + ",";
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(standard_title_id) && !string.IsNullOrEmpty(standard_value_id))
                        {
                            DataTable dt_standard_value = new BLL.standard_price().GetList("good_id='" + item.id + "' and standard_ids='" + standard_title_id.Substring(0, standard_title_id.Length - 1) + "' and standard_value_ids='" + standard_value_id.Substring(0, standard_value_id.Length - 1) + "'").Tables[0];
                            if (dt_standard_value != null && dt_standard_value.Rows.Count == 1)
                            {
                                good_no = dt_standard_value.Rows[0]["good_no"].ToString();
                            }
                        }

                        real_amount += item.user_price * item.quantity;
                        payable_amount += item.price * item.quantity;
                        total_point += item.point * item.quantity;


                        BLL.unit bll_unit = new BLL.unit();
                        Model.unit model_unit = bll_unit.GetModel(item.unit_id);
                        string str_unit = "";
                        if (model_unit != null)
                        {
                            str_unit = model_unit.title;
                            if (!string.IsNullOrEmpty(model_unit.content))
                            {
                                str_unit += "(" + model_unit.content + ")";
                            }
                        }

                        gls.Add(new Model.order_goods { goods_id = item.id, good_no = good_no, goods_title = item.title, goods_price = item.price, real_price = item.user_price, quantity = item.quantity, point = item.point, standard = (string.IsNullOrEmpty(str_standard) ? "" : str_standard.Substring(0, str_standard.Length - 1)), unit_id = item.unit_id, unit = str_unit });
                    }
                }

            }

            model_order.payable_amount = payable_amount;
            model_order.real_amount = real_amount;
            model.point = total_point;
            //订单总金额=实付商品金额+运费+支付手续费
            model_order.order_amount = model_order.real_amount + model_order.express_fee + model_order.payment_fee;
            model_order.order_goods = gls;
            int result = new BLL.orders().Add(model_order);
            if (result < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"订单保存过程中发生错误，请重新提交！\"}");
                return;
            }
            else
            {
                string[] arr_car_id = car_ids.Split('_');
                foreach (string str in arr_car_id)
                {
                    //清空购物车
                    DTcms.Web.UI.ShopCart.Clear(str);
                }
                context.Response.Write("{\"status\":1, \"msg\":\"提交订单成功！\",\"order_no\":\"" + model_order.order_no + "\",\"order_money\":\"" + model_order.order_amount + "\",\"user_money\":\"" + model.amount + "\",\"order_id\":\"" + result + "\"}");
                return;
            }

        }

        private void car_add_address(HttpContext context)
        {
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("Lost");
                return;
            }
            int province = DTRequest.GetFormInt("car_province");
            int city = DTRequest.GetFormInt("car_city");
            int district = DTRequest.GetFormInt("car_district");
            string address = DTRequest.GetFormString("car_address");
            string consignee = DTRequest.GetFormString("car_consignee");
            string consignee_mobile = DTRequest.GetFormString("car_consignee_mobile");
            string consignee_company = DTRequest.GetFormString("car_consignee_company");
            //非必填
            string zip_phone = DTRequest.GetFormString("car_zip_phone");
            string phone = DTRequest.GetFormString("car_phone");

            BLL.address bll = new BLL.address();
            Model.address model_address = new Model.address();
            model_address.user_id = model.id;
            model_address.province = province;
            model_address.city = city;
            model_address.distract = district;
            model_address.content = address;

            model_address.consignee = consignee;
            model_address.consignee_mobile = consignee_mobile;
            model_address.add_time = DateTime.Now;
            model_address.company_address = consignee_company;
            model_address.consignee_phone = zip_phone + "-" + phone;

            int new_id = bll.Add(model_address);
            if (new_id <= 0)
            {
                context.Response.Write("Error");
                return;
            }
            DataTable dt = bll.GetList("user_id=" + model.id).Tables[0];
            DataTable ret_dt = new DataTable();
            ret_dt.Columns.Add("id");
            ret_dt.Columns.Add("address");
            ret_dt.Columns.Add("selected");
            ret_dt.PrimaryKey = new DataColumn[] { ret_dt.Columns["id"] };

            foreach (DataRow dr in dt.Rows)
            {
                DataRow ret_dr = ret_dt.NewRow();
                ret_dr["id"] = dr["id"];
                string province1 = new BasePage().get_province_title(Convert.ToInt32(dr["province"]));
                string city1 = new BasePage().get_city_title(Convert.ToInt32(dr["city"]));
                string district1 = new BasePage().get_district_title(Convert.ToInt32(dr["distract"]));
                string address1 = dr["content"].ToString();
                string consignee1 = dr["consignee"].ToString();
                string consignee_mobile1 = dr["consignee_mobile"].ToString();
                string company_address = dr["company_address"].ToString();
                ret_dr["address"] = province1 + " " + city1 + " " + district1 + " " + address1 + "(公司地址:" + company_address + ")" + " " + consignee1 + ":" + consignee_mobile1;
                if (Convert.ToInt32(dr["id"]) == new_id)
                {
                    ret_dr["selected"] = 1;
                }
                else
                {
                    ret_dr["selected"] = 0;
                }
                ret_dt.Rows.Add(ret_dr);
            }

            if (ret_dt != null && ret_dt.Rows.Count > 0)
            {
                context.Response.Write(myJson.getJson(ret_dt));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }
        }

        private void get_address(HttpContext context)
        {
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("Error");
                return;
            }

            BLL.address bll = new BLL.address();
            DataTable dt = bll.GetList("user_id=" + model.id).Tables[0];

            DataTable ret_dt = new DataTable();
            ret_dt.Columns.Add("id");
            ret_dt.Columns.Add("address");
            ret_dt.PrimaryKey = new DataColumn[] { ret_dt.Columns["id"] };

            foreach (DataRow dr in dt.Rows)
            {
                DataRow ret_dr = ret_dt.NewRow();
                ret_dr["id"] = dr["id"];
                string province = new BasePage().get_province_title(Convert.ToInt32(dr["province"]));
                string city = new BasePage().get_city_title(Convert.ToInt32(dr["city"]));
                string district = new BasePage().get_district_title(Convert.ToInt32(dr["distract"]));
                string address = dr["content"].ToString();
                string consignee = dr["consignee"].ToString();
                string consignee_mobile = dr["consignee_mobile"].ToString();
                string company_address = dr["company_address"].ToString();
                ret_dr["address"] = province + " " + city + " " + district + " " + address + "(公司地址:" + company_address + ")" + " " + consignee + ":" + consignee_mobile;

                ret_dt.Rows.Add(ret_dr);
            }

            if (ret_dt != null && ret_dt.Rows.Count > 0)
            {
                context.Response.Write(myJson.getJson(ret_dt));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }
        }

        private void del_car(HttpContext context)
        {
            string car_id = DTRequest.GetQueryString("car_ids");
            try
            {
                string[] arr_car_ids = car_id.Split('^');

                foreach (string str in arr_car_ids)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        ShopCart.Clear(str);
                    }
                }
                context.Response.Write("{\"status\":\"1\",\"msg\":\"删除购物车成功！\"}");
                return;
            }
            catch
            {
                context.Response.Write("{\"status\":\"0\",\"msg\":\"删除购物车失败！\"}");
                return;
            }
        }

        private void change_car_count(HttpContext context)
        {
            string car_id = DTRequest.GetQueryString("car_id");
            int quantity = DTRequest.GetQueryInt("quantity", 1);
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }
            BLL.cart cartbll = new BLL.cart();
            Model.cart modelcart = new Model.cart();
            DataTable dt = cartbll.GetList("ProductName='" + car_id + "' and UserID='" + model.id + "'").Tables[0];

            if (dt.Rows.Count == 1)
            {
                modelcart = cartbll.GetModel(int.Parse(dt.Rows[0][0].ToString()));
                if (modelcart != null)
                {
                    modelcart.Counts = quantity.ToString();
                    cartbll.Update(modelcart);
                }
            }
            if (ShopCart.Update(car_id, quantity))
            {
                context.Response.Write("{\"status\":\"1\",\"msg\":\"修改购物车数量成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"0\",\"msg\":\"修改购物车数量失败！\"}");
                return;
            }
        }

        private void get_car_list(HttpContext context)
        {
            IList<DTcms.Model.cart_items> ls1 = get_cart_list();
            string car_ids = DTRequest.GetQueryString("car_ids");
            DataTable dt = new DataTable();
            dt.Columns.Add("car_id");
            dt.Columns.Add("goods_id");
            dt.Columns.Add("title");
            dt.Columns.Add("img_url");
            dt.Columns.Add("standard");
            dt.Columns.Add("category");
            dt.Columns.Add("price");
            dt.Columns.Add("user_price");
            dt.Columns.Add("stock_quantity");
            dt.Columns.Add("quantity");
            dt.Columns.Add("weight");
            dt.Columns.Add("unit");
            dt.PrimaryKey = new DataColumn[] { dt.Columns["car_id"] };

            foreach (Model.cart_items item in ls1)
            {
                if (!string.IsNullOrEmpty(car_ids))
                {
                    if (car_ids.IndexOf((item.id + "-" + item.standard)) <= -1)
                    {
                        continue;
                    }
                }

                DataRow dr = dt.NewRow();
                dr["car_id"] = item.id + "-" + item.standard + "-" + item.unit_id;
                dr["goods_id"] = item.id;
                dr["title"] = item.title;
                dr["img_url"] = item.img_url;
                string str_standard = "";
                string[] arr_standard = item.standard.Split(',');
                foreach (string str in arr_standard)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        BLL.standard_value bll_standard_value = new BLL.standard_value();
                        Model.standard_value model_standard_value = bll_standard_value.GetModel(Convert.ToInt32(str.Split('|')[1]));
                        if (model_standard_value != null)
                        {
                            str_standard += model_standard_value.value + " ";
                        }
                    }
                }
                dr["standard"] = str_standard.TrimEnd(' ');
                BLL.article bll = new BLL.article();
                Model.article model = bll.GetModel(item.id);
                dr["category"] = new BLL.article_category().GetTitle(model.category_id);
                if (new BasePage().GetUserInfo() != null)
                {
                    dr["price"] = item.user_price;
                }
                else
                {
                    dr["price"] = item.price;
                }

                dr["stock_quantity"] = item.stock_quantity;
                dr["quantity"] = item.quantity;
                dr["weight"] = model.fields["weight"];
                dr["unit"] = "";
                BLL.unit bll_unit = new BLL.unit();
                Model.unit model_unit = bll_unit.GetModel(item.unit_id);
                if (model_unit != null)
                {
                    string str_unit = model_unit.title;
                    if (!string.IsNullOrEmpty(model_unit.content))
                    {
                        str_unit += "(" + model_unit.content + ")";
                    }
                    dr["unit"] = str_unit;
                }
                dt.Rows.Add(dr);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                context.Response.Write(myJson.getJson(dt));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }
        }

        private IList<Model.cart_items> get_cart_list()
        {
            int group_id = 0;
            Model.users userModel = new BasePage().GetUserInfo();
            if (userModel != null)
            {
                group_id = userModel.group_id;
            }
            IList<Model.cart_items> ls = Web.UI.ShopCart.GetList(group_id);
            if (ls == null)
            {
                ls = new List<Model.cart_items>();
            }
            return ls;
        }

        private void add_car(HttpContext context)
        {
            int goods_id = DTRequest.GetQueryInt("goods_id");
            int goods_quantity = DTRequest.GetQueryInt("goods_quantity", 1);
            string standard = DTRequest.GetQueryString("standard");
            decimal unit_id = DTRequest.GetQueryDecimal("unit_id", 0);
            if (goods_id <= 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }
            //查找会员组
            int group_id = 0;
            Model.users groupModel = new Web.UI.BasePage().GetUserInfo();
            if (groupModel != null)
            {
                group_id = groupModel.group_id;
            }
            //规格ID|规格值ID,规格ID|规格值ID 
            BLL.standard_price bll_standard_price = new BLL.standard_price();
            string standard_value_ids = "";
            if (!string.IsNullOrEmpty(standard))
            {
                string[] arr_standard = standard.Split(',');
                foreach (string str in arr_standard)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        if (str.Split('|').Length == 2)
                        {
                            standard_value_ids += str.Split('|')[1] + ",";
                        }
                    }
                }
            }

            int total_quantity = goods_quantity;

            BLL.unit bll_unit = new BLL.unit();
            Model.unit model_unit = bll_unit.GetModel(unit_id);
            if (model_unit != null)
            {
                total_quantity = total_quantity * model_unit.quantity;
            }

            BLL.article bll_article = new BLL.article();
            Model.article model_article = bll_article.GetModel(goods_id);
            if (model_article != null)
            {
                if (model_article.fields["stock_quantity"] != null && model_article.fields["stock_quantity"].ToString() != "")
                {
                    if (Convert.ToInt32(model_article.fields["stock_quantity"]) < total_quantity)
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"对不起，该商品库存不足，购买失败！\"}");
                        return;
                    }
                }
                else
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该商品库存不足，购买失败！\"}");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(standard_value_ids))
            {
                standard_value_ids = standard_value_ids.Substring(0, standard_value_ids.Length - 1);
                DataTable dt_standard_price = bll_standard_price.GetList("standard_value_ids='" + standard_value_ids + "' and good_id=" + goods_id).Tables[0];
                if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt_standard_price.Rows[0]["stock_quantity"]) < total_quantity)
                    {
                        context.Response.Write("{\"status\":0, \"msg\":\"对不起，该商品库存不足，购买失败！\"}");
                        return;
                    }
                }
                else
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该商品库存不足，购买失败！\"}");
                    return;
                }
            }



            //统计购物车
            Web.UI.ShopCart.Add(goods_id + "-" + standard + "-" + unit_id, goods_quantity);
            Model.cart_total cartModel = Web.UI.ShopCart.GetTotal(group_id);
            context.Response.Write("{\"status\":1, \"msg\":\"商品已成功添加到购物车！\", \"quantity\":" + cartModel.total_quantity + ", \"amount\":" + cartModel.real_amount + "}");
            return;
        }





        private void get_goods(HttpContext context)
        {

            Model.users model_user = new BasePage().GetUserInfo();

            int goods_id = DTRequest.GetQueryInt("goods_id");

            BLL.article bll = new BLL.article();
            //商品表
            DataTable dt_article = bll.GetList(0, "id=" + goods_id, "id desc").Tables[0];
            if (dt_article.Rows.Count <= 0)
            {
                context.Response.Write("NotFind");
                return;
            }

            dt_article.TableName = "dt_goods";
            DataSet ds = new DataSet();
            ds.Tables.Add(dt_article.Copy());

            //销量
            DataTable dt_order_good_count = new BLL.orders().get_order_good_count(goods_id).Tables[0];

            if (dt_order_good_count != null && dt_order_good_count.Rows.Count > 0)
            {
                dt_order_good_count.TableName = "dt_order_good_count";
                ds.Tables.Add(dt_order_good_count.Copy());
            }

            //图片表
            DataTable dt_albums = bll.GetAlbumsList(5, "article_id=" + goods_id, "add_time desc").Tables[0];
            dt_albums.TableName = "dt_albums";
            if (dt_albums != null && dt_albums.Rows.Count > 0)
            {
                ds.Tables.Add(dt_albums.Copy());
            }
            //扩展字段表
            DataTable dt_attribute = bll.GetAttributeList(0, "article_id=" + goods_id, "").Tables[0];
            if (dt_attribute == null && dt_attribute.Rows.Count <= 0)
            {
                context.Response.Write("NotFind");
                return;
            }
            dt_attribute.TableName = "dt_attribute";
            ds.Tables.Add(dt_attribute.Copy());

            //规格表
            BLL.standard_price bll_standard_price = new BLL.standard_price();
            DataTable dt_standard_price = bll_standard_price.GetList("good_id=" + goods_id).Tables[0];
            if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
            {
                BLL.standard bll_standard = new BLL.standard();
                Model.article_category model_category = new BLL.article_category().GetModel(Convert.ToInt32(dt_article.Rows[0]["category_id"]));
                if (model_category == null)
                {
                    context.Response.Write("NotFind");
                    return;
                }
                DataTable dt_old_standard = bll_standard.GetList("'" + model_category.class_list + "' like '%,'+convert(nvarchar(10),category_id)+',%'").Tables[0];
                DataTable dt_standard = new DataTable();
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
                    if (dt_standard_value == null || dt_standard_value.Rows.Count <= 0)
                    {
                        context.Response.Write("NotFind");
                        return;
                    }

                    string str_value = "";
                    foreach (DataRow dr_value in dt_standard_value.Rows)
                    {
                        str_value += dr_value["id"].ToString() + "|" + dr_value["value"].ToString() + ",";
                    }
                    new_dr["value"] = str_value.TrimEnd(',');
                    dt_standard.Rows.Add(new_dr);

                }
                dt_standard.TableName = "dt_standard";
                if (dt_standard != null && dt_standard.Rows.Count > 0)
                {
                    ds.Tables.Add(dt_standard.Copy());
                }
            }
            //单位表
            BLL.unit bll_unit = new BLL.unit();
            DataTable dt_unit = bll_unit.GetList("good_id=" + goods_id).Tables[0];
            dt_unit.TableName = "dt_unit";
            if (dt_unit != null && dt_unit.Rows.Count > 0)
            {
                ds.Tables.Add(dt_unit.Copy());
            }
            BLL.meal_good bll_meal_good = new BLL.meal_good();
            //套餐()
            BLL.meal bll_meal = new BLL.meal();
            DataTable dt_meal = bll_meal.GetMealByGood(goods_id, "jiejuefangan").Tables[0];

            dt_meal.TableName = "dt_meal";
            if (dt_meal != null && dt_meal.Rows.Count > 0)
            {
                ds.Tables.Add(dt_meal.Copy());
                //套餐商品
                DataTable old_dt_meal_good = bll_meal_good.GetList("meal_id=" + dt_meal.Rows[0]["id"].ToString()).Tables[0];
                DataTable dt_meal_good = new DataTable();
                dt_meal_good.Columns.Add("meal_id");
                dt_meal_good.Columns.Add("good_standard_price");
                dt_meal_good.Columns.Add("title");
                dt_meal_good.Columns.Add("all_title");
                dt_meal_good.Columns.Add("img_url");
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

                            dt_meal_good.Rows.Add(new_dr);
                        }
                    }
                    dt_meal_good.TableName = "dt_meal_good";
                    ds.Tables.Add(dt_meal_good.Copy());
                }
            }
            //推荐
            DataTable dt_red = bll_meal.GetMealByGood(goods_id, "tuijiandapei").Tables[0];

            dt_red.TableName = "dt_red";
            if (dt_red != null && dt_red.Rows.Count > 0)
            {

                DataTable old_dt_red_good = bll_meal_good.GetList("meal_id=" + dt_red.Rows[0]["id"].ToString()).Tables[0];


                DataTable dt_red_good = new DataTable();
                dt_red_good.Columns.Add("meal_id");
                dt_red_good.Columns.Add("good_standard_price");
                dt_red_good.Columns.Add("title");
                dt_red_good.Columns.Add("all_title");
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

                            dt_red_good.Rows.Add(new_dr);
                        }
                    }
                    dt_red_good.TableName = "dt_red_good";
                    ds.Tables.Add(dt_red_good.Copy());
                }
            }



            context.Response.Write(myJson.getJson(ds));
        }

        private void save_address(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");

            int province = DTRequest.GetFormInt("province");
            int city = DTRequest.GetFormInt("city");
            int district = DTRequest.GetFormInt("district");
            string address = DTRequest.GetFormString("address");
            string zipcode = DTRequest.GetFormString("zipcode");
            string consignee = DTRequest.GetFormString("consignee");
            string consignee_mobile = DTRequest.GetFormString("consignee_mobile");
            string company_address = DTRequest.GetFormString("consignee_company");
            //非必填
            string zip_phone = DTRequest.GetFormString("zip_phone");
            string phone = DTRequest.GetFormString("phone");

            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }

            BLL.address bll = new BLL.address();
            Model.address model_address = bll.GetModel(id);
            if (model_address == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"当前内容不存在或已删除！\"}");
                return;
            }

            model_address.province = province;
            model_address.city = city;
            model_address.distract = district;
            model_address.content = address;

            model_address.consignee = consignee;
            model_address.consignee_mobile = consignee_mobile;
            model_address.company_address = company_address;
            model_address.consignee_phone = zip_phone + "-" + phone;
            model_address.zipcode = zipcode;

            if (bll.Update(model_address))
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"修改收货地址成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"修改收货地址失败！\"}");
                return;
            }
        }

        private void add_address(HttpContext context)
        {
            int province = DTRequest.GetFormInt("province");
            int city = DTRequest.GetFormInt("city");
            int district = DTRequest.GetFormInt("district");
            string address = DTRequest.GetFormString("address");
            string zipcode = DTRequest.GetFormString("zipcode");
            string consignee = DTRequest.GetFormString("consignee");
            string consignee_mobile = DTRequest.GetFormString("consignee_mobile");
            string company_address = DTRequest.GetFormString("consignee_company");
            //非必填
            string zip_phone = DTRequest.GetFormString("zip_phone");
            string phone = DTRequest.GetFormString("phone");





            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }

            BLL.address bll = new BLL.address();
            Model.address model_address = new Model.address();
            model_address.user_id = model.id;
            model_address.province = province;
            model_address.city = city;
            model_address.distract = district;
            model_address.content = address;

            model_address.consignee = consignee;
            model_address.consignee_mobile = consignee_mobile;
            model_address.add_time = DateTime.Now;
            model_address.company_address = company_address;

            model_address.consignee_phone = zip_phone + "-" + phone;
            model_address.zipcode = zipcode;

            if (bll.Add(model_address) > 0)
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"新增收货地址成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"新增收货地址失败！\"}");
                return;
            }

        }





        private void del_branch(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }
            BLL.branch bll = new BLL.branch();
            if (bll.Delete(id))
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"删除部门成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"删除部门失败！\"}");
                return;
            }
        }

        private void save_branch(HttpContext context)
        {
            string title = DTRequest.GetFormString("title");
            int id = DTRequest.GetFormInt("hd_id");
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }
            BLL.branch bll = new BLL.branch();
            Model.branch branch_model = bll.GetModel(id);
            if (branch_model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"当前内容不存在或已删除！\"}");
                return;
            }
            branch_model.title = title;

            if (bll.Update(branch_model))
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"修改部门成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"修改部门失败！\"}");
                return;

            }
        }

        private void add_branch(HttpContext context)
        {
            string title = DTRequest.GetFormString("title");
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"对不起，请重新登录！\"}");
                return;
            }
            BLL.branch bll = new BLL.branch();
            Model.branch branch_model = new Model.branch();
            branch_model.user_id = model.id;
            branch_model.add_time = DateTime.Now;
            branch_model.title = title;

            if (bll.Add(branch_model) > 0)
            {
                context.Response.Write("{\"status\":\"1\", \"msg\":\"新增部门成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":\"0\", \"msg\":\"新增部门失败！\"}");
                return;

            }
        }


        /// <summary>
        /// 添加分配账户员工
        /// </summary>
        /// <param name="context"></param>

        private void dealing_users(HttpContext context)
        {
            string username = DTRequest.GetString("username");
            string password = DTRequest.GetString("psd");
            string phone = DTRequest.GetString("phone");
            string email = DTRequest.GetString("email");
            string real_name = DTRequest.GetString("real_name");
            int branch = DTRequest.GetFormInt("branch_id");
            Model.users model = new Model.users();
            BLL.users bll = new BLL.users();
            Model.users model1 = new BasePage().GetUserInfo();
            if (model1 == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请重新登录！\"}");
                return;
            }

            if (bll.Exists(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该账户名已存在！\"}");
                return;

            }
            model.user_name = username;
            model.password = password;
            model.telphone = phone;
            model.real_name = real_name;
            model.email = email;
            model.branch_id = branch;
            model.user_status = 3;
            model.user_type = 1;
            model.parent_id = model1.id;
            model.group_id = 1;
            if (bll.Add(model) > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"添加员工成功！\"}");
                return;

            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，添加员工失败！\"}");
                return;

            }
        }

        private void save_user_info(HttpContext context)
        {
            string nick_name = DTRequest.GetFormString("nick_name");
            string email = DTRequest.GetFormString("email");
            string mobile = DTRequest.GetFormString("mobile");
            string sex = DTRequest.GetFormString("sex");
            string txtBirthday = DTRequest.GetFormString("txtBirthday");
            int province = DTRequest.GetFormInt("province");
            int city = DTRequest.GetFormInt("city");
            int district = DTRequest.GetFormInt("district");
            string address = DTRequest.GetFormString("address");

            string purchase = DTRequest.GetFormString("purchase");
            string purchase_mobile = DTRequest.GetFormString("purchase_mobile");

            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请重新登录！\"}");
                return;
            }
            BLL.users bll = new BLL.users();

            model.nick_name = nick_name;
            model.email = email;
            model.mobile = mobile;
            if (!string.IsNullOrEmpty(sex))
            {
                model.sex = sex;
            }
            else
            {
                model.sex = "保密";
            }
            if (!string.IsNullOrEmpty(txtBirthday))
            {
                model.birthday = Convert.ToDateTime(txtBirthday);
            }
            model.province = province;
            model.city = city;
            model.district = district;
            model.address = address;
            model.purchase = purchase;
            model.purchase_mobile = purchase_mobile;
            if (bll.Update(model))
            {
                BLL.address bll_address = new BLL.address();
                if (bll_address.GetList("user_id=" + model.id).Tables[0].Rows.Count <= 0)
                {
                    Model.address model_address = new Model.address();

                    if (model.user_type == 2)
                    {
                        model_address.consignee = purchase;
                        model_address.consignee_mobile = purchase_mobile;
                    }
                    else
                    {
                        model_address.consignee = nick_name;
                        model_address.consignee_mobile = mobile;
                    }
                    model_address.user_id = model.id;
                    model_address.province = model.province;
                    model_address.city = model.city;
                    model_address.distract = model.district;
                    model_address.content = model.address;
                    model_address.add_time = DateTime.Now;

                    bll_address.Add(model_address);
                }
                context.Response.Write("{\"status\":1, \"msg\":\"保存成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"保存失败！\"}");
                return;
            }

        }

        private void get_district_list(HttpContext context)
        {
            int city_id = DTRequest.GetQueryInt("city_id");

            BLL.district bll = new BLL.district();
            DataTable dt = bll.GetList("CityID=" + city_id).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                context.Response.Write(myJson.getJson(dt));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }
        }

        private void get_city_list(HttpContext context)
        {
            int province_id = DTRequest.GetQueryInt("province_id");

            BLL.city bll = new BLL.city();
            DataTable dt = bll.GetList("ProvinceID=" + province_id).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                context.Response.Write(myJson.getJson(dt));
                return;
            }
            else
            {
                context.Response.Write("Null");
                return;
            }

        }

        #region 提交评论的处理方法OK===========================
        private void comment_add(HttpContext context)
        {
            StringBuilder strTxt = new StringBuilder();
            BLL.article_comment bll = new BLL.article_comment();
            Model.article_comment model = new Model.article_comment();

            string code = DTRequest.GetFormString("txtCode");
            int article_id = DTRequest.GetQueryInt("article_id");
            string _content = DTRequest.GetFormString("txtContent");
            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            if (article_id == 0)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，参数传输有误！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_content))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请输入评论的内容！\"}");
                return;
            }
            //检查该文章是否存在
            Model.article artModel = new BLL.article().GetModel(article_id);
            if (artModel == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，主题不存在或已删除！\"}");
                return;
            }
            //检查用户是否登录
            int user_id = 0;
            string user_name = "匿名用户";
            Model.users userModel = new Web.UI.BasePage().GetUserInfo();
            if (userModel != null)
            {
                user_id = userModel.id;
                user_name = userModel.user_name;
            }
            model.channel_id = artModel.channel_id;
            model.article_id = artModel.id;
            model.content = Utils.ToHtml(_content);
            model.user_id = user_id;
            model.user_name = user_name;
            model.user_ip = DTRequest.GetIP();
            model.is_lock = siteConfig.commentstatus; //审核开关
            model.add_time = DateTime.Now;
            model.is_reply = 0;
            if (bll.Add(model) > 0)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，留言提交成功啦！\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"对不起，保存过程中发生错误！\"}");
            return;
        }
        #endregion

        #region 取得评论列表方法OK=============================
        private void comment_list(HttpContext context)
        {
            int article_id = DTRequest.GetQueryInt("article_id");
            int page_index = DTRequest.GetQueryInt("page_index");
            int page_size = DTRequest.GetQueryInt("page_size");
            int totalcount;
            StringBuilder strTxt = new StringBuilder();

            if (article_id == 0 || page_size == 0)
            {
                context.Response.Write("获取失败，传输参数有误！");
                return;
            }

            BLL.article_comment bll = new BLL.article_comment();
            DataSet ds = bll.GetList(page_size, page_index, string.Format("is_lock=0 and article_id={0}", article_id.ToString()), "add_time asc", out totalcount);
            //如果记录存在
            if (ds.Tables[0].Rows.Count > 0)
            {
                strTxt.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    strTxt.Append("{");
                    strTxt.Append("\"user_id\":" + dr["user_id"]);
                    strTxt.Append(",\"user_name\":\"" + dr["user_name"] + "\"");
                    if (Convert.ToInt32(dr["user_id"]) > 0)
                    {
                        Model.users userModel = new BLL.users().GetModel(Convert.ToInt32(dr["user_id"]));
                        if (userModel != null)
                        {
                            strTxt.Append(",\"avatar\":\"" + userModel.avatar + "\"");
                        }
                    }
                    strTxt.Append("");
                    strTxt.Append(",\"content\":\"" + Microsoft.JScript.GlobalObject.escape(dr["content"]) + "\"");
                    strTxt.Append(",\"add_time\":\"" + dr["add_time"] + "\"");
                    strTxt.Append(",\"is_reply\":" + dr["is_reply"]);
                    if (Convert.ToInt32(dr["is_reply"]) == 1)
                    {
                        strTxt.Append(",\"reply_content\":\"" + Microsoft.JScript.GlobalObject.escape(dr["reply_content"]) + "\"");
                        strTxt.Append(",\"reply_time\":\"" + dr["reply_time"] + "\"");
                    }
                    strTxt.Append("}");
                    //是否加逗号
                    if (i < ds.Tables[0].Rows.Count - 1)
                    {
                        strTxt.Append(",");
                    }

                }
                strTxt.Append("]");
            }
            context.Response.Write(strTxt.ToString());
        }
        #endregion

        #region 验证用户名是否可用OK===========================
        private void validate_username(HttpContext context)
        {
            string username = DTRequest.GetString("param");
            //如果为Null，退出
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{ \"info\":\"用户名不可为空\", \"status\":\"n\" }");
                return;
            }
            //过滤注册用户名字符
            string[] strArray = userConfig.regkeywords.Split(',');
            foreach (string s in strArray)
            {
                if (s.ToLower() == username.ToLower())
                {
                    context.Response.Write("{ \"info\":\"该用户名不可用\", \"status\":\"n\" }");
                    return;
                }
            }
            BLL.users bll = new BLL.users();
            //查询数据库
            if (!bll.Exists(username.Trim()))
            {
                context.Response.Write("{ \"info\":\"该用户名可用\", \"status\":\"y\" }");
                return;
            }
            context.Response.Write("{ \"info\":\"该用户名已被注册\", \"status\":\"n\" }");
            return;
        }
        #endregion

        #region 用户注册OK=====================================
        private void user_register(HttpContext context)
        {
            //string code = DTRequest.GetFormString("txtCode").Trim();
            //string invitecode = DTRequest.GetFormString("txtInviteCode").Trim();
            string username = Utils.ToHtml(DTRequest.GetFormString("username").Trim());
            string password = DTRequest.GetFormString("pwd").Trim();
            string email = Utils.ToHtml(DTRequest.GetFormString("email").Trim());
            int user_type = DTRequest.GetFormInt("hd_user_type");
            //string mobile = Utils.ToHtml(DTRequest.GetFormString("txtMobile").Trim());
            string userip = DTRequest.GetIP();

            if (user_type <= 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"参数错误，请通知管理员！\"}");
                return;
            }
            #region 检查各项并提示
            //检查是否开启会员功能
            if (siteConfig.memberstatus == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，会员功能已关闭，无法注册！\"}");
                return;
            }
            if (userConfig.regstatus == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，系统暂不允许注册新用户！\"}");
                return;
            }
            //校检验证码,如果注册使用手机短信则只需验证手机验证码，否则使用网页验证码
            //if (userConfig.regstatus == 2) //手机验证码
            //{
            //    string result = verify_sms_code(context, code);
            //    if (result != "success")
            //    {
            //        context.Response.Write(result);
            //        return;
            //    }
            //}
            //else //网页验证码
            //{
            //    string result = verify_code(context, code);
            //    if (result != "success")
            //    {
            //        context.Response.Write(result);
            //        return;
            //    }
            //}
            //检查用户输入信息是否为空
            if (username == "" || password == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误：用户名和密码不能为空！\"}");
                return;
            }
            if (userConfig.regemailditto == 0 && email == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误：电子邮箱不能为空！\"}");
                return;
            }
            //if (userConfig.mobilelogin == 1 && mobile == "")
            //{
            //    context.Response.Write("{\"status\":0, \"msg\":\"错误：手机号码不能为空！\"}");
            //    return;
            //}

            //检查用户名
            BLL.users bll = new BLL.users();
            Model.users model = new Model.users();
            if (bll.Exists(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户名已经存在！\"}");
                return;
            }
            //检查同一IP注册时隔
            if (userConfig.regctrl > 0)
            {
                if (bll.Exists(userip, userConfig.regctrl))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，同IP在" + userConfig.regctrl + "小时内禁止重复注册！\"}");
                    return;
                }
            }
            //不允许同一Email注册不同用户
            if (userConfig.regemailditto == 0 || userConfig.emaillogin == 1)
            {
                if (bll.ExistsEmail(email))
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，该邮箱已被注册！\"}");
                    return;
                }
            }
            //不允许同一手机号码注册不同用户
            //if (userConfig.mobilelogin == 1)
            //{
            //    if (bll.ExistsMobile(mobile))
            //    {
            //        context.Response.Write("{\"status\":0, \"msg\":\"对不起，该手机号码已被注册！\"}");
            //        return;
            //    }
            //}
            //检查默认组别是否存在
            Model.user_groups modelGroup = new BLL.user_groups().GetDefault();
            if (modelGroup == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"用户尚未分组，请联系网站管理员！\"}");
                return;
            }
            //检查是否通过邀请码注册
            //if (userConfig.regstatus == 2)
            //{
            //    string result1 = verify_invite_reg(username, invitecode);
            //    if (result1 != "success")
            //    {
            //        context.Response.Write(result1);
            //        return;
            //    }
            //}
            #endregion

            //保存注册信息
            model.group_id = modelGroup.id;
            model.user_name = username;
            model.salt = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            model.password = DESEncrypt.Encrypt(password, model.salt);
            model.email = email;
            model.user_type = user_type;
            //model.mobile = mobile;
            model.reg_ip = userip;
            model.reg_time = DateTime.Now;
            //设置对应的状态
            switch (userConfig.regverify)
            {
                case 0:
                    model.status = 0; //正常
                    break;
                case 3:
                    model.status = 2; //人工审核
                    break;
                default:
                    model.status = 1; //待验证
                    break;
            }
            int newId = bll.Add(model);
            if (newId < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"系统故障，请联系网站管理员！\"}");
                return;
            }
            model = bll.GetModel(newId);
            //赠送积分金额
            if (modelGroup.point > 0)
            {
                new BLL.user_point_log().Add(model.id, model.user_name, modelGroup.point, "注册赠送积分", false);
            }
            if (modelGroup.amount > 0)
            {
                new BLL.user_amount_log().Add(model.id, model.user_name, DTEnums.AmountTypeEnum.SysGive.ToString(), modelGroup.amount, "注册赠送金额", 1);
            }

            #region 判断是否发送欢迎消息
            if (userConfig.regmsgstatus == 1) //站内短消息
            {
                new BLL.user_message().Add(1, "", model.user_name, "欢迎您成为本站会员", userConfig.regmsgtxt);
            }
            else if (userConfig.regmsgstatus == 2) //发送邮件
            {
                //取得邮件模板内容
                Model.mail_template mailModel = new BLL.mail_template().GetModel("welcomemsg");
                if (mailModel != null)
                {
                    //替换标签
                    string mailTitle = mailModel.maill_title;
                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                    string mailContent = mailModel.content;
                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                    mailContent = mailContent.Replace("{username}", model.user_name);
                    //发送邮件
                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                        siteConfig.emailfrom, model.email, mailTitle, mailContent);
                }
            }
            //else if (userConfig.regmsgstatus == 3 && mobile != "") //发送短信
            //{
            //    Model.sms_template smsModel = new BLL.sms_template().GetModel("welcomemsg"); //取得短信内容
            //    if (smsModel != null)
            //    {
            //        //替换标签
            //        string msgContent = smsModel.content;
            //        msgContent = msgContent.Replace("{webname}", siteConfig.webname);
            //        msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
            //        msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
            //        msgContent = msgContent.Replace("{username}", model.user_name);
            //        //发送短信
            //        string tipMsg = string.Empty;
            //        new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
            //    }
            //}
            #endregion

            //需要Email验证
            if (userConfig.regverify == 1)
            {
                string result2 = verify_email(model);
                if (result2 != "success")
                {
                    context.Response.Write(result2);
                    return;
                }
                context.Response.Write("{\"status\":1, \"url\":\"" + new Web.UI.BasePage().linkurl("register") + "?action=sendmail&username=" + Utils.UrlEncode(model.user_name) + "\", \"msg\":\"注册成功，请进入邮箱验证激活账户！\"}");
            }
            //手机短信验证
            else if (userConfig.regverify == 2)
            {
                string result3 = verify_mobile(model);
                if (result3 != "success")
                {
                    context.Response.Write(result3);
                    return;
                }
                context.Response.Write("{\"status\":1, \"url\":\"" + new Web.UI.BasePage().linkurl("register") + "?action=sendsms&username=" + Utils.UrlEncode(model.user_name) + "\", \"msg\":\"注册成功，请查收短信验证激活账户！\"}");
            }
            //需要人工审核
            else if (userConfig.regverify == 3)
            {
                context.Response.Write("{\"status\":1, \"url\":\"" + new Web.UI.BasePage().linkurl("register") + "?action=verify&username=" + Utils.UrlEncode(model.user_name) + "\", \"msg\":\"注册成功，请等待审核通过！\"}");
            }
            else
            {
                context.Session[DTKeys.SESSION_USER_INFO] = model;
                context.Session.Timeout = 45;

                //防止Session提前过期
                Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "DTcms", model.user_name);
                Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "DTcms", model.password);

                //写入登录日志
                new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");


                context.Response.Write("{\"status\":1, \"url\":\"" + new Web.UI.BasePage().linkurl("register") + "?action=succeed&username=" + Utils.UrlEncode(model.user_name) + "\", \"msg\":\"注册成功，欢迎成为本站会员！\"}");
            }
            return;
        }

        #region 邀请注册处理方法OK=============================
        private string verify_invite_reg(string user_name, string invite_code)
        {
            if (string.IsNullOrEmpty(invite_code))
            {
                return "{\"status\":0, \"msg\":\"邀请码不能为空！\"}";
            }
            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel = codeBll.GetModel(invite_code);
            if (codeModel == null)
            {
                return "{\"status\":0, \"msg\":\"邀请码不正确或已过期！\"}";
            }
            if (userConfig.invitecodecount > 0)
            {
                if (codeModel.count >= userConfig.invitecodecount)
                {
                    codeModel.status = 1;
                    return "{\"status\":0, \"msg\":\"该邀请码已经被使用！\"}";
                }
            }
            //检查是否给邀请人增加积分
            if (userConfig.pointinvitenum > 0)
            {
                new BLL.user_point_log().Add(codeModel.user_id, codeModel.user_name, userConfig.pointinvitenum, "邀请用户【" + user_name + "】注册获得积分", true);
            }
            //更改邀请码状态
            codeModel.count += 1;
            codeBll.Update(codeModel);
            return "success";
        }
        #endregion

        #region Email验证发送邮件OK============================
        private string verify_email(Model.users userModel)
        {
            //生成随机码
            string strcode = Utils.GetCheckCode(20);
            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel;
            //检查是否重复提交
            codeModel = codeBll.GetModel(userModel.user_name, DTEnums.CodeEnum.RegVerify.ToString(), "d");
            if (codeModel == null)
            {
                codeModel = new Model.user_code();
                codeModel.user_id = userModel.id;
                codeModel.user_name = userModel.user_name;
                codeModel.type = DTEnums.CodeEnum.RegVerify.ToString();
                codeModel.str_code = strcode;
                codeModel.eff_time = DateTime.Now.AddDays(userConfig.regemailexpired);
                codeModel.add_time = DateTime.Now;
                new BLL.user_code().Add(codeModel);
            }
            //获得邮件内容
            Model.mail_template mailModel = new BLL.mail_template().GetModel("regverify");
            if (mailModel == null)
            {
                return "{\"status\":0, \"msg\":\"邮件发送失败，邮件模板内容不存在！\"}";
            }
            //替换模板内容
            string titletxt = mailModel.maill_title;
            string bodytxt = mailModel.content;
            titletxt = titletxt.Replace("{webname}", siteConfig.webname);
            titletxt = titletxt.Replace("{username}", userModel.user_name);
            bodytxt = bodytxt.Replace("{webname}", siteConfig.webname);
            bodytxt = bodytxt.Replace("{webtel}", siteConfig.webtel);
            bodytxt = bodytxt.Replace("{weburl}", siteConfig.weburl);
            bodytxt = bodytxt.Replace("{username}", userModel.user_name);
            bodytxt = bodytxt.Replace("{valid}", userConfig.regemailexpired.ToString());
            bodytxt = bodytxt.Replace("{linkurl}", "http://" + HttpContext.Current.Request.Url.Authority.ToLower() + new Web.UI.BasePage().linkurl("register") + "?action=checkmail&strcode=" + codeModel.str_code);
            //发送邮件
            try
            {
                DTMail.sendMail(siteConfig.emailsmtp,
                    siteConfig.emailusername,
                    DESEncrypt.Decrypt(siteConfig.emailpassword),
                    siteConfig.emailnickname,
                    siteConfig.emailfrom,
                    userModel.email,
                    titletxt, bodytxt);
            }
            catch
            {
                return "{\"status\":0, \"msg\":\"邮件发送失败，请联系本站管理员！\"}";
            }
            return "success";
        }
        #endregion

        #region 手机验证发送短信OK=============================
        private string verify_mobile(Model.users userModel)
        {
            //生成随机码
            string strcode = Utils.Number(4);
            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel;
            //检查是否重复提交
            codeModel = codeBll.GetModel(userModel.user_name, DTEnums.CodeEnum.RegVerify.ToString(), "n");
            if (codeModel == null)
            {
                codeModel = new Model.user_code();
                codeModel.user_id = userModel.id;
                codeModel.user_name = userModel.user_name;
                codeModel.type = DTEnums.CodeEnum.RegVerify.ToString();
                codeModel.str_code = strcode;
                codeModel.eff_time = DateTime.Now.AddMinutes(userConfig.regsmsexpired);
                codeModel.add_time = DateTime.Now;
                new BLL.user_code().Add(codeModel);
            }
            //获得短信模板内容
            Model.sms_template smsModel = new BLL.sms_template().GetModel("usercode");
            if (smsModel == null)
            {
                return "{\"status\":0, \"msg\":\"发送失败，短信模板内容不存在！\"}";
            }
            //替换模板内容
            string msgContent = smsModel.content;
            msgContent = msgContent.Replace("{webname}", siteConfig.webname);
            msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
            msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
            msgContent = msgContent.Replace("{username}", userModel.user_name);
            msgContent = msgContent.Replace("{code}", codeModel.str_code);
            msgContent = msgContent.Replace("{valid}", userConfig.regsmsexpired.ToString());
            //发送短信
            string tipMsg = string.Empty;
            bool sendStatus = new BLL.sms_message().Send(userModel.mobile, msgContent, 2, out tipMsg);
            if (!sendStatus)
            {
                return "{\"status\": 0, \"msg\": \"短信发送失败，" + tipMsg + "\"}";
            }
            return "success";
        }
        #endregion

        #endregion

        #region 申请邀请码OK===================================
        private void user_invite_code(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            //检查是否开启邀请注册
            if (userConfig.regstatus != 2)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，系统不允许通过邀请注册！\"}");
                return;
            }
            BLL.user_code codeBll = new BLL.user_code();
            //检查申请是否超过限制
            if (userConfig.invitecodenum > 0)
            {
                int result = codeBll.GetCount("user_name='" + model.user_name + "' and type='" + DTEnums.CodeEnum.Register.ToString() + "' and datediff(d,add_time,getdate())=0");
                if (result >= userConfig.invitecodenum)
                {
                    context.Response.Write("{\"status\":0, \"msg\":\"对不起，您申请邀请码的数量已超过每天限制！\"}");
                    return;
                }
            }
            //删除过期的邀请码
            codeBll.Delete("type='" + DTEnums.CodeEnum.Register.ToString() + "' and status=1 or datediff(d,eff_time,getdate())>0");
            //随机取得邀请码
            string str_code = Utils.GetCheckCode(8);
            Model.user_code codeModel = new Model.user_code();
            codeModel.user_id = model.id;
            codeModel.user_name = model.user_name;
            codeModel.type = DTEnums.CodeEnum.Register.ToString();
            codeModel.str_code = str_code;
            if (userConfig.invitecodeexpired > 0)
            {
                codeModel.eff_time = DateTime.Now.AddDays(userConfig.invitecodeexpired);
            }
            codeBll.Add(codeModel);
            context.Response.Write("{\"status\":1, \"msg\":\"恭喜您，申请邀请码已成功！\"}");
            return;
        }
        #endregion

        #region 发送注册验证码短信OK===========================
        private void user_register_smscode(HttpContext context)
        {
            string mobile = DTRequest.GetFormString("mobile");
            if (mobile == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"发送失败，请填写手机号码！\"}");
                return;
            }
            //检查是否过快
            string cookie = Utils.GetCookie("user_register_sms");
            if (cookie == mobile)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"刚已发送过短信，请2分钟后再试！\"}");
                return;
            }
            Model.sms_template smsModel = new BLL.sms_template().GetModel("usercode"); //取得短信内容
            if (smsModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"发送失败，短信模板不存在！\"}");
                return;
            }
            string strcode = Utils.Number(4); //随机验证码
            //替换标签
            string msgContent = smsModel.content;
            msgContent = msgContent.Replace("{webname}", siteConfig.webname);
            msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
            msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
            msgContent = msgContent.Replace("{code}", strcode);
            msgContent = msgContent.Replace("{valid}", "二十");
            //发送短信
            string tipMsg = string.Empty;
            bool result = new BLL.sms_message().Send(mobile, msgContent, 1, out tipMsg);
            if (!result)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"发送失败，" + tipMsg + "\"}");
                return;
            }
            //写入SESSION，保存验证码
            context.Session[DTKeys.SESSION_SMS_CODE] = strcode;
            Utils.WriteCookie("user_register_sms", mobile, 2); //2分钟内无重复发送
            context.Response.Write("{\"status\":1, \"msg\":\"短信发送成功，请注意查收验证码！\"}");
            return;
        }
        #endregion

        #region 发送注册验证邮件=============================
        private void user_verify_email(HttpContext context)
        {
            string username = DTRequest.GetFormString("username");
            //检查是否过快
            string cookie = Utils.GetCookie("user_reg_email");
            if (cookie == username)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"发送邮件间隔为20分钟，您刚才已经提交过啦，休息一下再来吧！\"}");
                return;
            }
            Model.users model = new BLL.users().GetModel(username);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户不存在或已删除！\"}");
                return;
            }
            if (model.status != 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户无法进行邮箱验证！\"}");
                return;
            }
            string result = verify_email(model);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            context.Response.Write("{\"status\":1, \"msg\":\"邮件已经发送成功啦！\"}");
            Utils.WriteCookie("user_reg_email", username, 20); //20分钟内无重复发送
            return;
        }
        #endregion

        #region 用户登录OK=====================================
        private void user_login(HttpContext context)
        {
            string username = DTRequest.GetFormString("username");
            string password = DTRequest.GetFormString("pwd");
            string remember = DTRequest.GetFormString("chkRemember");
            //检查用户名密码
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"温馨提示：请输入用户名或密码！\"}");
                return;
            }

            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(username, password, userConfig.emaillogin, userConfig.mobilelogin, true);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误提示：用户名或密码错误，请重试！\"}");
                return;
            }
            //检查用户是否通过验证
            if (model.status == 1) //待验证
            {
                context.Response.Write("{\"status\":1, \"url\":\"" + new Web.UI.BasePage().linkurl("register") + "?action=sendmail&username=" + Utils.UrlEncode(model.user_name) + "\", \"msg\":\"会员尚未通过验证！\"}");
                return;
            }
            else if (model.status == 2) //待审核
            {
                context.Response.Write("{\"status\":1, \"url\":\"" + new Web.UI.BasePage().linkurl("register") + "?action=verify&username=" + Utils.UrlEncode(model.user_name) + "\", \"msg\":\"会员尚未通过审核！\"}");
                return;
            }
            context.Session[DTKeys.SESSION_USER_INFO] = model;
            context.Session.Timeout = 45;
            //记住登录状态下次自动登录
            if (remember.ToLower() == "true")
            {
                Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "DTcms", model.user_name, 43200);
                Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "DTcms", model.password, 43200);
            }
            else
            {
                //防止Session提前过期
                Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "DTcms", model.user_name);
                Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "DTcms", model.password);
            }

            //写入登录日志
            new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");
            //返回URL
            context.Response.Write("{\"status\":1, \"msg\":\"会员登录成功！\"}");
            return;
        }
        #endregion

        #region 检查用户是否登录OK=============================
        private void user_check_login(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"username\":\"匿名用户\"}");
                return;
            }
            context.Response.Write("{\"status\":1, \"username\":\"" + model.user_name + "\"}");
        }
        #endregion

        #region 绑定第三方登录账户OK===========================
        private void user_oauth_bind(HttpContext context)
        {
            //检查URL参数
            if (context.Session["oauth_name"] == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：授权参数不正确！\"}");
                return;
            }
            //获取授权信息
            string result = Utils.UrlExecute(siteConfig.webpath + "api/oauth/" + context.Session["oauth_name"].ToString() + "/result_json.aspx");
            if (result.Contains("error"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：请检查URL是否正确！\"}");
                return;
            }
            //反序列化JSON
            Dictionary<string, object> dic = JsonMapper.ToObject<Dictionary<string, object>>(result);
            if (dic["ret"].ToString() != "0")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误代码：" + dic["ret"] + "，描述：" + dic["msg"] + "\"}");
                return;
            }

            //检查用户名密码
            string username = DTRequest.GetString("txtUserName");
            string password = DTRequest.GetString("txtPassword");
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"温馨提示：请输入用户名或密码！\"}");
                return;
            }
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(username, password, userConfig.emaillogin, userConfig.mobilelogin, true);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误提示：用户名或密码错误！\"}");
                return;
            }
            //开始绑定
            Model.user_oauth oauthModel = new Model.user_oauth();
            oauthModel.oauth_name = dic["oauth_name"].ToString();
            oauthModel.user_id = model.id;
            oauthModel.user_name = model.user_name;
            oauthModel.oauth_access_token = dic["oauth_access_token"].ToString();
            oauthModel.oauth_openid = dic["oauth_openid"].ToString();
            int newId = new BLL.user_oauth().Add(oauthModel);
            if (newId < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"错误提示：绑定过程中出错，请重新获取！\"}");
                return;
            }
            context.Session[DTKeys.SESSION_USER_INFO] = model;
            context.Session.Timeout = 45;
            //记住登录状态，防止Session提前过期
            Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "DTcms", model.user_name);
            Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "DTcms", model.password);
            //写入登录日志
            new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");
            //返回URL
            context.Response.Write("{\"status\":1, \"msg\":\"会员登录成功！\"}");
            return;
        }
        #endregion

        #region 注册第三方登录账户OK===========================
        private void user_oauth_register(HttpContext context)
        {
            //检查URL参数
            if (context.Session["oauth_name"] == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：授权参数不正确！\"}");
                return;
            }
            //获取授权信息
            string result = Utils.UrlExecute(siteConfig.webpath + "api/oauth/" + context.Session["oauth_name"].ToString() + "/result_json.aspx");
            if (result.Contains("error"))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误提示：请检查URL是否正确！\"}");
                return;
            }
            //反序列化JSON
            Dictionary<string, object> dic = JsonMapper.ToObject<Dictionary<string, object>>(result);
            if (dic["ret"].ToString() != "0")
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"错误代码：" + dic["ret"] + "，" + dic["msg"] + "\"}");
                return;
            }

            string password = DTRequest.GetFormString("txtPassword").Trim();
            string email = Utils.ToHtml(DTRequest.GetFormString("txtEmail").Trim());
            string mobile = Utils.ToHtml(DTRequest.GetFormString("txtMobile").Trim());
            string userip = DTRequest.GetIP();

            BLL.users bll = new BLL.users();
            Model.users model = new Model.users();
            //检查默认组别是否存在
            Model.user_groups modelGroup = new BLL.user_groups().GetDefault();
            if (modelGroup == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"用户尚未分组，请联系管理员！\"}");
                return;
            }
            //保存注册信息
            model.group_id = modelGroup.id;
            model.user_name = bll.GetRandomName(10); //随机用户名
            model.salt = Utils.GetCheckCode(6); //获得6位的salt加密字符串
            model.password = DESEncrypt.Encrypt(password, model.salt);
            model.email = email;
            model.mobile = mobile;
            if (!string.IsNullOrEmpty(dic["nick"].ToString()))
            {
                model.nick_name = dic["nick"].ToString();
            }
            if (dic["avatar"].ToString().StartsWith("http://"))
            {
                model.avatar = dic["avatar"].ToString();
            }
            if (!string.IsNullOrEmpty(dic["sex"].ToString()))
            {
                model.sex = dic["sex"].ToString();
            }
            if (!string.IsNullOrEmpty(dic["birthday"].ToString()))
            {
                model.birthday = Utils.StrToDateTime(dic["birthday"].ToString());
            }
            model.reg_ip = userip;
            model.reg_time = DateTime.Now;
            model.status = 0; //设置为正常状态
            int newId = bll.Add(model);
            if (newId < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"注册失败，请联系网站管理员！\"}");
                return;
            }
            model = bll.GetModel(newId);
            //赠送积分金额
            if (modelGroup.point > 0)
            {
                new BLL.user_point_log().Add(model.id, model.user_name, modelGroup.point, "注册赠送积分", false);
            }
            if (modelGroup.amount > 0)
            {
                new BLL.user_amount_log().Add(model.id, model.user_name, DTEnums.AmountTypeEnum.SysGive.ToString(), modelGroup.amount, "注册赠送金额", 1);
            }
            //判断是否发送欢迎消息
            if (userConfig.regmsgstatus == 1) //站内短消息
            {
                new BLL.user_message().Add(1, "", model.user_name, "欢迎您成为本站会员", userConfig.regmsgtxt);
            }
            else if (userConfig.regmsgstatus == 2) //发送邮件
            {
                //取得邮件模板内容
                Model.mail_template mailModel = new BLL.mail_template().GetModel("welcomemsg");
                if (mailModel != null)
                {
                    //替换标签
                    string mailTitle = mailModel.maill_title;
                    mailTitle = mailTitle.Replace("{username}", model.user_name);
                    string mailContent = mailModel.content;
                    mailContent = mailContent.Replace("{webname}", siteConfig.webname);
                    mailContent = mailContent.Replace("{weburl}", siteConfig.weburl);
                    mailContent = mailContent.Replace("{webtel}", siteConfig.webtel);
                    mailContent = mailContent.Replace("{username}", model.user_name);
                    //发送邮件
                    DTMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername, siteConfig.emailpassword, siteConfig.emailnickname,
                        siteConfig.emailfrom, model.email, mailTitle, mailContent);
                }
            }
            else if (userConfig.regmsgstatus == 3 && mobile != "") //发送短信
            {
                Model.sms_template smsModel = new BLL.sms_template().GetModel("welcomemsg"); //取得短信内容
                if (smsModel != null)
                {
                    //替换标签
                    string msgContent = smsModel.content;
                    msgContent = msgContent.Replace("{webname}", siteConfig.webname);
                    msgContent = msgContent.Replace("{weburl}", siteConfig.weburl);
                    msgContent = msgContent.Replace("{webtel}", siteConfig.webtel);
                    msgContent = msgContent.Replace("{username}", model.user_name);
                    //发送短信
                    string tipMsg = string.Empty;
                    new BLL.sms_message().Send(model.mobile, msgContent, 2, out tipMsg);
                }
            }
            //绑定到对应的授权类型
            Model.user_oauth oauthModel = new Model.user_oauth();
            oauthModel.oauth_name = dic["oauth_name"].ToString();
            oauthModel.user_id = model.id;
            oauthModel.user_name = model.user_name;
            oauthModel.oauth_access_token = dic["oauth_access_token"].ToString();
            oauthModel.oauth_openid = dic["oauth_openid"].ToString();
            new BLL.user_oauth().Add(oauthModel);

            context.Session[DTKeys.SESSION_USER_INFO] = model;
            context.Session.Timeout = 45;
            //记住登录状态，防止Session提前过期
            Utils.WriteCookie(DTKeys.COOKIE_USER_NAME_REMEMBER, "DTcms", model.user_name);
            Utils.WriteCookie(DTKeys.COOKIE_USER_PWD_REMEMBER, "DTcms", model.password);
            //写入登录日志
            new BLL.user_login_log().Add(model.id, model.user_name, "会员登录");
            //返回URL
            context.Response.Write("{\"status\":1, \"msg\":\"会员登录成功！\"}");
            return;
        }
        #endregion

        #region 修改用户信息OK=================================
        private void user_info_edit(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string email = Utils.ToHtml(DTRequest.GetFormString("txtEmail"));
            string nick_name = Utils.ToHtml(DTRequest.GetFormString("txtNickName"));
            string sex = DTRequest.GetFormString("rblSex");
            string birthday = DTRequest.GetFormString("txtBirthday");
            string telphone = Utils.ToHtml(DTRequest.GetFormString("txtTelphone"));
            string mobile = Utils.ToHtml(DTRequest.GetFormString("txtMobile"));
            string qq = Utils.ToHtml(DTRequest.GetFormString("txtQQ"));
            string address = Utils.ToHtml(context.Request.Form["txtAddress"]);
            string safe_question = Utils.ToHtml(context.Request.Form["txtSafeQuestion"]);
            string safe_answer = Utils.ToHtml(context.Request.Form["txtSafeAnswer"]);
            //检查昵称
            if (nick_name == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您的姓名昵称！\"}");
                return;
            }
            //检查邮箱
            if (userConfig.emaillogin == 1 && email == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您邮箱帐号！\"}");
                return;
            }
            //检查手机
            if (userConfig.mobilelogin == 1 && mobile == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入手机号码！\"}");
                return;
            }

            //开始写入数据库
            model.email = email;
            model.nick_name = nick_name;
            model.sex = sex;
            DateTime _birthday;
            if (DateTime.TryParse(birthday, out _birthday))
            {
                model.birthday = _birthday;
            }
            model.telphone = telphone;
            model.mobile = mobile;
            model.qq = qq;
            model.address = address;
            model.safe_question = safe_question;
            model.safe_answer = safe_answer;


            new BLL.users().Update(model);
            context.Response.Write("{\"status\":1, \"msg\":\"账户资料已修改成功！\"}");
            return;
        }
        #endregion

        #region 确认裁剪用户头像OK=============================
        private void user_avatar_crop(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string fileName = DTRequest.GetFormString("hideFileName");
            int x1 = DTRequest.GetFormInt("hideX1");
            int y1 = DTRequest.GetFormInt("hideY1");
            int w = DTRequest.GetFormInt("hideWidth");
            int h = DTRequest.GetFormInt("hideHeight");
            //检查是否图片

            //检查参数
            if (!Utils.FileExists(fileName) || w == 0 || h == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请先上传一张图片！\"}");
                return;
            }
            //取得保存的新文件名
            UpLoad upFiles = new UpLoad();
            bool result = upFiles.cropSaveAs(fileName, fileName, 180, 180, w, h, x1, y1);
            if (!result)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"图片裁剪过程中发生意外错误！\"}");
                return;
            }
            //删除原用户头像
            Utils.DeleteFile(model.avatar);
            model.avatar = fileName;
            //修改用户头像
            new BLL.users().UpdateField(model.id, "avatar='" + model.avatar + "'");
            context.Response.Write("{\"status\": 1, \"msg\": \"" + model.avatar + "\"}");
            return;
        }
        #endregion

        #region 修改登录密码OK=================================
        private void user_password_edit(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int user_id = model.id;
            string oldpassword = DTRequest.GetFormString("txtOldPassword");
            string password = DTRequest.GetFormString("txtPassword");
            //检查输入的旧密码
            if (string.IsNullOrEmpty(oldpassword))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入您的旧登录密码！\"}");
                return;
            }
            //检查输入的新密码
            if (string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入您的新登录密码！\"}");
                return;
            }
            //旧密码是否正确
            if (model.password != DESEncrypt.Encrypt(oldpassword, model.salt))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的旧密码不正确！\"}");
                return;
            }
            //执行修改操作
            model.password = DESEncrypt.Encrypt(password, model.salt);
            new BLL.users().Update(model);
            context.Response.Write("{\"status\":1, \"msg\":\"您的密码已修改成功，请记住新密码！\"}");
            return;
        }
        #endregion

        #region 邮箱取回密码=================================
        private void user_getpassword(HttpContext context)
        {
            string code = DTRequest.GetFormString("txtCode");
            string username = DTRequest.GetFormString("txtUserName").Trim();
            //检查用户名是否正确
            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户名不可为空！\"}");
                return;
            }
            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            //检查用户信息
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(username);
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的用户名不存在！\"}");
                return;
            }
            if (string.IsNullOrEmpty(model.email))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您尚未设置邮箱地址，无法使用取回密码功能！\"}");
                return;
            }
            //生成随机码
            string strcode = Utils.GetCheckCode(20);
            //获得邮件内容
            Model.mail_template mailModel = new BLL.mail_template().GetModel("getpassword");
            if (mailModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"邮件发送失败，邮件模板内容不存在！\"}");
                return;
            }
            //检查是否重复提交
            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel;
            codeModel = codeBll.GetModel(username, DTEnums.CodeEnum.RegVerify.ToString(), "d");
            if (codeModel == null)
            {
                codeModel = new Model.user_code();
                //写入数据库
                codeModel.user_id = model.id;
                codeModel.user_name = model.user_name;
                codeModel.type = DTEnums.CodeEnum.Password.ToString();
                codeModel.str_code = strcode;
                codeModel.eff_time = DateTime.Now.AddDays(userConfig.regemailexpired);
                codeModel.add_time = DateTime.Now;
                codeBll.Add(codeModel);
            }
            //替换模板内容
            string titletxt = mailModel.maill_title;
            string bodytxt = mailModel.content;
            titletxt = titletxt.Replace("{webname}", siteConfig.webname);
            titletxt = titletxt.Replace("{username}", model.user_name);
            bodytxt = bodytxt.Replace("{webname}", siteConfig.webname);
            bodytxt = bodytxt.Replace("{weburl}", siteConfig.weburl);
            bodytxt = bodytxt.Replace("{webtel}", siteConfig.webtel);
            bodytxt = bodytxt.Replace("{valid}", userConfig.regemailexpired.ToString());
            bodytxt = bodytxt.Replace("{username}", model.user_name);
            bodytxt = bodytxt.Replace("{linkurl}", "http://" + HttpContext.Current.Request.Url.Authority.ToLower() + new BasePage().linkurl("repassword", "reset", strcode));
            //发送邮件
            try
            {
                DTMail.sendMail(siteConfig.emailsmtp,
                    siteConfig.emailusername,
                    DESEncrypt.Decrypt(siteConfig.emailpassword),
                    siteConfig.emailnickname,
                    siteConfig.emailfrom,
                    model.email,
                    titletxt, bodytxt);
            }
            catch
            {
                context.Response.Write("{\"status\":0, \"msg\":\"邮件发送失败，请联系本站管理员！\"}");
                return;
            }
            context.Response.Write("{\"status\":1, \"msg\":\"邮件发送成功，请登录您的邮箱找回登录密码！\"}");
            return;
        }
        #endregion

        #region 邮箱重设密码OK=================================
        private void user_repassword(HttpContext context)
        {
            string code = context.Request.Form["txtCode"];
            string strcode = context.Request.Form["hideCode"];
            string password = context.Request.Form["txtPassword"];

            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            //检查验证字符串
            if (string.IsNullOrEmpty(strcode))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"邮件验证码不存在或已删除！\"}");
                return;
            }
            //检查输入的新密码
            if (string.IsNullOrEmpty(password))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"请输入您的新密码！\"}");
                return;
            }

            BLL.user_code codeBll = new BLL.user_code();
            Model.user_code codeModel = codeBll.GetModel(strcode);
            if (codeModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"邮件验证码不存在或已过期！\"}");
                return;
            }
            //验证用户是否存在
            BLL.users userBll = new BLL.users();
            if (!userBll.Exists(codeModel.user_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"该用户不存在或已被删除！\"}");
                return;
            }
            Model.users userModel = userBll.GetModel(codeModel.user_id);
            //执行修改操作
            userModel.password = DESEncrypt.Encrypt(password, userModel.salt);
            userBll.Update(userModel);
            //更改验证字符串状态
            codeModel.count = 1;
            codeModel.status = 1;
            codeBll.Update(codeModel);
            context.Response.Write("{\"status\":1, \"msg\":\"修改密码成功，请记住新密码！\"}");
            return;
        }
        #endregion

        #region 删除短消息OK===================================
        private void user_message_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (check_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                new BLL.user_message().Delete(int.Parse(arrId[i]), model.user_name);
            }
            context.Response.Write("{\"status\":1, \"msg\":\"删除短消息成功！\"}");
            return;
        }
        #endregion

        #region 发布站内短消息OK===============================
        private void user_message_add(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string code = context.Request.Form["txtCode"];
            string send_save = DTRequest.GetFormString("sendSave");
            string user_name = Utils.ToHtml(DTRequest.GetFormString("txtUserName"));
            string title = Utils.ToHtml(DTRequest.GetFormString("txtTitle"));
            string content = Utils.ToHtml(DTRequest.GetFormString("txtContent"));
            //校检验证码
            string result = verify_code(context, code);
            if (result != "success")
            {
                context.Response.Write(result);
                return;
            }
            //检查用户名
            if (user_name == "" || !new BLL.users().Exists(user_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，该用户不存在或已删除！\"}");
                return;
            }
            //检查标题
            if (title == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入短消息标题！\"}");
                return;
            }
            //检查内容
            if (content == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入短消息内容！\"}");
                return;
            }
            //保存数据
            Model.user_message modelMessage = new Model.user_message();
            modelMessage.type = 2;
            modelMessage.post_user_name = model.user_name;
            modelMessage.accept_user_name = user_name;
            modelMessage.title = title;
            modelMessage.content = Utils.ToHtml(content);
            new BLL.user_message().Add(modelMessage);
            if (send_save == "true") //保存到收件箱
            {
                modelMessage.type = 3;
                new BLL.user_message().Add(modelMessage);
            }
            context.Response.Write("{\"status\":1, \"msg\":\"发布短信息成功！\"}");
            return;
        }
        #endregion

        #region 用户兑换积分OK=================================
        private void user_point_convert(HttpContext context)
        {
            //检查系统是否启用兑换积分功能
            if (userConfig.pointcashrate == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，网站已关闭兑换积分功能！\"}");
                return;
            }
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            int amout = DTRequest.GetFormInt("txtAmount");
            string password = DTRequest.GetFormString("txtPassword");
            if (model.amount < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您账户上的余额不足！\"}");
                return;
            }
            if (amout < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，最小兑换金额为1元！\"}");
                return;
            }
            if (amout > model.amount)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您兑换的金额大于账户余额！\"}");
                return;
            }
            if (password == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入您账户的密码！\"}");
                return;
            }
            //验证密码
            if (DESEncrypt.Encrypt(password, model.salt) != model.password)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，您输入的密码不正确！\"}");
                return;
            }
            //计算兑换后的积分值
            int convertPoint = (int)(Convert.ToDecimal(amout) * userConfig.pointcashrate);
            //扣除金额
            int amountNewId = new BLL.user_amount_log().Add(model.id, model.user_name, DTEnums.AmountTypeEnum.Convert.ToString(), amout * -1, "用户兑换积分", 1);
            //增加积分
            if (amountNewId < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"转换过程中发生错误，请重新提交！\"}");
                return;
            }
            int pointNewId = new BLL.user_point_log().Add(model.id, model.user_name, convertPoint, "用户兑换积分", true);
            if (pointNewId < 1)
            {
                //返还金额
                new BLL.user_amount_log().Add(model.id, model.user_name, DTEnums.AmountTypeEnum.Convert.ToString(), amout, "用户兑换积分失败，返还金额", 1);
                context.Response.Write("{\"status\":0, \"msg\":\"转换过程中发生错误，请重新提交！\"}");
                return;
            }

            context.Response.Write("{\"status\":1, \"msg\":\"恭喜您，积分兑换成功！\"}");
            return;
        }
        #endregion

        #region 删除用户积分明细OK=============================
        private void user_point_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (check_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                new BLL.user_point_log().Delete(int.Parse(arrId[i]), model.user_name);
            }
            context.Response.Write("{\"status\":1, \"msg\":\"积分明细删除成功！\"}");
            return;
        }
        #endregion

        #region 用户在线充值OK=================================
        private void user_amount_recharge(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            decimal amount = DTRequest.GetFormDecimal("order_amount", 0);
            int payment_id = DTRequest.GetFormInt("payment_id");
            if (amount == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入正确的充值金额！\"}");
                return;
            }
            if (payment_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择正确的支付方式！\"}");
                return;
            }
            if (!new BLL.payment().Exists(payment_id))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，支付方式不存在或已删除！\"}");
                return;
            }
            //生成订单号
            string order_no = "R" + Utils.GetOrderNumber(); //订单号R开头为充值订单
            new BLL.user_amount_log().Add(model.id, model.user_name, DTEnums.AmountTypeEnum.Recharge.ToString(), order_no,
                payment_id, amount, "账户充值(" + new BLL.payment().GetModel(payment_id).title + ")", 0);
            //保存成功后返回订单号
            context.Response.Write("{\"status\":1, \"msg\":\"订单保存成功！\", \"url\":\"" + new Web.UI.BasePage().linkurl("payment", "confirm", order_no) + "\"}");
            return;

        }
        #endregion

        #region 删除用户收支明细OK=============================
        private void user_amount_delete(HttpContext context)
        {
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            string check_id = DTRequest.GetFormString("checkId");
            if (check_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"删除失败，请检查传输参数！\"}");
                return;
            }
            string[] arrId = check_id.Split(',');
            for (int i = 0; i < arrId.Length; i++)
            {
                new BLL.user_amount_log().Delete(int.Parse(arrId[i]), model.user_name);
            }
            context.Response.Write("{\"status\":1, \"msg\":\"收支明细删除成功！\"}");
            return;
        }
        #endregion

        #region 购物车加入商品OK===============================
        private void cart_goods_add(HttpContext context)
        {
            string goods_id = DTRequest.GetFormString("goods_id");
            int goods_quantity = DTRequest.GetFormInt("goods_quantity", 1);
            if (goods_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }
            //查找会员组
            int group_id = 0;
            Model.users groupModel = new Web.UI.BasePage().GetUserInfo();
            if (groupModel != null)
            {
                group_id = groupModel.group_id;
            }
            //统计购物车
            Web.UI.ShopCart.Add(goods_id, goods_quantity);
            Model.cart_total cartModel = Web.UI.ShopCart.GetTotal(group_id);
            context.Response.Write("{\"status\":1, \"msg\":\"商品已成功添加到购物车！\", \"quantity\":" + cartModel.total_quantity + ", \"amount\":" + cartModel.real_amount + "}");
            return;
        }
        #endregion

        #region 修改购物车商品OK===============================
        private void cart_goods_update(HttpContext context)
        {
            string goods_id = DTRequest.GetFormString("goods_id");
            int goods_quantity = DTRequest.GetFormInt("goods_quantity");
            if (goods_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }

            if (Web.UI.ShopCart.Update(goods_id, goods_quantity))
            {
                context.Response.Write("{\"status\":1, \"msg\":\"商品数量修改成功！\"}");
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"商品数量更改失败，请检查操作是否有误！\"}");
            }
            return;
        }
        #endregion

        #region 删除购物车商品OK===============================
        private void cart_goods_delete(HttpContext context)
        {
            string goods_id = DTRequest.GetFormString("goods_id");
            if (goods_id == "")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
                return;
            }
            Web.UI.ShopCart.Clear(goods_id);
            context.Response.Write("{\"status\":1, \"msg\":\"商品移除成功！\"}");
            return;
        }
        #endregion

        #region 保存用户订单OK=================================
        private void order_save(HttpContext context)
        {
            //获得传参信息
            int payment_id = DTRequest.GetFormInt("payment_id");
            int express_id = DTRequest.GetFormInt("express_id");
            string accept_name = Utils.ToHtml(DTRequest.GetFormString("accept_name"));
            string post_code = Utils.ToHtml(DTRequest.GetFormString("post_code"));
            string telphone = Utils.ToHtml(DTRequest.GetFormString("telphone"));
            string mobile = Utils.ToHtml(DTRequest.GetFormString("mobile"));
            string address = Utils.ToHtml(DTRequest.GetFormString("address"));
            string message = Utils.ToHtml(DTRequest.GetFormString("message"));
            //获取订单配置信息
            Model.orderconfig orderConfig = new BLL.orderconfig().loadConfig();

            //检查物流方式
            if (express_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择配送方式！\"}");
                return;
            }
            Model.express expModel = new BLL.express().GetModel(express_id);
            if (expModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，配送方式不存在或已删除！\"}");
                return;
            }
            //检查支付方式
            if (payment_id == 0)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请选择支付方式！\"}");
                return;
            }
            Model.payment payModel = new BLL.payment().GetModel(payment_id);
            if (payModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，支付方式不存在或已删除！\"}");
                return;
            }
            //检查收货人
            if (string.IsNullOrEmpty(accept_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入收货人姓名！\"}");
                return;
            }
            //检查手机和电话
            if (string.IsNullOrEmpty(telphone) && string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入收货人联系电话或手机！\"}");
                return;
            }
            //检查地址
            if (string.IsNullOrEmpty(address))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入详细的收货地址！\"}");
                return;
            }
            //如果开启匿名购物则不检查会员是否登录
            int user_id = 0;
            int user_group_id = 0;
            string user_name = string.Empty;
            //检查用户是否登录
            Model.users userModel = new BasePage().GetUserInfo();
            if (userModel != null)
            {
                user_id = userModel.id;
                user_group_id = userModel.group_id;
                user_name = userModel.user_name;
            }
            if (orderConfig.anonymous == 0 && userModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            //检查购物车商品
            IList<Model.cart_items> iList = DTcms.Web.UI.ShopCart.GetList(user_group_id);
            if (iList == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，购物车为空，无法结算！\"}");
                return;
            }
            //统计购物车
            Model.cart_total cartModel = DTcms.Web.UI.ShopCart.GetTotal(user_group_id);
            //保存订单=======================================================================
            Model.orders model = new Model.orders();
            model.order_no = "B" + Utils.GetOrderNumber(); //订单号B开头为商品订单
            model.user_id = user_id;
            model.user_name = user_name;
            model.payment_id = payment_id;
            model.express_id = express_id;
            model.accept_name = accept_name;
            model.post_code = post_code;
            model.telphone = telphone;
            model.mobile = mobile;
            model.address = address;
            model.message = message;
            model.payable_amount = cartModel.payable_amount;
            model.real_amount = cartModel.real_amount;
            model.express_status = 1;
            model.express_fee = expModel.express_fee; //物流费用
            //如果是先款后货的话
            if (payModel.type == 1)
            {
                model.payment_status = 1; //标记未付款
                if (payModel.poundage_type == 1) //百分比
                {
                    model.payment_fee = model.real_amount * payModel.poundage_amount / 100;
                }
                else //固定金额
                {
                    model.payment_fee = payModel.poundage_amount;
                }
            }
            //订单总金额=实付商品金额+运费+支付手续费
            model.order_amount = model.real_amount + model.express_fee + model.payment_fee;
            //购物积分,可为负数
            model.point = cartModel.total_point;
            model.add_time = DateTime.Now;
            //商品详细列表
            List<Model.order_goods> gls = new List<Model.order_goods>();
            foreach (Model.cart_items item in iList)
            {
                gls.Add(new Model.order_goods { goods_id = item.id, goods_title = item.title, goods_price = item.price, real_price = item.user_price, quantity = item.quantity, point = item.point });
            }
            model.order_goods = gls;
            int result = new BLL.orders().Add(model);
            if (result < 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"订单保存过程中发生错误，请重新提交！\"}");
                return;
            }
            //扣除积分
            if (model.point < 0)
            {
                new BLL.user_point_log().Add(model.user_id, model.user_name, model.point, "积分换购，订单号：" + model.order_no, false);
            }
            //清空购物车
            DTcms.Web.UI.ShopCart.Clear("0");
            //提交成功，返回URL
            context.Response.Write("{\"status\":1, \"url\":\"" + new Web.UI.BasePage().linkurl("payment", "confirm", model.order_no) + "\", \"msg\":\"恭喜您，订单已成功提交！\"}");
            return;
        }
        #endregion

        #region 用户取消订单OK=================================
        private void order_cancel(HttpContext context)
        {
            //检查用户是否登录
            Model.users userModel = new BasePage().GetUserInfo();
            if (userModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，用户尚未登录或已超时！\"}");
                return;
            }
            //检查订单是否存在
            string order_no = DTRequest.GetQueryString("order_no");
            Model.orders orderModel = new BLL.orders().GetModel(order_no);
            if (order_no == "" || orderModel == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单号不存在或已删除！\"}");
                return;
            }
            //检查是否自己的订单
            if (userModel.id != orderModel.user_id)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，不能取消别人的订单状态！\"}");
                return;
            }
            //检查订单状态
            if (orderModel.status > 1)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，订单不是生成状态，不能取消！\"}");
                return;
            }
            bool result = new BLL.orders().UpdateField(order_no, "status=4");
            if (!result)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，操作过程中发生不可遇知的错误！\"}");
                return;
            }
            //如果是积分换购则返还积分
            if (orderModel.point < 0)
            {
                new BLL.user_point_log().Add(orderModel.user_id, orderModel.user_name, -1 * orderModel.point, "取消订单，返还换购积分，订单号：" + orderModel.order_no, false);
            }
            context.Response.Write("{\"status\":1, \"msg\":\"取消订单成功！\"}");
            return;
        }
        #endregion

        #region 统计及输出阅读次数OK===========================
        private void view_article_click(HttpContext context)
        {
            int article_id = DTRequest.GetInt("id", 0);
            int click = DTRequest.GetInt("click", 0);
            int count = 0;
            if (article_id > 0)
            {
                BLL.article bll = new BLL.article();
                count = bll.GetClick(article_id);
                if (click > 0)
                {
                    bll.UpdateField(article_id, "click=click+1");
                }
            }
            context.Response.Write("document.write('" + count + "');");
        }
        #endregion

        #region 输出评论总数OK=================================
        private void view_comment_count(HttpContext context)
        {
            int article_id = DTRequest.GetInt("id", 0);
            int count = 0;
            if (article_id > 0)
            {
                count = new BLL.article_comment().GetCount("is_lock=0 and article_id=" + article_id);
            }
            context.Response.Write("document.write('" + count + "');");
        }
        #endregion

        #region 输出附件下载总数OK=============================
        private void view_attach_count(HttpContext context)
        {
            int attach_id = DTRequest.GetInt("id", 0);
            int count = 0;
            if (attach_id > 0)
            {
                count = new BLL.article_attach().GetDownNum(attach_id);
            }
            context.Response.Write("document.write('" + count + "');");
        }
        #endregion

        #region 输出购物车总数OK===============================
        private void view_cart_count(HttpContext context)
        {
            int group_id = 0;
            //检查用户是否登录
            Model.users model = new BasePage().GetUserInfo();
            if (model != null)
            {
                group_id = model.group_id;
            }
            Model.cart_total cartModel = Web.UI.ShopCart.GetTotal(group_id);
            context.Response.Write("document.write('" + cartModel.total_quantity + "');");
        }
        #endregion

        #region 通用外理方法OK=================================
        //校检网站验证码
        private string verify_code(HttpContext context, string strcode)
        {
            if (string.IsNullOrEmpty(strcode))
            {
                return "{\"status\":0, \"msg\":\"对不起，请输入验证码！\"}";
            }
            if (context.Session[DTKeys.SESSION_CODE] == null)
            {
                return "{\"status\":0, \"msg\":\"对不起，验证码超时或已过期！\"}";
            }
            if (strcode.ToLower() != (context.Session[DTKeys.SESSION_CODE].ToString()).ToLower())
            {
                return "{\"status\":0, \"msg\":\"您输入的验证码与系统的不一致！\"}";
            }
            context.Session[DTKeys.SESSION_CODE] = null;
            return "success";
        }
        //校检网站验证码
        private string verify_sms_code(HttpContext context, string strcode)
        {
            if (string.IsNullOrEmpty(strcode))
            {
                return "{\"status\":0, \"msg\":\"对不起，请输入验证码！\"}";
            }
            if (context.Session[DTKeys.SESSION_SMS_CODE] == null)
            {
                return "{\"status\":0, \"msg\":\"对不起，验证码超时或已过期！\"}";
            }
            if (strcode.ToLower() != (context.Session[DTKeys.SESSION_SMS_CODE].ToString()).ToLower())
            {
                return "{\"status\":0, \"msg\":\"您输入的验证码与系统的不一致！\"}";
            }
            context.Session[DTKeys.SESSION_SMS_CODE] = null;
            return "success";
        }
        #endregion END通用方法=================================================

        /// <summary>
        /// 分配账户修改资料
        /// </summary>
        /// <param name="context"></param>
        private void edit_dealing_users(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            string password = DTRequest.GetString("psd");
            string phone = DTRequest.GetString("phone");
            string email = DTRequest.GetString("email");
            string real_name = DTRequest.GetString("real_name");
            int branch = DTRequest.GetFormInt("branch_id");

            BLL.users bll = new BLL.users();
            Model.users model1 = new BasePage().GetUserInfo();
            if (model1 == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请重新登录！\"}");
                return;
            }
            Model.users model = bll.GetModel(id);

            string psd = DESEncrypt.Encrypt(password, model1.salt);
            model.password = psd;
            model.telphone = phone;
            model.real_name = real_name;
            model.email = email;
            model.branch_id = branch;
            model.user_status = 3;
            model.user_type = 1;
            model.parent_id = model1.id;
            model.group_id = 1;
            if (bll.Update(model))
            {
                context.Response.Write("{\"status\":1, \"msg\":\"修改员工资料成功！\"}");
                return;

            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，修改员工资料失败！\"}");
                return;

            }

        }


        #region================================启用禁用====================
        private void user_status(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            int status = DTRequest.GetQueryInt("status");
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(id);
            Model.users users = new BasePage().GetUserInfo();
            if (users == null)
            {

                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请重新登录！\"}");
                return;
            }
            model.status = status;
            if (bll.Update(model))
            {
                context.Response.Write("{\"status\":1, \"msg\":\"用户状态更改！\"}");
                return;
            }
        }
        #endregion
        #region========================修改企业用户密码==========================
        private void edit_userpsd(HttpContext context)
        {

            string oldpsd = DTRequest.GetString("oldpsd");
            string newpsd = DTRequest.GetString("newpsd");
            BLL.users user_bll = new BLL.users();
            Model.users user_model = new BasePage().GetUserInfo();
            if (user_model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起请重新登录！\"}");
                return;

            }
            string psd = DESEncrypt.Encrypt(oldpsd, user_model.salt);
            if (user_model.password != psd)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起您输入的旧密码错误，请重新操作！\"}");
                return;
            }
            string newpsds = DESEncrypt.Encrypt(newpsd, user_model.salt);
            user_model.password = newpsds;
            if (user_bll.Update(user_model))
            {
                context.Response.Write("{\"status\":1, \"msg\":\"更改密码成功！\"}");
                return;

            }





        }
        #endregion

        #region=========================收藏商品=========
        private void get_collect(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            BLL.collect bll_collect = new BLL.collect();
            Model.collect model_collect = new Model.collect();
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(id);
            Model.users user_model = new BasePage().GetUserInfo();
            if (user_model == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"收藏商品失败，请您先登录！\"}");
                return;

            }
            //赋值
            model_collect.goods_name = model.title;
            model_collect.img_url = model.img_url;
            model_collect.goods_id = model.id;
            model_collect.user_id = user_model.id;
            model_collect.add_time = DateTime.Now;
            if (bll_collect.Exists1(model.id))
            {

                context.Response.Write("{\"status\":0, \"msg\":\"已收藏该商品！\"}");
                return;
            }
            if (bll_collect.Add(model_collect) > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"收藏商品成功！\"}");
                return;

            }
            else
            {

                context.Response.Write("{\"status\":0, \"msg\":\"收藏失败！\"}");
                return;
            }
        }
        #endregion
        #region===============================浏览过的商品==============
        private void get_browse_goods(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            BLL.browse_goods bll = new BLL.browse_goods();
            BLL.article abll = new BLL.article();
            Model.article model = abll.GetModel(id);
            Model.browse_goods bmodel = new Model.browse_goods();
            Model.users users = new BasePage().GetUserInfo();
            if (users == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请登录！\"}");
                return;

            }
            if (bll.Exists1(id))
            {
                bll.UpdateField(id, "add_time=getdate()");
                context.Response.Write("{\"status\":1, \"msg\":\"修改浏览信息成功！\"}");
                return;

            }
            bmodel.user_id = users.id;
            bmodel.goods_id = model.id;
            bmodel.goods_name = model.title;
            bmodel.img_url = model.img_url;
            bmodel.add_time = DateTime.Now;
            bmodel.time = bmodel.add_time.ToString("yyyy-MM-dd");
            if (bll.Add(bmodel) > 0)
            {
                context.Response.Write("{\"status\":1, \"msg\":\"添加浏览信息成功！\"}");
                return;
            }
            else
            {
                context.Response.Write("{\"status\":0, \"msg\":\"添加浏览信息失败！\"}");
                return;
            }
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