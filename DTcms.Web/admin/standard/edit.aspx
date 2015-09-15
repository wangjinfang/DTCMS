<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.standard.edit"
    ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑用户</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #dd_standard_value span
        {
            border: 1px solid #d4d4d4;
            height: 32px;
            line-height: 32px;
            margin: auto 5px;
            cursor: pointer;
        }
        #dd_standard_value span.on
        {
            border: 1px solid red;
        }
    </style>
    <script type="text/javascript">
        $(function ()
        {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function ()
            {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
        });

        function add_standard_value()
        {
            //var str = "<label style=\"margin: auto 5px;\"><input type=\"checkbox\" name=\"ck_standard_value\" checked=\"checked\" value=\"0|" + $("#txt_standard_value").val() + "\" />" + $("#txt_standard_value").val() + "</label>";
            var str = "<span onclick=\"ck_standard_value(this)\">&nbsp;&nbsp;" + $("#txt_standard_value").val()
            + "<input type=\"checkbox\" name=\"ck_standard_value\" checked=\"checked\" value=\"0|" + $("#txt_standard_value").val() + "\" style=\"display:none;\" />&nbsp;&nbsp;</span>";
            $("#dd_standard_value").append(str);
            $("#txt_standard_value").val("");
        }

        function ck_standard_value(obj)
        {
            if ($(obj).hasClass("on"))
            {
                $(obj).removeClass("on");
            }
            else
            {
                $(obj).addClass("on");
            }
        }

        function del_standard_value()
        {
            $("#dd_standard_value").find(".on").remove();
        }

        function verify_standard_value() {

            //alert($("[name=ck_standard_value]").lenght);
            if ($("[name=ck_standard_value]") == undefined || $("[name=ck_standard_value]").length<=0) {
                $.dialog.alert("请添加规格值！");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>会员管理</span>
        <i class="arrow"></i><span>编辑用户</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本资料</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>所属类别</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlCategoryId" runat="server" datatype="*" sucmsg=" ">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>规格名</dt>
            <dd>
                <asp:TextBox ID="txt_standard_title" runat="server" CssClass="input normal" datatype="*2-100"
                    sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*</span></dd>
        </dl>
        <dl>
            <dt>规格值</dt>
            <dd>
                <input type="text" class="input" id="txt_standard_value" />&nbsp;
                <input type="button" value="添加" class="btn" onclick="add_standard_value()" />&nbsp;
                <input type="button" value="删除" class="btn yellow" onclick="del_standard_value()" />
            </dd>
        </dl>
        <dl>
            <dt></dt>
            <dd id="dd_standard_value">
            <%=str_standard_value%>
            </dd>
        </dl>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="return verify_standard_value()" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
