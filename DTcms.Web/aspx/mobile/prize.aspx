<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.prize" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2014/12/19 18:05:05.
		本页面代码由DTcms模板引擎生成于 2014/12/19 18:05:05. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	model = new DTcms.Web.UI.BasePage().GetUserInfo();
	if (model != null)
	{
	    DTcms.BLL.prizes pbll = new DTcms.BLL.prizes();
	    DTcms.BLL.share sbll = new DTcms.BLL.share();
	    DataSet sds = sbll.GetList("user_id=" + model.id);
	    if (sds != null && sds.Tables[0].Rows.Count > 0)
	    {
	        num = 4;//分享过之后4次抽奖机会
	    }
	
	    DataSet uds = pbll.GetList("user_id=" + model.id);
	    if (uds != null && uds.Tables[0].Rows.Count >= 0)
	    {
	        jp_dt = uds.Tables[0];
	        num = num - uds.Tables[0].Rows.Count;
	    }
	}
	

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html;charset=UTF-8\" />\r\n    <title>企力办公-中奖页面</title>\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/css/prize.css\">\r\n    <script src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/js/jquery-1.10.2.min.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/js/jquery.SuperSlide.2.1.1.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/js/jQueryRotate.2.2.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/js/jquery.easing.min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\">\r\n        $(function () {\r\n            var timeOut = function () {  //超时函数\r\n                $(\"#lotteryBtn\").rotate({\r\n                    angle: 0,\r\n                    duration: 10000,\r\n                    animateTo: 2160, //这里是设置请求超时后返回的角度，所以应该还是回到最原始的位置，2160是因为我要让它转6圈，就是360*6得来的\r\n                    callback: function () {\r\n                        alert('网络超时')\r\n                    }\r\n                });\r\n            };\r\n            var rotateFunc = function (awards, angle, text) {  //awards:奖项，angle:奖项对应的角度\r\n                $('#lotteryBtn').stopRotate();\r\n                $(\"#lotteryBtn\").rotate({\r\n                    angle: 0,\r\n                    duration: 5000,\r\n                    animateTo: angle + 1440, //angle是图片上各奖项对应的角度，1440是我要让指针旋转4圈。所以最后的结束的角度就是这样子^^\r\n                    callback: function () {\r\n                        alert(text)\r\n                    }\r\n                });\r\n            };\r\n            $(\"#lotteryBtn\").rotate({\r\n                bind: {\r\n                    click: function () {\r\n                        $.ajax({\r\n                            type: \"post\",\r\n                            url: \"/tools/submit_ajax.ashx?action=user_get_prize&r=\" + Math.random(),\r\n                            beforeSend: function (XMLHttpRequest) {\r\n                                //ShowLoading();\r\n                            },\r\n                            success: function (result, textStatus) {\r\n                                var data = $.parseJSON(result);\r\n                                if (data.status == 0) {\r\n                                    alert(data.msg);\r\n                                    location.href = '");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("';\r\n                                } else {\r\n                                    $(\"#num\").html(parseInt($(\"#num\").html()) - 1);\r\n                                }\r\n                                if (data.status == 1) {\r\n                                    rotateFunc(1, 23, '恭喜您抽中IPhone6');\r\n                                }\r\n                                if (data.status == 2) {\r\n                                    rotateFunc(2, 52, '恭喜您抽中10元体验包');\r\n                                }\r\n                                if (data.status == 3) {\r\n                                    rotateFunc(3, 112, '哎呀我去！什么都没有。');\r\n                                }\r\n                                if (data.status == 4) {\r\n                                    rotateFunc(4, 155, '恭喜您抽中100元抵用券');\r\n                                }\r\n                                if (data.status == 5) {\r\n                                    rotateFunc(5, 203, '恭喜您抽中100元话费');\r\n                                }\r\n                                if (data.status == 6) {\r\n                                    rotateFunc(6, 240, '恭喜您抽中小米4');\r\n                                }\r\n                                if (data.status == 7) {\r\n                                    rotateFunc(7, 301, '恭喜您抽中免费送货劵');\r\n                                }\r\n                                if (data.status == 8) {\r\n                                    rotateFunc(8, 330, '恭喜您抽中50元抵用券');\r\n                                }\r\n                            },\r\n                            error: function () {\r\n                                //请求出错处理\r\n                                alert(\"抽奖失败！\");\r\n                            }\r\n                        });\r\n                    }\r\n                }\r\n            });\r\n        });\r\n    </");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n    <!--中奖头部 开始-->\r\n    <div class=\"prize_top\">\r\n    </div>\r\n    <!--中奖头部 结束-->\r\n    <!--中奖名单 开始-->\r\n    <div class=\"prize_name\">\r\n        <div class=\"prize_namel rotate-bg\">\r\n            <div style=\"background-image: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/prize_namel.jpg); width: 465px;\r\n                height: 470px; position: relative;\">\r\n                <div id=\"lotteryBtn\" style=\"width: 178px; height: 178px; position: absolute; top: 131px;\r\n                    left: 143px;\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/rotate-static.png\" width=\"178px\" height=\"178px\"\r\n                        alt=\"指针\">\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"prize_namer\">\r\n            <div class=\"prize_name_list\">\r\n                <ul>\r\n                    ");
	foreach(DataRow dr in p_dt.Rows)
	{

	templateBuilder.Append("\r\n                    <li>" + Utils.ObjectToStr(dr["user_name"]) + " 获得 " + Utils.ObjectToStr(dr["prize"]) + "</li>\r\n                    ");
	}	//end for if

	templateBuilder.Append("                    \r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!--中奖名单 结束-->\r\n    <!--奖品区域 开始-->\r\n    ");
	if (model!=null)
	{

	templateBuilder.Append("\r\n    <div class=\"giftbox\">\r\n        <div class=\"gift\">\r\n            <div class=\"gift_left\">\r\n                <ul>\r\n                    ");
	foreach(DataRow dr in jp_dt.Rows)
	{

	templateBuilder.Append("\r\n                    <li><a href=\"javascript:void();\">\r\n                    ");
	if (dr["prize"].ToString().Trim()=="100元话费")
	{

	templateBuilder.Append("\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/iph3.gif\" width=\"216px\" height=\"154px\" alt=\"100元话费\">\r\n                        ");
	}
	else if (dr["prize"].ToString().Trim()=="10元体验包")
	{

	templateBuilder.Append("\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/iph5.gif\" width=\"216px\" height=\"154px\" alt=\"10元体验包\">\r\n                        ");
	}
	else if (dr["prize"].ToString().Trim()=="50元抵用券")
	{

	templateBuilder.Append("\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/iph1.gif\" width=\"216px\" height=\"154px\" alt=\"50元抵用券\">\r\n                        ");
	}
	else if (dr["prize"].ToString().Trim()=="iph2.gif")
	{

	templateBuilder.Append("\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/prizeone.jpg\" width=\"216px\" height=\"154px\" alt=\"100元抵用券\">\r\n                        ");
	}
	else if (dr["prize"].ToString().Trim()=="iph4.gif")
	{

	templateBuilder.Append("\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/prizeone.jpg\" width=\"216px\" height=\"154px\" alt=\"免费送货劵\">\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n                                               </a></li>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"gift_right\">\r\n                <p>\r\n                    剩余抽奖次数</p>\r\n                <strong id=\"num\">");
	templateBuilder.Append(Utils.ObjectToStr(num));
	templateBuilder.Append("</strong>\r\n                <input type=\"button\" value=\"全部领取\" class=\"getprize\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
	}	//end for if

	templateBuilder.Append("\r\n    <!--奖品区域 结束-->\r\n    <script type=\"text/javascript\">\r\n        //奖品滚动\r\n        jQuery(\".gift\").slide({ mainCell: \".gift_left ul\", autoPlay: true, effect: \"leftMarquee\", vis: 4, interTime: 30, trigger: \"click\", opp: true });\r\n        //名单滚动\r\n        jQuery(\".prize_namer\").slide({ mainCell: \".prize_name_list ul\", autoPlay: true, effect: \"topMarquee\", vis: 13, interTime: 50, trigger: \"click\" });\r\n    </");
	templateBuilder.Append("script>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
