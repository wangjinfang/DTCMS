// JavaScript Document
//菜单效果
var menu_mark = 0;
$(document).ready(function () {
    $("#about_qili").mouseenter(function () {
        $(this).children("a").css("color", "#fff");
        $(this).children("a").css("background-color", "#c40014");
        $("#about_qili_a").css("display", "block");
    });
    $("#about_qili").mouseleave(function () {
        $(this).children("a").css("background-color", "#fff")
			; $(this).children("a").css("color", "#000");
        $("#about_qili_a").css("display", "none");
    });
});
//加入收藏夹
function AddFavorite(sURL, sTitle) {
    sURL = encodeURI(sURL);
    try {
        window.external.addFavorite(sURL, sTitle);
    } catch (e) {
        try {
            window.sidebar.addPanel(sTitle, sURL, "");
        } catch (e) {
            alert("加入收藏失败，请使用Ctrl+D进行添加,或手动在浏览器里进行设置.");
        }
    }
};
//底部菜单效果
$(document).ready(function () {
    $("#purchase").click(open_menu);
    $("#open_close").click(function () {
        if (menu_mark == 0) {
            open_menu();
        }
        else
        { close_menu(); }
    })
});
function open_menu() {
    $(".Procure_bottom_3").slideDown(function () {


    }); $("html").animate({ scrollTop: '4000px' }, "slow");
    $("#open_close").css("background", "url(images/close.jpg) no-repeat center center");
    menu_mark = 1;
    var bottom = document.body.scrollHeight;

};
function close_menu() {
    $(".Procure_bottom_2").slideUp();
    $(".Procure_bottom_3").slideUp();
    $("#open_close").css("background", "url(images/open.jpg) no-repeat center center");
    $(".Procure_bottom_3").find("ul li").css("background", "none");
    menu_mark = 0;
};
$(document).ready(function () {
    $(".Procure_bottom_3").find("li").click(function () {
        $(".Procure_bottom_2_ul").css("display", "none");
        var id = this.id;
        $(this).siblings().css("background", "none");
        $(this).css("background", "url(images/menu.jpg) no-repeat center top");
        var lastchar = id.charAt(id.length - 1);
        var new_id = "#ul_" + lastchar;
        $(new_id).css("display", "block");
        $(".Procure_bottom_2").slideDown();

    })
});

//商品列表tab效果
$(document).ready(function () {
    $(".Tab").find("ul li a").click(function () {
        $(this).parent().siblings("li").find("a").removeClass("selected_li");
        $(this).addClass("selected_li");

    });
});
//悬浮框

$(document).ready(function () {
    $(".suspension").mouseenter(function () {
        $(this).animate({ right: '0px' }, "fast");
    });
    $(".suspension").mouseout(function () {
        $(this).animate({ right: '-67px' }, "fast");
    });
});

//筛选商品		
$(document).ready(function () {
    $(".select_tip").find("a").click(function () {
        $("#first_list").toggle();
        $(".select_list").toggle();
        if (document.getElementById("hmgoods").style.display == "block") {
            $(".select_tip").find("span").html("收起筛选");
        }
        else {
            $(".select_tip").find("span").html("筛选商品");
        }
    });
});
//选中类型
$(document).ready(function () {
    $(".select_list").find("dl dd a").click(function () {
        $(this).css("color", "#fff");
        $(this).parent().css("background", "url('images/select_type.jpg' )no-repeat");
    });

    $(".select_list").find("dl dd span").click(function () {
        $(this).parent().find("a").css("color", "#000");
        $(this).parent().css("background", "none");
    });
});
//增加删除按钮
$(document).ready(function () {
    $(".add_btn").click(function () {
        var num = parseInt($(this).siblings(":text").val());
        num++;
        $(this).siblings(":text").val(num);
    });
    $(".reduce_btn").click(function () {
        var num = parseInt($(this).siblings(":text").val());
        num--;
        if (num <= 0) {
            num = 0;
        }
        $(this).siblings(":text").val(num);
    });
})
//全选效果
$(document).ready(function () {
    $(".shopping_car_select").click(function () {
        if ($(this).attr("checked")) { // 全选
            $(".shopping_car_select").attr("checked", true);
            $(".shopping_car_main_table_main").find(":checkbox").each(function () {
                $(this).attr("checked", true);
            });
        }
        else { // 取消全选
            $(".shopping_car_select").attr("checked", false);
            $(".shopping_car_main_table_main").find(":checkbox").each(function () {
                $(this).attr("checked", false);
            });
        }
    })
});
/*----------------下订单流程效果-------------*/
//弹出采购车
function open_shopping() {
    var h = document.body.scrollHeight;
    $(".all").height(h);
    $(".black_overlay").height(h);
    $(".black_overlay").show();
    $(".all").show();
    $(".all").children().removeClass("selected_shopping");
    $(".shopping_car").addClass("selected_shopping");
}
//关闭弹出框
function close_shopping() {
    $(".all").css("display", "none");
    $(".black_overlay").css("display", "none");
    $(".all").children().removeClass("selected_shopping");
}
//购物车点击结算
function shopping_to_address() {
    $(".all").children().removeClass("selected_shopping");
    $(".Address_information").addClass("selected_shopping");
}
function address_to_Receipt() {
    $(".all").children().removeClass("selected_shopping");
    $(".Receipt_information").addClass("selected_shopping");
}
function Receipt_to_surepay() {
    $(".all").children().removeClass("selected_shopping");
    $(".sure_pay").addClass("selected_shopping");
}
function finish_pay() {
    $(".all").children().removeClass("selected_shopping");
    $(".activity").addClass("selected_shopping");
}
//配送方式
$(document).ready(function () {
    $(".rurecontent").find("li a").click(function () {
        $(this).siblings("a").removeClass("selected_dispatching");
        $(this).addClass("selected_dispatching");

    })
});
//活动选择
$(document).ready(function () {
    $(".activity_top_left").find("a").click(function () {
        $(this).siblings("a").removeClass("selected_activity");
        $(this).addClass("selected_activity");

    })
});

/*----------------商品信息和搜索效果-------------*/
//商品详情页图片浏览
$(document).ready(function () {
    $(".Product_detail_main_left").find("ul li a").click(function () {
        $(this).parent().siblings("li").find("a").removeClass("Product_detail_main_left_selected_img");
        $(this).addClass("Product_detail_main_left_selected_img");
        var img_src = $(this).find("img").attr("src");
        $(".Product_detail_main_bigimg").find("img").attr("src", img_src);
    });
});
//商品详情页右部型号选择
$(document).ready(function () {
    $(".Product_detail_main_select").find("dl dd a").click(function () {
        $(this).parent().siblings("dd").find("a").removeClass("Product_detail_mian_selected_a");
        $(this).addClass("Product_detail_mian_selected_a");
    });
});

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
                for (var i = 0; i < data.dt_albums.length; i++) {
                    str_small_img += " <li><a href=\"javascript:;\"";
                    if (i == 0) {
                        str_small_img += " class=\"Product_detail_main_left_selected_img\"";
                        big_img_url = data.dt_albums[i].original_path;
                    }
                    str_small_img += "><img src=\"" + data.dt_albums[i].thumb_path + "\" width=\"50\" height=\"50\" /></a></li>";
                }
                $("#ul_picture").html(str_small_img);
                $("#img_big").attr("src", big_img_url);
            }
            else {

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        }
    });
}
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
                case 0: $(".Product_detail").addClass("selected_shopping"); break;
                case 1: $(".collocation").addClass("selected_shopping"); break;
                case 2: break;
                default: $(".recommended").addClass("selected_shopping"); break;
            }
        });
    });
});

//搜索页下拉菜单效果
$(document).ready(function () {
    $(".search_menu").find("ul li").mouseenter(function () {
        $(this).children("ul").slideDown();
    });
    $(".search_menu").find("ul li").mouseleave(function () {
        $(this).children("ul").slideUp();
    });
});

//搜索页底部菜单选择效果
$(document).ready(function () {
    $(".search_bottom_top").find("ul li a").click(function () {
        $(this).parent().siblings("li").find("a").removeClass("selected_li");
        $(this).addClass("selected_li");
    });
});

/*----------------帮助中心界面-------------*/
$(document).ready(function () {
    $(".help_center_left").find("ul>li").each(function (index) {
        $(this).click(function () {
            $(this).parent().find("a").removeClass("selected_help_center");
            $(this).find("a").addClass("selected_help_center");
            $(".help_center_right").children().css("display", "none");
            if (index == 0) {
                $(".about").css("display", "block");
            }
            else
            { $(".help").css("display", "block"); }

        })
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