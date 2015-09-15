function change_standard(str_name) {
    var standard_ids = "";
    $("[name=" + str_name + "]").each(function () {
        if ($(this).prop("checked")) {
            standard_ids += $(this).val()+",";
        }
    });
    if (standard_ids == "") {
        $("#dd_standard_value").html("");
        return ;
    }

    var groups_price = "";
    $(".groupprice").each(function () {
        groups_price += $(this).val() + ",";
    });
    if (groups_price != "") {
        groups_price = groups_price.substring(0, groups_price.length - 1);
    }
   
    $.ajax({
        type: "POST",
        url: "/tools/admin_ajax.ashx?action=change_standard&standard_ids=" + standard_ids.substring(0, standard_ids.length - 1)
        + "&quntity=" + $("#field_control_stock_quantity").val() + "&market_price=" + $("#field_control_market_price").val()
        + "&sell_price=" + $("#field_control_sell_price").val() + "&groups_price=" + groups_price,
        dataType: "json",
        timeout: 20000,
        success: function (data) {
            if (data.status == "y") {
                $("#dd_standard_value").html(data.info);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}