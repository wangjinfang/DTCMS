////////////////////////////////////////////////////////会员中心开始
//注册
function register() {
    if ($("#email").val() == "") {
        $.dialog.alert("请输入您的电子邮箱！");
        return;
    }
    if ($("#username").val() == "") {
        $.dialog.alert("请输入用户名！");
        return;
    }
    if ($("#pwd").val() == "") {
        $.dialog.alert("请输入密码！");
        return;
    }
    if ($("#pwd").val() != $("#pwd1").val()) {
        $.dialog.alert("对不起两次密码输入不一致！");
        return;
    }
    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=user_register",
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            $("#btn_register").html("提交中...");
            $("#btn_register").attr("disabled", "disabled");
        },
        success: function (data) {
            $.dialog.alert(data.msg);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//登录
function login(url) {
    if ($("#username").val() == "") {
        $.dialog.alert("请输入用户名！");
        return;
    }
    if ($("#pwd").val() == "") {
        $.dialog.alert("请输入密码！");
        return;
    }

    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=user_login",
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            $("#btn_login").html("登录中...");
            $("#btn_login").attr("disabled", "disabled");
        },
        success: function (data) {
            if (data.status == 1) {
                if (typeof (data.url) == "undefined") {
                    location.href = url;
                } else {
                    location.href = data.url;
                }
            } else {
                $("#btn_login").attr("disabled", false);
                $.dialog.alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//改变省
function province_change(province, city) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_city_list&province_id=" + $("#" + province).val(),
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            var str = "<option value=\"0\">-请选择-</option>";
            if (data != "Null") {
                data = eval("(" + data + ")");
                for (var i = 0; i < data.Rows.length; i++) {
                    str += "<option value=\"" + data.Rows[i].CityID + "\">" + data.Rows[i].CityName + "</option>"
                }
                $("#" + city).html(str);
            }
            else {
                $("#" + city).html(str);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//改变市
function city_change(city, district) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_district_list&city_id=" + $("#" + city).val(),
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            var str = "<option value=\"0\">-请选择-</option>";
            if (data != "Null") {
                data = eval("(" + data + ")");
                for (var i = 0; i < data.Rows.length; i++) {
                    str += "<option value=\"" + data.Rows[i].DistrictID + "\">" + data.Rows[i].DistrictName + "</option>"
                }
                $("#" + district).html(str);
            }
            else {
                $("#" + district).html(str);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//保存用户信息
function save_user_info(user_type) {
    if (user_type == 2) {
        if ($("#nick_name").val() == "") {
            $.dialog.alert("请输入企业名称！");
            return;
        }
    }
    if ($("#email").val() == "") {
        $.dialog.alert("请输入邮箱！");
        return;
    }
    if ($("#mobile").val() == "") {
        $.dialog.alert("请输入手机号码！");
        return;
    }

    if ($("#province").val() == "") {
        $.dialog.alert("请选择所在省！");
        return;
    }
    if ($("#city").val() == "") {
        $.dialog.alert("请选择所在市！");
        return;
    }
    if ($("#district").val() == "") {
        $.dialog.alert("请选择所在区/县！");
        return;
    }
    if ($("#address").val() == "") {
        $.dialog.alert("请输入详细地址！");
        return;

    }
    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=save_user_info",
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            $("#btn_save").html("提交中...");
            $("#btn_save").attr("disabled", "disabled");
        },
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);
                location.reload();
            }
            else {
                $.dialog.alert(data.msg);
                $("#btn_save").html("再次提交");
                $("#btn_save").attr("disabled", "true");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//添加部门
function add_branch(url) {
    if ($("#title").val() == "") {
        $.dialog.alert("请输入部门名称！");
        return;
    }
    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=add_branch",
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            $("#btn_save").html("提交中...");
            $("#btn_save").attr("disabled", "disabled");
        },
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);
                location.href = url;
            }
            else {
                $.dialog.alert(data.msg);
                $("#btn_add").html("再次提交");
                $("#btn_add").attr("disabled", "true");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//修改部门
function save_branch(url) {
    if ($("#title").val() == "") {
        $.dialog.alert("请输入部门名称！");
        return;
    }
    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=save_branch",
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            $("#btn_save").html("提交中...");
            $("#btn_save").attr("disabled", "disabled");
        },
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);
                location.href = url;
            }
            else {
                $.dialog.alert(data.msg);
                $("#btn_add").html("再次提交");
                $("#btn_add").attr("disabled", "true");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//删除部门
function del_branch(id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=del_branch&id=" + id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);
                location.reload();
            }
            else {
                $.dialog.alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//添加收货地址
function add_address() {

    if ($("#province").val() == "") {
        $.dialog.alert("请选择所在省！");
        return;
    }
    if ($("#city").val() == "") {
        $.dialog.alert("请选择所在市！");
        return;
    }
    if ($("#district").val() == "") {
        $.dialog.alert("请选择所在区/县！");
        return;
    }

    if ($("#address").val() == "") {
        $.dialog.alert("请输入详细地址！");
        return;
    }
    if ($("#consignee").val() == "") {
        $.dialog.alert("请输入收货人姓名！");
        return;
    }
    if ($("#consignee_mobile").val() == "") {
        $.dialog.alert("请输入收货人手机号码！");
        return;
    }
    if ($("#consignee_company").val() == "") {
        $.dialog.alert("请输入公司名称！");
        return;
    }

    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=add_address",
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            $("#btn").html("提交中...");
            $("#btn").attr("disabled", "disabled");
        },
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);
                location.reload();
            }
            else {
                $.dialog.alert(data.msg);
                $("#btn").html("再次提交");
                $("#btn").attr("disabled", "true");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//保存收货地址
function save_address(id, url) {
    if ($("#province").val() == "") {
        $.dialog.alert("请选择所在省！");
        return;
    }
    if ($("#city").val() == "") {
        $.dialog.alert("请选择所在市！");
        return;
    }
    if ($("#district").val() == "") {
        $.dialog.alert("请选择所在区/县！");
        return;
    }

    if ($("#address").val() == "") {
        $.dialog.alert("请输入详细地址！");
        return;
    }
    if ($("#consignee").val() == "") {
        $.dialog.alert("请输入收货人姓名！");
        return;
    }
    if ($("#consignee_mobile").val() == "") {
        $.dialog.alert("请输入收货人手机号码！");
        return;
    }
    if ($("#consignee_company").val() == "") {
        $.dialog.alert("请输入公司名称！");
        return;
    }
    $("#form1").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=save_address&id=" + id,
        dataType: "json",
        timeout: 20000,
        beforeSubmit: function () {
            $("#btn").html("提交中...");
            $("#btn").attr("disabled", "disabled");
        },
        success: function (data) {
            if (data.status == 1) {
                $.dialog.alert(data.msg);
                location.href = url;
            }
            else {
                $.dialog.alert(data.msg);
                $("#btn").html("再次提交");
                $("#btn").attr("disabled", "true");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

////////////////////////////////////////////////会员中心结束


////////////////////////////////////////////////商品开始




//弹出详情框
function open_detail(goods_id) {
    var h = document.body.scrollHeight;
    $(".all").height(h);
    $(".black_overlay").height(h);
    $(".black_overlay").show();
    $(".all").show();
    $(".Product_detail").addClass("selected_shopping");
    //2014-10-10改
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_goods&goods_id=" + goods_id,
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            if (data != "NotFind") {
                data = eval("(" + data + ")");
                var str_small_img = "";
                var big_img_url = "";
                if (data.dt_albums != undefined) {
                    for (var i = 0; i < data.dt_albums.length; i++) {
                        str_small_img += " <li><a href=\"javascript:;\" onclick=\"click_small_img(this,'" + data.dt_albums[i].original_path + "')\"";
                        if (i == 0) {
                            str_small_img += " class=\"Product_detail_main_left_selected_img\"";
                            big_img_url = data.dt_albums[i].original_path;
                        }
                        str_small_img += "><img src=\"" + data.dt_albums[i].thumb_path + "\" width=\"50\" height=\"50\" /></a></li>";
                    }
                }
                $("#ul_picture").html(str_small_img); //绑定小图列表
                $("#img_big").attr("src", big_img_url); //绑定首张大图
                //$("#div_big_img").html("<img id=\"img_big\" src=\"" + big_img_url + "\" onload=\"img_load(472,472,this)\" />")
                //$("[name=img_meal]").attr("src", big_img_url);




                $("[name=img_meal]").each(function () {
                    $(this).attr("src", big_img_url);
                });

                $("[name=p_meal_good_name]").each(function () {
                    $(this).html(data.dt_goods[0].title);
                });

                $("#div_title").html(data.dt_goods[0].title); //绑定商品名称
                $("#collocation_good_name").html(data.dt_goods[0].title); //套餐头部商品名称
                $("#span_sell").html("￥" + data.dt_attribute[0].sell_price); //绑定商品售价
                $("#div_good_content").html(data.dt_goods[0].content);
                //$("[div_meal_price]").html("￥" + data.dt_attribute[0].sell_price);

                $("[name=div_meal_price]").each(function () {
                    $(this).html("￥" + data.dt_attribute[0].sell_price);
                });

                $("#del_market").html(data.dt_attribute[0].market_price); //绑定商品市场价
                $("#hd_stock_quantity").val(data.dt_attribute[0].stock_quantity); //绑定商品库存
                $("#hd_goods").val(data.dt_goods[0].id); //绑定商品ID

                //商品销量 
                if (data.dt_order_good_count != undefined) {
                    $("#dd_order_good_count").html(data.dt_order_good_count[0].quantity + "件");
                }
                else {
                    $("#dd_order_good_count").html("0件");
                }



                //规格显示
                var str_standard = "";
                if (data.dt_standard != undefined) {
                    for (var i = 0; i < data.dt_standard.length; i++) {
                        str_standard += "<dl><dt>" + data.dt_standard[i].title + ":</dt>";
                        var value_arr = new Array();
                        value_arr = data.dt_standard[i].value.split(',');
                        for (var j = 0; j < value_arr.length; j++) {

                            str_standard += "<dd><a href=\"javascript:;\" onclick=\"check_standard(this," + goods_id + "," + value_arr[j].split('|')[0] + ")\">" + value_arr[j].split('|')[1] + "</a><input type=\"checkbox\" style=\"display:none;\" value=\"" + data.dt_standard[i].id + "|" + value_arr[j].split('|')[0] + "\"></dd>";
                        }
                        str_standard += "</dl>";
                    }

                }
                //单位显示
                var str_unit = "";
                if (data.dt_unit != undefined) {
                    str_unit += "<ul style=\"margin: 5px;\"><dt>单位:</dt>";
                    for (var i = 0; i < data.dt_unit.length; i++) {
                        if (i == 0) {
                            str_unit += "<li><label ><input type=\"radio\" name=\"rd_unit\" onclick=\"check_unit(" + goods_id + "," + data.dt_unit[i].id + ")\" checked=\"checked\" value=\"" + data.dt_unit[i].id + "\" />" + data.dt_unit[i].title + "</label>";
                        }
                        else {
                            str_unit += "<li><label ><input type=\"radio\" name=\"rd_unit\" onclick=\"check_unit(" + goods_id + "," + data.dt_unit[i].id + ")\" value=\"" + data.dt_unit[i].id + "\" />" + data.dt_unit[i].title + "</label>";
                        }
                        if (data.dt_unit[i].content != "") {
                            str_unit += "&nbsp;&nbsp;(" + data.dt_unit[i].content + ")";
                        }
                        str_unit += "</li>";

                    }
                    str_unit += "</ul>";
                }
                //套餐
                var str_meal = "";
                if (data.dt_meal != undefined) {
                    for (var i = 0; i < data.dt_meal.length; i++) {
                        str_meal += " <a href=\"javascript:;\" onclick=\"get_meal_good(" + data.dt_meal[i].id + ",'" + data.dt_attribute[0].sell_price + "')\">" + data.dt_meal[i].title + "</a> |";
                    }
                    if (str_meal != "") {
                        $("#div_meal").html(str_meal.substring(0, (str_meal.length - 1)));
                    }
                }

                //套餐商品
                var str_meal_good = "";
                var meal_good_price = parseFloat(data.dt_attribute[0].sell_price);
                if (data.dt_meal_good != undefined) {
                    for (var i = 0; i < data.dt_meal_good.length; i++) {
                        str_meal_good += " <li><a href=\"#\" title=\"" + data.dt_meal_good[i].all_title + "\"><img src=\"" + data.dt_meal_good[i].img_url + "\" width=\"100\" height=\"98\" title=\"" + data.dt_meal_good[i].all_title + "\">" + data.dt_meal_good[i].title + "</a>";
                        str_meal_good += " <div class=\"select_collocation\"> ";
                        str_meal_good += " <input type=\"checkbox\" class=\"select_collocaton\" checked=\"checked\" value=\"" + data.dt_meal_good[i].price + "\" name=\"ck_meal_good_price\" onclick=\"sum_ck_meal_good_price('" + data.dt_attribute[0].sell_price + "')\">￥" + data.dt_meal_good[i].price + "</div>";
                        str_meal_good += " </li>";
                        if (i < data.dt_meal_good.length - 1) {
                            str_meal_good += "<span></span>";
                        }
                        meal_good_price += parseFloat(data.dt_meal_good[i].price);
                    }


                    $("#ul_meal_good").css("width", (100 * data.dt_meal_good.length + 59 * data.dt_meal_good.length) + "px");
                }
                else {
                    $("#div_meal_box").css("display", "none");
                }
                $("#b_meal_price1").html("￥" + parseFloat(meal_good_price).toFixed(2));
                $("#ul_meal_good").html(str_meal_good);
                //推荐
                var str_red_good = "";
                var red_good_price = parseFloat(data.dt_attribute[0].sell_price);

                if (data.dt_red_good != undefined) {
                    for (var i = 0; i < data.dt_red_good.length; i++) {
                        str_red_good += " <li><a href=\"#\" title=\"" + data.dt_red_good[i].all_title + "\"><img src=\"" + data.dt_red_good[i].img_url + "\" width=\"100\" height=\"98\" title=\"" + data.dt_red_good[i].all_title + "\">" + data.dt_red_good[i].title + "</a>";
                        str_red_good += " <div class=\"select_collocation\"> ";
                        str_red_good += " <input type=\"checkbox\" class=\"select_collocaton\" checked=\"checked\" value=\"" + data.dt_red_good[i].price + "\" name=\"ck_red_good_price\" onclick=\"sum_ck_red_good_price('" + data.dt_attribute[0].sell_price + "')\">￥" + data.dt_red_good[i].price + "</div>";
                        str_red_good += " </li>";
                        if (i < data.dt_red_good.length - 1) {
                            str_red_good += "<span></span>";
                        }
                        red_good_price += parseFloat(data.dt_red_good[i].price);
                    }
                    //alert(red_good_price);
                    $("#b_red_price1").html("￥" + parseFloat(red_good_price).toFixed(2));
                    $("#ul_red_good").html(str_red_good);

                    $("#ul_red_good").css("width", (100 * data.dt_red_good.length + 59 * data.dt_red_good.length) + "px");
                }
                else {
                    $("#div_red_box").css("display", "none");
                }


                if (data.dt_red_good == undefined && data.dt_meal_good == undefined) {
                    $("[name=li_good_meal]").css("display", "none");
                }


                $("#b_red_price1").html("￥" + parseFloat(red_good_price).toFixed(2));
                $("#ul_red_good").html(str_red_good);

                $("#div_standard").html(str_standard + str_unit);
                add(goods_id);
            }
            else {
                $.dialog.alert("内容不存在或已删除！");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//商品套餐商品列表
function get_meal_good(meal_id, default_price) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_meal_good&meal_id=" + meal_id,
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            if (data != "Null") {
                //套餐商品
                var str_meal_good = "";
                var meal_good_price = parseFloat(default_price);
                if (data.dt_meal_good != undefined) {
                    for (var i = 0; i < data.Rows.length; i++) {
                        str_meal_good += " <li><a href=\"#\" title=\"" + data.Rows[i].all_title + "\"><img src=\"" + data.Rows[i].img_url + "\" width=\"100\" height=\"98\" title=\"" + data.Rows[i].all_title + "\">" + data.Rows[i].title + "</a>";
                        str_meal_good += " <div class=\"select_collocation\"> ";
                        str_meal_good += " <input type=\"checkbox\" class=\"select_collocaton\" checked=\"checked\" value=\"" + data.Rows[i].price + "\" name=\"ck_meal_good_price\" onclick=\"sum_ck_meal_good_price('" + default_price + "')\">￥" + data.Rows[i].price + "</div>";
                        str_meal_good += " </li>";
                        if (i < data.dt_meal_good.length - 1) {
                            str_meal_good += "<span></span>";
                        }
                        meal_good_price += parseFloat(data.Rows[i].price);
                    }


                    $("#ul_meal_good").css("width", (100 * data.Rows.length + 59 * data.Rows.length) + "px");
                }
                $("#b_meal_price1").html("￥" + parseFloat(meal_good_price).toFixed(2));
                $("#ul_meal_good").html(str_meal_good);
            }
            else {

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//计算套餐商品列表金额
function sum_ck_meal_good_price(good_price) {
    var meal_good_price = parseFloat(good_price);
    $("[name=ck_red_good_price]").each(function () {
        if ($(this).prop("checked")) {
            meal_good_price += parseFloat($(this).val());
        }
    });
    $("#b_red_price1").html("￥" + parseFloat(meal_good_price).toFixed(2));
}

function sum_ck_red_good_price(good_price) {
    var meal_good_price = parseFloat(good_price);
    $("[name=ck_meal_good_price]").each(function () {
        if ($(this).prop("checked")) {
            meal_good_price += parseFloat($(this).val());
        }
    });
    $("#b_meal_price1").html("￥" + parseFloat(meal_good_price).toFixed(2));
}

//选择规格
function check_standard(obj, goods_id, standard_value_id) {
    $(obj).addClass("on");
    $(obj).parent("dd").siblings().find("a").removeClass("on");

    var unit_id = 0;
    if ($('input:radio[name=rd_unit]') != undefined) {
        unit_id = $('input:radio[name=rd_unit]:checked').val();
    }

    var str_value = "";

    if ($("#div_standard dl").length > 0) {
        if ($("#div_standard dl dd a.on").length <= 0 || $("#div_standard dl dd a.on").length != $("#div_standard dl").length) {
            return;
        }
        else {

            $("#div_standard dl dd a.on").each(function () {
                str_value += $(this).next("input").val() + ",";
            });

        }
    }

    str_value = str_value.substring(0, str_value.length - 1);
    get_standard_unit_price(goods_id, str_value, unit_id);
}





//获取规格  单位价格
function get_standard_unit_price(good_id, standard_value_id, unit_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=check_standard_unit_price&goods_id=" + good_id + "&standard_value_id=" + standard_value_id + "&unit_id=" + unit_id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                $("#span_sell").html("￥" + parseFloat(data.msg, 2));
                if (data.msg <= 0) {
                    $(".add_car").find("a").unbind("click");
                }
                else {
                    $(".add_car").find("a").bind("click", function () {
                        add_car();
                    });
                }
            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//改变加入购物车数量
function change_sum(str_id, sum) {

    var old_sum = parseInt($("#" + str_id).val()) + sum;

    if (old_sum <= 0 || old_sum > parseInt($("#stock_quantity").val())) {
        return;
    }
    else {
        $("#" + str_id).val(old_sum);
    }
}

//关闭弹出框
function close_shopping() {
    $(".all").css("display", "none");
    $(".black_overlay").css("display", "none");
    $(".all").children().removeClass("selected_shopping");
}

//商品点击小图显示大图
function click_small_img(obj, big_img_url) {
    $(obj).parent().siblings("li").find("a").removeClass("Product_detail_main_left_selected_img");
    $(obj).addClass("Product_detail_main_left_selected_img");

    //$("#div_big_img").html("<img id=\"img_big\" src=\"" + big_img_url + "\" onload=\"img_load(472,472,this)\" />")
    $("#img_big").attr("src", big_img_url);
}
//加入购物车
function add_car() {

    var str_value = ""; //规格字符串

    if ($("#div_standard dl").length > 0) {
        if ($("#div_standard dl dd a.on").length <= 0 && $("#div_standard dl dd a.on").length != $("#div_standard dl").length) {
            $.dialog.alert("请选择规格！");
            return;
        }
        else {

            $("#div_standard dl dd a.on").each(function () {
                str_value += $(this).next("input").val() + ",";
            });
            str_value = str_value.substring(0, str_value.length - 1);
        }
    }

    var unit_id = 0;
    if ($('input:radio[name=rd_unit]') != undefined) {
        unit_id = $('input:radio[name=rd_unit]:checked').val();
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=add_car&goods_id=" + $("#hd_goods").val() + "&goods_quantity=" + $("#inputCount1").val() + "&standard=" + str_value + "&unit_id=" + unit_id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            $.dialog.alert(data.msg);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//弹出采购车
function open_shopping() {
    var h = document.body.scrollHeight;
    $(".all").height(h);
    $(".black_overlay").height(h);
    $(".black_overlay").show();
    $(".all").show();
    $(".all").children().removeClass("selected_shopping");
    $(".shopping_car").addClass("selected_shopping");
    get_car_list();

}
//购物车列表
function get_car_list() {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_car_list",
        dataType: "text",
        beforeSend: function () { $("#car_list").html("<li>正在加载您的购物车...！</li>"); },
        timeout: 20000,
        success: function (data) {
            if (data != "Null" && data != "Erorr") {
                data = eval("(" + data + ")");
                var str_li = "";
                var weightcount = 0;
                var moneycount = 0;
                for (var i = 0; i < data.Rows.length; i++) {
                    str_li += "<li><ul><li><input type=\"checkbox\" name=\"ck_car\" value=\"" + data.Rows[i].car_id + "\"/></li>";
                    str_li += "<li style=\"height: 96px; padding: 13px 0 0 13px; width: 363px;\"><a href=\"/good_show.aspx?id=" + data.Rows[i].id + "\" target=\"_blank\">";
                    str_li += "<img src=\"" + data.Rows[i].img_url + "\" width=\"90\" height=\"90\" /></a><a href=\"/good_show.aspx?id=" + data.Rows[i].id + "\" target=\"_blank\">";
                    str_li += "<p>" + data.Rows[i].title + " " + data.Rows[i].unit + "</p>";
                    str_li += "<p style=\"color: #666\">" + data.Rows[i].standard + "</p>";
                    str_li += "</a></li>";
                    str_li += "<li>￥" + parseFloat(data.Rows[i].price).toFixed(2) + "</li>";
                    str_li += "<li>" + data.Rows[i].category + "</li>";
                    str_li += "<li style=\"width: 155px\">";
                    str_li += "<img class=\"reduce_btn\" src=\"/templates/ql/images/reduce.jpg\" width=\"14\" height=\"14\" onclick=\"btn_change(this,'" + data.Rows[i].car_id + "',-1," + data.Rows[i].stock_quantity + ")\"/>";
                    str_li += "<input type=\"text\" class=\"inputCount\" value=\"" + data.Rows[i].quantity + "\" onblur=\"txt_change(this,'" + data.Rows[i].car_id + "','" + data.Rows[i].stock_quantity + "')\" />";
                    str_li += "<img class=\"add_btn\" src=\"/templates/ql/images/add.jpg\" width=\"14\" height=\"14\" onclick=\"btn_change(this,'" + data.Rows[i].car_id + "',1," + data.Rows[i].stock_quantity + ")\"/></li>";
                    str_li += "<li><strong>￥" + parseFloat(data.Rows[i].price * data.Rows[i].quantity).toFixed(2) + "</strong></li>";
                    var weight = 0;
                    if (parseFloat(data.Rows[i].weight).toFixed(2) > 0) {
                        weight = parseFloat(data.Rows[i].weight).toFixed(2);
                    }
                    else {
                        weight = 0.00;
                    }
                    str_li += "<li>" + weight + "kg</li>";
                    str_li += "<li class=\"last_li\" style=\"width: 88px; padding-left: 17px; height: 62px; border-right: none;\">";
                    str_li += "<a href=\"javascript:;\" onclick=\"del_car('" + data.Rows[i].car_id + "')\">删除</a><a href=\"javascript:;\" onclick=\"Submit4('" + data.Rows[i].car_id + "')\" style=\"margin-left: 20px;\">收藏</a></li>";
                    str_li += "</ul></li>";
                    weightcount += parseFloat(weight).toFixed(2) * data.Rows[i].quantity;
                    moneycount += parseFloat(data.Rows[i].price).toFixed(2) * data.Rows[i].quantity;
                }
                $("#span_money").html("总计：￥" + parseFloat(moneycount).toFixed(2));
                $("#div_weight").html(parseFloat(weightcount).toFixed(2) + "kg");
                $("#car_list").html(str_li);
            }
            else if (data == "Null") {
                $("#car_list").html("<li>您的购物车中空啦，请立即选购吧！</li>");
                $("#span_money").html("总计：￥0.00");
                $("#div_weight").html("0kg");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//+-按钮改变加入购物车数量
function btn_change(obj, car_id, sum, stock_quantity) {
    var txt = $(obj).siblings("input");
    var old_sum = parseInt($(txt).val()) + sum;

    if (old_sum <= 0 || old_sum > parseInt(stock_quantity)) {
        return;
    }
    else {
        change_car_sum(txt, car_id, old_sum);
    }
}
//文本框改变加入购物车数量
function txt_change(obj, car_id, stock_quantity) {
    var reg = /^[1-9]d*/;
    if (!reg.test($(obj).val())) {
        $.dialog.alert("您输入的格式不对！");
        get_car_list();
        return;
    }

    var quantity = $(obj).val();
    if (quantity <= 0 || quantity > parseInt(stock_quantity)) {
        get_car_list();
        return;
    }
    else {
        change_car_sum(obj, car_id, $(obj).val());
    }
}

//改变服务器购物车数量方法
function change_car_sum(txt, car_id, quantity) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=change_car_count&car_id=" + car_id + "&quantity=" + quantity,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                get_car_list();
            }
            else {
                $.dialog.alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//删除购物车
function del_car(car_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=del_car&car_ids=" + car_id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                get_car_list();
            }
            else {
                $.dialog.alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//删除购物车
function del_car_ck(str_name) {
    var car_ids = "";
    var i = 0;
    $("[name=" + str_name + "]").each(function () {
        if ($(this).prop("checked")) {
            car_ids += $(this).val() + "^";
            i++
        }
    });
    if (i <= 0) {
        $.dialog.alert("请选择您要删除的项！");
    }
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=del_car&car_ids=" + car_ids,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                get_car_list();
            }
            else {
                $.dialog.alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//全选
function ck_all(obj, ck_name) {
    if ($(obj).prop("checked")) {
        $("[name=" + ck_name + "]").each(function () {
            $(this).prop("checked", true);
        });
    }
    else {
        $("[name=" + ck_name + "]").each(function () {
            $(this).prop("checked", false);
        });
    }
}

//关闭弹出框
function close_shopping() {
    $(".all").css("display", "none");
    $(".black_overlay").css("display", "none");
    $(".all").children().removeClass("selected_shopping");
}
var is_login = false;

//购物车点击结算
function shopping_to_address() {

    var car_ids = "";
    $("[name=ck_car]").each(function () {
        if ($(this).prop("checked")) {
            car_ids += $(this).val() + "_";
        }
    });
    if (car_ids.length > 0) {
        get_address();
        get_car_list_by_car_id(car_ids.substring(0, car_ids.length - 1));
    }
    else {
        $.dialog.alert("请选择您要选购的商品！");
        return;
    }
}

//获取收货地址
function get_address() {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_address",
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            if (data != "Error" && data != "Null") {
                data = eval("(" + data + ")");
                var str = "<option value=\"\">请选择...</option>";
                for (var i = 0; i < data.Rows.length; i++) {
                    str += "<option value=\"" + data.Rows[i].id + "\" >" + data.Rows[i].address + "</option>";
                }
                $("#sel_address").html(str);
                $("#div_choose_address").css("display", "block");
                $("#div_add_address").css("display", "none");


                $(".all").children().removeClass("selected_shopping");
                $(".Address_information").addClass("selected_shopping");


            }
            else if (data == "Null") {
                $("#div_choose_address").css("display", "none");
                $("#div_add_address").css("display", "block");


                $(".all").children().removeClass("selected_shopping");
                $(".Address_information").addClass("selected_shopping");
            }
            else if (data == "Error") {
                $.dialog.alert("请您先登录！", function () { window.location.href = "login.aspx" });
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//通过购物车id获取购物车列表
function get_car_list_by_car_id(car_ids) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_car_list&car_ids=" + car_ids,
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            if (data != "Null" && data != "Erorr") {
                data = eval("(" + data + ")");
                var str_li = "";
                var weightcount = 0;
                var moneycount = 0;
                for (var i = 0; i < data.Rows.length; i++) {
                    str_li += "<li><ul><li style=\"height: 96px; padding: 13px 0 0 13px; width: 363px;\">";
                    str_li += "<a href=\"#\"><input type=\"checkbox\" value=\"" + data.Rows[i].car_id + "\" checked=\"checked\" name=\"ck_address_goods\" style=\"display:none;\" /><img src=\"" + data.Rows[i].img_url + "\" width=\"90\" height=\"90\" onclick=\"window.location.href='/good_show.aspx?id=" + data.Rows[i].goods_id + "')\"></a>";
                    str_li += "<a href=\"/good_show.aspx?id=" + data.Rows[i].goods_id + "\" target=\"_blank\">";
                    str_li += "<p>" + data.Rows[i].title + " " + data.Rows[i].unit + "</p>";
                    str_li += "<p style=\"color:#666\">" + data.Rows[i].standard + "</p></a>";
                    str_li += "</li>";
                    str_li += "<li>￥" + parseFloat(data.Rows[i].price).toFixed(2) + "</li>";
                    str_li += "<li>" + data.Rows[i].category + "</li>";
                    str_li += "<li>" + data.Rows[i].quantity + "</li>";
                    str_li += "<li>" + parseFloat(data.Rows[i].price * data.Rows[i].quantity).toFixed(2) + "</li>";
                    str_li += "<li><strong>" + data.Rows[i].weight + "kg</strong></li></ul></li>";
                    var weight
                    if (parseInt(data.Rows[i].weight) > 0) {
                        weight = data.Rows[i].weight;
                    }
                    else {
                        weight = 0.00;
                    }
                    weightcount += parseInt(weight) * data.Rows[i].quantity;
                    moneycount += parseFloat(data.Rows[i].price) * data.Rows[i].quantity;
                }
                $("#span_address_price").html("总计：￥" + parseFloat(moneycount).toFixed(2));
                $("#car_address_list").html(str_li);
                $("#hd_amount").val(parseFloat(moneycount).toFixed(2));
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//显示添加地址
function show_add_address(str_id) {
    $("#" + str_id).show();
}

function car_add_address() {
    if ($("#car_province").val() == "") {
        $.dialog.alert("请选择所在省！");
        return;
    }
    if ($("#car_city").val() == "") {
        $.dialog.alert("请选择所在市！");
        return;
    }
    if ($("#car_district").val() == "") {
        $.dialog.alert("请选择所在区/县！");
        return;
    }

    if ($("#car_address").val() == "") {
        $.dialog.alert("请输入详细地址！");
        return;
    }
    if ($("#car_consignee").val() == "") {
        $.dialog.alert("请输入收货人姓名！");
        return;
    }
    if ($("#car_consignee_mobile").val() == "") {
        $.dialog.alert("请输入收货人手机号码！");
        return;
    }
    if ($("#car_consignee_company").val() == "") {
        $.dialog.alert("请输入公司名称！");
        return;
    }
    $("#add_form").ajaxSubmit({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=car_add_address",
        dataType: "text",
        timeout: 20000,
        beforeSubmit: function () {
            $("#address_btn").html("提交中...");
            $("#address_btn").attr("disabled", "disabled");
        },
        success: function (data) {
            if (data != "Null" && data != "Error") {
                $.dialog.alert("添加地址成功");
                data = eval("(" + data + ")");
                var str = "<option value=\"\">请选择...</option>";
                for (var i = 0; i < data.Rows.length; i++) {
                    str += "<option value=\"" + data.Rows[i].id + "\" ";
                    if (data.Rows[i].selected == 1) {
                        str += "selected=\"selected\"";
                        $("#hd_address").val(data.Rows[i].id);
                    }
                    str += ">" + data.Rows[i].address + "</option>";
                }
                $("#sel_address").html(str);


                $("#car_province option").each(function () {
                    if ($(this).val() == "") {
                        $($(this).prop("selected", true));
                    }
                });

                $("#car_city").html("<option value=\"\">-请选择-</option>");
                $("#car_district").html("<option value=\"\">-请选择-</option>")





                $("#car_address").val("");

                $("#car_consignee").val("");

                $("#car_consignee_mobile").val("");
                $("#car_consignee_company").val("");
                $("#car_zip_phone").val("");

                $("#car_phone").val("");

                $("#div_add_address").hide();
            }
            else if (data == "Error") {
                $.dialog.alert(data.msg);
                $("#address_btn").html("再次提交");
                $("#address_btn").attr("disabled", "true");
            }
            else if (data == "Lost") {
                $.dialog.alert("请您先登录！");
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//计算运费
function sum_freight(id, freight) {
    $("#hd_freight").val(id);
    $("#span_freight").html("￥" + freight);
    $("#span_address_price").html("总计：￥" + (parseFloat(freight) + parseFloat($("#hd_amount").val())));
}
//显示支付界面
function Receipt_to_surepay() {
    if (parseInt($("#hd_address").val()) <= 0) {
        $.dialog.alert("请选择收货地址！");
        return;
    }
    if (parseInt($("#hd_freight").val()) <= 0) {
        $.dialog.alert("请选择配送方式！");
        return;
    }
    var car_ids = "";
    $("[name=ck_address_goods]").each(function () {
        if ($(this).prop("checked")) {
            car_ids += $(this).val() + "_";
        }
    });
    if (car_ids.length <= 0) {
        $.dialog.alert("请选择您要购买的商品！");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=add_order&address=" + $("#hd_address").val() + "&freight=" + $("#hd_freight").val() + "&car_ids=" + escape(car_ids.substring(0, car_ids.length - 1)),
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                $("#span_orderno").html(data.order_no);
                $("#span_paymoney").html(parseFloat(data.order_money).toFixed(2));
                $("[name=f_money]").each(function () {
                    $(this).html(data.user_money);
                });
                $("#hd_orderid").val(data.order_id);

                $(".all").children().removeClass("selected_shopping");
                $(".sure_pay").addClass("selected_shopping");
                $("[name=rd_freight]").each(function () {
                    if ($(this).prop("checked")) {
                        $(this).prop("checked", false);
                    }
                });


            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });





}

//改变收货地址
function change_address() {
    $("#hd_address").val($("#sel_address").val());
}
//选择支付方式
function finish_pay() {
    var pay_type = "";
    var pay_ment = "";
    $("[name=pay_type]").each(function () {
        if ($(this).prop("checked")) {
            pay_type = $(this).val();
        }
    });
    if (pay_type == "") {
        $.dialog.alert("请选择支付类型！");
        return;
    }
    if (pay_type == "payno") {
        $("[name=payment]").each(function () {
            if ($(this).prop("checked")) {
                pay_ment = $(this).val();
            }
        });
        if (pay_ment == "") {
            $.dialog.alert("请选择支付方式！");
            return;
        }
    }


    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=order_pay&pay_type=" + pay_type + "&pay_ment=" + pay_ment + "&order_id=" + $("#hd_orderid").val(),
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                if (data.url != "") {
                    //$("body").append("");

                    //var a = $("<a href=\"" + data.url + "\" target=\"_blank\" id=\"a_pay_open\"/>").get(0);

                    //                    var e = document.createEvent('MouseEvents');
                    //                    e.initEvent('click', true, true);
                    //                    a.dispatchEvent(e);
                    window.location.href = data.url;

                    $("#a_pay_open").bind("click");
                    $("#a_pay_open").remove();
                }
                else {
                    alert(data.msg);
                    window.location.href = window.location.href;
                }
                $(".all").children().removeClass("selected_shopping");

                //return;
                //                $(".activity").addClass("selected_shopping");
            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}



////////////////////////////////////////////////商品结束


///////////////////////////////////////////////搜索相关  开始
//弹出搜索框

function open_search() {
    var h = document.body.scrollHeight;
    $(".all").height(h);
    $(".black_overlay").height(h);
    $(".black_overlay").show();
    $(".all").show();
    $(".Search_page").addClass("selected_shopping");
};

//悬浮框

$(document).ready(function () {
    $(".suspension").mouseenter(function () {
        $(this).animate({ right: '0px' }, "fast");
    });
    $(".suspension").mouseout(function () {
        $(this).animate({ right: '-67px' }, "fast");
    });
});
///////////////////////////////////////////////搜索相关  结束


///////////////////////////////////////////////套餐相关  开始
function meal_into_shopping(meal_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=meal_into_shopping&meal_id=" + meal_id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            $.dialog.alert(data.msg);
            return;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
////////////////////////////////////////////////商品结束
///////////////////////////////////////////////套餐相关   结束
$(document).ready(function () {
    $(".help_center_left").find("ul>li").each(function (index) {
        $(this).click(function () {
            $(this).parent().find("a").removeClass("selected_help_center");
            $(this).find("a").addClass("selected_help_center");
            $(".help_center_right").children().css("display", "none");
            if (index == 0) { 
                $(".about").css("display", "block");
            }
            else if (index == 1) { 
                $(".help").css("display", "block");
            }
            else { 
                $(".bk").css("display", "block");
            }
        });
    });
});

$(document).ready(function () {
    $(".help_content").find("ul li dl dd a").click(function () {
        $(".help_content_answear").hide();
        $(this).siblings("div").slideDown("fast");
        $(".help_content").find("ul>li>dl>dd>a").removeClass("selected_answear");
        $(this).addClass("selected_answear");
    });
});

function setObjScroll(objectID, lh, speed, delay) {//lh:行高;delay:延迟;speed:滚动速度
    var o = document.getElementById(objectID);
    var oldspeed = speed;
    o.style.height = "auto";
    var park = false; //是否停靠
    var t; //定时器
    //修正滚动的区域
    /*
    *1、把父元素溢出隐藏
    *2、滚动元素的高度不能为0：通过设置滚动元素中的子元素的高度等于行高lh
    */
    var partnt = o.parentNode;
    if (partnt.offsetHeight <= 0) partnt.style.overflowY = "hidden"; //1、把父元素溢出隐藏
    configObj(o); //2、滚动元素的高度不能为0：通过设置滚动元素中的子元素的高度等于行高lh

    if (needScroll(o)) {//如果需要滚动，则进行滚动设置
        o.innerHTML += o.innerHTML; //复制一份同样的内容置于原来内容之下，才能实现无缝连
        o.style.marginTop = 0;
        if (window.attachEvent)//IE
        {
            o.attachEvent("onmouseover", setPark);
            o.attachEvent("onmouseout", setScroll); ;
        }
        else//FF
        {
            o.addEventListener("mouseover", setPark, true); //必须要有三个参数，缺一不可，而且事件名称没有 on  只是mouseover
            o.addEventListener("mouseout", setScroll, true);
        }

        setTimeout(start, delay);
    }
    function start() {//运行时开始网上滚动
        if (speed == 0) {
            park = true;
        }
        else {
            park = false;
        }
        t = setInterval(scrolling, speed); //setInterval（）不停地调用函数
        if (!park) {
            o.style.marginTop = parseInt(o.style.marginTop) - 1 + "px"; //向上滚动一个像素以便 scrolling函数的 parseInt(o.style.marginTop) % lh != 0 为真
            //o.style.marginTop = parseInt(o.style.marginTop) - 1 + "px";//向下滚动
        }
    }
    function scrolling() {
        if (parseInt(o.style.marginTop) % lh != 0) {
            o.style.marginTop = parseInt(o.style.marginTop) - 1 + "px";
            if (Math.abs(parseInt(o.style.marginTop)) >= o.scrollHeight / 2) o.style.marginTop = 0;
            //在滚动屏内的内容没有滚动完之前，再重新复制一份内容于下方连接
        } else {//滚动完一行的时候执行
            clearInterval(t); //将终止setInterval调动的循环执行
            setTimeout(start, delay);
        }
    }
    function needScroll(obj) {//判断是否需要滚动
        var partnt = o.parentNode; //返回对元素高度
        if (partnt.offsetHeight > obj.offsetHeight) {//如果父元素的高度比要滚动的元素的高度要高，则不需要滚动
            return false
        }
        return true;
    }
    function configObj(obj) {
        var allChilds = obj.childNodes;
        for (var i = 0; i < allChilds.length; i++) {
            if (allChilds[i].nodeType == 1)//返回1代表该元素为正常元素标签，返回3代表该元素为文本内容，返回8代表是注释标签，返回9代表是文档的类型
            {
                if (allChilds[i].offsetHeight <= 0) {//如果滚动元素中的子元素的高度小于等于零，则可能是元素里面放了浮动元素，需要修正元素的属性
                    allChilds[i].style.height = lh + "px";
                    allChilds[i].style.lineHeight = lh + "px";
                } else {
                    return;
                }
            }
        }

    }
    function setPark() {
        speed = 0;
    }
    function setScroll() {
        speed = oldspeed;
    }
}
//悬浮框

$(document).ready(function () {
    $(".suspension").mouseenter(function () {
        $(this).animate({ right: '0px' }, "fast");
    });
    $(".suspension").mouseout(function () {
        $(this).animate({ right: '-67px' }, "fast");
    });
});
//弹出搜索框

function open_search() {
    var h = document.body.scrollHeight;
    $(".all").height(h);
    $(".black_overlay").height(h);
    $(".black_overlay").show();
    $(".all").show();
    $(".Search_page").addClass("selected_shopping");
};


//变化弹出弹出框
$(document).ready(function () {
    $(".Product_detail_main_bottom").find("ul>li").each(function (index) {
        $(this).click(function () {
            $(".all").children().removeClass("selected_shopping");

            switch (index % 4) {
                case 0:
                    $(".Product_detail").addClass("selected_shopping");
                    break;
                case 1:
                    $(".collocation").addClass("selected_shopping");
                    break;
                case 2:
                    $(".good_content").addClass("selected_shopping");
                    break;
                default:
                    $(".recommended").addClass("selected_shopping");
                    break;
            }
        });
    });
});

////////////////////////////////////////////////////////////////////////////


function getpagedata(keyword, propty, category, page) {
    pageindex = page;
    var url = "/tools/data_ajax.ashx";
    var data = new Object();

    data.category = category;
    data.keyword = keyword;
    data.page = page;
    data.propty = propty;
    data.pagesize = 12;
    data.action = "get_productdate_page";
    AjaxRequest1(url, data, function (result) {
        var obj = JSON.parse(result);
        if (obj.status == "1") {
            $(".ret_1").eq(0).html(obj.html);
            $(".ret_1").eq(0).show();
            if (obj.pagelist != "") {
                $(".flickr").eq(0).html(obj.pagelist);
                $(".flickr").show();
            }
            else {
                $(".flickr").html(obj.pagelist);
                $(".flickr").hide();
            }
        }
        else {
        }
    });
    get_prop_data(keyword, category, page);
}

function get_prop_data(category, page) {

    var url = "/tools/data_ajax.ashx";
    var data = new Object();

    data.category = category;
    data.page = page;
    data.action = "get_prop_page";
    AjaxRequest1(url, data, function (result) {
        var obj = JSON.parse(result);
        if (obj.status == "1") {
            $(".select_list").eq(0).html(obj.html);
        }
        else {
            $(".select_list").eq(0).html(obj.info);
        }
    });
}
function AjaxRequest1(url, data, callBack) {
    $.ajax({
        url: url,
        type: 'POST',
        data: data,
        success: function (result) {
            callBack(result);
        }
    });
}
function getpagedata_search(url) {
    var key = $("#search").val();

    getpagedata(key, 0, 0, 1);
    $("#hmgoods").hide();
    $(".all").hide();
    $(".black_overlay").hide();
}

//筛选属性	
$(document).ready(function () {
    $(".select_tip").find("a").click(function () {
        $("#good_list_default").toggle();
        $(".select_list").toggle();
        $(".div_property_good_list").toggle();
        if (document.getElementById("div_property_good_list").style.display == "block") {
            $(".select_tip").find("span").html("收起筛选");
        }
        else {
            $(".select_tip").find("span").html("筛选商品");
        }
    });
});




//获取商品列表
function get_good_list(page, pagesize, category, property, order, keyword, flag) {
    if (page == 0) {
        page = 1;
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_good_list&page=" + page + "&pagesize=" + pagesize + "&category=" + category + "&property=" + property + "&order=" + order + "&keyword=" + keyword + "&flag=" + flag,
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            if (data != "Null") {
                data = eval("(" + data + ")");
                var str = "";
                //商品列表
                if (data.dt_good != undefined) {
                    for (var i = 0; i < data.dt_good.length; i++) {
                        str += "<li><div class=\"Procurement_list_li_top\"><input type=\"checkbox\" class=\"select_buy\" name=\"ck_good\" value=\"" + data.dt_good[i].id + "\"/></div>";
                        str += "<div class=\"img_describe\"><a href=\"/good_show.aspx?id=" + data.dt_good[i].id + "\" target=\"_blank\" ><img src=\"" + data.dt_good[i].img_url + "\" width=\"235\" height=\"229\" /> " + data.dt_good[i].title + " </a></div>";
                        str += "<span><strong>￥" + data.dt_good[i].sell_price + "</strong></span>";
                        str += "<div class=\"Procurement_list_li_bottom\">";
                        str += "<img class=\"reduce_btn\" src=\"../../../../templates/ql/images/reduce.jpg\" width=\"14\" height=\"14\" onclick=\"change_good_list_quantity(this,'-')\" />";
                        str += "<input type=\"text\" value=\"1\" id=\"txt_good_list_quantity_" + data.dt_good[i].id + "\" />";
                        str += "<img class=\"add_btn\" src=\"../../../../templates/ql/images/add.jpg\" width=\"14\" height=\"14\" onclick=\"change_good_list_quantity(this,'+')\"/>";
                        if (data.dt_good[i].standard == 2) {
                            str += "<a href=\"javascript:;\" onclick=\"list_to_shopping('" + data.dt_good[i].id + "')\" class=\"enter_shoppingcar\">进购物车</a>";
                        }
                        else {
                            str += "<a href=\"/good_show.aspx?id=" + data.dt_good[i].id + "\"  class=\"enter_shoppingcar\" target=\"_blank\">请选规格</a>";
                        }
                        str += "<a class=\"sc\" href=\"javascript:;\" onclick=\"Submit4('" + data.dt_good[i].id + "')\">收藏</a></div>";
                        str += "</li>";
                    }
                }
                else {
                    str = "<li>暂无数据！</li>";
                }
                //属性列表
                var str_property = "";

                if (data.dt_property != undefined) {

                    for (var i = 0; i < data.dt_property.length; i++) {
                        if (i == 0) {
                            str_property += "<dl>";
                        }
                        if (data.dt_property[i].parent_id == "0" && i == 0) {
                            str_property += "<dt>" + data.dt_property[i].title + "</dt>";
                        }
                        if (data.dt_property[i].parent_id == "0" && i > 0) {
                            str_property += "</dl><dl><dt>" + data.dt_property[i].title + "</dt>";
                        }

                        if (data.dt_property[i].parent_id > 0) {
                            str_property += "<dd style=\"position:relative;padding-right:26px; padding-left:7px; margin-right:5px;\">"
                            str_property += "<p style=\"display:block;height:22px;width:7px;position:absolute;left:0;top:0;\"></p>"
                            str_property += "<a href=\"javascript:;\" style=\" margin-right:5px;\">" + data.dt_property[i].title + "<input type=\"checkbox\" name=\"ck_property\" value=\"" + data.dt_property[i].id + "\" style=\" display:none;\"/></a>"
                            str_property += "<span style=\"display:block;height:22px;width:26px;position:absolute;right:0;top:0;\"></span>"
                            str_property += "</dd>";
                        }
                        if (i == data.dt_property.length - 1) {
                            str_property += "</dl>";
                        }
                    }
                }

                //类别
                if (data.dt_category != undefined) {
                    //ul_category
                    var str_category = "";
                    var li_length = 0;
                    for (var i = 0; i < data.dt_category.length; i++) {
                        str_category += "<li><a href=\"javascript:;\" onclick=\"$('#good_category_id').val('" + data.dt_category[i].id + "');get_good_list(1,12,'" + data.dt_category[i].id + "','','',$('#top_txt_sel').val(),'default')\">" + data.dt_category[i].title + "</a></li>";
                        li_length++;
                    }
                    $("#ul_category").html(str_category);
                    $("#parent_category_title").html("全部");
                }


                if (data.dt_page != undefined) {
                    $("#div_page").html((data.dt_page[0].page).replace(/\\\'/g, "").replace(/\\/g, ""));
                }


                $("#good_list_default").html(str);
                $("#div_property_good_list").html(str);
                //属性点击方法
                if (flag == "default" || flag == "self_category" || flag == "self" || flag == "other") {
                    $("#property_list").html(str_property);

                    $(".select_list").find("dl dd a").click(function () {
                        $(this).css("color", "#fff");
                        //$(this).parent().css("background", "url('../../../../templates/ql/images/select_type.jpg' )no-repeat").find("span").css("cursor", "pointer");
                        $(this).prev().css("background", "url('../../../../templates/ql/images/left_c.gif')");
                        $(this).next().css("background", "url('../../../../templates/ql/images/right_c.gif')").css("cursor", "pointer");
                        $(this).parent().css("background", "#ff572a");


                        $(this).find("[name=ck_property]").each(function () {
                            $(this).prop("checked", true);
                        });
                        var ck_property = "";
                        $("[name=ck_property]").each(function () {
                            if ($(this).prop("checked")) {
                                ck_property += $(this).val() + ",";
                            }
                        });
                        if (ck_property.length > 0) {
                            ck_property = ck_property.substring(0, ck_property.length - 1);
                        }
                        get_good_list(1, 12, $("#good_category_id").val(), ck_property, $("#sel_order").val(), $('#top_txt_sel').val(), "self_property");
                    });

                    $(".select_list").find("dl dd span").click(function () {
                        $(this).parent().find("a").css("color", "#000");
                        $(this).parent().css("background", "none");

                        //$(this).next().css("background", "none");
                        $(this).prevAll().css("background", "none");
                        $(this).css("background", "none");


                        //                    $(this).find("[name=ck_property]").each(function () {
                        //                        $(this).prop("checked", false);
                        //                        alert(1);
                        //                    });
                        $(this).prevAll().find("[name=ck_property]").each(function () {
                            $(this).prop("checked", false);
                        });
                        var ck_property = "";
                        $("[name=ck_property]").each(function () {
                            if ($(this).prop("checked")) {
                                ck_property += $(this).val() + ",";
                            }
                        });
                        if (ck_property.length > 0) {
                            ck_property = ck_property.substring(0, ck_property.length - 1);
                        }

                        get_good_list(1, 12, $("#good_category_id").val(), ck_property, $("#sel_order").val(), $('#top_txt_sel').val(), "self_property");
                    });
                }
                //alert(data.dt_property);
                if (data.dt_property == undefined) {
                    $("#property_list").hide();
                    $("#good_list_default").show();
                    $("#div_property_good_list").hide();
                }
                else {
                    $("#good_list_default").hide();
                    $("#property_list").show();
                    $("#div_property_good_list").show();
                }
            }
            else {
                $("#good_list_default").html("<li>暂无数据！</li>");
                $("#div_property_good_list").html("<li>暂无数据！</li>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

function category_move() {
    //头部类别  左右滚动方法
    var oPic = $('.slider_pic').find('ul');
    var oImg = oPic.find('li');
    var oLen = oImg.length;
    var oLi = oImg.width();
    var prev = $("#prev");
    var next = $("#next");

    oPic.width(oLen * 122); //计算总长度
    var iNow = 0;
    var iTimer = null;
    prev.click(function () {
        $("#prev").unbind("click");
        $("#next").unbind("click");
        if (iNow > 0) {
            iNow--;

        }
        ClickScroll();
    })
    next.click(function () {
        $("#prev").unbind("click");
        $("#next").unbind("click");
        if (iNow < oLen - 7) {
            iNow++
        }
        ClickScroll();
    })

    function ClickScroll() {

        iNow == 0 ? prev.addClass('no_click') : prev.removeClass('no_click');
        iNow == oLen - 7 ? next.addClass("no_click") : next.removeClass("no_click");

        oPic.animate({ left: -iNow * 122 }, 1000, function () {
            $("#prev").bind("click", function () {
                $("#prev").unbind("click");
                $("#next").unbind("click");
                if (iNow > 0) {
                    iNow--;

                }
                ClickScroll();
            });
            $("#next").bind("click", function () {
                $("#prev").unbind("click");
                $("#next").unbind("click");
                if (iNow < oLen - 7) {
                    iNow++
                }
                ClickScroll();
            });
        });

    }
}

//列表改变数量
function change_good_list_quantity(obj, change) {
    var now_sum = $(obj).siblings("input").val();

    if (change == "-") {
        if (now_sum <= 1) {
            return;
        }
        $(obj).siblings("input").val(parseInt(now_sum) - 1);
    }
    else {
        $(obj).siblings("input").val(parseInt(now_sum) + 1);
    }
}

//批量加入购物车
function batch_to_shopping() {
    //id-quantity
    var ids = "";
    $("[name=ck_good]").each(function () {
        if ($(this).prop("checked")) {
            ids += $(this).val() + "_" + $("#txt_good_list_quantity_" + $(this).val()).val() + ",";
        }
    });

    if (ids == "") {
        $.dialog.alert("请选择您要购买的商品！");
        return;
    }
    else {
        ids = ids.substring(0, ids.length - 1);
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=batch_to_shopping&ids=" + ids,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            $.dialog.alert(data.msg);
            return;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//商品列表单个商品加入购物车
function list_to_shopping(id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=batch_to_shopping&ids=" + id + "_" + $("#txt_good_list_quantity_" + id).val(),
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            $.dialog.alert(data.msg);
            return;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//头部搜索
function top_search() {

    if ($("#top_txt_sel").val() == "") {
        $.dialog.alert("请输入您要搜索的关键字！");
        return;
    }

    if ($("#good_list_default").length <= 0) {
        //非商品列表
        window.location.href = "/goods_list.aspx?category_id=0&keyword=" + $("#top_txt_sel").val() + "&flag=other";
    }
    else {
        //商品列表  get_good_list(1, 12, $("#good_category_id").val(), ck_property, $("#sel_order").val(), "", ""); 
        var ck_property = "";
        $("[name=ck_property]").each(function () {
            if ($(this).prop("checked")) {
                ck_property += $(this).val() + ",";
            }
        });
        if (ck_property.length > 0) {
            ck_property = ck_property.substring(0, ck_property.length - 1);
        }
        window.location.href = "/goods_list.aspx?category_id=" + $("#good_category_id").val() + "&keyword=" + $("#top_txt_sel").val() + "&flag=self&order=" + $("#sel_order").val() + "property=" + ck_property;
    }
}


//商品排序
function goods_sel_change() {
    var ck_property = "";
    $("[name=ck_property]").each(function () {
        if ($(this).prop("checked")) {
            ck_property += $(this).val() + ",";
        }
    });
    if (ck_property.length > 0) {
        ck_property = ck_property.substring(0, ck_property.length - 1);
    }
    get_good_list(1, 12, $("#good_category_id").val(), ck_property, $("#sel_order").val(), $("#top_txt_sel").val(), 'self_order')
}

function img_load(w, h, obj) {

    var old_height = $(obj).height();
    var old_width = $(obj).width();

    if (old_width > old_height) {
        //宽更长
        $(obj).width(w);
        var new_height = old_width / w * old_height;
        $(obj).height(new_height);
        $(obj).css({ marginTop: ((h - new_height) / 2) });
        // $(img).css({ width: new_width + "px"});
    }
    else {
        $(obj).height(h);
        $(obj).width(old_height / h * old_width);
    }
}


/////////////////////////////////////////////////////////////////////////////////////订单开始
//立即支付
function pay_now(order_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=pay_now&order_id=" + order_id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                $("#span_orderno").html(data.order_no);
                $("#span_paymoney").html(parseFloat(data.order_money).toFixed(2));
                $("[name=f_money]").each(function () {
                    $(this).html(data.user_money);
                });
                $("#hd_orderid").val(data.order_id);


                $(".sure_pay").addClass("selected_shopping");
                $(".black_overlay").show();
                $(".all").show();
            }
            else {
                $.dialog.alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//取消订单
function cancel_order(order_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=cancel_order&order_id=" + order_id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            alert(data.msg);
            location.href = location.href;

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}


//收藏批量加入购物车
function collect_batch_to_shopping() {
    //id-quantity
    var ids = "";
    $("[name=collect_good]").each(function () {
        if ($(this).prop("checked")) {
            ids += $(this).val() + "_1,";
        }
    });

    if (ids == "") {
        $.dialog.alert("请选择您要购买的商品！");
        return;
    }
    else {
        ids = ids.substring(0, ids.length - 1);
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=batch_to_shopping&ids=" + ids,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                alert(data.msg);
                window.location.href = window.location.href;
            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//浏览批量加入购物车
function browse_batch_to_shopping() {
    //id-quantity
    var ids = "";
    $("[name=browse_ck]").each(function () {
        if ($(this).prop("checked")) {
            ids += $(this).val() + "_1,";
        }
    });

    if (ids == "") {
        $.dialog.alert("请选择您要购买的商品！");
        return;
    }
    else {
        ids = ids.substring(0, ids.length - 1);
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=batch_to_shopping&ids=" + ids,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                alert(data.msg);
                window.location.href = window.location.href;
            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//删除用户地址
function del_address(id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=del_address&id=" + id,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                alert(data.msg);
                window.location.href = window.location.href;
            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}


//批量加入收藏夹
function batch_to_collect(ck_name) {
    var ids = "";
    $("[name=" + ck_name + "]").each(function () {
        if ($(this).prop("checked")) {
            ids = $(this).val() + ",";
        }
    });
    if (ids.length > 0) {
        ids = ids.substring(0, ids.length - 1);
    }
    else {
        $.dialog.alert("请选择您要加入收藏的商品！");
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=batch_to_collect&ids=" + ids,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                alert(data.msg);
                window.location.href = window.location.href;
            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
/////////////////////////////////////////////////////////////////////////////////////订单结束



//---------------------------------------------------------2015-1-27改--------------------------------------------------------
//选择规格
function new_check_standard(obj, goods_id, standard_value_id) {
    $(obj).addClass("current");
    $(obj).find("input").prop("checked", true);

    $(obj).siblings().removeClass("current");
    $(obj).siblings("a").find("input").prop("checked", false);
    var sum = 0;
    var str_value = "";

    $("[name=new_ck_standard]").each(function () {
        if ($(this).prop("checked")) {
            sum++;
            str_value += $(this).val() + ",";
        }
    });
    if ($("[name=strandard_title]").length > 0) {
        if (sum <= 0 || sum != $("[name=strandard_title]").length) {
            return;
        }
    }
    var unit_id = 0;
    if ($('input:radio[name=rd_unit]') != undefined) {
        unit_id = $('input:radio[name=rd_unit]:checked').val();
    }
    str_value = str_value.substring(0, str_value.length - 1);
    get_standard_unit_price(goods_id, str_value, unit_id);
}


//选择单位
function new_check_unit(good_id, unit_id, obj) {
    $(obj).addClass("current").siblings().removeClass("current");
    $("#new_unit_id").val(unit_id);
    var str_value = "";
    var sum = 0;

    $("[name=new_ck_standard]").each(function () {
        if ($(this).prop("checked")) {
            sum++;
            str_value += $(this).val() + ",";
        }
    });
    if ($("[name=strandard_title]").length > 0) {
        if (sum <= 0 || sum != $("[name=strandard_title]").length) {
            str_value = "";
            //return;
        }
        else {
            str_value = str_value.substring(0, str_value.length - 1);
        }
    }
    new_get_standard_unit_price(good_id, str_value, unit_id);

}

//获取规格  单位价格
function new_get_standard_unit_price(good_id, standard_value_id, unit_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=check_standard_unit_price&goods_id=" + good_id + "&standard_value_id=" + standard_value_id + "&unit_id=" + $("#new_unit_id").val(),
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == 1) {
                $("#new_span_sell").html("￥" + parseFloat(data.msg).toFixed(2));
                if (data.msg <= 0) {
                    $(".add_car").find("a").unbind("click");
                }
                else {
                    $(".add_car").find("a").bind("click", function () {
                        new_add_car();
                    });
                }
            }
            else {
                $.dialog.alert(data.msg);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}

//加入购物车
function new_add_car() {

    var sum = 0;
    var str_value = "";

    $("[name=new_ck_standard]").each(function () {
        if ($(this).prop("checked")) {
            sum++;
            str_value += $(this).val() + ",";
        }
    });

    if ($("[name=strandard_title]").length > 0) {
        if (sum <= 0 || sum != $("[name=strandard_title]").length) {
            $.dialog.alert("请选择规格！");

            return;
        }
        else {
            str_value = str_value.substring(0, str_value.length - 1);
        }
    }

    var unit_id = 0;
    if ($("[name=new_rd_unit]").length > 0) {
        unit_id = $("#new_unit_id").val();
        if (unit_id <= 0) {
            $.dialog.alert("请选择单位！");
            return;
        }
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=add_car&goods_id=" + $("#new_hd_good_id").val() + "&goods_quantity=" + $("#text_box").val() + "&standard=" + str_value + "&unit_id=" + unit_id,
        beforeSend: function () { $("#a_submit").unbind("click"); },
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status != "1") {
                $("#a_submit").bind("click", function () {
                    new_add_car();
                });
            }
            $.dialog.alert(data.msg);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}


//计算套餐商品列表金额
function new_sum_ck_meal_good_price() {

    var meal_good_price = 0;
    $("[name=new_ck_meal_good_price]").each(function () {
        if ($(this).prop("checked")) {
            meal_good_price += parseFloat($(this).attr("price"));
        }
    });
    $("#new_b_red_price1").html("￥" + parseFloat(meal_good_price).toFixed(2));
}

//计算套餐商品列表金额
function new_sum_ck_red_good_price() {
    var meal_good_price = 0;
    $("[name=new_ck_red_good_price]").each(function () {
        if ($(this).prop("checked")) {
            meal_good_price += parseFloat($(this).attr("price"));
        }
    });
    $("#new_b_red_price2").html("￥" + parseFloat(meal_good_price).toFixed(2));
}
//切换套餐
function new_ck_meal(obj, show_str, hide_str) {
    $(obj).addClass("current").siblings().removeClass("current");
    $("#" + show_str).css("display", "block");
    $("#" + hide_str).css("display", "none");
}


//获取套餐商品
function new_get_meal_good(meal_id, good_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_meal_good&meal_id=" + meal_id,
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            if (data != "Null") {
                //套餐商品
                data = eval("(" + data + ")");
                var str_meal_good = "";
                var str_one_good = "";
                var meal_good_price = 0.00;
                for (var i = 0; i < data.Rows.length; i++) {
                    meal_good_price += parseFloat(data.Rows[i].price);
                    if (data.Rows[i].good_id == good_id) {
                        //第一个固定商品 
                        str_one_good = "<li style=\"background: url(/templates/ql/images/icon_add.png) no-repeat right 30px;\">"
                                        + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\"><img src=\"" + data.Rows[i].img_url + "\" /></a></p>"
                                        + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\" title=\"" + data.Rows[i].all_title + "\">" + cutstring(data.Rows[i].all_title, 11) + "</a></p>"
                                        + "<p class=\"price\">"
                                        + "<input type=\"checkbox\" name=\"new_ck_meal_good_price\" checked=\"checked\" onclick=\"new_sum_ck_meal_good_price()\" value=\"" + data.Rows[i].meal_id + "|" + data.Rows[i].good_id + "\" price=\"" + data.Rows[i].price + "\"/>￥" + data.Rows[i].price + "</p>"
                                        + "</li>";
                    }
                    else {
                        //商品列表
                        str_meal_good += "<li style=\"";
                        if (i == data.Rows.length - 1) {
                            str_meal_good += "background: none;";
                        }
                        str_meal_good += "height: 150px;\">"
                            + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\"><img src=\"" + data.Rows[i].img_url + "\" /></a></p>"
                            + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\" title=\"" + data.Rows[i].all_title + "\">" + cutstring(data.Rows[i].all_title, 11) + "</a></p>"
                            + "<p class=\"price\">"
                            + "<input type=\"checkbox\" name=\"new_ck_meal_good_price\" checked=\"checked\" onclick=\"new_sum_ck_meal_good_price()\" value=\"" + data.Rows[i].meal_id + "|" + data.Rows[i].good_id + "\"  price=\"" + data.Rows[i].price + "\"/>￥" + data.Rows[i].price + "</p>"
                            + "</li>";
                    }
                    $("#new_b_red_price1").html("￥" + parseFloat(meal_good_price).toFixed(2));
                    $("#meal_one_good").html(str_one_good);
                    $("#meal_list_good").html(str_meal_good);
                    $("#meal_list_good").css("width", (150 * (data.Rows.length - 1)) + "px");
                }
            }
            else {
                $("#meal_list_good").html("");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
//获取搭配商品
function new_get_red_good(meal_id, good_id) {
    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=get_meal_good&meal_id=" + meal_id,
        dataType: "text",
        timeout: 20000,
        success: function (data) {
            if (data != "Null") {
                //套餐商品
                data = eval("(" + data + ")");
                var str_meal_good = "";
                var str_one_good = "";
                var meal_good_price = 0.00;
                for (var i = 0; i < data.Rows.length; i++) {
                    meal_good_price += parseFloat(data.Rows[i].price);
                    if (data.Rows[i].good_id == good_id) {
                        //第一个固定商品 
                        str_one_good = "<li style=\"background: url(/templates/ql/images/icon_add.png) no-repeat right 30px;\">"
                                        + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\"><img src=\"" + data.Rows[i].img_url + "\" /></a></p>"
                                        + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\" title=\"" + data.Rows[i].all_title + "\">" + cutstring(data.Rows[i].all_title, 11) + "</a></p>"
                                        + "<p class=\"price\">"
                                        + "<input type=\"checkbox\" name=\"new_ck_meal_good_price\" checked=\"checked\" onclick=\"new_sum_ck_meal_good_price()\" value=\"" + data.Rows[i].meal_id + "|" + data.Rows[i].good_id + "\" price=\"" + data.Rows[i].price + "\"/>￥" + data.Rows[i].price + "</p>"
                                        + "</li>";
                    }
                    else {
                        //商品列表
                        str_meal_good += "<li style=\"";
                        if (i == data.Rows.length - 1) {
                            str_meal_good += "background: none;";
                        }
                        str_meal_good += "height: 150px;\">"
                            + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\"><img src=\"" + data.Rows[i].img_url + "\" /></a></p>"
                            + "<p><a href=\"/good_show.aspx?id=" + data.Rows[i].good_id + "\" title=\"" + data.Rows[i].all_title + "\">" + cutstring(data.Rows[i].all_title, 11) + "</a></p>"
                            + "<p class=\"price\">"
                            + "<input type=\"checkbox\" name=\"new_ck_meal_good_price\" checked=\"checked\" onclick=\"new_sum_ck_meal_good_price()\" value=\"" + data.Rows[i].meal_id + "|" + data.Rows[i].good_id + "\"  price=\"" + data.Rows[i].price + "\"/>￥" + data.Rows[i].price + "</p>"
                            + "</li>";
                    }
                    $("#new_b_red_price2").html("￥" + parseFloat(meal_good_price).toFixed(2));
                    $("#red_one_good").html(str_one_good);
                    $("#red_list_good").html(str_meal_good);
                    $("#red_list_good").css("width", (150 * (data.Rows.length - 1)) + "px");
                }
            }
            else {
                $("#meal_list_good").html("");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}


//截取字符串
function cutstring(string, len) {
    if (string.length > len) {
        return string.substring(0, len) + "…";
    }
    else {
        return string;
    }
}

//套餐加入购物车
function new_meal_into_shopping() {
    var good_info = "";
    $("[name=new_ck_meal_good_price]").each(function () {
        if ($(this).prop("checked")) {
            good_info += $(this).val() + ",";
        }
    });
    if (good_info == "") {
        $.dialog.alert("请选择您要购买的商品！");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=new_meal_into_shopping&good_info=" + good_info,
        beforeSend: function () { $("#a_meal_shopping").unbind("click"); },
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status != "1") {
                $("#a_meal_shopping").bind("click", function () {
                    new_meal_into_shopping();
                });
            }
            $.dialog.alert(data.msg);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}


//搭配加入购物车
function new_red_into_shopping() {
    var good_info = "";
    $("[name=new_ck_red_good_price]").each(function () {
        if ($(this).prop("checked")) {
            good_info += $(this).val() + ",";
        }
    });
    if (good_info == "") {
        $.dialog.alert("请选择您要购买的商品！");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/tools/submit_ajax.ashx?action=new_meal_into_shopping&good_info=" + good_info,
        beforeSend: function () { $("#a_red_shopping").unbind("click"); },
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status != "1") {
                $("#a_red_shopping").bind("click", function () {
                    new_meal_into_shopping();
                });
            }
            $.dialog.alert(data.msg);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
