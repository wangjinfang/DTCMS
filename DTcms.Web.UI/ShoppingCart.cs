using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using DTcms.Common;
using LitJson;

namespace DTcms.Web.UI
{
    /// <summary>
    /// 购物车帮助类
    /// </summary>
    public partial class ShopCart
    {
        #region 基本增删改方法====================================
        /// <summary>
        /// 获得购物车列表
        /// </summary>
        public static IList<Model.cart_items> GetList(int group_id)
        {
            IDictionary<string, int> dic = GetCart();
            if (dic==null || dic.Count <= 0)
            {
                 #region 获取数据库购物车
                Model.users model = new BasePage().GetUserInfo();
                if (model != null)
                {
                    BLL.cart cartbll = new BLL.cart();
                    DataTable dt = cartbll.GetList("UserID='" + model.id + "'").Tables[0];
                    if (dt.Rows.Count <= 0)
                    {
                        //return null;
                    }
                    else
                    {
                        dic = new Dictionary<string, int>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            dic.Add(dt.Rows[i]["ProductName"].ToString(), int.Parse(dt.Rows[i]["Counts"].ToString()));
                            
                        }
                     
                    }

                }
                #endregion
            }
            if (dic != null)
            {
                IList<Model.cart_items> iList = new List<Model.cart_items>();

                foreach (var item in dic)
                {
                    BLL.article bll = new BLL.article();


                    //key:1547-27|120,28|122-55
                    int goods_id = Convert.ToInt32(item.Key.Split('-')[0]);
                    string standard = item.Key.Split('-')[1];

                    decimal unit_id = decimal.Parse(item.Key.Split('-')[2], 0);// Convert.ToDecimal(item.Key.Split('-')[2]);
                    Model.article model = bll.GetModel(Convert.ToInt32(goods_id));
                    if (model == null || !model.fields.ContainsKey("sell_price"))
                    {
                        continue;
                    }
                    string standard_value_ids = "";
                    string[] arr_standard = standard.Split(',');
                    foreach (string str in arr_standard)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            standard_value_ids += str.Split('|')[1] + ",";
                        }
                    }
                    if (!string.IsNullOrEmpty(standard_value_ids))
                    {
                        standard_value_ids = standard_value_ids.Substring(0, standard_value_ids.Length - 1);
                    }

                    Model.cart_items modelt = new Model.cart_items();
                    modelt.id = model.id;
                    modelt.title = model.title;
                    modelt.img_url = model.img_url;
                    modelt.standard = standard;
                    modelt.unit_id = unit_id;
                    if (model.fields.ContainsKey("point"))
                    {
                        modelt.point = Utils.StrToInt(model.fields["point"], 0);
                    }

                    modelt.price = Utils.StrToDecimal(model.fields["sell_price"], 0);
                    modelt.user_price = Utils.StrToDecimal(model.fields["sell_price"], 0);

                    //单位价格  -- 有单位  无会员 无规格
                    BLL.unit bll_unit = new BLL.unit();
                    Model.unit model_unit = bll_unit.GetModel(unit_id);
                    if (model_unit != null)
                    {
                        modelt.price = Utils.StrToDecimal(model.fields["sell_price"], 0) * model_unit.quantity * (model_unit.rate / 100);
                        modelt.user_price = Utils.StrToDecimal(model.fields["sell_price"], 0) * model_unit.quantity * (model_unit.rate / 100);
                    }

                    //规格价格  --有/无单位  无会员  有规格
                    BLL.standard_price bll_standard_price = new BLL.standard_price();

                    DataTable dt_standard_price = bll_standard_price.GetList("standard_value_ids='" + standard_value_ids + "' and good_id=" + goods_id).Tables[0];
                    if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
                    {
                        modelt.user_price = modelt.price = Utils.StrToDecimal(dt_standard_price.Rows[0]["sell_price"].ToString(), 0);
                        if (model_unit != null)
                        {
                            modelt.user_price = modelt.price = Utils.StrToDecimal(dt_standard_price.Rows[0]["sell_price"].ToString(), 0) * model_unit.quantity * (model_unit.rate / 100);
                        }
                    }


                    if (model.fields.ContainsKey("stock_quantity"))
                    {
                        modelt.stock_quantity = Utils.StrToInt(model.fields["stock_quantity"], 0);
                    }
                    //会员价格
                    if (model.group_price != null)
                    {
                        Model.user_group_price gmodel = model.group_price.Find(p => p.group_id == group_id);
                        if (gmodel != null)
                        {
                            modelt.user_price = gmodel.price;
                            //有规格才有规格等级价格
                            if (dt_standard_price != null && dt_standard_price.Rows.Count > 0)
                            {
                                BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();
                                DataTable dt_standard_group_price = bll_standard_group_price.GetList("good_id=" + goods_id + " and standard_price_id=" + dt_standard_price.Rows[0]["id"].ToString() + " and group_id=" + group_id).Tables[0];
                                //有规格会员价格
                                if (dt_standard_group_price != null && dt_standard_group_price.Rows.Count > 0)
                                {
                                    //规格会员价格  无单位-- 有规格 有会员
                                    modelt.user_price = Convert.ToDecimal(dt_standard_group_price.Rows[0]["group_price"]);
                                }

                            }
                            if (model_unit != null)
                            {
                                modelt.user_price = modelt.user_price * model_unit.quantity * (model_unit.rate / 100);
                            }
                        }
                    }
                    modelt.quantity = item.Value;
                    iList.Add(modelt);
                }
                return iList;
            }
            return null;
        }

        /// <summary>
        /// 添加到购物车
        /// </summary>
        public static bool Add(string Key, int Quantity)
        {
            Model.users model = new BasePage().GetUserInfo();
            BLL.cart cartbll = new BLL.cart();
            Model.cart modelcart = new Model.cart();

            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                if (dic.ContainsKey(Key))
                {
                    dic[Key] += Quantity;
                    #region 添加到数据库
                    if (model!=null)
                    {
                        DataTable dt = cartbll.GetList("ProductName='" + Key + "' and UserID='" + model.id + "'").Tables[0];
                        if (dt.Rows.Count == 1)
                        {
                            modelcart = cartbll.GetModel(int.Parse(dt.Rows[0][0].ToString()));
                            if (modelcart != null)
                            {
                                modelcart.Counts = (int.Parse(modelcart.Counts)+1).ToString();
                                cartbll.Update(modelcart);
                            }
                        }
                    }
                    #endregion
                    AddCookies(JsonMapper.ToJson(dic));
                    return true;
                }
            }
            else
            {
                dic = new Dictionary<string, int>();
            }
            //不存在的则新增
            dic.Add(Key, Quantity);
            #region 添加到数据库
            if (model != null)
            {

                modelcart.ProductName = Key;
                modelcart.Counts = Quantity.ToString();
                modelcart.UserID = model.id;
                cartbll.Add(modelcart);
            }
            #endregion
            AddCookies(JsonMapper.ToJson(dic));
            return true;
        }

        /// <summary>
        /// 更新购物车数量
        /// </summary>
        public static bool Update(string Key, int Quantity)
        {
            if (Quantity == 0)
            {
                Clear(Key);
                return true;
            }
            IDictionary<string, int> dic = GetCart();
            if (dic != null && dic.ContainsKey(Key))
            {
                dic[Key] = Quantity;
                AddCookies(JsonMapper.ToJson(dic));
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移除购物车
        /// </summary>
        /// <param name="Key">主键 0为清理所有的购物车信息</param>
        public static void Clear(string Key)
        {

            Model.users model = new BasePage().GetUserInfo();
            BLL.cart cartbll = new BLL.cart();
            Model.cart modelcart = new Model.cart();

            if (Key == "0")//为0的时候清理全部购物车cookies
            {
                Utils.WriteCookie(DTKeys.COOKIE_SHOPPING_CART, "", -43200);
                #region 清空登录会员的购物车
                if (model!=null)
                {
                    cartbll.Delete_user(model.id);
                }
                #endregion
            }
            else
            {
                IDictionary<string, int> dic = GetCart();
                if (dic != null)
                {
                    dic.Remove(Key);
                    #region 删除登录会员指定的购物车
                    if (model != null)
                    {
                        cartbll.Delete(model.id,Key);
                    }
                    #endregion
                    AddCookies(JsonMapper.ToJson(dic));
                }
            }
        }
        #endregion

        #region 扩展方法==========================================
        public static Model.cart_total GetTotal(int group_id)
        {
            Model.cart_total model = new Model.cart_total();
            IList<Model.cart_items> iList = GetList(group_id);
            if (iList != null)
            {
                foreach (Model.cart_items modelt in iList)
                {
                    model.total_num++;
                    model.total_quantity += modelt.quantity;
                    model.payable_amount += modelt.price * modelt.quantity;
                    model.real_amount += modelt.user_price * modelt.quantity;
                    model.total_point += modelt.point * modelt.quantity;
                }
            }
            return model;
        }
        #endregion

        #region 私有方法==========================================
        /// <summary>
        /// 获取cookies值
        /// </summary>
        private static IDictionary<string, int> GetCart()
        {
            IDictionary<string, int> dic = new Dictionary<string, int>();
            #region 获取数据库购物车
            Model.users model = new BasePage().GetUserInfo();
            if (model != null)
            {
                BLL.cart cartbll = new BLL.cart();
                DataTable dt = cartbll.GetList("UserID='" + model.id + "'").Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    Utils.WriteCookie(DTKeys.COOKIE_SHOPPING_CART, "", -43200);
                }
                else
                {
                    //dic = new Dictionary<string, int>();
                    Utils.WriteCookie(DTKeys.COOKIE_SHOPPING_CART, "", -43200);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dic.Add(dt.Rows[i]["ProductName"].ToString(), int.Parse(dt.Rows[i]["Counts"].ToString()));
                    }

                }

            }
            if (dic != null && dic.Count > 0)
            {
                return dic;
            }
            #endregion
            if (!string.IsNullOrEmpty(GetCookies()))
            {
                return JsonMapper.ToObject<Dictionary<string, int>>(GetCookies());
            }
            
               
                return null;
          
        }

        /// <summary>
        /// 添加对象到cookies
        /// </summary>
        /// <param name="strValue"></param>
        private static void AddCookies(string strValue)
        {
            Utils.WriteCookie(DTKeys.COOKIE_SHOPPING_CART, strValue, 43200); //存储一个月
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <returns></returns>
        private static string GetCookies()
        {
            return Utils.GetCookie(DTKeys.COOKIE_SHOPPING_CART);
        }

        #endregion
    }

}
