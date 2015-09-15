﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.property
{
    public partial class edit : Web.UI.ManagePage
    {

        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected string str_property_value = "";


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
                if (!new BLL.property().Exists(this.id))
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
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, 2);

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
            BLL.property bll = new BLL.property();
            Model.property model = bll.GetModel(_id);
            ddlCategoryId.SelectedValue = model.category_id.ToString();
            txt_title.Text = model.title;
            if (model.property_values != null)
            {
                foreach (Model.property_value model_value in model.property_values)
                {
                    str_property_value += "<span onclick=\"ck_property_value(this)\">&nbsp;&nbsp;" + model_value.value
                        + "<input type=\"checkbox\" name=\"ck_property_value\" checked=\"checked\" value=\"" + model_value.id + "|" + model_value.value
                        + "\" style=\"display:none;\" />&nbsp;&nbsp;</span>";
                }
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            string property_values = DTRequest.GetFormString("ck_property_value");

            if (string.IsNullOrEmpty(property_values))
            {
                JscriptMsg("保存过程中发生错误！", "", "Error");
                return false;
            }

            BLL.property bll = new BLL.property();
            Model.property model = new Model.property();

            model.title = txt_title.Text.Trim();
            model.category_id = Convert.ToInt32(ddlCategoryId.SelectedValue);
            model.add_time = DateTime.Now;

            List<Model.property_value> lst = new List<Model.property_value>();
            string[] property_value_arr = property_values.Split(',');
            Model.property_value model_value;
            foreach (string str in property_value_arr)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    model_value = new Model.property_value();
                    model_value.value = str.Split('|')[1];
                    model_value.add_time = DateTime.Now;
                    lst.Add(model_value);
                }
            }
            model.property_values = lst;
            if (bll.Add(model) > 0)
            {
                //AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加用户:" + model.user_name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            string property_values = DTRequest.GetFormString("ck_property_value");
            BLL.property bll = new BLL.property();
            Model.property model = bll.GetModel(_id);
            model.title = txt_title.Text.Trim();
            model.category_id = Convert.ToInt32(ddlCategoryId.SelectedValue);

            List<Model.property_value> lst = new List<Model.property_value>();
            string[] property_value_arr = property_values.Split(',');
            Model.property_value model_value;
            foreach (string str in property_value_arr)
            {
                model_value = new Model.property_value();
                model_value.id = Convert.ToDecimal(str.Split('|')[0]);
                model_value.value = str.Split('|')[1];
                model_value.add_time = DateTime.Now;
                lst.Add(model_value);
            }
            model.property_values = lst;

            if (bll.Update(model))
            {
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
                JscriptMsg("修改规格成功！", "list.aspx", "Success");
            }
            else //添加
            {
                //ChkAdminLevel("user_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加规格成功！", "list.aspx", "Success");
            }
        }
    }
}