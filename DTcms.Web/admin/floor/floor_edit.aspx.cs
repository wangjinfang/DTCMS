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

namespace DTcms.Web.admin.floor
{
    public partial class floor_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id", 0);
                if (this.id < 1)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.advert().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("channel_floor", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.floor bll = new BLL.floor();
            Model.floor model = bll.GetModel(_id);
            rblBelongChannel.SelectedValue = model.belongchannel.ToString();
            txtfloorname.Text = model.floorname;
            txtTitle.Text = model.title;
            txtcolor.Text = model.color;
            txtRemark.Text = model.remark;
            rblStatus.SelectedValue = model.status;
            txtSortId.Text = model.sort_id.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.floor model = new Model.floor();
            BLL.floor bll = new BLL.floor();
            model.belongchannel = int.Parse(rblBelongChannel.SelectedValue);
            model.floorname = txtfloorname.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.color = txtcolor.Text.Trim();
            model.remark = txtRemark.Text.Trim();
            model.status = rblStatus.SelectedValue;
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            
            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加楼层：" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.floor bll = new BLL.floor();
            Model.floor model = bll.GetModel(_id);
            model.belongchannel = int.Parse(rblBelongChannel.SelectedValue);
            model.floorname = txtfloorname.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.color = txtcolor.Text.Trim();
            model.remark = txtRemark.Text.Trim();
            model.status = rblStatus.SelectedValue;
            model.sort_id =int.Parse(txtSortId.Text.Trim());
            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改楼层：" + model.title); //记录日志
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
                ChkAdminLevel("channel_floor", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改成功！", "floor_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("channel_floor", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加成功！", "floor_list.aspx", "Success");
            }
        }
    }
}