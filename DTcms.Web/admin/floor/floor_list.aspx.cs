using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using System.Text;

namespace DTcms.Web.admin.floor
{
    public partial class floor_list : DTcms.Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;
        protected string property = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords");
            this.property = DTRequest.GetQueryString("property");
            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("channel_floor", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.keywords, this.property), "add_time desc");
            }
        }
        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            BLL.floor bll = new BLL.floor();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("floor_list.aspx", "keywords={0}&property={1}&page={2}", this.keywords, this.property, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords, string _property)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like '%" + _keywords + "%'");
            }
            //if (!string.IsNullOrEmpty(_property))
            //{
            //    strTemp.Append(" and type=" + _property);
            //}
            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("floor_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 显示所属频道=============================
        protected string GetBelongChannelName(string belongchannel)
        {
             //<asp:ListItem Selected="True" Value="1">首页</asp:ListItem>
             //               <asp:ListItem Value="2">限时特卖</asp:ListItem>
             //               <asp:ListItem Value="3">省心搭配</asp:ListItem>
            //               <asp:ListItem Value="4">Yes想要！</asp:ListItem>
             //               <asp:ListItem Value="5">品牌直供</asp:ListItem>
             //               <asp:ListItem Value="6">积分商城</asp:ListItem>
            switch (belongchannel)
            {
                case "1":
                    return "首页";
                case "2":
                    return "限时特卖";
                case "3":
                    return "省心搭配";
                case "4":
                    return "Yes想要！";
                case "5":
                    return "品牌直供";
                case "6":
                    return "积分商城";
                default:
                    return "";
            }
        }
        #endregion

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("floor_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("floor_list.aspx", "keywords={0}", this.keywords));
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("floor_list.aspx", "keywords={0}&property={1}", txtKeywords.Text, this.property));
        }

       

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("floor_adv", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.advert bll = new BLL.advert();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount++;
                    }
                    else
                    {
                        errorCount++;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除楼层成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
                Utils.CombUrlTxt("floor_list.aspx", "keywords={0}&&property={1}", this.keywords, this.property), "Success");
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            BLL.floor bll = new BLL.floor();
            Repeater rptList = new Repeater();

            rptList = this.rptList;


            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "保存楼层排序"); //记录日志
            JscriptMsg("保存排序成功啦！", Utils.CombUrlTxt("floor_list.aspx", "keywords={0}&&property={1}", this.keywords, this.property), "Success");
        }
    }
}