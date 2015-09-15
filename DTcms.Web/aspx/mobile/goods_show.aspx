<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.article_show" ValidateRequest="false" %>
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
	templateBuilder.Append("<!DOCTYPE html>\r\n<!--HTML5 doctype-->\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">\r\n<meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />\r\n");
	string category_title = get_category_title(model.category_id,"商品介绍");

	templateBuilder.Append("\r\n<title>");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append(" - ");
	templateBuilder.Append(Utils.ObjectToStr(category_title));
	templateBuilder.Append(" - ");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("</title>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/icons.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/jqmobi/css/af.ui.base.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/css/idangerous.swiper.css\" />\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"");
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
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/idangerous.swiper-2.1.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/lhgdialog/lhgdialog.js?skin=idialog\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" charset=\"utf-8\" src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/js/cart.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n	$(document).ready(function(){\r\n	  var mySwiper = new Swiper('.swiper-container',{\r\n		calculateHeight:true,\r\n		resizeReInit:true,\r\n		pagination:\".pagination\",\r\n		autoplay:5000,\r\n		paginationClickable:true\r\n	  });\r\n	});\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<div id=\"afui\">\r\n  <div id=\"content\">\r\n\r\n	<div id=\"mainPanel\" class=\"panel\" data-header=\"main_header\" data-footer=\"main_footer\">\r\n      <!--幻灯片-->\r\n      <div id=\"slider\" class=\"swiper-container\">\r\n        <div class=\"swiper-wrapper\">\r\n          ");
	if (model.albums!=null)
	{

	foreach(DTcms.Model.article_albums modelt in model.albums)
	{

	templateBuilder.Append("\r\n          <div class=\"swiper-slide\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.thumb_path));
	templateBuilder.Append("\"/></div>\r\n          ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n        <div class=\"pagination\"></div>\r\n      </div>\r\n      <!--/幻灯片-->\r\n      \r\n      <!--商品信息-->\r\n      <div class=\"goods-btn\">\r\n		<h1>");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append("</h1>\r\n        <div class=\"price-box\">\r\n          <div>销售价：<b>￥" + Utils.ObjectToStr(model.fields["sell_price"]) + "</b></div>\r\n          <div>\r\n            会员价：\r\n            ");
	decimal user_price = get_user_article_price(model.id);

	if (user_price>-1)
	{

	templateBuilder.Append("\r\n            <b class=\"red\">￥");
	templateBuilder.Append(Utils.ObjectToStr(user_price));
	templateBuilder.Append("</b>\r\n            ");
	}
	else
	{

	templateBuilder.Append("\r\n            登录可见\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n          </div>\r\n        </div>\r\n        <div class=\"input-box\">\r\n            购买数量：\r\n            <div class=\"listbox\">\r\n              <a href=\"javascript:;\" class=\"min\" onclick=\"GoodsAddNum('#goods_quantity', -1);\">-</a>\r\n              <input id=\"goods_id\" name=\"goods_id\" type=\"hidden\" value=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("\" />\r\n              <input id=\"goods_quantity\" name=\"goods_quantity\" type=\"text\" value=\"1\" readonly />\r\n              <a href=\"javascript:;\" class=\"max\" onclick=\"GoodsAddNum('#goods_quantity', 1);\">+</a>\r\n            </div>\r\n        </div>\r\n        <div class=\"btn-box\">\r\n          <div class=\"col\">\r\n            <a href=\"javascript:void(0);\" class=\"btn add\" onclick=\"CartAdd(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', 0, '");
	templateBuilder.Append(linkurl("shopping","cart"));

	templateBuilder.Append("');\">加入购物车</a>\r\n          </div>\r\n          <div class=\"col\">\r\n            <a href=\"javascript:void(0);\" class=\"btn buy\" onclick=\"CartAdd(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("', 1, '");
	templateBuilder.Append(linkurl("shopping","confirm"));

	templateBuilder.Append("');\">立即购买</a>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      \r\n      <div class=\"goods-item\">\r\n        <h2>商品参数</h2>\r\n        <dl>\r\n          <dt>商品货号：</dt>\r\n          <dd>" + Utils.ObjectToStr(model.fields["goods_no"]) + "</dd>\r\n        </dl>\r\n        <dl>\r\n          <dt>库存情况：</dt>\r\n          <dd>" + Utils.ObjectToStr(model.fields["stock_quantity"]) + "件</dd>\r\n        </dl>\r\n        <dl>\r\n          <dt>上架时间：</dt>\r\n          <dd>");
	templateBuilder.Append(Utils.ObjectToStr(model.add_time));
	templateBuilder.Append("</dd>\r\n        </dl>\r\n      </div>\r\n      \r\n      <div>\r\n        <ul class=\"list inset listview\">\r\n          <li><a href=\"#contentPanel\" data-refresh-ajax=\"true\">图文介绍</a></li>\r\n          <li><a href=\"#commentPanel\">商品评论(<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_comment_count&id=");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("\"></");
	templateBuilder.Append("script>条)</a></li>\r\n        </ul>\r\n      </div>\r\n      <!--/商品信息-->\r\n      \r\n      <!--版权信息-->\r\n      ");

	templateBuilder.Append("      <div class=\"copyright\">\r\n        <p><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" data-ignore=\"true\">触屏版</a> | <a href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("?m2w\" data-ignore=\"true\">电脑版</a> | <a href=\"javascript:;\" onclick=\"$.ui.scrollToTop('mainPanel')\">返回顶部</a></p>\r\n        <address>版权所有 动力启航软件工作室 版本号 V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append("</address></p>\r\n      </div>");


	templateBuilder.Append("\r\n      <!--/版权信息-->\r\n    \r\n	</div>\r\n    \r\n    <!--页面头部-->\r\n    ");

	templateBuilder.Append("    <header id=\"main_header\">\r\n      <h2 class=\"logo\"><img src=\"");
	templateBuilder.Append("/templates/mobile");
	templateBuilder.Append("/images/logo.png\" /></h2>\r\n      <a onclick=\"af.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n    </header>");


	templateBuilder.Append("\r\n    <!--/页面头部-->\r\n    \r\n    <!--底部导航-->\r\n    ");

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


	templateBuilder.Append("\r\n    <!--/左侧导航-->\r\n    \r\n    <!--商品介绍-->\r\n    <div id=\"contentPanel\" class=\"panel\" data-footer=\"none\">\r\n      <header>\r\n        <a onclick=\"$.ui.goBack();\" class=\"backButton\">返回</a>\r\n        <h1>商品介绍</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      <div class=\"meta\">\r\n        <h1 class=\"meta-tit\">");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append("</h1>\r\n      </div>\r\n      <div class=\"entry\">\r\n        ");
	templateBuilder.Append(Utils.ObjectToStr(model.content));
	templateBuilder.Append("\r\n      </div>\r\n    </div>\r\n    <!--/商品介绍-->\r\n    \r\n    <!--评论-->\r\n    <div id=\"commentPanel\" class=\"panel\" data-footer=\"none\">\r\n      <header>\r\n        <a onclick=\"$.ui.goBack();\" class=\"backButton\">返回</a>\r\n        <h1>商品评论</h1>\r\n        <a onclick=\"$.ui.toggleSideMenu()\" class=\"menuButton\"></a>\r\n      </header>\r\n      ");

	int comment_count = get_comment_count(model.id, "is_lock=0");

	templateBuilder.Append("<!--取得评论总数-->\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n      <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/lhgdialog/lhgdialog.js?skin=idialog\"></");
	templateBuilder.Append("script>\r\n      <script type=\"text/javascript\">\r\n        //初始化评论列表\r\n		function InitCommentList(){\r\n			CommentAjaxList('#btnLoadComment','#comment_list',10,");
	templateBuilder.Append(Utils.ObjectToStr(comment_count));
	templateBuilder.Append(",'");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=comment_list&article_id=");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("');\r\n		}\r\n		//页面加载完毕事件\r\n		$(document).ready(function(){\r\n			//初始化评论列表\r\n			InitCommentList(); //加载第一页评论列表\r\n			//初始化发表评论表单\r\n			AjaxInitForm('#comment_form', '#btnSubmit', 1);\r\n        });\r\n		\r\n      </");
	templateBuilder.Append("script>\r\n      <div class=\"section\">\r\n        <h1><span>共");
	templateBuilder.Append(Utils.ObjectToStr(comment_count));
	templateBuilder.Append("条评论</span>网友评论</h1>\r\n      </div>\r\n      <div>\r\n        <div class=\"comment-add\">\r\n          <form id=\"comment_form\" name=\"comment_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=comment_add&article_id=");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("\">\r\n            <div><textarea id=\"txtContent\" name=\"txtContent\" rows=\"3\" placeholder=\"吐槽一下\" datatype=\"*\" nullmsg=\"请填写评论内容\" errormsg=\"请填写评论内容\" sucmsg=\" \"></textarea></div>\r\n            <div class=\"btn-list\">\r\n              <input id=\"btnSubmit\" name=\"submit\" type=\"submit\" value=\"发表\" class=\"btn\" />\r\n              <input id=\"txtCode\" name=\"txtCode\" type=\"text\" class=\"code\" maxlength=\"4\" placeholder=\"验证码\" datatype=\"s4-4\" nullmsg=\"请填写验证码\" errormsg=\"请填写4位验证码\" sucmsg=\" \" />\r\n              <a href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"25\" style=\"vertical-align:middle;\" /> 看不清楚？</a>\r\n            </div>\r\n          </form>\r\n        </div>\r\n        <ol id=\"comment_list\" class=\"comment-list\">\r\n          <p class=\"nodata\">暂无评论，快来抢沙发吧！</p>\r\n        </ol>\r\n      </div>\r\n      ");
	if (comment_count>0)
	{

	templateBuilder.Append("\r\n      <div class=\"more-comment\">\r\n        <input id=\"btnLoadComment\" type=\"button\" value=\"加载更多评论\" class=\"btn\" onclick=\"InitCommentList();\">\r\n      </div>\r\n      ");
	}	//end for if



	templateBuilder.Append("\r\n    </div>\r\n    <!--/评论-->\r\n      \r\n  </div>\r\n</div>\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
