/*检测是否移动设备来访否则跳转*/
if(!browserRedirect()){
	//location.href = 'http://demo.dtcms.net';
}
/*页面加载完毕时运行函数
-----------------------------------------------------*/
$(document).ready(function(e) {
    if (!((window.DocumentTouch && document instanceof DocumentTouch) || 'ontouchstart' in window)) {
		$.getScript("http://localhost:810/templates/mobile/jqmobi/plugins/af.desktopBrowsers.js");
	}
});
/*当窗体大小发生改变时缩放内容元素的大小*/
$(window).resize(function(){
	InitObjectWidth($(".entry iframe"));
	InitObjectWidth($(".entry embed"));
	InitObjectWidth($(".entry video"));
});
/*当窗体加载时缩放内容元素的大小*/
$(window).load(function(){
	InitObjectWidth($(".entry iframe"));
	InitObjectWidth($(".entry embed"));
	InitObjectWidth($(".entry video"));
});

/*全局函数
-----------------------------------------------------*/
//检测是否移动设备来访
function browserRedirect() { 
	var sUserAgent= navigator.userAgent.toLowerCase(); 
	var bIsIpad= sUserAgent.match(/ipad/i) == "ipad"; 
	var bIsIphoneOs= sUserAgent.match(/iphone os/i) == "iphone os"; 
	var bIsMidp= sUserAgent.match(/midp/i) == "midp"; 
	var bIsUc7= sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4"; 
	var bIsUc= sUserAgent.match(/ucweb/i) == "ucweb"; 
	var bIsAndroid= sUserAgent.match(/android/i) == "android"; 
	var bIsCE= sUserAgent.match(/windows ce/i) == "windows ce"; 
	var bIsWM= sUserAgent.match(/windows mobile/i) == "windows mobile"; 
	if (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM) { 
		return true;
	} else { 
		return false;
	} 
}
//初始化页面无素的大小
function InitObjectWidth(obj){
	var maxWidth=$(".entry").width();
	obj.each(function(){
		if($(this).width()>maxWidth){
			var wh=$(this).width()/$(this).height();
			var newHeight=maxWidth/wh;
			$(this).width(maxWidth);
			$(this).height(newHeight);
		}
	});
}
//写Cookie
function addCookie(objName, objValue, objHours) {
    var str = objName + "=" + escape(objValue);
    if (objHours > 0) {//为0时不设定过期时间，浏览器关闭时cookie自动消失
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

//读Cookie
function getCookie(objName) {//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
    return "";
}
/*页面通用函数
-----------------------------------------------------*/
/*切换验证码*/
function ToggleCode(obj, codeurl) {
    $(obj).children("img").eq(0).attr("src", codeurl + "?time=" + Math.random());
	return false;
}
/*搜索查询*/
function SiteSearch(send_url, divTgs, channel_name) {
    var strwhere = "";
    if (channel_name !== undefined) {
        strwhere = "&channel_name=" + channel_name
    }
	var str = $.trim($(divTgs).val());
	if (str.length > 0 && str != "输入关健字") {
	    window.location.href = send_url + "?keyword=" + encodeURI($(divTgs).val()) + strwhere;
	}
	return false;
}
/*下载链接*/
function downLink(point, linkurl){
	if(point > 0){
		$.dialog.confirm("下载需扣除" + point + "积分<br />有效时间内重复下载不扣分，继续吗？", function () {
			window.location.href = linkurl;
		});
	}else{
		window.location.href = linkurl;
	}
	return false;
}

//发送验证邮件
function SendEmail(username, sendurl) {
	if(username == ""){
		$.dialog.alert('对不起，用户名不允许为空！');
		return false;
	}
	//提交
	$.ajax({
		url: sendurl,
		type: "POST",
		timeout: 60000,
		data: {
			username: function () {
				return username;
			}
		},
		dataType: "json",
		success: function (data, type) {
			if (data.status == 1) {
				$.dialog.tips(data.msg, 2, "32X32/succ.png", function(){});
			} else {
				$.dialog.alert(data.msg);
			}
		},
		error: function(XMLHttpRequest, textStatus, errorThrown){
			 $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		}
	});
}

//单击执行AJAX请求操作
function clickSubmit(sendUrl){
	$.ajax({
		type: "POST",
		url: sendUrl,
		dataType: "json",
		timeout: 20000,
		success: function(data, textStatus) {
			if (data.status == 1){
				$.dialog.tips(data.msg, 2, "32X32/succ.png", function(){
					location.reload();
			    });
			} else {
				$.dialog.alert(data.msg);
			}
		},
		error: function (XMLHttpRequest, textStatus, errorThrown) {
			$.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
		}
	});
}

/*全选取消按钮函数*/
function checkAll(chkobj){
	if($(chkobj).text()=="全选"){
	    $(chkobj).text("取消");
		$(".checkall").prop("checked", true);
	}else{
    	$(chkobj).text("全选");
		$(".checkall").prop("checked", false);
	}
}

/*执行删除操作*/
function ExecDelete(sendUrl, checkValue, urlId){
	var urlObj = $(urlId);
	//检查传输的值
	if (!checkValue) {
		$.dialog.alert("对不起，请选中您要操作的记录！");
        return false;
	}
	var m = $.dialog.confirm("删除记录后不可恢复，您确定吗？", function () {
		$.ajax({
			type: "POST",
			url: sendUrl,
			dataType: "json",
			data: {
				"checkId":  checkValue
			},
			timeout: 20000,
			success: function(data, textStatus) {
				if (data.status == 1){
					$.dialog.tips(data.msg, 2, "32X32/succ.png", function(){
						if(urlObj){
							location.href = urlObj.val();
						}else{
							location.reload();
						}
					});
				} else {
					$.dialog.alert(data.msg);
				}
			},
			error: function (XMLHttpRequest, textStatus, errorThrown) {
				$.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
			}
		});
	}, function(){ });
}

/*表单AJAX提交封装(包含验证)*/
function AjaxInitForm(formId, btnId, isDialog, urlId){
	var formObj = $(formId); //表单元素
	var btnObj = $(btnId); //按钮元素
	var urlObj = $(urlId); //隐藏域元素
	
	formObj.Validform({
		tiptype:3,
		callback:function(form){
			$.ajax({
				type:"post",
				url:form.attr("url"),
				data:form.serialize(),
				dataType:"json",
				beforeSend:function(formData, jqForm, options){
					btnObj.prop("disabled", true);
					btnObj.val("请稍候...");
				},
				success:function(data, textStatus){
					if (data.status == 1) {
						btnObj.val("提交成功");
						//是否提示，默认不提示
						if(isDialog == 1){
							$.dialog.tips(data.msg, 2, "32X32/succ.png", function(){
								if(data.url){
									location.href = data.url;
								}else if(urlObj.length > 0 && urlObj.val() != ""){
									location.href = urlObj.val();
								}else{
									location.reload();
								}
							});
						}else{
							if(data.url){
								location.href = data.url;
							}else if(urlObj){
								location.href = urlObj.val();
							}else{
								location.reload();
							}
						}
					}else{
						$.dialog.alert(data.msg);
						btnObj.prop("disabled", false);
						btnObj.val("重新提交");
					}
				},
				error:function(XMLHttpRequest, textStatus, errorThrown){
					$.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
					btnObj.prop("disabled", false);
					btnObj.val("重新提交");
				}
			});
			return false;
		}
	});
}

/*AJAX加载评论列表*/
var comment_page_index = 1; //评论页码全局变量
function CommentAjaxList(btnObj,listDiv, pageSize, pageCount, sendUrl){
	//计算总页数
	var pageTotal = Math.ceil(pageCount / pageSize);
	if(comment_page_index > pageTotal){
		return false;
	}
	//发送AJAX请求
	$.ajax({
		type:"post",
		url:sendUrl + "&page_size=" + pageSize + "&page_index=" + comment_page_index,
		dataType:"json",
		beforeSend:function(){
			$(btnObj).prop("disabled", true);
			$(btnObj).val('正在加载...');
		},
		success:function(data){
			var strHtml = '';
			for(var i in data){
				strHtml += '<li>' + 
				'<div class="inner">' +
				'<p>' + unescape(data[i].content) + '</p>' +
				'<div class="meta">' +
				'<span class="blue">' + data[i].user_name + '</span>\n' +
				'<span class="time">' + data[i].add_time + '</span>' +
				'</div>' +
				'</div>';
				if(data[i].is_reply == 1){
					strHtml += '<div class="answer">' +
					'<div class="meta">' +
					'<span class="right time">' + data[i].reply_time + '</span>' +
					'<span class="blue">管理员回复：</span>' +
					'</div>' + 
					'<p>' + unescape(data[i].reply_content) + '</p>' +
					'</div>';
				}
				strHtml += '</li>';
			}
			//添加到列表
			if(comment_page_index==1){
				$(listDiv).html(strHtml);
			}else{
				$(listDiv).append(strHtml);
			}
			comment_page_index++; //当前页码加一
			if(comment_page_index > pageTotal){
				$(btnObj).hide();
			}
		},
		complete:function(){
			$(btnObj).prop("disabled", false);
			$(btnObj).val('加载更多评论');
		}
	});
}