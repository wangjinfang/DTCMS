using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.set_meal
{
    public partial class edit : Web.UI.ManagePage
    {

        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected string good_header = "";
        protected string good_body = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.meal().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                TreeBind(); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.meal_category bll = new BLL.meal_category();
            DataTable dt = bll.GetList(0);

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.meal bll = new BLL.meal();
            Model.meal model = bll.GetModel(_id);
            ddlCategoryId.SelectedValue = model.category_id.ToString();
            txt_title.Text = model.title;
            txtImgUrl.Text = model.img_url;
            txtIndexUrl.Text = model.index_url;
            txtSortId.Text = model.sort_id.ToString();


            BLL.meal_good bll_meal_good = new BLL.meal_good();
            DataTable dt_meal_good = bll_meal_good.GetList("meal_id=" + _id).Tables[0];
            string str_ck = "";
            string str_standard_good_price_ids = ",";
            foreach (DataRow dr in dt_meal_good.Rows)
            {
                if (str_standard_good_price_ids.IndexOf("," + (Convert.ToInt32(dr["meal_id"]) + "-" + Convert.ToInt32(dr["good_id"]) + "-" + Convert.ToDecimal(dr["standard_price_id"]) + "-" + Convert.ToDecimal(dr["unit_id"])) + ",") > -1)
                {
                    continue;
                }
                str_standard_good_price_ids += Convert.ToInt32(dr["meal_id"]) + "-" + Convert.ToInt32(dr["good_id"]) + "-" + Convert.ToDecimal(dr["standard_price_id"]) + "-" + Convert.ToDecimal(dr["unit_id"]) + ",";

                Model.article model_good = new BLL.article().GetModel(Convert.ToInt32(dr["good_id"]));
                if (model_good != null)
                {
                    //单位
                    string unit = "";
                    string str_quantity = ",数量：" + Convert.ToInt32(dr["quantity"]);
                    Model.unit model_unit = new BLL.unit().GetModel(Convert.ToInt32(dr["unit_id"]));
                    if (model_unit != null)
                    {
                        unit = ",单位：" + model_unit.title;
                        if (!string.IsNullOrEmpty(model_unit.content))
                        {
                            unit += "(" + model_unit.content + ")";
                        }
                    }

                    //规格
                    string standard = "";
                    BLL.standard_price bll_standard_price = new BLL.standard_price();
                    Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(dr["standard_price_id"]));
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

                    str_ck += "<span onclick='ck_goods(this)'>" + model_good.title + str_quantity + unit + " " + standard + "<input type='checkbox' name='ck_good' style='display:none;' value='" + model_good.id + "_" + Convert.ToDecimal(dr["standard_price_id"]) + "_" + Convert.ToInt32(dr["unit_id"]) + "_" + Convert.ToInt32(dr["quantity"]) + "' checked='checked'/></span><br />";
                }
                goods.InnerHtml = str_ck;
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            string check_good = DTRequest.GetFormString("ck_good");
            if (string.IsNullOrEmpty(check_good))
            {
                JscriptMsg("请选择商品！", "", "Error");
                return false;
            }

            BLL.meal bll = new BLL.meal();
            Model.meal model = new Model.meal();

            model.title = txt_title.Text.Trim();
            model.category_id = Convert.ToInt32(ddlCategoryId.SelectedValue);
            model.img_url = txtImgUrl.Text.Trim();
            model.add_time = DateTime.Now;
            model.index_url = txtIndexUrl.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.ToString());

            BLL.standard_price bll_standard_price = new BLL.standard_price();
            

            int _meal_id = bll.Add(model);

            if (_meal_id > 0)
            {
                BLL.meal_good bll_meal_good = new BLL.meal_good();

                string[] arr_str = check_good.Split(',');
                BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();

                for (int i = 0; i < arr_str.Length; i++)
                {
                    Model.article model_good = new Model.article();
                    model_good = new BLL.article().GetModel(Convert.ToInt32(arr_str[i].Split('_')[0]));
                    if (model_good != null)
                    {
                        if (!string.IsNullOrEmpty(arr_str[i]))
                        {
                            DataTable dt_standard_group_price = bll_standard_group_price.GetList("good_id=" + arr_str[i].Split('_')[0] + " and standard_price_id=" + arr_str[i].Split('_')[1]).Tables[0];
                            if (dt_standard_group_price != null && dt_standard_group_price.Rows.Count > 0)
                            {
                                //有会员规格价格   商品ID_规格价格ID_单位ID_数量  默认sell_price   规格价格standard_price（有规格未登入）  组别价格standard_group_price（不管有没有规格已登入）
                                foreach (DataRow dr_group_price in dt_standard_group_price.Rows)
                                {
                                    Model.meal_good model_meal_good = new Model.meal_good();
                                    model_meal_good.good_id = Convert.ToInt32(arr_str[i].Split('_')[0]);
                                    model_meal_good.group_id = Convert.ToInt32(dr_group_price["group_id"]);
                                    model_meal_good.meal_id = _meal_id;
                                    model_meal_good.standard_price_id = Convert.ToDecimal(arr_str[i].Split('_')[1]);
                                    model_meal_good.unit_id = Convert.ToInt32(arr_str[i].Split('_')[2]);
                                    model_meal_good.quantity = Convert.ToInt32(arr_str[i].Split('_')[3]);
                                    model_meal_good.sell_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                    model_meal_good.standard_price = Convert.ToDecimal(model_good.fields["sell_price"]);

                                    Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(arr_str[i].Split('_')[1]));
                                    if (model_standard_price != null)
                                    {
                                        //有库存价格  
                                        model_meal_good.standard_price = model_standard_price.sell_price;
                                        model_meal_good.action_price = model_standard_price.action_price;
                                    }
                                    model_meal_good.standard_group_price = Convert.ToDecimal(dr_group_price["group_price"]);
                                    model_meal_good.add_time = DateTime.Now;

                                    bll_meal_good.Add(model_meal_good);
                                }

                            }
                            else
                            {
                                if (model_good.group_price.Count > 0)
                                {
                                    foreach (Model.user_group_price model_user_group in model_good.group_price)
                                    {
                                        Model.meal_good model_meal_good = new Model.meal_good();
                                        model_meal_good.good_id = Convert.ToInt32(arr_str[i].Split('_')[0]);
                                        model_meal_good.group_id = model_user_group.group_id;
                                        model_meal_good.meal_id = _meal_id;
                                        model_meal_good.standard_price_id = Convert.ToDecimal(arr_str[i].Split('_')[1]);
                                        model_meal_good.unit_id = Convert.ToInt32(arr_str[i].Split('_')[2]);
                                        model_meal_good.quantity = Convert.ToInt32(arr_str[i].Split('_')[3]);
                                        model_meal_good.sell_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                        model_meal_good.standard_price = Convert.ToDecimal(model_good.fields["sell_price"]);

                                        Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(arr_str[i].Split('_')[1]));
                                        if (model_standard_price != null)
                                        {
                                            //有库存价格  
                                            model_meal_good.standard_price = model_standard_price.sell_price;
                                            model_meal_good.action_price = model_standard_price.action_price;
                                        }
                                        model_meal_good.standard_group_price = Convert.ToDecimal(model_user_group.price);
                                        model_meal_good.add_time = DateTime.Now;
                                        bll_meal_good.Add(model_meal_good);
                                    }

                                }
                                else
                                {
                                    Model.meal_good model_meal_good = new Model.meal_good();
                                    model_meal_good.good_id = Convert.ToInt32(arr_str[i].Split('_')[0]);
                                    model_meal_good.group_id = 0;
                                    model_meal_good.meal_id = _meal_id;
                                    model_meal_good.standard_price_id = Convert.ToDecimal(arr_str[i].Split('_')[1]);
                                    model_meal_good.unit_id = Convert.ToInt32(arr_str[i].Split('_')[2]);
                                    model_meal_good.quantity = Convert.ToInt32(arr_str[i].Split('_')[3]);
                                    model_meal_good.sell_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                    model_meal_good.standard_price = Convert.ToDecimal(model_good.fields["sell_price"]);

                                    Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(arr_str[i].Split('_')[1]));
                                    if (model_standard_price != null)
                                    {
                                        //有库存价格  
                                        model_meal_good.standard_price = model_standard_price.sell_price;
                                        model_meal_good.action_price = model_standard_price.action_price;
                                    }
                                    model_meal_good.standard_group_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                    model_meal_good.add_time = DateTime.Now;
                                    bll_meal_good.Add(model_meal_good);
                                }
                            }

                        }

                        
                        
                    }
                }

                //AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加用户:" + model.user_name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {

            string check_good = DTRequest.GetFormString("ck_good");
            if (string.IsNullOrEmpty(check_good))
            {
                JscriptMsg("请选择商品！", "", "Error");
                return false;
            }

            bool result = false;
            BLL.meal bll = new BLL.meal();
            Model.meal model = bll.GetModel(_id);
            model.title = txt_title.Text.Trim();
            model.img_url = txtImgUrl.Text.Trim();
            model.category_id = Convert.ToInt32(ddlCategoryId.SelectedValue);
            model.index_url = txtIndexUrl.Text.Trim();
            model.sort_id = int.Parse(txtSortId.Text.ToString());

            if (bll.Update(model))
            {


                BLL.standard_price bll_standard_price = new BLL.standard_price();

                BLL.meal_good bll_meal_good = new BLL.meal_good();

                bll_meal_good.Delete(_id);

                string[] arr_str = check_good.Split(',');
                BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();

                for (int i = 0; i < arr_str.Length; i++)
                {
                    Model.article model_good = new Model.article();
                    model_good = new BLL.article().GetModel(Convert.ToInt32(arr_str[i].Split('_')[0]));
                    if (model_good != null)
                    {
                        if (!string.IsNullOrEmpty(arr_str[i]))
                        {
                            DataTable dt_standard_group_price = bll_standard_group_price.GetList("good_id=" + arr_str[i].Split('_')[0] + " and standard_price_id=" + arr_str[i].Split('_')[1]).Tables[0];
                            if (dt_standard_group_price != null && dt_standard_group_price.Rows.Count > 0)
                            {
                                //有会员规格价格
                                foreach (DataRow dr_group_price in dt_standard_group_price.Rows)
                                {
                                    Model.meal_good model_meal_good = new Model.meal_good();
                                    model_meal_good.good_id = Convert.ToInt32(arr_str[i].Split('_')[0]);
                                    model_meal_good.group_id = Convert.ToInt32(dr_group_price["group_id"]);
                                    model_meal_good.meal_id = _id;
                                    model_meal_good.standard_price_id = Convert.ToDecimal(arr_str[i].Split('_')[1]);
                                    model_meal_good.unit_id = Convert.ToInt32(arr_str[i].Split('_')[2]);
                                    model_meal_good.quantity = Convert.ToInt32(arr_str[i].Split('_')[3]);
                                    model_meal_good.sell_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                    model_meal_good.standard_price = Convert.ToDecimal(model_good.fields["sell_price"]);

                                    Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(arr_str[i].Split('_')[1]));
                                    if (model_standard_price != null)
                                    {
                                        //有库存价格  
                                        model_meal_good.standard_price = model_standard_price.sell_price;
                                        model_meal_good.action_price = model_standard_price.action_price;
                                    }
                                    model_meal_good.standard_group_price = Convert.ToDecimal(dr_group_price["group_price"]);
                                    model_meal_good.add_time = DateTime.Now;

                                    bll_meal_good.Add(model_meal_good);
                                }

                            }
                            else
                            {
                                if (model_good.group_price.Count > 0)
                                {
                                    foreach (Model.user_group_price model_user_group in model_good.group_price)
                                    {
                                        Model.meal_good model_meal_good = new Model.meal_good();
                                        model_meal_good.good_id = Convert.ToInt32(arr_str[i].Split('_')[0]);
                                        model_meal_good.group_id = model_user_group.group_id;
                                        model_meal_good.meal_id = _id;
                                        model_meal_good.standard_price_id = Convert.ToDecimal(arr_str[i].Split('_')[1]);
                                        model_meal_good.unit_id = Convert.ToInt32(arr_str[i].Split('_')[2]);
                                        model_meal_good.quantity = Convert.ToInt32(arr_str[i].Split('_')[3]);
                                        model_meal_good.sell_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                        model_meal_good.standard_price = Convert.ToDecimal(model_good.fields["sell_price"]);

                                        Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(arr_str[i].Split('_')[1]));
                                        if (model_standard_price != null)
                                        {
                                            //有库存价格  
                                            model_meal_good.standard_price = model_standard_price.sell_price;
                                            model_meal_good.action_price = model_standard_price.action_price;
                                        }
                                        model_meal_good.standard_group_price = Convert.ToDecimal(model_user_group.price);
                                        model_meal_good.add_time = DateTime.Now;
                                        bll_meal_good.Add(model_meal_good);
                                    }

                                }
                                else
                                {
                                    Model.meal_good model_meal_good = new Model.meal_good();
                                    model_meal_good.good_id = Convert.ToInt32(arr_str[i].Split('_')[0]);
                                    model_meal_good.group_id = 0;
                                    model_meal_good.meal_id = _id;
                                    model_meal_good.standard_price_id = Convert.ToDecimal(arr_str[i].Split('_')[1]);
                                    model_meal_good.unit_id = Convert.ToInt32(arr_str[i].Split('_')[2]);
                                    model_meal_good.quantity = Convert.ToInt32(arr_str[i].Split('_')[3]);
                                    model_meal_good.sell_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                    model_meal_good.standard_price = Convert.ToDecimal(model_good.fields["sell_price"]);

                                    Model.standard_price model_standard_price = bll_standard_price.GetModel(Convert.ToDecimal(arr_str[i].Split('_')[1]));
                                    if (model_standard_price != null)
                                    {
                                        //有库存价格  
                                        model_meal_good.standard_price = model_standard_price.sell_price;
                                        model_meal_good.action_price = model_standard_price.action_price;
                                    }
                                    model_meal_good.standard_group_price = Convert.ToDecimal(model_good.fields["sell_price"]);
                                    model_meal_good.add_time = DateTime.Now;
                                    bll_meal_good.Add(model_meal_good);
                                }
                            }

                        }
                    }
                }
                //AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改用户信息:" + model.user_name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                //ChkAdminLevel("user_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改套餐成功！", "list.aspx", "Success");

                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>$('#ldg_lockmask').css('display','none')</script>", true);
            }
            else //添加
            {
                //ChkAdminLevel("user_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加套餐成功！", "list.aspx", "Success");
                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>$('#ldg_lockmask').css('display','none')</script>", true);
            }
        }

    }
}