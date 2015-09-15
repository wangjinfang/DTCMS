<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.set_meal.edit"
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
        #goods span
        {
            border: 1px solid #d4d4d4;
            height: 32px;
            line-height: 32px;
            margin: auto 5px;
            cursor: pointer;
        }
        #goods span.on
        {
            border: 1px solid red;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });

            get_category_sel();
        });


        //获取类别列表
        function get_category_sel() {
            $.ajax({
                type: "POST",
                url: "../../tools/admin_ajax.ashx?action=get_category_list",
                dataType: "text",
                timeout: 20000,
                async:false,
                success: function (data) {
                    $("#sel_category").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
                }
            });
        }
        //获取商品列表
        function meal_change_category() { 
            $.ajax({
                type: "POST",
                url: "../../tools/admin_ajax.ashx?action=get_good_list&category_id=" + $("#sel_category").val(),
                dataType: "text",
                timeout: 20000,
                success: function (data) {
                    $("#sel_good").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
                }
            });
        }
        //获取商品信息
        function get_good_info() {
            $.ajax({
                type: "POST",
                url: "../../tools/admin_ajax.ashx?action=get_good_info&good_id=" + $("#sel_good").val(),
                dataType: "text",
                timeout: 20000,
                success: function (data) {
                    if (data != "NotFind") {
                        $("#good_list").html(data);
                        get_good_unit($("#sel_good").val());
                    }
                    else {
                        $.dialog.alert("该商品不存在或已删除！");
                        return;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
                }
            });
        }
        //获取单位信息
        function get_good_unit(good_id) {
            $.ajax({
                type: "POST",
                url: "../../tools/admin_ajax.ashx?action=get_good_unit&good_id=" + good_id,
                dataType: "text",
                timeout: 20000,
                success: function (data) {
                    if (data != "NotFind" && data != "Null") {
                        var str_sel = "<select id=\"sel_unit\">"
                        data = eval("(" + data + ")");
                        str_sel += "<option value=\"\">请选择单位...</option>";
                        for (var i = 0; i < data.Rows.length; i++) {
                            str_sel += "<option value=\"" + data.Rows[i].id + "\">" + data.Rows[i].title + "</option>";
                        }
                        str_sel += "</select>"

                        $("#dd_unit").html(str_sel);
                    }
                    else if (data == "Null") {
                        $("#dd_unit").html("");
                    }
                    else {
                        $.dialog.alert("该商品不存在或已删除！");
                        return;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
                }
            });
        }
        //加入
        function into_meal(good_id, standard_value_price_id,obj) {

            var unit_id = 0;
            if ($("#sel_unit") != undefined) {
                unit_id = $("#sel_unit").val(); 
                if (unit_id == "") {
                    $.dialog.alert('请选择单位！');
                    return;
                }
            }

            var quantity = 0;
            if ($("#quantity_" + good_id + "_" + standard_value_price_id) != undefined) {
                if ($("#quantity_" + good_id + "_" + standard_value_price_id).val() == "") {
                    $.dialog.alert('请输入数量！');
                    return;
                }
                else {
                    quantity = $("#quantity_" + good_id + "_" + standard_value_price_id).val();
                }
            }
            
            $.ajax({
                type: "POST",
                url: "../../tools/admin_ajax.ashx?action=into_meal&good_id=" + $("#sel_good").val() + "&standard_value_price_id=" + standard_value_price_id + "&unit_id=" + unit_id + "&quantity=" + quantity,
                dataType: "text",
                timeout: 20000,
                success: function (data) {
                    if (data != "Erorr") {

                        $("#goods").append(data+"<br />");

                    }
                    else {

                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
                }
            });
        }

        function verify_standard_value() {

            //alert($("[name=ck_standard_value]").lenght);
            if ($("[name=ck_good]") == undefined || $("[name=ck_good]").length <= 0) {
                $.dialog.alert("请添加规格值！");
                return false;
            }
            else {
                return true;
            }
        }


        function ck_goods(obj) {
            if ($(obj).hasClass("on")) {
                $(obj).removeClass("on");
            }
            else {
                $(obj).addClass("on");
            }
        }

        function del_goods() {
            $("#goods").find(".on").next().remove();
            $("#goods").find(".on").remove();
            
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
                    <li><a href="javascript:;" onclick="tabs(this);">商品资料</a></li>
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
            <dt>套餐名称</dt>
            <dd>
                <asp:TextBox ID="txt_title" runat="server" CssClass="input normal" datatype="*2-100"
                    sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*</span></dd>
        </dl>
        <dl>
    <dt>排序数字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*数字，越小越向前</span>
    </dd>
  </dl>
        <dl>
            <dt>首页图片</dt>
            <dd>
                <asp:TextBox ID="txtIndexUrl" runat="server" CssClass="input normal upload-path" />
                <div class="upload-box upload-img">
                </div>
            </dd>
        </dl>

        <dl>
            <dt>封面图片</dt>
            <dd>
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                <div class="upload-box upload-img">
                </div>
            </dd>
        </dl>
    </div>
    <div id="div_good" runat="server" class="tab-content" style="display: none;">
        <dl>
            <dt>选择商品：</dt>
            <dd>
                <select id="sel_category" onchange="meal_change_category()">
                </select>
                <select id="sel_good" onchange="get_good_info()">
                    <option value="">请选择商品...</option>
                </select>&nbsp;&nbsp;&nbsp;
                <input type="button" value="删除" class="btn yellow" onclick="del_goods()" />
            </dd>
        </dl>
        <dl>
            <dt></dt>
            <dd id="goods" runat="server">

            </dd>
        </dl>
        <dl>
            <dt>选择商品单位</dt>
            <dd id="dd_unit">
                
            </dd>
        </dl>
        <dl>
            <dt>选择商品规格</dt>
            <dd id="good_list">
                
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
