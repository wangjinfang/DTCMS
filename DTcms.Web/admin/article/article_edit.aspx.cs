using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.article
{
    public partial class article_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected string channel_name = string.Empty; //频道名称
        protected int channel_id;
        private int id = 0;

        //页面初始化事件
        protected void Page_Init(object sernder, EventArgs e)
        {
            this.channel_id = DTRequest.GetQueryInt("channel_id");
            CreateOtherField(this.channel_id); //动态生成相应的扩展字段
        }

        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得频道名称

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.article().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("channel_" + this.channel_name + "_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                ShowSysField(this.channel_id); //显示相应的默认控件
                GroupBind(""); //绑定用户组
                TreeBind(this.channel_id); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }


        #region 创建其它扩展字段=========================
        private void CreateOtherField(int _channel_id)
        {
            List<Model.article_attribute_field> ls = new BLL.article_attribute_field().GetModelList(this.channel_id, "is_sys=0");
            if (ls.Count > 0)
            {
                field_tab_item.Visible = true;
                field_tab_content.Visible = true;
            }
            foreach (Model.article_attribute_field modelt in ls)
            {
                //创建一个dl标签
                HtmlGenericControl htmlDL = new HtmlGenericControl("dl");
                HtmlGenericControl htmlDT = new HtmlGenericControl("dt");
                HtmlGenericControl htmlDD = new HtmlGenericControl("dd");
                htmlDT.InnerHtml = modelt.title;

                switch (modelt.control_type)
                {
                    case "single-text": //单行文本
                        //创建一个TextBox控件
                        TextBox txtControl = new TextBox();
                        txtControl.ID = "field_control_" + modelt.name;
                        //CSS样式及TextMode设置
                        if (modelt.control_type == "single-text") //单行
                        {
                            txtControl.CssClass = "input normal";
                            //是否密码框
                            if (modelt.is_password == 1)
                            {
                                txtControl.TextMode = TextBoxMode.Password;
                            }
                        }
                        else if (modelt.control_type == "multi-text") //多行
                        {
                            txtControl.CssClass = "input";
                            txtControl.TextMode = TextBoxMode.MultiLine;
                        }
                        else if (modelt.control_type == "number") //数字
                        {
                            txtControl.CssClass = "input small";
                        }
                        else if (modelt.control_type == "images") //图片
                        {
                            txtControl.CssClass = "input normal upload-path";
                        }
                        //设置默认值
                        txtControl.Text = modelt.default_value;
                        //验证提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_tip_msg))
                        {
                            txtControl.Attributes.Add("tipmsg", modelt.valid_tip_msg);
                        }
                        //验证失败提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_error_msg))
                        {
                            txtControl.Attributes.Add("errormsg", modelt.valid_error_msg);
                        }
                        //验证表达式
                        if (!string.IsNullOrEmpty(modelt.valid_pattern))
                        {
                            txtControl.Attributes.Add("datatype", modelt.valid_pattern);
                            txtControl.Attributes.Add("sucmsg", " ");
                        }
                        //创建一个Label控件
                        Label labelControl = new Label();
                        labelControl.CssClass = "Validform_checktip";
                        labelControl.Text = modelt.valid_tip_msg;

                        //将控件添加至DD中
                        htmlDD.Controls.Add(txtControl);
                        //如果是图片则添加上传按钮
                        if (modelt.control_type == "images")
                        {
                            HtmlGenericControl htmlBtn = new HtmlGenericControl("div");
                            htmlBtn.Attributes.Add("class", "upload-box upload-img");
                            htmlBtn.Attributes.Add("style", "margin-left:4px;");
                            htmlDD.Controls.Add(htmlBtn);
                        }
                        htmlDD.Controls.Add(labelControl);
                        break;
                    case "multi-text": //多行文本
                        goto case "single-text";
                    case "editor": //编辑器
                        HtmlTextArea txtTextArea = new HtmlTextArea();
                        txtTextArea.ID = "field_control_" + modelt.name;
                        txtTextArea.Attributes.Add("style", "visibility:hidden;");
                        //是否简洁型编辑器
                        if (modelt.editor_type == 1)
                        {
                            txtTextArea.Attributes.Add("class", "editor-mini");
                        }
                        else
                        {
                            txtTextArea.Attributes.Add("class", "editor");
                        }
                        txtTextArea.Value = modelt.default_value; //默认值
                        //验证提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_tip_msg))
                        {
                            txtTextArea.Attributes.Add("tipmsg", modelt.valid_tip_msg);
                        }
                        //验证失败提示信息
                        if (!string.IsNullOrEmpty(modelt.valid_error_msg))
                        {
                            txtTextArea.Attributes.Add("errormsg", modelt.valid_error_msg);
                        }
                        //验证表达式
                        if (!string.IsNullOrEmpty(modelt.valid_pattern))
                        {
                            txtTextArea.Attributes.Add("datatype", modelt.valid_pattern);
                            txtTextArea.Attributes.Add("sucmsg", " ");
                        }
                        //创建一个Label控件
                        Label labelControl2 = new Label();
                        labelControl2.CssClass = "Validform_checktip";
                        labelControl2.Text = modelt.valid_tip_msg;
                        //将控件添加至DD中
                        htmlDD.Controls.Add(txtTextArea);
                        htmlDD.Controls.Add(labelControl2);
                        break;
                    case "images": //图片上传
                        goto case "single-text";
                    case "number": //数字
                        goto case "single-text";
                    case "checkbox": //复选框
                        CheckBox cbControl = new CheckBox();
                        cbControl.ID = "field_control_" + modelt.name;
                        //默认值
                        if (modelt.default_value == "1")
                        {
                            cbControl.Checked = true;
                        }
                        HtmlGenericControl htmlDiv1 = new HtmlGenericControl("div");
                        htmlDiv1.Attributes.Add("class", "rule-single-checkbox");
                        htmlDiv1.Controls.Add(cbControl);
                        //将控件添加至DD中
                        htmlDD.Controls.Add(htmlDiv1);
                        if (!string.IsNullOrEmpty(modelt.valid_tip_msg))
                        {
                            //创建一个Label控件
                            Label labelControl3 = new Label();
                            labelControl3.CssClass = "Validform_checktip";
                            labelControl3.Text = modelt.valid_tip_msg;
                            htmlDD.Controls.Add(labelControl3);
                        }
                        break;
                    case "multi-radio": //多项单选
                        RadioButtonList rblControl = new RadioButtonList();
                        rblControl.ID = "field_control_" + modelt.name;
                        rblControl.RepeatDirection = RepeatDirection.Horizontal;
                        rblControl.RepeatLayout = RepeatLayout.Flow;
                        HtmlGenericControl htmlDiv2 = new HtmlGenericControl("div");
                        htmlDiv2.Attributes.Add("class", "rule-multi-radio");
                        htmlDiv2.Controls.Add(rblControl);
                        //赋值选项
                        string[] valArr = modelt.item_option.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        for (int i = 0; i < valArr.Length; i++)
                        {
                            string[] valItemArr = valArr[i].Split('|');
                            if (valItemArr.Length == 2)
                            {
                                rblControl.Items.Add(new ListItem(valItemArr[0], valItemArr[1]));
                            }
                        }
                        rblControl.SelectedValue = modelt.default_value; //默认值
                        //创建一个Label控件
                        Label labelControl4 = new Label();
                        labelControl4.CssClass = "Validform_checktip";
                        labelControl4.Text = modelt.valid_tip_msg;
                        //将控件添加至DD中
                        htmlDD.Controls.Add(htmlDiv2);
                        htmlDD.Controls.Add(labelControl4);
                        break;
                    case "multi-checkbox": //多项多选
                        CheckBoxList cblControl = new CheckBoxList();
                        cblControl.ID = "field_control_" + modelt.name;
                        cblControl.RepeatDirection = RepeatDirection.Horizontal;
                        cblControl.RepeatLayout = RepeatLayout.Flow;
                        HtmlGenericControl htmlDiv3 = new HtmlGenericControl("div");
                        htmlDiv3.Attributes.Add("class", "rule-multi-checkbox");
                        htmlDiv3.Controls.Add(cblControl);
                        //赋值选项
                        string[] valArr2 = modelt.item_option.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        for (int i = 0; i < valArr2.Length; i++)
                        {
                            string[] valItemArr2 = valArr2[i].Split('|');
                            if (valItemArr2.Length == 2)
                            {
                                cblControl.Items.Add(new ListItem(valItemArr2[0], valItemArr2[1]));
                            }
                        }
                        cblControl.SelectedValue = modelt.default_value; //默认值
                        //创建一个Label控件
                        Label labelControl5 = new Label();
                        labelControl5.CssClass = "Validform_checktip";
                        labelControl5.Text = modelt.valid_tip_msg;
                        //将控件添加至DD中
                        htmlDD.Controls.Add(htmlDiv3);
                        htmlDD.Controls.Add(labelControl5);
                        break;
                }

                //将DT和DD添加到DL中
                htmlDL.Controls.Add(htmlDT);
                htmlDL.Controls.Add(htmlDD);
                //将DL添加至field_tab_content中
                field_tab_content.Controls.Add(htmlDL);
            }
        }
        #endregion

        #region 显示默认扩展字段=========================
        private void ShowSysField(int _channel_id)
        {
            //查找该频道所选的默认字段
            List<Model.article_attribute_field> ls = new BLL.article_attribute_field().GetModelList(this.channel_id, "is_sys=1");
            foreach (Model.article_attribute_field modelt in ls)
            {
                //查找相应的控件，如找到则显示
                HtmlGenericControl htmlDiv = FindControl("div_" + modelt.name) as HtmlGenericControl;
                if (htmlDiv != null)
                {
                    htmlDiv.Visible = true;
                    ((Label)htmlDiv.FindControl("div_" + modelt.name + "_title")).Text = modelt.title;
                    ((TextBox)htmlDiv.FindControl("field_control_" + modelt.name)).Text = modelt.default_value;
                    ((Label)htmlDiv.FindControl("div_" + modelt.name + "_tip")).Text = modelt.valid_tip_msg;
                }
            }
            //查找该频道所开启的功能
            Model.channel channelModel = new BLL.channel().GetModel(_channel_id);
            if (channelModel.is_albums == 1)
            {
                div_albums_container.Visible = true;
            }
            if (channelModel.is_attach == 1)
            {
                div_attach_container.Visible = true;
            }
            if (channelModel.is_group_price == 1)
            {

            }

            if (channelModel.name == "goods")
            {
                div_standard.Visible = true;
                div_good_isput.Visible = true;
            }
        }
        #endregion

        #region 绑定类别=================================
        private void TreeBind(int _channel_id)
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, _channel_id);

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
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(_id);

            ddlCategoryId.SelectedValue = model.category_id.ToString();
            txtCallIndex.Text = model.call_index;
            txtTitle.Text = model.title;
            txtLinkUrl.Text = model.link_url;
            //不是相册图片就绑定
            string filename = model.img_url.Substring(model.img_url.LastIndexOf("/") + 1);
            if (!filename.StartsWith("thumb_"))
            {
                txtImgUrl.Text = model.img_url;
            }
            txtSeoTitle.Text = model.seo_title;
            txtSeoKeywords.Text = model.seo_keywords;
            txtSeoDescription.Text = model.seo_description;
            txtZhaiyao.Text = model.zhaiyao;
            txtContent.Value = model.content;
            txtSortId.Text = model.sort_id.ToString();
            txtClick.Text = model.click.ToString();
            rblStatus.SelectedValue = model.status.ToString();
            txtAddTime.Text = model.add_time.ToString("yyyy-MM-dd HH:mm:ss");
            if (model.is_msg == 1)
            {
                cblItem.Items[0].Selected = true;
            }
            if (model.is_top == 1)
            {
                cblItem.Items[1].Selected = true;
            }
            if (model.is_red == 1)
            {
                cblItem.Items[2].Selected = true;
            }
            if (model.is_hot == 1)
            {
                cblItem.Items[3].Selected = true;
            }
            if (model.is_slide == 1)
            {
                cblItem.Items[4].Selected = true;
            }

            if (model.is_put == 1)
            {
                isPut.Items[0].Selected = false;
                isPut.Items[1].Selected = true;
            }
            else
            {
                isPut.Items[1].Selected = false;
                isPut.Items[0].Selected = true;
            }
            //扩展字段赋值
            List<Model.article_attribute_field> ls1 = new BLL.article_attribute_field().GetModelList(this.channel_id, "");
            foreach (Model.article_attribute_field modelt1 in ls1)
            {
                switch (modelt1.control_type)
                {
                    case "single-text": //单行文本
                        TextBox txtControl = FindControl("field_control_" + modelt1.name) as TextBox;
                        if (txtControl != null && model.fields.ContainsKey(modelt1.name))
                        {
                            if (modelt1.is_password == 1)
                            {
                                txtControl.Attributes.Add("value", model.fields[modelt1.name]);
                            }
                            else
                            {
                                txtControl.Text = model.fields[modelt1.name];
                            }
                        }
                        break;
                    case "multi-text": //多行文本
                        goto case "single-text";
                    case "editor": //编辑器
                        HtmlTextArea txtAreaControl = FindControl("field_control_" + modelt1.name) as HtmlTextArea;
                        if (txtAreaControl != null && model.fields.ContainsKey(modelt1.name))
                        {
                            txtAreaControl.Value = model.fields[modelt1.name];
                        }
                        break;
                    case "images": //图片上传
                        goto case "single-text";
                    case "number": //数字
                        goto case "single-text";
                    case "checkbox": //复选框
                        CheckBox cbControl = FindControl("field_control_" + modelt1.name) as CheckBox;
                        if (cbControl != null && model.fields.ContainsKey(modelt1.name))
                        {
                            if (model.fields[modelt1.name] == "1")
                            {
                                cbControl.Checked = true;
                            }
                            else
                            {
                                cbControl.Checked = false;
                            }
                        }
                        break;
                    case "multi-radio": //多项单选
                        RadioButtonList rblControl = FindControl("field_control_" + modelt1.name) as RadioButtonList;
                        if (rblControl != null && model.fields.ContainsKey(modelt1.name))
                        {
                            rblControl.SelectedValue = model.fields[modelt1.name];
                        }
                        break;
                    case "multi-checkbox": //多项多选
                        CheckBoxList cblControl = FindControl("field_control_" + modelt1.name) as CheckBoxList;
                        if (cblControl != null && model.fields.ContainsKey(modelt1.name))
                        {
                            string[] valArr = model.fields[modelt1.name].Split(',');
                            for (int i = 0; i < cblControl.Items.Count; i++)
                            {
                                cblControl.Items[i].Selected = false; //先取消默认的选中
                                foreach (string str in valArr)
                                {
                                    if (cblControl.Items[i].Value == str)
                                    {
                                        cblControl.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            //绑定图片相册
            if (filename.StartsWith("thumb_"))
            {
                hidFocusPhoto.Value = model.img_url; //封面图片
            }
            rptAlbumList.DataSource = model.albums;
            rptAlbumList.DataBind();
            //绑定内容附件
            rptAttachList.DataSource = model.attach;
            rptAttachList.DataBind();
            //赋值用户组价格
            if (model.group_price != null)
            {
                for (int i = 0; i < this.rptPrice.Items.Count; i++)
                {
                    int hideId = Convert.ToInt32(((HiddenField)this.rptPrice.Items[i].FindControl("hideGroupId")).Value);
                    foreach (Model.user_group_price modelt in model.group_price)
                    {
                        if (hideId == modelt.group_id)
                        {
                            ((HiddenField)this.rptPrice.Items[i].FindControl("hidePriceId")).Value = modelt.id.ToString();
                            ((TextBox)this.rptPrice.Items[i].FindControl("txtGroupPrice")).Text = modelt.price.ToString();
                        }
                    }
                }
            }

            #region  商品相关
            if (channel_name == "goods")
            {
                //规格价格
                BLL.standard bll_standard = new BLL.standard();
                BLL.standard_price bll_price = new BLL.standard_price();
                Model.article_category model_category = new BLL.article_category().GetModel(model.category_id);
                string str1 = "";
                if (model_category != null)
                {
                    DataTable dt = bll_standard.GetList(0, "'" + model_category.class_list + "' like '%,'+convert(varchar(50),category_id)+',%'", "id asc").Tables[0];
                    
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string is_checked = "";
                            DataTable dt_price1 = bll_price.GetList(0, "good_id=" + _id, "id asc").Tables[0];
                            if (dt_price1 != null && dt_price1.Rows.Count > 0)
                            {
                                foreach (DataRow dr1 in dt_price1.Rows)
                                {
                                    string[] standard_ids = dr1["standard_ids"].ToString().Trim().Split(',');
                                    foreach (string str in standard_ids)
                                    {
                                        if (!string.IsNullOrEmpty(str))
                                        {
                                            if (Convert.ToInt32(dr["id"]) == Convert.ToInt32(str))
                                            {
                                                is_checked = " checked=\"checked\" ";
                                            }
                                        }
                                    }
                                }


                            }

                            str1 += "<label><input type=\"checkbox\" value=\"" + dr["id"].ToString() + "\" name=\"ck_standard\" " + is_checked + " onclick=\"change_standard('ck_standard')\" />" + dr["title"].ToString() + "</label>&nbsp;&nbsp;&nbsp;";
                           
                        }
                        dd_standard_title.InnerHtml = str1;
                    }
                }


                DataTable dt_price = bll_price.GetList(0, "good_id=" + _id, "id asc").Tables[0];
                if (dt_price != null && dt_price.Rows.Count > 0)
                {
                    //规格
                    //string str_standard = "";
                    //string[] str_standardid_arr = dt_price.Rows[0]["standard_ids"].ToString().Split(',');
                    string[] str_standardtitle_arr = dt_price.Rows[0]["standards"].ToString().Split(',');
                    //for (int i = 0; i < str_standardid_arr.Length; i++)
                    //{
                    //    str_standard += "<label><input type=\"checkbox\" checked=\"checked\" value=\"" + str_standardid_arr[i].ToString() + "\" name=\"ck_standard\" onclick=\"change_standard('ck_standard')\" />" + str_standardtitle_arr[i].ToString() + "</label>&nbsp;&nbsp;&nbsp;";
                    //}
                    //dd_standard_title.InnerHtml = str_standard;


                    //规格值  规格价格
                    //头部

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
                    string rest_header = "";
                    rest_header += "<tr><td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>商品编号</td>";
                    for (int i = 0; i < str_standardtitle_arr.Length; i++)
                    {
                        rest_header += "<td  style='font-weight:bold;color:#33B5E5; padding-right:10px;'>" + str_standardtitle_arr[i] + "</td>";
                    }
                    rest_header += "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>库存</td>"
                        + "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>市场价</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>销售价</td>"
                    + "<td style='font-weight:bold;color:#33B5E5;text-align:left;padding-right:10px;'>活动价</td>"
                    + str_groups_header + "</tr>";

                    string rest_body = "";

                    foreach (DataRow dr in dt_price.Rows)
                    {
                        string[] str_arr_value = dr["standard_values"].ToString().Split(',');
                        rest_body += "<tr><td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;width: 100px;' type='text' class='input normal small' name='good_no_" + dr["standard_value_ids"].ToString().Replace(',', '_') + "' value='" + dr["good_no"].ToString() + "'/></td>";
                        foreach (string str in str_arr_value)
                        {
                            rest_body += "<td style='padding-right: 20px;'>" + str + "</td>";
                        }
                        rest_body += "<td style='padding-right: 20px;'><input type='checkbox' value='" + dr["standard_value_ids"].ToString().Replace(',', '_') + "'  name='ck_standard_value' checked='checked' style='display:none;'/>";
                        rest_body += "<input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='stock_quantity_" + dr["standard_value_ids"].ToString().Replace(',', '_') + "' value='" + dr["stock_quantity"].ToString() + "'/></td>";
                        rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='market_price_" + dr["standard_value_ids"].ToString().Replace(',', '_') + "' value='" + dr["market_price"].ToString() + "'/></td>";
                        rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='sell_price_" + dr["standard_value_ids"].ToString().Replace(',', '_') + "' value='" + dr["sell_price"].ToString() + "'/></td>";
                        rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='action_price_" + dr["standard_value_ids"].ToString().Replace(',', '_') + "' value='" + dr["action_price"].ToString() + "'/></td>";
                        for (int i = 0; i < dt_groups.Rows.Count; i++)
                        {
                            BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();
                            Model.standard_group_price model_standard_group_price = bll_standard_group_price.GetModel(_id, Convert.ToInt32(dt_groups.Rows[i]["id"]), Convert.ToDecimal(dr["id"]));
                            if (model_standard_group_price != null)
                            {
                                rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='user_price_" + dt_groups.Rows[i]["id"].ToString() + "_" + dr["standard_value_ids"].ToString().Replace(',', '_') + "' value='" + model_standard_group_price.group_price + "'/></td>";
                            }
                            else
                            {
                                foreach (Model.user_group_price modelt in model.group_price)
                                {
                                    if (Convert.ToInt32(dt_groups.Rows[i]["id"]) == modelt.group_id)
                                    {
                                        rest_body += "<td style='padding-right: 20px;'><input style='border: 1px solid #d8d8d8;margin: 10px 18px 12px 0;' type='text' class='input normal small' name='user_price_" + dt_groups.Rows[i]["id"].ToString() + "_" + dr["standard_value_ids"].ToString().Replace(',', '_') + "' value='" + modelt.price + "'/></td>";
                                    }
                                }

                            }
                        }


                        rest_body += "</tr>";
                    }

                    dd_standard_value.InnerHtml = "<table>" + rest_header + rest_body + "</table>";

                }

                //单位
                BLL.unit bll_unit = new BLL.unit();
                DataTable dt_unit = bll_unit.GetList("good_id=" + _id).Tables[0];
                string str_unit = "";
                if (dt_unit != null && dt_unit.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_unit.Rows)
                    {
                        string unit = dr["title"].ToString() + "_" + Convert.ToInt32(dr["quantity"]) + "_" + Convert.ToDecimal(dr["rate"]) + "_" + dr["content"].ToString();
                        str_unit += "<tr>";
                        str_unit += "<td style='padding-right: 20px;'>" + dr["title"].ToString() + "<input type=\"checkbox\" name=\"ck_unit\" value=\"" + unit + "\" checked=\"checked\" style=\"display:none;\">" + "</td>";
                        str_unit += "<td style='padding-right: 20px;'>" + Convert.ToInt32(dr["quantity"]) + "</td>";
                        str_unit += "<td style='padding-right: 20px;'>" + Convert.ToDecimal(dr["rate"]) + "</td>";
                        str_unit += "<td style='padding-right: 20px;'>" + dr["content"].ToString() + "</td>";
                        str_unit += "<td style='padding-right: 20px;'><a href=\"javascript:;\" onclick=\"del_unit(this)\">删除</a></td>";
                        str_unit += "</tr>";
                    }
                }
                tb_unit_value.InnerHtml = str_unit;


                //别名
                BLL.alias bll_alias = new BLL.alias();
                DataTable dt_alias = bll_alias.GetList(" category_id in(select id from dt_article_category where (select class_list from dt_article_category where id=" + model.category_id + ") like '%,'+CONVERT(varchar(20),id)+',%')").Tables[0];
                if (dt_alias != null && dt_alias.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_alias.Rows)
                    {
                        ck_alias.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
                    }
                }

                BLL.alias_good bll_alias_good = new BLL.alias_good();
                for (int i = 0; i < ck_alias.Items.Count; i++)
                {
                    DataTable dt_have = bll_alias_good.GetList("alias_id=" + ck_alias.Items[i].Value + " and good_id=" + _id).Tables[0];
                    if (dt_have != null && dt_have.Rows.Count > 0)
                    {
                        ck_alias.Items[i].Selected = true;
                    }
                }

                //属性
                BLL.property bll_property = new BLL.property();
                DataTable dt_property = bll_property.GetList(" category_id in(select id from dt_article_category where (select class_list from dt_article_category where id=" + model.category_id + ") like '%,'+CONVERT(varchar(20),id)+',%')").Tables[0];
                string str_result = "";
                foreach (DataRow dr in dt_property.Rows)
                {
                    str_result += "<dl>";
                    str_result += "<dt>" + dr["title"].ToString() + "：</dt>";
                    BLL.property_value bll_value = new BLL.property_value();
                    DataTable dt_property_value = bll_value.GetList("property_id=" + dr["id"].ToString()).Tables[0];
                    str_result += "<dd>";
                    if (dt_property_value != null && dt_property_value.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt_property_value.Rows)
                        {
                            BLL.property_good bll_property_good = new BLL.property_good();
                            DataTable dt_property_good = bll_property_good.GetList("good_id=" + model.id + " and property_value_id=" + dr1["id"].ToString()).Tables[0];
                            if (dt_property_good != null && dt_property_good.Rows.Count > 0)
                            {
                                str_result += "<label><input type=\"checkbox\" name=\"ck_property_value\" checked=\"checked\" value=\"" + dr1["id"].ToString() + "\" />" + dr1["value"].ToString() + "</label>&nbsp;&nbsp;&nbsp;";
                            }
                            else
                            {
                                str_result += "<label><input type=\"checkbox\" name=\"ck_property_value\" value=\"" + dr1["id"].ToString() + "\" />" + dr1["value"].ToString() + "</label>&nbsp;&nbsp;&nbsp;";
                            }
                        }

                    }
                    str_result += "</dd>";
                    str_result += "</dl>";
                }

                div_property.InnerHtml = str_result;


                //标签
                BLL.tag bll_tag = new BLL.tag();
                DataTable dt_tag = bll_tag.GetList(" category_id in(select id from dt_article_category where (select class_list from dt_article_category where id=" + model.category_id + ") like '%,'+CONVERT(varchar(20),id)+',%')").Tables[0];
                if (dt_tag != null && dt_tag.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_tag.Rows)
                    {
                        ck_tag.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
                    }
                }

                BLL.tag_good bll_tag_good = new BLL.tag_good();
                for (int i = 0; i < ck_tag.Items.Count; i++)
                {
                    DataTable dt_have = bll_tag_good.GetList("tag_id=" + ck_tag.Items[i].Value + " and good_id=" + _id).Tables[0];
                    if (dt_have != null && dt_have.Rows.Count > 0)
                    {
                        ck_tag.Items[i].Selected = true;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region 绑定会员组===============================
        private void GroupBind(string strWhere)
        {
            //检查网站是否开启会员功能
            if (siteConfig.memberstatus == 0)
            {
                return;
            }
            //检查该频道是否开启会员组价格
            Model.channel model = new BLL.channel().GetModel(this.channel_id);
            if (model == null || model.is_group_price == 0)
            {
                return;
            }
            BLL.user_groups bll = new BLL.user_groups();
            DataSet ds = bll.GetList(0, strWhere, "grade asc,id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.rptPrice.DataSource = ds;
                this.rptPrice.DataBind();
            }
        }
        #endregion

        #region 扩展字段赋值=============================
        private Dictionary<string, string> SetFieldValues(int _channel_id)
        {
            DataTable dt = new BLL.article_attribute_field().GetList(_channel_id, "").Tables[0];
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow dr in dt.Rows)
            {
                //查找相应的控件
                switch (dr["control_type"].ToString())
                {
                    case "single-text": //单行文本
                        TextBox txtControl = FindControl("field_control_" + dr["name"].ToString()) as TextBox;
                        if (txtControl != null)
                        {
                            dic.Add(dr["name"].ToString(), txtControl.Text.Trim());

                        }
                        break;
                    case "multi-text": //多行文本
                        goto case "single-text";
                    case "editor": //编辑器
                        HtmlTextArea htmlTextAreaControl = FindControl("field_control_" + dr["name"].ToString()) as HtmlTextArea;
                        if (htmlTextAreaControl != null)
                        {
                            dic.Add(dr["name"].ToString(), htmlTextAreaControl.Value);
                        }
                        break;
                    case "images": //图片上传
                        goto case "single-text";
                    case "number": //数字
                        goto case "single-text";
                    case "checkbox": //复选框
                        CheckBox cbControl = FindControl("field_control_" + dr["name"].ToString()) as CheckBox;
                        if (cbControl != null)
                        {
                            if (cbControl.Checked == true)
                            {
                                dic.Add(dr["name"].ToString(), "1");
                            }
                            else
                            {
                                dic.Add(dr["name"].ToString(), "0");
                            }
                        }
                        break;
                    case "multi-radio": //多项单选
                        RadioButtonList rblControl = FindControl("field_control_" + dr["name"].ToString()) as RadioButtonList;
                        if (rblControl != null)
                        {
                            dic.Add(dr["name"].ToString(), rblControl.SelectedValue);
                        }
                        break;
                    case "multi-checkbox": //多项多选
                        CheckBoxList cblControl = FindControl("field_control_" + dr["name"].ToString()) as CheckBoxList;
                        if (cblControl != null)
                        {
                            StringBuilder tempStr = new StringBuilder();
                            for (int i = 0; i < cblControl.Items.Count; i++)
                            {
                                if (cblControl.Items[i].Selected)
                                {
                                    tempStr.Append(cblControl.Items[i].Value.Replace(',', '，') + ",");
                                }
                            }
                            dic.Add(dr["name"].ToString(), Utils.DelLastComma(tempStr.ToString()));
                        }
                        break;
                }
            }
            return dic;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.article model = new Model.article();
            BLL.article bll = new BLL.article();

            model.channel_id = this.channel_id;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            model.is_put = 1;
            if (isPut.Items[0].Selected)
            {
                model.is_put = 0;
            }
            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.click = int.Parse(txtClick.Text.Trim());
            model.status = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.is_msg = 0;
            model.is_top = 0;
            model.is_red = 0;
            model.is_hot = 0;
            model.is_slide = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_top = 1;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.is_red = 1;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.is_hot = 1;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.is_slide = 1;
            }
            model.is_sys = 1; //管理员发布
            model.user_name = "admin"; //获得当前登录用户名
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
            model.fields = SetFieldValues(this.channel_id); //扩展字段赋值

            #region 保存相册====================
            //检查是否有自定义图片
            if (txtImgUrl.Text.Trim() == "")
            {
                model.img_url = hidFocusPhoto.Value;
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Model.article_albums> ls = new List<Model.article_albums>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.article_albums { original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.article_albums { original_path = imgArr[1], thumb_path = imgArr[2] });
                        }
                    }
                }
                model.albums = ls;
            }
            #endregion

            #region 保存附件====================
            //保存附件
            string[] attachFileNameArr = Request.Form.GetValues("hid_attach_filename");
            string[] attachFilePathArr = Request.Form.GetValues("hid_attach_filepath");
            string[] attachFileSizeArr = Request.Form.GetValues("hid_attach_filesize");
            string[] attachPointArr = Request.Form.GetValues("txt_attach_point");
            if (attachFileNameArr != null && attachFilePathArr != null && attachFileSizeArr != null && attachPointArr != null
                && attachFileNameArr.Length > 0 && attachFilePathArr.Length > 0 && attachFileSizeArr.Length > 0 && attachPointArr.Length > 0)
            {
                List<Model.article_attach> ls = new List<Model.article_attach>();
                for (int i = 0; i < attachFileNameArr.Length; i++)
                {
                    int fileSize = Utils.StrToInt(attachFileSizeArr[i], 0);
                    string fileExt = Utils.GetFileExt(attachFilePathArr[i]);
                    int _point = Utils.StrToInt(attachPointArr[i], 0);
                    ls.Add(new Model.article_attach { file_name = attachFileNameArr[i], file_path = attachFilePathArr[i], file_size = fileSize, file_ext = fileExt, point = _point });
                }
                model.attach = ls;
            }
            #endregion

            #region 保存会员组价格==============
            List<Model.user_group_price> priceList = new List<Model.user_group_price>();
            for (int i = 0; i < rptPrice.Items.Count; i++)
            {
                int _groupid = Convert.ToInt32(((HiddenField)rptPrice.Items[i].FindControl("hideGroupId")).Value);
                decimal _price = Convert.ToDecimal(((TextBox)rptPrice.Items[i].FindControl("txtGroupPrice")).Text.Trim());
                priceList.Add(new Model.user_group_price { group_id = _groupid, price = _price });
            }
            model.group_price = priceList;
            #endregion

            int _id = bll.Add(model);

            if (_id > 0)
            {
                #region  商品相关
                if (channel_name == "goods")
                {
                    #region  规格相关
                    //规格 
                    string standard_ids = DTRequest.GetFormString("ck_standard");
                    string standard_value_ids = DTRequest.GetFormString("ck_standard_value");
                    //string good_nos = DTRequest.GetFormString("good_no");


                    string str_standards = "";
                    BLL.standard bll_standard = new BLL.standard();
                    string[] str_standard_arr = standard_ids.Split(','); 
                    foreach (string str in str_standard_arr)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            Model.standard model_standard = bll_standard.GetModel(Convert.ToInt32(str));
                            if (model_standard != null)
                            {
                                str_standards += model_standard.title + ",";
                            }
                        }
                    }


                    BLL.standard_price bll_price = new BLL.standard_price();
                    BLL.standard_value bll_value = new BLL.standard_value();
                    string[] str_standard_value_arr = standard_value_ids.Split(',');
                    foreach (string str in str_standard_value_arr)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            string str_title = "";
                            string[] str_arr = str.Split('_');
                            foreach (string s in str_arr)
                            {
                                if (!string.IsNullOrEmpty(s))
                                {
                                    Model.standard_value model_value = bll_value.GetModel(Convert.ToInt32(s));
                                    if (model_value != null)
                                    {
                                        str_title += model_value.value + ",";
                                    }
                                }
                            }

                            Model.standard_price model_price = new Model.standard_price();
                            model_price.good_no = DTRequest.GetFormString("good_no_" + str);
                            model_price.good_id = _id;
                            model_price.standard_ids = standard_ids;
                            model_price.standards = str_standards.Substring(0, str_standards.Length - 1);
                            model_price.standard_value_ids = str.Replace('_', ',');
                            model_price.standard_values = str_title.Substring(0, str_title.Length - 1);
                            model_price.stock_quantity = DTRequest.GetFormInt("stock_quantity_" + str, 0);
                            model_price.market_price = DTRequest.GetFormDecimal("market_price_" + str, 0);
                            model_price.sell_price = DTRequest.GetFormDecimal("sell_price_" + str, 0);
                            model_price.action_price = DTRequest.GetFormDecimal("action_price_" + str, 0);
                            model_price.user_price = 0;
                            model_price.add_time = DateTime.Now;

                            decimal _standard_price_id = bll_price.Add(model_price);
                            if (_standard_price_id <= 0)
                            {
                                JscriptMsg("规格价格添加失败！", "", "Error");
                                return false;
                            }
                            //规格会员组价格
                            BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();
                            BLL.user_groups bll_user_group = new BLL.user_groups();

                            DataTable dt_user_group = bll_user_group.GetList(0, "", "grade asc,id desc").Tables[0];
                            foreach (DataRow dr_user_group in dt_user_group.Rows)
                            {
                                Model.standard_group_price model_standard_group_price = new Model.standard_group_price();
                                model_standard_group_price.good_id = _id;
                                model_standard_group_price.group_id = Convert.ToInt32(dr_user_group["id"]);
                                model_standard_group_price.standard_price_id = _standard_price_id;
                                model_standard_group_price.group_price = DTRequest.GetFormDecimal("user_price_" + dr_user_group["id"] + "_" + str, 0);
                                model_standard_group_price.add_time = DateTime.Now;
                                if (bll_standard_group_price.Add(model_standard_group_price) <= 0)
                                {
                                    JscriptMsg("规格会员价格添加失败！", "", "Error");
                                    return false;
                                }
                            }
                        }
                    }
                    #endregion


                    //单位 
                    string str_unit = DTRequest.GetFormString("ck_unit");
                    if (!string.IsNullOrEmpty(str_unit))
                    {
                        BLL.unit bll_unit = new BLL.unit();
                        string[] arr_unit = str_unit.Split(',');
                        foreach (string s_unit in arr_unit)
                        {
                            if (!string.IsNullOrEmpty(s_unit))
                            {
                                string[] unit = s_unit.Split('_');
                                Model.unit model_unit = new Model.unit();
                                model_unit.good_id = _id;
                                model_unit.title = unit[0];
                                model_unit.quantity = Convert.ToInt32(unit[1]);
                                model_unit.rate = Convert.ToDecimal(unit[2]);
                                model_unit.content = unit[3];
                                model_unit.add_time = DateTime.Now;

                                if (bll_unit.Add(model_unit) <= 0)
                                {
                                    JscriptMsg("单位添加失败！", "", "Error");
                                    return false;
                                }
                            }
                        }
                    }

                    //别名
                    BLL.alias_good bll_alias_good = new BLL.alias_good();
                    for (int i = 0; i < ck_alias.Items.Count; i++)
                    {
                        if (ck_alias.Items[i].Selected)
                        {
                            Model.alias_good model_alias_good = new Model.alias_good();
                            model_alias_good.alias_id = Convert.ToInt32(ck_alias.Items[i].Value);
                            model_alias_good.good_id = _id;

                            bll_alias_good.Add(model_alias_good);
                        }
                    }

                    //属性

                    BLL.property_value bll_property_value = new BLL.property_value();
                    BLL.property_good bll_property_good = new BLL.property_good();
                    string str_property_value = DTRequest.GetFormString("ck_property_value");
                    if (!string.IsNullOrEmpty(str_property_value))
                    {
                        string[] arr_property_value = str_property_value.Split(',');
                        foreach (string str_1 in arr_property_value)
                        {
                            Model.property_good model_property_good = new Model.property_good();
                            model_property_good.good_id = _id;
                            model_property_good.property_value_id = Convert.ToInt32(str_1);
                            Model.property_value model_property_value = bll_property_value.GetModel(Convert.ToInt32(str_1));
                            if (model_property_value != null)
                            {
                                model_property_good.property_id = model_property_value.property_id;
                            }

                            bll_property_good.Add(model_property_good);
                        }
                    }


                    //标签
                    BLL.tag_good bll_tag_good = new BLL.tag_good();
                    for (int i = 0; i < ck_tag.Items.Count; i++)
                    {
                        if (ck_tag.Items[i].Selected)
                        {
                            Model.tag_good model_tag_good = new Model.tag_good();
                            model_tag_good.tag_id = Convert.ToInt32(ck_tag.Items[i].Value);
                            model_tag_good.good_id = _id;

                            bll_tag_good.Add(model_tag_good);
                        }
                    }
                }
                #endregion

                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加" + this.channel_name + "频道内容:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(_id);


            decimal sell_price = 0;
            decimal standard_price = 0;
            decimal standard_group_price = 0;
            decimal action_price = 0;

            model.channel_id = this.channel_id;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.click = int.Parse(txtClick.Text.Trim());
            model.status = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.is_msg = 0;
            model.is_top = 0;
            model.is_red = 0;
            model.is_hot = 0;
            model.is_slide = 0;
            model.is_put = 1;
            if (isPut.Items[0].Selected)
            {
                model.is_put = 0;
            }
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_top = 1;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.is_red = 1;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.is_hot = 1;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.is_slide = 1;
            }
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
            model.update_time = DateTime.Now;
            model.fields = SetFieldValues(this.channel_id); //扩展字段赋值
            sell_price = Convert.ToDecimal(model.fields["sell_price"]);

            #region 保存相册====================
            //检查是否有自定义图片
            if (txtImgUrl.Text.Trim() == "")
            {
                model.img_url = hidFocusPhoto.Value;
            }
            if (model.albums != null)
            {
                model.albums.Clear();
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null)
            {
                List<Model.article_albums> ls = new List<Model.article_albums>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    int img_id = Utils.StrToInt(imgArr[0], 0);
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.article_albums { id = img_id, article_id = _id, original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.article_albums { id = img_id, article_id = _id, original_path = imgArr[1], thumb_path = imgArr[2] });
                        }
                    }
                }
                model.albums = ls;
            }
            #endregion

            #region 保存附件====================
            if (model.attach != null)
            {
                model.attach.Clear();
            }
            string[] attachIdArr = Request.Form.GetValues("hid_attach_id");
            string[] attachFileNameArr = Request.Form.GetValues("hid_attach_filename");
            string[] attachFilePathArr = Request.Form.GetValues("hid_attach_filepath");
            string[] attachFileSizeArr = Request.Form.GetValues("hid_attach_filesize");
            string[] attachPointArr = Request.Form.GetValues("txt_attach_point");
            if (attachIdArr != null && attachFileNameArr != null && attachFilePathArr != null && attachFileSizeArr != null && attachPointArr != null
                && attachIdArr.Length > 0 && attachFileNameArr.Length > 0 && attachFilePathArr.Length > 0 && attachFileSizeArr.Length > 0 && attachPointArr.Length > 0)
            {
                List<Model.article_attach> ls = new List<Model.article_attach>();
                for (int i = 0; i < attachFileNameArr.Length; i++)
                {
                    int attachId = Utils.StrToInt(attachIdArr[i], 0);
                    int fileSize = Utils.StrToInt(attachFileSizeArr[i], 0);
                    string fileExt = Utils.GetFileExt(attachFilePathArr[i]);
                    int _point = Utils.StrToInt(attachPointArr[i], 0);
                    ls.Add(new Model.article_attach { id = attachId, article_id = _id, file_name = attachFileNameArr[i], file_path = attachFilePathArr[i], file_size = fileSize, file_ext = fileExt, point = _point, });
                }
                model.attach = ls;
            }
            #endregion

            #region 保存会员组价格==============
            List<Model.user_group_price> priceList = new List<Model.user_group_price>();
            for (int i = 0; i < rptPrice.Items.Count; i++)
            {
                int hidPriceId = 0;
                if (!string.IsNullOrEmpty(((HiddenField)rptPrice.Items[i].FindControl("hidePriceId")).Value))
                {
                    hidPriceId = Convert.ToInt32(((HiddenField)rptPrice.Items[i].FindControl("hidePriceId")).Value);
                }
                int hidGroupId = Convert.ToInt32(((HiddenField)rptPrice.Items[i].FindControl("hideGroupId")).Value);
                decimal _price = Convert.ToDecimal(((TextBox)rptPrice.Items[i].FindControl("txtGroupPrice")).Text.Trim());
                priceList.Add(new Model.user_group_price { id = hidPriceId, article_id = _id, group_id = hidGroupId, price = _price });
            }
            model.group_price = priceList;
            #endregion

            if (bll.Update(model))
            {
                #region  商品相关

                if (channel_name == "goods")
                {
                    //规格价格
                    BLL.standard_price bll_price = new BLL.standard_price();
                    DataTable dt = bll_price.GetList(0, "good_id=" + _id, "id asc").Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (!bll_price.Delete("good_id=" + _id))
                        {
                            JscriptMsg("价格信息清除失败！", "", "Error");
                            return false;
                        }
                    }
                    string standard_ids = DTRequest.GetFormString("ck_standard");
                    string standard_value_ids = DTRequest.GetFormString("ck_standard_value");


                    string str_standards = "";
                    BLL.standard bll_standard = new BLL.standard();
                    string[] str_standard_arr = standard_ids.Split(',');
                    foreach (string str in str_standard_arr)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            Model.standard model_standard = bll_standard.GetModel(Convert.ToInt32(str));
                            if (model_standard != null)
                            {
                                str_standards += model_standard.title + ",";
                            }
                        }
                    }



                    BLL.standard_value bll_value = new BLL.standard_value();
                    string[] str_standard_value_arr = standard_value_ids.Split(',');

                    BLL.standard_group_price bll_standard_group_price = new BLL.standard_group_price();
                    DataTable dt_standard_group_price = bll_standard_group_price.GetList("good_id=" + _id).Tables[0];
                    if (dt_standard_group_price != null && dt_standard_group_price.Rows.Count > 0)
                    {
                        if (!bll_standard_group_price.Delete(_id))
                        {
                            JscriptMsg("清除商品规格会员价格失败！", "", "Error");
                            return false;
                        }
                    }


                    foreach (string str in str_standard_value_arr)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            string str_title = "";
                            string[] str_arr = str.Split('_');
                            foreach (string s in str_arr)
                            {
                                if (!string.IsNullOrEmpty(s))
                                {
                                    Model.standard_value model_value = bll_value.GetModel(Convert.ToInt32(s));
                                    if (model_value != null)
                                    {
                                        str_title += model_value.value + ",";
                                    }
                                }
                            }

                            Model.standard_price model_price = new Model.standard_price();
                            
                            
                            model_price.good_id = _id;
                            model_price.standard_ids = standard_ids;
                            model_price.good_no = DTRequest.GetFormString("good_no_" + str);
                            model_price.standards = str_standards.Substring(0, str_standards.Length - 1);
                            model_price.standard_value_ids = str.Replace('_', ',');
                            model_price.standard_values = str_title.Substring(0, str_title.Length - 1);
                            model_price.stock_quantity = DTRequest.GetFormInt("stock_quantity_" + str, 0);
                            model_price.market_price = DTRequest.GetFormDecimal("market_price_" + str, 0);
                            model_price.sell_price=sell_price=standard_price = DTRequest.GetFormDecimal("sell_price_" + str, 0);
                            model_price.action_price=action_price = DTRequest.GetFormDecimal("action_price_" + str, 0);
                            model_price.user_price = DTRequest.GetFormDecimal("user_price_" + str, 0);
                            model_price.add_time = DateTime.Now;

                            decimal _standard_price_id = bll_price.Add(model_price);
                            if (_standard_price_id <= 0)
                            {
                                JscriptMsg("更新价格信息失败！", "", "Error");
                                return false;
                            }

                            //规格会员组价格

                            BLL.user_groups bll_user_group = new BLL.user_groups();

                            DataTable dt_user_group = bll_user_group.GetList(0, "", "grade asc,id desc").Tables[0];
                            foreach (DataRow dr_user_group in dt_user_group.Rows)
                            {
                                Model.standard_group_price model_standard_group_price = new Model.standard_group_price();
                                model_standard_group_price.good_id = _id;
                                model_standard_group_price.group_id = Convert.ToInt32(dr_user_group["id"]);
                                model_standard_group_price.standard_price_id = _standard_price_id;
                                model_standard_group_price.group_price=standard_group_price = DTRequest.GetFormDecimal("user_price_" + dr_user_group["id"] + "_" + str, 0);
                                model_standard_group_price.add_time = DateTime.Now;
                                if (bll_standard_group_price.Add(model_standard_group_price) <= 0)
                                {
                                    JscriptMsg("规格会员价格更新失败！", "", "Error");
                                    return false;
                                }
                            }
                        }
                    }
                    //BLL.meal_good bll_meal_good = new BLL.meal_good();
                    //if (!bll_meal_good.UpdateMealGoodPrice(_id, sell_price, standard_price, standard_group_price, action_price))
                    //{
                    //    JscriptMsg("套餐商品价格更新失败！", "", "Error");
                    //    return false;
                    //}
                    //单位

                    BLL.unit bll_unit = new BLL.unit();
                    bll_unit.Delete(_id);
                    string str_unit = DTRequest.GetFormString("ck_unit");
                    if (!string.IsNullOrEmpty(str_unit))
                    {

                        string[] arr_unit = str_unit.Split(',');
                        foreach (string s_unit in arr_unit)
                        {
                            if (!string.IsNullOrEmpty(s_unit))
                            {
                                string[] unit = s_unit.Split('_');
                                Model.unit model_unit = new Model.unit();
                                model_unit.good_id = _id;
                                model_unit.title = unit[0];
                                model_unit.quantity = Convert.ToInt32(unit[1]);
                                model_unit.rate = Convert.ToDecimal(unit[2]);
                                model_unit.content = unit[3];
                                model_unit.add_time = DateTime.Now;

                                if (bll_unit.Add(model_unit) <= 0)
                                {
                                    JscriptMsg("更新单位失败！", "", "Error");
                                    return false;
                                }
                            }
                        }
                    }

                    //别名

                    BLL.alias_good bll_alias_good = new BLL.alias_good();
                    //删除
                    bll_alias_good.Delete(_id);

                    for (int i = 0; i < ck_alias.Items.Count; i++)
                    {
                        if (ck_alias.Items[i].Selected)
                        {
                            Model.alias_good model_alias_good = new Model.alias_good();
                            model_alias_good.alias_id = Convert.ToInt32(ck_alias.Items[i].Value);
                            model_alias_good.good_id = _id;

                            bll_alias_good.Add(model_alias_good);
                        }
                    }


                    //属性

                    BLL.property_value bll_property_value = new BLL.property_value();
                    BLL.property_good bll_property_good = new BLL.property_good();

                    bll_property_good.Delete(_id);

                    string str_property_value = DTRequest.GetFormString("ck_property_value");
                    if (!string.IsNullOrEmpty(str_property_value))
                    {
                        string[] arr_property_value = str_property_value.Split(',');
                        foreach (string str_1 in arr_property_value)
                        {
                            Model.property_good model_property_good = new Model.property_good();
                            model_property_good.good_id = _id;
                            model_property_good.property_value_id = Convert.ToInt32(str_1);
                            Model.property_value model_property_value = bll_property_value.GetModel(Convert.ToInt32(str_1));
                            if (model_property_value != null)
                            {
                                model_property_good.property_id = model_property_value.property_id;
                            }

                            bll_property_good.Add(model_property_good);
                        }
                    }


                    //标签
                    BLL.tag_good bll_tag_good = new BLL.tag_good();

                    bll_tag_good.Delete(_id);

                    for (int i = 0; i < ck_tag.Items.Count; i++)
                    {
                        if (ck_tag.Items[i].Selected)
                        {
                            Model.tag_good model_tag_good = new Model.tag_good();
                            model_tag_good.tag_id = Convert.ToInt32(ck_tag.Items[i].Value);
                            model_tag_good.good_id = _id;

                            bll_tag_good.Add(model_tag_good);
                        }
                    }
                }
                #endregion

                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改" + this.channel_name + "频道内容:" + model.title); //记录日志
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
                ChkAdminLevel("channel_" + this.channel_name + "_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "article_list.aspx?channel_id=" + this.channel_id, "Success");
            }
            else //添加
            {
                ChkAdminLevel("channel_" + this.channel_name + "_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "article_list.aspx?channel_id=" + this.channel_id, "Success");
            }
        }




        protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (channel_name == "goods")
            {

                string str = "";//dd_standard_title
                BLL.standard bll = new BLL.standard();
                Model.article_category model = new BLL.article_category().GetModel(Convert.ToInt32(ddlCategoryId.SelectedValue));
                if (model != null)
                {
                    DataTable dt = bll.GetList(0, "'" + model.class_list + "' like '%,'+convert(varchar(50),category_id)+',%'", "id asc").Tables[0];
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            str += "<label><input type=\"checkbox\" value=\"" + dr["id"].ToString() + "\" name=\"ck_standard\" onclick=\"change_standard('ck_standard')\" />" + dr["title"].ToString() + "</label>&nbsp;&nbsp;&nbsp;";
                        }
                        dd_standard_title.InnerHtml = str;
                    }
                }

                dd_standard_value.InnerHtml = "";
                Bind_Alias(Convert.ToInt32(ddlCategoryId.SelectedValue));

                Bind_Property(Convert.ToInt32(ddlCategoryId.SelectedValue));

                Bind_Tag(Convert.ToInt32(ddlCategoryId.SelectedValue));
            }

        }

        /// <summary>
        /// 绑定别名
        /// </summary>
        /// <param name="category_id"></param>
        private void Bind_Alias(int category_id)
        {
            ck_alias.Items.Clear();
            BLL.alias bll = new BLL.alias();
            DataTable dt = bll.GetList(" category_id in(select id from dt_article_category where (select class_list from dt_article_category where id=" + category_id + ") like '%,'+CONVERT(varchar(20),id)+',%')").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ck_alias.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
                }

            }

            for (int i = 0; i < ck_alias.Items.Count; i++)
            {
                ck_alias.Items[i].Selected = true;
            }
        }

        /// <summary>
        /// 绑定属性
        /// </summary>
        /// <param name="category_id"></param>
        private void Bind_Property(int category_id)
        {
            BLL.property bll = new BLL.property();
            DataTable dt = bll.GetList(" category_id in(select id from dt_article_category where (select class_list from dt_article_category where id=" + category_id + ") like '%,'+CONVERT(varchar(20),id)+',%')").Tables[0];
            string str_result = "";
            foreach (DataRow dr in dt.Rows)
            {
                str_result += "<dl>";
                str_result += "<dt>" + dr["title"].ToString() + "：</dt>";
                BLL.property_value bll_value = new BLL.property_value();
                DataTable dt_value = bll_value.GetList("property_id=" + dr["id"].ToString()).Tables[0];
                str_result += "<dd>";
                if (dt_value != null && dt_value.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt_value.Rows)
                    {
                        str_result += "<label><input type=\"checkbox\" name=\"ck_property_value\" value=\"" + dr1["id"].ToString() + "\" />" + dr1["value"].ToString() + "</label>&nbsp;&nbsp;&nbsp;";
                    }

                }
                str_result += "</dd>";
                str_result += "</dl>";
            }

            div_property.InnerHtml = str_result;
        }

        /// <summary>
        /// 绑定标签
        /// </summary>
        /// <param name="category_id"></param>
        private void Bind_Tag(int category_id)
        {
            ck_tag.Items.Clear();
            BLL.tag bll = new BLL.tag();
            DataTable dt = bll.GetList(" category_id in(select id from dt_article_category where (select class_list from dt_article_category where id=" + category_id + ") like '%,'+CONVERT(varchar(20),id)+',%')").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ck_tag.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
                }

            }

            for (int i = 0; i < ck_alias.Items.Count; i++)
            {
                ck_alias.Items[i].Selected = true;
            }
        }
    }
}