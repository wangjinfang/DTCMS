///添加员工验证和表单提交

function Submit1(id) {

    var psd, pas1, username, branch, real_name, phone, email;
    branch = $("#branch_id").val();
    if (branch == "") {
        $.dialog.alert("请选择部门！");
        return;
    }
    username = $("#username")
    if (username == "") {
        $.dialog.alert("账户名不能为空！");
        return;
    }

    psd = $("#psd").val();
    if (psd == "") {
        $.dialog.alert("密码不能为空！");
        return;
    }
    psd1 = $("#psd1").val();
    if (psd != psd1) {
        $.dialog.alert("密码不一致！");
        return;
    }

    real_name = $("#real_name").val();
    if (real_name == null || real_name == "") {
        $.dialog.alert("请输入姓名!");
        return;
    }
    phone = $("#phone").val();
    if (phone == "") {
        $.dialog.alert("请输入电话号码！");
        return;
    }
    email = $("#email").val();
    if (email == "") {
        $.dialog.alert("请输入邮箱地址");
        return;
    }
    var parent_id = id;

    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=dealing_users",
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            //                $("#btn_register").html("提交中...");
            //                $("#btn_register").attr("disabled", "disabled");
        },
        success: function (data) {
            $.dialog.alert(data.msg);
            if (data.status == 1) {

                window.location.href = '/usercenter.aspx?action=staff_list';
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });

}






////修改员工资料验证和提交表单

function Submit2(id) {

    var psd, pas1, branch, real_name, phone, email;
    branch = $("#branch_id").val();
    if (branch == "") {
        $.dialog.alert("请选择部门！");
        return;
    }
   

    psd = $("#psd").val();
    if (psd == "") {
        $.dialog.alert("密码不能为空！");
        return;
    }
    psd1 = $("#psd1").val();
    if (psd != psd1) {
        $.dialog.alert("密码不一致！");
        return;
    }

    real_name = $("#real_name").val();
    if (real_name == null || real_name == "") {
        $.dialog.alert("请输入姓名!");
        return;
    }
    phone = $("#phone").val();
    if (phone == "") {
        $.dialog.alert("请输入电话号码！");
        return;
    }
    email = $("#email").val();
    if (email == "") {
        $.dialog.alert("请输入邮箱地址");
        return;
    }


    $("#form2").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=edit_dealing_users&id=" + id,
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            //                $("#btn_register").html("提交中...");
            //                $("#btn_register").attr("disabled", "disabled");
        },
        success: function (data) {
            $.dialog.alert(data.msg);
            if (data.status == 1) {
                window.location.href = '/usercenter.aspx?action=staff_list';

            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });

}



///员工状态变更js
function Button_on(id,status) {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: '/tools/submit_ajax.ashx?action=user_status&id=' + id + '&status=' + status,
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);
                window.location.href = '/usercenter.aspx?action=staff_list';
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });

}


////企业用户密码管理密码强弱验证

function validate1() {

    var psd=$("#newpsd").val();

    if (psd != "") {

        var reg3 = /\s+/; ;
        var obj3 = $("#newpsd").val();
        if (reg3.test(obj3)) {
            $.dialog.alert("用户密码请不要包含空格！");
            $("#newpsd").val("");
            return;
        }

        var reg = new RegExp("^[0-9]*$");
        var obj = document.getElementById("newpsd");
        var reg1 = new RegExp("^[A-Za-z0-9]+$");
        var obj1 = document.getElementById("newpsd");
        if (reg.test(obj.value)) {
            $("#img_show").attr("src", "templates/ql/img/inferior.jpg");
        }
        else if (reg1.test(obj1.value)) {
            $("#img_show").attr("src", "templates/ql/img/amid.jpg");
        }
        else {
            $("#img_show").attr("src", "templates/ql/img/strong.jpg");

        }
    }
    else {

        $("#img_show").attr("src", "templates/ql/img/nocheck.jpg");
    }


}


///提交企业用户修改密码表单
function Submit3(id) {

    var oldpsd, newpsd, repsd;
    oldpsd = $("#oldpsd").val();
    if (oldpsd == "") {
        $.dialog.alert("请输入旧密码");
        return;
    }
    newpsd = $("#newpsd").val();
    if (newpsd == "") {
        $.dialog.alert("请输入新密码");
        return;
    } repsd = $("#repsd").val();
    if (repsd == "") {
        $.dialog.alert("您没有在此输入密码");
        return;
    }
    if (newpsd != repsd) {

        $.dialog.alert("两次输入的密码不一致！");
        return;
    }


    $("#form3").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=edit_userpsd&id=" + id,
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            //                $("#btn_register").html("提交中...");
            //                $("#btn_register").attr("disabled", "disabled");
        },
        success: function (data) {
            $.dialog.alert(data.msg);
            if (data.status == 1) {
                window.location.href ='/usercenter.aspx?action=exit';

            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });

}




function Submit4(id) {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: '/tools/submit_ajax.ashx?action=get_collect&id='+id,
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);

            }
            else if (data.status == 0) {
                $.dialog.alert(data.msg);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });

}

function add(id) {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: '/tools/submit_ajax.ashx?action=get_browse_goods&id=' + id,
        success: function (data) {
            return;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });

}