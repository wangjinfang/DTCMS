<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.shopping" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2014/3/21 17:55:12.
		本页面代码由DTcms模板引擎生成于 2014/3/21 17:55:12. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n<title>购物中心－");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/icons.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/af.ui.base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/style.css\" />\r\n<!--jqMobi主JS-->\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.10.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/jq.appframework.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/ui/appframework.ui.js\"></");
	templateBuilder.Append("script>\r\n<!--jqMobi插件-->\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/plugins/jq.slidemenu.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/lhgdialog/lhgdialog.js?skin=idialog\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/cart.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(e) {\r\n		$(\"#main_footer a.basket\").addClass(\"pressed\");\r\n    });\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-footer=\"main_footer\" style=\"padding-bottom:0;\">\r\n      <header>\r\n        <a href=\"javascript:;\" onclick=\"history.back(-1);\" class=\"backButton\">返回</a>\r\n        <h1>购物车</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      \r\n      ");
	if (action=="cart")
	{

	templateBuilder.Append("\r\n      <!--购物车-->\r\n      <div>\r\n        <ul class=\"car-list\">\r\n          ");
	IList<DTcms.Model.cart_items> ls1 = get_cart_list();

	foreach(DTcms.Model.cart_items modelt in ls1)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("goods_show",modelt.id));

	templateBuilder.Append("\" class=\"img-box\" data-ignore=\"true\">\r\n              <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" />\r\n            </a>\r\n            <h2>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("</h2>\r\n            <div class=\"note\">\r\n                <div class=\"btn-list\">\r\n                  <a href=\"javascript:;\" onclick=\"CartComputNum(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', '");
	templateBuilder.Append(Utils.ObjectToStr(modelt.id));
	templateBuilder.Append("', -1);\">-</a>\r\n                  <input name=\"goods_quantity\" type=\"text\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("\" readonly />\r\n                  <a href=\"javascript:;\" onclick=\"CartComputNum(this,'");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', '");
	templateBuilder.Append(Utils.ObjectToStr(modelt.id));
	templateBuilder.Append("', 1);\">+</a>\r\n                  <a href=\"javascript:;\" class=\"del\" onclick=\"DeleteCart(this,'");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("','");
	templateBuilder.Append(Utils.ObjectToStr(modelt.id));
	templateBuilder.Append("');\">删除</a>\r\n                </div>\r\n                <i class=\"price\">￥");
	templateBuilder.Append(Utils.ObjectToStr(modelt.user_price));
	templateBuilder.Append("</i>\r\n            </div>\r\n          </li>\r\n          ");
	}	//end for if

	if (ls1.Count<1)
	{

	templateBuilder.Append("\r\n          <div class=\"nodata\">\r\n            <h1></h1>\r\n            <p>购物车暂无商品</p>\r\n          </div>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      \r\n      ");
	if (cartModel.total_quantity>0)
	{

	templateBuilder.Append("\r\n      <div class=\"car-total\">\r\n        <div class=\"btn-list\">\r\n          <a href=\"");
	templateBuilder.Append(linkurl("shopping","confirm"));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"btn orange\">去结算</a>\r\n        </div>\r\n        <div class=\"note\">\r\n          <h3>总计(不含运费)：</h3>\r\n          <p>金额：￥");
	templateBuilder.Append(Utils.ObjectToStr(cartModel.real_amount));
	templateBuilder.Append("元&nbsp;&nbsp;&nbsp;积分：");
	templateBuilder.Append(Utils.ObjectToStr(cartModel.total_point));
	templateBuilder.Append("分</p>\r\n        </div>\r\n      </div>\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      <!--/购物车-->\r\n      ");
	}
	else if (action=="confirm")
	{

	templateBuilder.Append("\r\n      <!--订单结算-->\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n	  <script type=\"text/javascript\">\r\n        $(function () {\r\n            //表单提交\r\n            AjaxInitForm('#order_form', '#btnSubmit', 0);\r\n        });\r\n      </");
	templateBuilder.Append("script>\r\n      <form name=\"order_form\" id=\"order_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=order_save\">\r\n        <div class=\"wrap-box\">\r\n          <h2>收货信息</h2>\r\n          <div>\r\n            <div><input name=\"accept_name\" id=\"accept_name\" type=\"text\" placeholder=\"收货人姓名\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.nick_name));
	templateBuilder.Append("\" datatype=\"s2-20\" sucmsg=\" \" /></div>\r\n            <div><input name=\"address\" id=\"address\" type=\"text\" placeholder=\"收货地址\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.address));
	templateBuilder.Append("\" datatype=\"*2-100\" sucmsg=\" \" /></div>\r\n            <div><input name=\"post_code\" id=\"post_code\" type=\"text\" placeholder=\"邮政编码\" /></div>\r\n            <div><input name=\"mobile\" id=\"mobile\" type=\"text\" placeholder=\"手机号码\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.mobile));
	templateBuilder.Append("\" datatype=\"m\" sucmsg=\" \" /></div>\r\n            <div><input name=\"telphone\" id=\"telphone\" type=\"text\" placeholder=\"联系电话\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(userModel.telphone));
	templateBuilder.Append("\" /></div>\r\n          </div>\r\n        </div>\r\n        \r\n        <div class=\"wrap-box\">\r\n          <h2>支付配送</h2>\r\n          <div>\r\n            <select name=\"payment_id\" onchange=\"PaymentAmountTotal(this);\" datatype=\"*\" sucmsg=\" \">\r\n              <option value=\"\" fee=\"0\">付款方式</option>\r\n              ");
	DataTable list1 = get_payment_list(0, "is_lock=0");

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n              ");
	foreach(DataRow dr in list1.Rows)
	{

	decimal poundage_amount = get_payment_poundage_amount(Utils.StrToInt(Utils.ObjectToStr(dr["id"]), 0));

	templateBuilder.Append("\r\n              <option value=\"" + Utils.ObjectToStr(dr["id"]) + "\" fee=\"");
	templateBuilder.Append(Utils.ObjectToStr(poundage_amount));
	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["title"]) + "(手续费");
	templateBuilder.Append(Utils.ObjectToStr(poundage_amount));
	templateBuilder.Append("元)</option>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </select>\r\n            <select name=\"express_id\" onchange=\"FreightAmountTotal(this);\" datatype=\"*\" sucmsg=\" \">\r\n              <option value=\"\" fee=\"0\">配送方式</option>\r\n              ");
	DataTable list2 = get_express_list(0, "is_lock=0");

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n              ");
	foreach(DataRow dr in list2.Rows)
	{

	templateBuilder.Append("\r\n              <option value=\"" + Utils.ObjectToStr(dr["id"]) + "\" fee=\"" + Utils.ObjectToStr(dr["express_fee"]) + "\">" + Utils.ObjectToStr(dr["title"]) + "(运费" + Utils.ObjectToStr(dr["express_fee"]) + "元)</option>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </select>\r\n            <textarea name=\"message\" rows=\"2\" placeholder=\"若您对订单有特殊的要求，可在此备注\"></textarea>\r\n          </div>\r\n        </div>\r\n        \r\n        <div>\r\n          <ul class=\"car-list inset\">\r\n            ");
	IList<DTcms.Model.cart_items> ls2 = get_cart_list();

	foreach(DTcms.Model.cart_items modelt in ls2)
	{

	templateBuilder.Append("\r\n            <li>\r\n              <a href=\"");
	templateBuilder.Append(linkurl("goods_show",modelt.id));

	templateBuilder.Append("\" data-ignore=\"true\" class=\"img-box\">\r\n                <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.img_url));
	templateBuilder.Append("\" />\r\n              </a>\r\n              <h2>");
	templateBuilder.Append(Utils.ObjectToStr(modelt.title));
	templateBuilder.Append("</h2>\r\n              <div class=\"note\">\r\n                <span>共");
	templateBuilder.Append(Utils.ObjectToStr(modelt.quantity));
	templateBuilder.Append("件</span>\r\n                <i class=\"price\">￥");
	templateBuilder.Append((modelt.user_price*modelt.quantity).ToString());

	templateBuilder.Append("</i>\r\n              </div>\r\n            </li>\r\n            ");
	}	//end for if

	if (ls2.Count<1)
	{

	templateBuilder.Append("\r\n            <div class=\"nodata\">\r\n              <h1></h1>\r\n              <p>购物车暂无商品</p>\r\n            </div>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n          </ul>\r\n        </div>\r\n        \r\n        <div class=\"wrap-box\">\r\n          <h2>应付总金额：￥<b id=\"order_amount\" class=\"red\">");
	templateBuilder.Append(Utils.ObjectToStr(cartModel.real_amount));
	templateBuilder.Append("</b></h2>\r\n          <p>商品：￥<b id=\"goods_amount\">");
	templateBuilder.Append(Utils.ObjectToStr(cartModel.real_amount));
	templateBuilder.Append("</b>&nbsp;&nbsp;运费：￥<b id=\"express_fee\">0.00</b>&nbsp;&nbsp;手续费：￥<b id=\"payment_fee\">0.00</b></p>\r\n          <p>商品件数：");
	templateBuilder.Append(Utils.ObjectToStr(cartModel.total_quantity));
	templateBuilder.Append("件&nbsp;&nbsp;总积分：");
	templateBuilder.Append(Utils.ObjectToStr(cartModel.total_point));
	templateBuilder.Append("分</p>\r\n        </div>\r\n        \r\n        <div>\r\n          ");
	if (get_cart_quantity()>0)
	{

	templateBuilder.Append("\r\n          <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" value=\"确认提交\" class=\"btn red full\" />\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          <a class=\"btn gray full\">暂无商品</a>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n      </form>\r\n      <!--/订单结算-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 动力启航软件工作室 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n	</div>\r\n  \r\n    <!--底部导航-->\r\n    ");

	templateBuilder.Append("    <footer id=\"main_footer\">\r\n      <a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" class=\"icon home\" data-ignore=\"true\">首页</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" class=\"icon user\" data-ignore=\"true\">会员</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("shopping","cart"));

	templateBuilder.Append("\" class=\"icon basket\" data-ignore=\"true\">购物车 <span class=\"af-badge lr\"><script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_cart_count\"></");
	templateBuilder.Append("script></span></a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("\" class=\"icon magnifier\" data-ignore=\"true\">搜索</a>\r\n      <a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\" class=\"icon phone\" data-ignore=\"true\">电话</a>\r\n    </footer>");


	templateBuilder.Append("\r\n    <!--/底部导航-->\r\n	\r\n    <!--左侧导航-->\r\n    ");

	templateBuilder.Append("    <nav>\r\n      <ul class=\"list\">\r\n        <li class=\"divider\">网站导航</li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" class=\"icon home\" data-ignore=\"true\">网站首页</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\" class=\"icon tv\" data-ignore=\"true\">新闻资讯</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\" class=\"icon basket\" data-ignore=\"true\">购物商城</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\" class=\"icon picture\" data-ignore=\"true\">图片分享</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\" class=\"icon download\" data-ignore=\"true\">资源下载</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\" class=\"icon user\" data-ignore=\"true\">会员中心</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\" class=\"icon phone\" data-ignore=\"true\">关于我们</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("mfeedback"));

	templateBuilder.Append("\" class=\"icon message\" data-ignore=\"true\">在线留言</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\" class=\"icon phone\" data-ignore=\"true\">联系我们</a></li>\r\n      </ul>\r\n    </nav>");


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n      \r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
