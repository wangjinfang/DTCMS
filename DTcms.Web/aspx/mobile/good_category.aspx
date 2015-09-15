<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.good_category" ValidateRequest="false" %>
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
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>三部导购</title>\r\n<link href=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.10.2.min.js\"></");
	templateBuilder.Append("script> \r\n<script language=\"javascript\" type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n        $('.guidenr dl').each(function () {\r\n            $(this).hover(\r\n 			function () {\r\n 			    $(this).children('dt.dis_none').slideDown('fast');\r\n 			},\r\n 			function () {\r\n 			    $(this).children('dt.dis_none').slideUp('fast');\r\n 			}\r\n 		);\r\n        })\r\n    });\r\n</");
	templateBuilder.Append("script> \r\n</head>\r\n<body>\r\n<!--顶部 start-->\r\n    ");

	templateBuilder.Append("<div class=\"top\" style=\"background: #fff;\">\r\n    <div class=\"top_main\" style=\"position: relative;\">\r\n        <!--logo start-->\r\n        <div class=\"logo\">\r\n            <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/logo2.jpg\" width=\"92\" height=\"89\"></div>\r\n        <!--logo end-->\r\n        <!--菜单 start-->\r\n        <div class=\"top_menu\">\r\n            <ul>\r\n                <li><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\" target=\"_blank\" class=\"a_class\">首页</a></li>\r\n                <li><a href=\"");
	templateBuilder.Append(linkurl("good_category"));

	templateBuilder.Append("\" class=\"a_class\">办公用品</a></li>\r\n                <li><a href=\"");
	templateBuilder.Append(linkurl("qyservice"));

	templateBuilder.Append("\" class=\"a_class\">办公服务</a>\r\n                    <ul class=\"subnav\" style=\"background: #fff; position: absolute; display: none;\">\r\n                        <li style=\"display: block; float: none; line-height: 22px; overflow: hidden; height: 22px;\">\r\n                            <a href=\"#\" style=\"display: block; text-align: center;\">家政</a></li>\r\n                        <li style=\"display: block; float: none; line-height: 22px; overflow: hidden; height: 22px;\">\r\n                            <a href=\"#\" style=\"display: block; text-align: center;\">建站</a></li>\r\n                        <li style=\"display: block; float: none; line-height: 22px; overflow: hidden; height: 22px;\">\r\n                            <a href=\"#\" style=\"display: block; text-align: center;\">金融</a></li>\r\n                        <li style=\"display: block; float: none; line-height: 22px; overflow: hidden; height: 24px;\">\r\n                            <a href=\"#\" style=\"display: block; text-align: center; border-bottom: 1px solid #F00;\">\r\n                                礼品</a></li>\r\n                    </ul>\r\n                </li>\r\n                <li><a href=\"");
	templateBuilder.Append(linkurl("prize"));

	templateBuilder.Append("\" class=\"a_class\">最新活动</a></li>\r\n                <li><a href=\"");
	templateBuilder.Append(linkurl("about"));

	templateBuilder.Append("\" class=\"a_class\">帮助中心</a></li>\r\n            </ul>\r\n        </div>\r\n        <!--菜单 end-->\r\n        <!--入驻 start-->\r\n        <div class=\"top_right\">\r\n            <div class=\"top_right_top\">\r\n                ");
	DTcms.Model.users __user = GetUserInfo();

	if (__user!=null)
	{

	templateBuilder.Append("\r\n                欢迎您&nbsp;&nbsp;");
	templateBuilder.Append(Utils.ObjectToStr(__user.user_name));
	templateBuilder.Append("&nbsp;&nbsp;&nbsp;&nbsp; <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","order"));

	templateBuilder.Append("\">我的订单</a></span>&nbsp;|\r\n                <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","order"));

	templateBuilder.Append("\">我的账户</a></span>&nbsp;| <span><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">\r\n                        退出 </a></span>\r\n                ");
	}
	else
	{

	templateBuilder.Append("\r\n                <span><a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a></span>&nbsp;| <span><a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">\r\n                    注册 </a></span>\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n                | <span><a\r\n                    href=\"javascript:;\" onclick=\"open_shopping()\">购物车</a></span>&nbsp;\r\n            </div>\r\n        </div>\r\n        <div class=\"top_right_b\">\r\n            <div style=\"padding-left: 65px; line-height: 45px;\">\r\n                <input type=\"text\" class=\"input_class\" id=\"top_txt_sel\" /><a href=\"javascript:;\" onclick=\"top_search()\" class=\"search_a\"><img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/search2.jpg\" height=\"28\" width=\"28\" title=\"search\" /></a> \r\n                <span class=\"span_search_1\"><a href=\"");
	templateBuilder.Append(linkurl("iph"));

	templateBuilder.Append("\" style=\"color: White; text-decoration: none;\">手机订购</a></span> \r\n                <span class=\"span_search_2\">\r\n                            <style type=\"text/css\">\r\n                              .Industry_a{height:30px;overflow: hidden;width: 100px;float: left;}\r\n                                ul, li{margin: 0;padding: 0;list-style-type: none; } \r\n                                #in span {float: left;}\r\n                            </style>\r\n                            <div class=\"Industry_a\">\r\n                            ");
	DataTable list = get_article_list("hezuomingqi", 10, "");

	templateBuilder.Append("\r\n             \r\n                                <ul id=\"in\">\r\n                                 ");
	int listdr1__loop__id=0;
	foreach(DataRow listdr1 in list.Rows)
	{
		listdr1__loop__id++;


	templateBuilder.Append("\r\n                                    <li class=\"wuzi_text\" style=\"line-height: 30px;\"><a href=\"#\"><span style=\" color:White;\">" + Utils.ObjectToStr(listdr1["abbreviation"]) + "入驻</span></a></li>\r\n                                    ");
	}	//end for if

	templateBuilder.Append("\r\n                                </ul>\r\n                            </div>\r\n                        </span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!--入驻 end-->\r\n</div>\r\n<!--<script language=\"javascript\" type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n        $('.top_menu li').each(function () {\r\n            $(this).hover(\r\n 			function () {\r\n 			    $(this).children('ul.subnav').slideDown('fast');\r\n 			},\r\n 			function () {\r\n 			    $(this).children('ul.subnav').slideUp('fast');\r\n 			}\r\n 		);\r\n        })\r\n    });\r\n</");
	templateBuilder.Append("script>-->\r\n<script type=\"text/javascript\" language=\"javascript\">\r\n\r\n    setObjScroll(\"in\", 30, 20, 1500);\r\n    </");
	templateBuilder.Append("script>\r\n");


	templateBuilder.Append("\r\n    <!--顶部 end-->\r\n<!--三步导购 开始-->\r\n<div class=\"Guide\">\r\n      <div class=\"guidestep\">\r\n	        <ul>\r\n			    <li><a href=\"#\" class=\"on\" style=\" cursor:default;\"><i>1</i>选大类</a></li>\r\n				<li><span></span></li>\r\n			    <li><a href=\"#\" style=\" cursor:default;\"><i>2</i>选小类</a></li>\r\n				<li><span></span></li>\r\n			    <li><a href=\"#\" style=\" cursor:default;\"><i>3</i>选属性</a></li>\r\n				<div class=\"clear\"></div>\r\n			</ul>		\r\n	  </div>\r\n	  <div class=\"guidenr\">\r\n      ");
	DataTable category_list_tit = get_category_child_list("goods", 0);

	string str_son = "";;

	int cdr2_tit__loop__id=0;
	foreach(DataRow cdr2_tit in category_list_tit.Rows)
	{
		cdr2_tit__loop__id++;

 
	                str_son="";
	                DataTable dt_cdr_son=get_category_child_list("goods", Convert.ToInt32(cdr2_tit["id"]));
	                foreach(DataRow dr in dt_cdr_son.Rows)
	                {
	                str_son+=dr["title"].ToString()+"、";
	                }
	                if(!string.IsNullOrEmpty(str_son))
	                {
	                str_son=str_son.Substring(0,str_son.Length-1);
	                }
	
	                

	templateBuilder.Append("\r\n	       <dl style=\" position:relative;\" >\r\n		       <dt style=\"display:none;\" class=\"dis_none\">");
	templateBuilder.Append(Utils.DropHTML(str_son,75));

	templateBuilder.Append("\"都在这里！\"</dt>\r\n              \r\n			   <dd style=\" position:absolute; top:108px; left:0;\"><a href=\"");
	templateBuilder.Append(linkurl("good_category_list",Convert.ToInt32(cdr2_tit["id"])));

	templateBuilder.Append("\"><img src=\"" + Utils.ObjectToStr(cdr2_tit["img_url"]) + "\" width=\"163\" height=\"165\" border=\"0\" alt=\"\"></a>\r\n               <span style=\"position: absolute;top: 200px;left: 54px;\">" + Utils.ObjectToStr(cdr2_tit["title"]) + "</span>\r\n               </dd>\r\n		   </dl>\r\n           ");
	}	//end for if

	templateBuilder.Append("\r\n		   \r\n		   <div class=\"clear\"></div>\r\n	  </div>\r\n\r\n</div>\r\n<!--三步导购 结束-->\r\n\r\n<!--Footer-->\r\n    ");

	templateBuilder.Append("<div class=\"Procure_bottom\" style=\"text-align: center;\">\r\nCopyright © 2014 福州企力办公用品有限公司 闽ICP备14017195号-1\r\n  <div class=\"Procure_bottom_1\" style=\" display:none;\"><a id=\"open_close\" href=\"javascript:;\" ></a></div>\r\n  <div class=\"Procure_bottom_2\"> \r\n    <!--二级菜单1 start-->\r\n    <ul id=\"ul_1\" class=\"Procure_bottom_2_ul\" style=\"display:block\">\r\n      <li class=\"Procure_bottom_li\"  style=\"margin-left:0\"> <a href=\"Procurement_list.html\"> <img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n    </ul>\r\n    <!--二级菜单1 end--> \r\n    <!--二级菜单2 start-->\r\n    <ul id=\"ul_2\" class=\"Procure_bottom_2_ul\" style=\"display:none\">\r\n      <li class=\"Procure_bottom_li\"  style=\"margin-left:0\"> <a href=\"Procurement_list.html\"> <img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n    </ul>\r\n    <!--二级菜单2 end--> \r\n    <!--二级菜单3 start-->\r\n    <ul id=\"ul_3\" class=\"Procure_bottom_2_ul\" style=\"display:none\">\r\n      <li class=\"Procure_bottom_li\"  style=\"margin-left:0\"> <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n    </ul>\r\n    <!--二级菜单3 end--> \r\n    <!--二级菜单4 start-->\r\n    <ul id=\"ul_4\" class=\"Procure_bottom_2_ul\" style=\"display:none\">\r\n      <li class=\"Procure_bottom_li\"  style=\"margin-left:0\"> <a href=\"Procurement_list.html\"> <img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n    </ul>\r\n    <!--二级菜单4 end--> \r\n    <!--二级菜单5 start-->\r\n    <ul id=\"ul_5\" class=\"Procure_bottom_2_ul\" style=\"display:none\">\r\n      <li class=\"Procure_bottom_li\"  style=\"margin-left:0\"> <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li class=\"Procure_bottom_li\" > <a href=\"Procurement_list.html\"> <img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n    </ul>\r\n    <!--二级菜单5 end--> \r\n  </div>\r\n  <!--二级菜单 end--> \r\n  <!--一级菜单 start-->\r\n  <div class=\"Procure_bottom_3\">\r\n    <ul>\r\n      <li id=\"li_1\" class=\"Procure_bottom_li\" style=\"margin-left:0; \"> <a href=\"javascript:;\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li id=\"li_2\" class=\"Procure_bottom_li\"> <a href=\"javascript:;\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li id=\"li_3\" class=\"Procure_bottom_li\"><a href=\"javascript:;\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li id=\"li_4\" class=\"Procure_bottom_li\"> <a href=\"javascript:;\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n      <li id=\"li_5\" class=\"Procure_bottom_li\"> <a href=\"javascript:;\"><img src=\"images/house.jpg\" /> 办公文具</a> </li>\r\n    </ul>\r\n  </div>\r\n  <!--一级菜单 end--> \r\n</div>\r\n<!-------------------公共部分-------------------------------------------------------------------------------------------------------->\r\n    <!--覆盖页 start-->\r\n    <div class=\"black_overlay\">\r\n    </div>\r\n    <!--覆盖页 end-->\r\n    <!--弹出框 start-->\r\n    <div class=\"all\">\r\n        <!-----------下订单流程------------------->\r\n        <!--购物车列表-->\r\n    ");

	templateBuilder.Append("<!--购物车start-->\r\n        <div class=\"shopping_car\">\r\n            <!--购物车顶部 start-->\r\n            <div class=\"ruretop_all\">\r\n                <div class=\"ruretop\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_caring.jpg\" width=\"93\" height=\"33\" style=\"margin-left: 0\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/gray.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/sure_order_gray.jpg\" width=\"104\" height=\"34\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/gray.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/pay.jpg\" width=\"104\" height=\"34\" />\r\n                </div>\r\n                <div class=\"ruretop_close\" onclick=\"close_shopping()\">\r\n                </div>\r\n            </div>\r\n            <!---------------------------------------------------------------------------购物车顶部 end-->\r\n            <div class=\"shopping_car_center\">\r\n                <div class=\"shopping_car_main\">\r\n                    <div class=\"shopping_car_main_title\">\r\n                    ");
	if (__user==null)
	{

	templateBuilder.Append("\r\n                        温馨提示：<span style=\"color: #f03\">登录</span>可享受更多优惠\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n                        </div>\r\n                    <div class=\"shopping_car_main_table\">\r\n                        <div class=\"shopping_car_main_table_top\">\r\n                            <ul>\r\n                                <li>\r\n                                    <input type=\"checkbox\" class=\"shopping_car_select\"  onchange=\"ck_all(this,'ck_car')\"  name=\"all_select\" id=\"all_select\"  />\r\n                                    全选</li>\r\n                                <li style=\"width: 376px\">商品</li>\r\n                                <li>单价</li>\r\n                                <li>类型</li>\r\n                                <li style=\"width: 155px\">数量</li>\r\n                                <li>小计</li>\r\n                                <li>重量</li>\r\n                                <li style=\"width: 104px\">操作</li>\r\n                            </ul>\r\n                        </div>\r\n                        <div class=\"shopping_car_main_table_main\">\r\n                            <ul id=\"car_list\">\r\n\r\n                            </ul>\r\n                        </div>\r\n                        <div class=\"shopping_car_main_table_top \">\r\n                            <ul>\r\n                                <li style=\"border-right: none; width: 72px\">\r\n                                    <input type=\"checkbox\" class=\"shopping_car_select\" onchange=\"ck_all(this,'ck_car')\" name=\"all_select\" />\r\n                                    全选</li>\r\n                                <li style=\"width: 748px; color: #f03; text-align: left\">\r\n                                <a href=\"javascript:;\" onclick=\"del_car_ck('ck_car')\" style=\"color: #f03;\">\r\n                                    删除所选商品</a></li>\r\n                                <li style=\"width: 177px; background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/weight_sum.jpg) no-repeat left top;\">\r\n                                    <div class=\"weight_sum\" id=\"div_weight\">\r\n                                        </div>\r\n                                </li>\r\n                            </ul>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"shopping_car_activity\">\r\n                        <ul>\r\n                            <li style=\"margin-left: 0;\"><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_car_activity.jpg\" width=\"247\" height=\"114\" />\r\n                            </a></li>\r\n                            <li><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_car_activity.jpg\" width=\"247\" height=\"114\" />\r\n                            </a></li>\r\n                            <li><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_car_activity.jpg\" width=\"247\" height=\"114\" />\r\n                            </a></li>\r\n                            <li><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_car_activity.jpg\" width=\"247\" height=\"114\" />\r\n                            </a></li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!--购物车 底部 start-->\r\n            <div class=\"rurebottom\">\r\n                <div class=\"rurebottom_main\">\r\n                    <a href=\"javascript:;\" onclick=\"close_shopping()\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/continue_shopping.jpg') no-repeat;\">\r\n                    </a><a href=\"javascript:;\" onclick=\"shopping_to_address()\" style=\"float: right; background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/accounts.jpg') no-repeat;\">\r\n                    </a>\r\n                    <div class=\"rurebottom_main_price\">\r\n                        &nbsp;<span style=\"font-size: 20px; color: #f03\" id=\"span_money\">总计：￥</span></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!--购物车 底部 end-->");


	templateBuilder.Append("\r\n    <!--/购物车列表-->\r\n        <!--购物车 end-->\r\n        <!--------------------------------------------------------------------------填写订单地址 start-->\r\n       <!--选择地址-->\r\n    ");

	templateBuilder.Append(" <div class=\"Address_information\">\r\n            <!--填写订单地址 顶部 start-->\r\n            <div class=\"ruretop_all\">\r\n                <div class=\"ruretop\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_car_img.jpg\" width=\"93\" height=\"33\" style=\"margin-left: 0\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/green.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/sure_order_img.jpg\" width=\"104\" height=\"34\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/gray.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/pay.jpg\" width=\"104\" height=\"34\" />\r\n                </div>\r\n                <div class=\"ruretop_close\" onclick=\"close_shopping()\">\r\n                </div>\r\n            </div>\r\n            <!--填写订单地址 顶部 end-->\r\n            <!--填写订单地址 内容start-->\r\n            <div class=\"rurecontent\">\r\n                <dl>\r\n                    <dt>收货信息</dt>\r\n                    <dd>\r\n                        <ul>\r\n                        <!--10月13号添加内容开始-->\r\n\r\n\r\n                        <div class=\"laterplus\" id=\"div_choose_address\">\r\n<li>\r\n <span class=\"input_text\">已填地址：<span style=\"color:#F03\">*&nbsp;</span></span>\r\n<select id=\"sel_address\" name=\"sel_address\" class=\"select_connet\" onchange=\"change_address()\" style=\"width:740px;\" >\r\n                \r\n              </select>\r\n\r\n<input type=\"button\" value=\"添加地址\" onclick=\"show_add_address('div_add_address')\" style=\"height:30px;float:left;\"/>\r\n</li>\r\n</div>\r\n<!--10月13号添加内容结-->\r\n<form id=\"add_form\">\r\n<div class=\"lateradd\" id=\"div_add_address\">\r\n\r\n                            <li><span class=\"input_text\">收货人<span style=\"color: #F03\">*&nbsp;</span></span>\r\n                                <input class=\"sure_order_input\" type=\"text\" value=\"\" id=\"car_consignee\" name=\"car_consignee\" />\r\n                                <span class=\"input_text\">手机号码<span style=\"color: #F03\">*&nbsp;</span></span>\r\n                                <input class=\"sure_order_input\" type=\"text\" value=\"\" id=\"car_consignee_mobile\" name=\"car_consignee_mobile\" />\r\n                            </li>\r\n                            <li><span class=\"input_text\">所在地区<span style=\"color: #F03\">*&nbsp;</span></span>\r\n                                \r\n\r\n                                <select class=\"select_connet\" id=\"car_province\" name=\"car_province\" onchange=\"province_change('car_province','car_city')\">\r\n                                <option value=\"\">-请选择-</option>\r\n                                ");
	DataTable dt_province1 = get_province();

	int dr_province1__loop__id=0;
	foreach(DataRow dr_province1 in dt_province1.Rows)
	{
		dr_province1__loop__id++;


	templateBuilder.Append("\r\n									<option value=\"" + Utils.ObjectToStr(dr_province1["ProvinceID"]) + "\">" + Utils.ObjectToStr(dr_province1["ProvinceName"]) + "</option>\r\n                                    ");
	}	//end for if

	templateBuilder.Append("\r\n								</select>\r\n								<select class=\"select_connet\" id=\"car_city\" name=\"car_city\" onchange=\"city_change('car_city','car_district')\">\r\n									<option value=\"\">-请选择-</option>\r\n								</select>\r\n								<select class=\"select_connet\" id=\"car_district\" name=\"car_district\">\r\n									<option value=\"\">-请选择-</option>\r\n								</select> \r\n                                <span class=\"input_text\">详细地址<span style=\"color: #F03\">*&nbsp;</span></span>\r\n                                <input class=\"sure_order_input\" type=\"text\" value=\"\" id=\"car_address\" name=\"car_address\" style=\"width: 360px\" />\r\n                            </li>\r\n                            <li>\r\n                                <span class=\"input_text\">或固定电话</span>\r\n                                <input class=\"sure_order_input\" type=\"text\" id=\"car_zip_phone\" name=\"car_zip_phone\" value=\"\" style=\"width: 79px;\r\n                                    margin-right: 0\" />\r\n                                <span style=\"float: left; margin: auto 10px\">- </span>\r\n                                <input class=\"sure_order_input\" type=\"text\" id=\"car_phone\" name=\"car_phone\" value=\"\" />\r\n                                <input type=\"button\" value=\"保存地址\" onclick=\"car_add_address()\" style=\"height:30px;float:left;\" id=\"address_btn\"/>\r\n                            </li>\r\n                            </div>\r\n                            </form>\r\n                        </ul>\r\n                    </dd>\r\n                </dl>\r\n                <dl style=\"border: 1px solid #C5C5C5;margin-top: 10px;\"><li><span class=\"input_text\">配送方式<span style=\"color: #F03\">*&nbsp;</span></span>\r\n                ");
	DataTable list2 = get_express_list(0, "is_lock=0");

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n      ");
	int dr2__loop__id=0;
	foreach(DataRow dr2 in list2.Rows)
	{
		dr2__loop__id++;


	templateBuilder.Append("\r\n        \r\n        <label style=\" float:left\"><input type=\"radio\" name=\"rd_freight\" value=\"" + Utils.ObjectToStr(dr2["id"]) + "\" onclick=\"sum_freight('" + Utils.ObjectToStr(dr2["id"]) + "','" + Utils.ObjectToStr(dr2["express_fee"]) + "')\" />" + Utils.ObjectToStr(dr2["title"]) + "\r\n        \r\n        <em>费用：" + Utils.ObjectToStr(dr2["express_fee"]) + "元</em></label> \r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n               <input type=\"hidden\" id=\"hd_freight\" name=\"hd_freight\" value=\"0\" /> \r\n               <input type=\"hidden\" id=\"hd_address\" name=\"hd_address\" value=\"0\" />\r\n               \r\n                 \r\n               <input type=\"hidden\" id=\"hd_amount\"   value=\"0.00\" />\r\n\r\n                                <div class=\"input_text_right\" style=\"margin-left: 30px;\">\r\n                                    您所在的区域订<span style=\"color: #F03\">199元</span>单满可免费送货，这是您的选择</div>\r\n                            </li></dl>\r\n                <dl style=\"margin-top: 10px;\">\r\n                    <dt>商品信息</dt>\r\n                   <!--10月13号修改开始-->\r\n        <dd style=\"height:250px;overflow-y:scroll;overflow-x:hidden;\">\r\n<!--10月13号修改结束-->\r\n                        <ul>\r\n                        <!--10月13号添加开始-->\r\n<div class=\"shopping_car_main_table\">\r\n          <div class=\"shopping_car_main_table_top\">\r\n            <ul class=\"first\">\r\n              <li style=\"width:376px\">商品</li>\r\n              <li>单价</li>\r\n              <li>类型</li>\r\n              <li>数量</li>\r\n              <li>小计</li>\r\n              <li>重量</li>\r\n            </ul>\r\n          </div>\r\n          <div class=\"shopping_car_main_table_main\">\r\n            <ul class=\"first\" id=\"car_address_list\">\r\n            \r\n            </ul>\r\n            \r\n          </div>\r\n        </div>\r\n\r\n<!--10月13号添加结束-->\r\n                        </ul>\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n            <!--填写订单地址 内容end-->\r\n            <!--填写订单地址 底部 start-->\r\n            <div class=\"rurebottom\">\r\n                <div class=\"rurebottom_main\">\r\n                    <a href=\"javascript:;\" onclick=\"close_shopping()\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/continue_shopping.jpg') no-repeat;\">\r\n                    </a><a href=\"javascript:;\" onclick=\"Receipt_to_surepay()\" style=\"float: right; background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/accounts.jpg') no-repeat;\">\r\n                    </a>\r\n                    <div class=\"rurebottom_main_price\">\r\n                        配送运费：<span style=\"color: #f03; margin-right: 23px\" id=\"span_freight\">￥0.00</span>&nbsp;<span style=\"font-size: 20px;\r\n                            color: #f03\" id=\"span_address_price\">总计：￥0.00</span></div>\r\n                </div>\r\n            </div>\r\n            <!--填写订单地址 底部 end-->\r\n        </div>");


	templateBuilder.Append("\r\n    <!--/选择地址-->\r\n        <!--填写订单地址 end-->\r\n        <!--填写发票 start-->\r\n       ");

	templateBuilder.Append(" <div class=\"Receipt_information\">\r\n            <!--填写发票顶部 start-->\r\n            <div class=\"ruretop_all\">\r\n                <div class=\"ruretop\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_car_img.jpg\" width=\"93\" height=\"33\" style=\"margin-left: 0\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/green.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/sure_order_img.jpg\" width=\"104\" height=\"34\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/gray.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/pay.jpg\" width=\"104\" height=\"34\" />\r\n                </div>\r\n                <div class=\"ruretop_close\" onclick=\"close_shopping()\">\r\n                </div>\r\n            </div>\r\n            <!--填写发票 顶部 end-->\r\n            <!--填写发票 内容start-->\r\n            <div class=\"rurecontent\">\r\n                <dl>\r\n                    <dt>随货单据\r\n                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                        <label>\r\n                            清单+收据</label>\r\n                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                        <label>\r\n                            清单+发票</label>\r\n                    </dt>\r\n                    <dd style=\"height: 512px\">\r\n                        <ul class=\"sure_order3_ul\">\r\n                            <li>\r\n                                <div class=\"sure_order3_content_left\">\r\n                                    发票抬头</div>\r\n                                <div class=\"sure_order_content_right\">\r\n                                    <p>\r\n                                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                                        <label>\r\n                                            个人</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" />\r\n                                    </p>\r\n                                    <p>\r\n                                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                                        <label>\r\n                                            单位</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" style=\"width: 583px;\" />\r\n                                    </p>\r\n                                </div>\r\n                            </li>\r\n                            <li>\r\n                                <div class=\"sure_order3_content_left\">\r\n                                    发票内容</div>\r\n                                <div class=\"sure_order_content_right\">\r\n                                    <p>\r\n                                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                                        <label>\r\n                                            办公用品</label>\r\n                                    </p>\r\n                                    <p>\r\n                                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                                        <label>\r\n                                            其他</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" />\r\n                                    </p>\r\n                                </div>\r\n                            </li>\r\n                            <li style=\"border-bottom: none; height: 69px\">\r\n                                <div class=\"sure_order3_content_left\">\r\n                                    发票类型</div>\r\n                                <div class=\"sure_order_content_right\">\r\n                                    <p>\r\n                                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                                        <label>\r\n                                            增值税发票</label>\r\n                                    </p>\r\n                                    <p>\r\n                                        <input name=\"sex\" type=\"radio\" class=\"input\" value=\"male\" />\r\n                                        <label>\r\n                                            普通发票</label>\r\n                                    </p>\r\n                                </div>\r\n                            </li>\r\n                            <li style=\"border-bottom: none; padding: 0; height: 188px\">\r\n                                <div class=\"sure_order3_content_left\" style=\"height: 188px\">\r\n                                    开票信息</div>\r\n                                <div class=\"sure_order_content_right last\">\r\n                                    <p>\r\n                                        <label>\r\n                                            增值纳税人识别号</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" />\r\n                                    </p>\r\n                                    <p>\r\n                                        <label>\r\n                                            增值纳税人识别号</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" />\r\n                                    </p>\r\n                                    <p>\r\n                                        <label>\r\n                                            增值纳税人识别号</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" />\r\n                                    </p>\r\n                                    <p>\r\n                                        <label>\r\n                                            增值纳税人识别号</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" />\r\n                                    </p>\r\n                                    <p>\r\n                                        <label>\r\n                                            增值纳税人识别号</label>\r\n                                        <input type=\"text\" value=\"\" class=\"sure_order3_input\" />\r\n                                    </p>\r\n                                </div>\r\n                            </li>\r\n                        </ul>\r\n                    </dd>\r\n                </dl>\r\n\r\n            </div>\r\n            <!--填写发票 内容end-->\r\n            <!--填写发票 底部 start-->\r\n            <div class=\"rurebottom\">\r\n                <div class=\"rurebottom_main\">\r\n                    <a href=\"javascript:;\" onclick=\"close_shopping()\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/continue_shopping.jpg') no-repeat;\">\r\n                    </a><a href=\"javascript:;\" onclick=\"Receipt_to_surepay()\" style=\"float: right; background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/accounts.jpg') no-repeat;\">\r\n                    </a>\r\n                    <div class=\"rurebottom_main_price\">\r\n                        配送运费：<span style=\"color: #f03; margin-right: 23px\">￥84.00</span>&nbsp;<span style=\"font-size: 20px;\r\n                            color: #f03\">总计：￥333.00</span></div>\r\n                </div>\r\n            </div>\r\n            <!--填写发票 底部 end-->\r\n        </div>");


	templateBuilder.Append("\r\n        <!--填写发票 end-->\r\n        <!--确认付款  start-->\r\n       ");

	templateBuilder.Append(" <form id=\"form_pay\">\r\n <div class=\"sure_pay\">\r\n            <!--确认付款 顶部 start-->\r\n            <div class=\"ruretop_all\">\r\n                <div class=\"ruretop\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/shopping_car_img.jpg\" width=\"93\" height=\"33\" style=\"margin-left: 0\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/green.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/sure_pay_green.jpg\" width=\"104\" height=\"34\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/green.jpg\" width=\"281\" height=\"6\" style=\"padding-top: 15px\" />\r\n                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/sure_pay_rec.jpg\" width=\"104\" height=\"34\" />\r\n                </div>\r\n                <div class=\"ruretop_close\" onclick=\"close_shopping()\">\r\n                </div>\r\n            </div>\r\n            <!--确认付款  顶部 end-->\r\n            <!--确认付款  内容start-->\r\n            <div class=\"sure_pay_center\">\r\n                <div class=\"sure_pay_main\">\r\n                    <div class=\"sure_pay_main_top\">\r\n                        您的订单已确认, <span style=\"margin-left: 26px\">订单号：<span style=\"color: #000054\" id=\"span_orderno\"></span></span><span\r\n                            style=\"margin-left: 38px\">应付金额：<span style=\"font-size: 22px; color: #000054\" id=\"span_paymoney\"></span>RMB</span></div>\r\n                    <div class=\"sure_pay_main_main\">\r\n                        <dl>\r\n                            <dt>请选择支付方式</dt>\r\n                             ");
	DTcms.Model.users shopping_user = GetUserInfo();

	                            if (shopping_user!=null && shopping_user.user_type==1 && shopping_user.parent_id>0){
	                            

	templateBuilder.Append("\r\n                            <dd style=\"height: 59px;\">\r\n                                <div class=\"sure_pay_main_left\">\r\n                                    <input type=\"radio\" name=\"pay_type\" class=\"sure_pay_main_left_radiobutton\" value=\"is_up\">\r\n                                    上报\r\n                                </div>\r\n                                <div class=\"sure_pay_main_right\">\r\n                                   \r\n                                    <p>\r\n                                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/exclamatory.gif\" width=\"13\" height=\"13\" />（您的当前余额为：<font name=\"f_money\"></font>元）</p>\r\n                                </div>\r\n                            </dd>\r\n                            ");
	                            }else if (shopping_user!=null && shopping_user.user_type==2){
	                            

	templateBuilder.Append(" \r\n                             <dd style=\"height: 59px; display:none;\">\r\n                                <div class=\"sure_pay_main_left\">\r\n                                    <input type=\"radio\" name=\"pay_type\" class=\"sure_pay_main_left_radiobutton\" value=\"month\">\r\n                                    月底结算\r\n                                </div>\r\n                                <div class=\"sure_pay_main_right\">\r\n                                    <p>\r\n                                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/exclamatory.gif\" width=\"13\" height=\"13\" />（您的当前余额为：<font name=\"f_money\"></font>元）</p>\r\n                                </div>\r\n                            </dd>\r\n                            ");
	                            }
	                            

	templateBuilder.Append("\r\n\r\n                            <dd style=\" height:264px;\">\r\n                                <div class=\"sure_pay_main_left\">\r\n                                    <input type=\"radio\" name=\"pay_type\" class=\"sure_pay_main_left_radiobutton\" value=\"payno\">\r\n                                    支付\r\n                                </div>\r\n                                <div class=\"sure_pay_main_right\">\r\n                                    <p>\r\n                                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/exclamatory.gif\" width=\"13\" height=\"13\" />（您的当前余额为：<font name=\"f_money\"></font>元）</p>\r\n                                    <div class=\"pay_ways\">\r\n                                        <p>\r\n                                            请选择支付方式支付</p>\r\n                                        <ul style=\"margin-bottom: 0\">\r\n                                        ");
	DataTable dt_pay = get_payment_list(0, "is_lock=0");

	templateBuilder.Append(" <!--取得一个DataTable-->\r\n                                          ");
	int dr_pay__loop__id=0;
	foreach(DataRow dr_pay in dt_pay.Rows)
	{
		dr_pay__loop__id++;


	decimal poundage_amount = get_payment_poundage_amount(Utils.StrToInt(Utils.ObjectToStr(dr_pay["id"]), 0));

	templateBuilder.Append("\r\n                                            <li style=\"margin-left: 0\">\r\n                                                <input type=\"radio\" name=\"payment\" class=\"pay_ways_radiobutton\" value=\"" + Utils.ObjectToStr(dr_pay["id"]) + "\">\r\n                                                <img src=\"" + Utils.ObjectToStr(dr_pay["img_url"]) + "\" title=\"" + Utils.ObjectToStr(dr_pay["title"]) + "\" width=\"119\" height=\"37\" />\r\n                                            </li>\r\n                                            ");
	}	//end for if

	templateBuilder.Append("\r\n                                        </ul>\r\n                                       \r\n                                    </div>\r\n                                </div>\r\n                            </dd>\r\n                        </dl>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!--确认付款 内容end-->\r\n            <!--确认付款 底部 start-->\r\n            <div class=\"rurebottom\">\r\n                <div class=\"rurebottom_main\">\r\n                     <a href=\"javascript:;\" onclick=\"finish_pay()\" style=\"float: right; background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/accounts.jpg') no-repeat; margin-top: -52px; \">\r\n                    </a>\r\n                </div>\r\n            </div>\r\n            <!--确认付款  底部 end-->\r\n        </div>\r\n        <input type=\"hidden\" id=\"hd_orderid\" value=\"\" />\r\n        </form>");


	templateBuilder.Append("\r\n        <!--确认付款  end-->\r\n        <!--活动页 start-->\r\n       ");

	templateBuilder.Append(" <div class=\"activity\">\r\n            <div class=\"activity_top\">\r\n                <div class=\"activity_top_left\">\r\n                    <a href=\"javascript:;\" class=\"selected_activity\">运行中的活动</a> <a href=\"javascript:;\">活动预告</a>\r\n                </div>\r\n                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/close_detail.jpg\" onclick=\"close_shopping()\" width=\"14\" height=\"17\" /></div>\r\n            <div class=\"activity_main\">\r\n                <div class=\"activity_main_center\">\r\n                    <ul>\r\n                        <li>\r\n                            <div class=\"activity_main_center_left\">\r\n                                <div class=\"activity_topic\">\r\n                                    2月买赠专场</div>\r\n                                <div class=\"activity_deputy_topic\">\r\n                                    <p>\r\n                                        上百种商品有买有赠送不停</p>\r\n                                    <p>\r\n                                        02月10号-02月15号</p>\r\n                                </div>\r\n                                <div class=\"activity_time\">\r\n                                    剩余&nbsp;<span>2</span>&nbsp;小时&nbsp;<span>3</span>&nbsp;分钟&nbsp;<span>45</span>&nbsp;秒&nbsp;</div>\r\n                            </div>\r\n                            <div class=\"activity_main_center_right\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/activity_right.jpg\" width=\"610\" height=\"218\" /></div>\r\n                            <span class=\"activity_span\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/juedui.jpg\" width=\"64\" height=\"64\" /></span> </li>\r\n                        <li>\r\n                            <div class=\"activity_main_center_left\">\r\n                                <div class=\"activity_topic\">\r\n                                    2月买赠专场</div>\r\n                                <div class=\"activity_deputy_topic\">\r\n                                    <p>\r\n                                        上百种商品有买有赠送不停</p>\r\n                                    <p>\r\n                                        02月10号-02月15号</p>\r\n                                </div>\r\n                                <div class=\"activity_time\">\r\n                                    剩余&nbsp;<span>2</span>&nbsp;小时&nbsp;<span>3</span>&nbsp;分钟&nbsp;<span>45</span>&nbsp;秒&nbsp;</div>\r\n                            </div>\r\n                            <div class=\"activity_main_center_right\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/activity_right.jpg\" width=\"610\" height=\"218\" /></div>\r\n                            <span class=\"activity_span\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/juedui.jpg\" width=\"64\" height=\"64\" /></span> </li>\r\n                        <li style=\"margin-bottom: 0\">\r\n                            <div class=\"activity_main_center_left\">\r\n                                <div class=\"activity_topic\">\r\n                                    2月买赠专场</div>\r\n                                <div class=\"activity_deputy_topic\">\r\n                                    <p>\r\n                                        上百种商品有买有赠送不停</p>\r\n                                    <p>\r\n                                        02月10号-02月15号</p>\r\n                                </div>\r\n                                <div class=\"activity_time\">\r\n                                    剩余&nbsp;<span>2</span>&nbsp;小时&nbsp;<span>3</span>&nbsp;分钟&nbsp;<span>45</span>&nbsp;秒&nbsp;</div>\r\n                            </div>\r\n                            <div class=\"activity_main_center_right\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/activity_right.jpg\" width=\"610\" height=\"218\" /></div>\r\n                            <span class=\"activity_span\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/juedui.jpg\" width=\"64\" height=\"64\" /></span> </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>");


	templateBuilder.Append("\r\n        <!--活动页 end -->\r\n        <!------------------------------------------------------------商品详情，搭配，活动，商品搜索------------------>\r\n        <!--商品详情 start-->\r\n       ");

	templateBuilder.Append(" <div class=\"Product_detail\">\r\n            <!--商品详情 顶部 start-->\r\n            <div class=\"Product_detail_top\">\r\n                <img onclick=\"close_shopping()\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/close_detail.jpg\" width=\"14\" height=\"17\"></div>\r\n            <!--商品详情 顶部 end-->\r\n            <!--商品详情 内容 start-->\r\n            <div class=\"Product_detail_main\">\r\n                <div class=\"Product_detail_main_left\">\r\n                    <ul id=\"ul_picture\"> \r\n\r\n                    </ul>\r\n                </div>\r\n                <div class=\"Product_detail_main_bigimg\" id=\"div_big_img\" style=\" text-align:center;\">\r\n                    <img id=\"img_big\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/load.gif\" width=\"472\" height=\"472\"/></div>\r\n                <div class=\"Product_detail_main_right\">\r\n                    <div class=\"Product_detail_main_title\" id=\"div_title\">\r\n                        </div>\r\n                    <div class=\"Product_detail_main_price\">\r\n                        <div class=\"Product_detail_main_price_left\">\r\n                            <p>\r\n                                原价：<span id=\"span_sell\">￥</span></p>\r\n                            <p style=\" display:none;\">\r\n                                原价：<del id=\"del_market\"></del></p>\r\n                        </div>\r\n                        <div class=\"Product_detail_main_price_right\" style=\" display:none;\">\r\n                            <span>春节促销</span> <a href=\"#\">活动详情</a></div>\r\n                        <div class=\"Product_detail_main_select\" id=\"div_standard\">\r\n                        </div>\r\n                        <div class=\"Product_detail_main_count\">\r\n                            <span style=\"float: left\">数量：</span>\r\n                            <div class=\"Procurement_list_li_bottom\" style=\"margin: auto; width: 80px;\">\r\n                                <img class=\"reduce_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/reduce.jpg\" width=\"14\" height=\"14\" onclick=\"change_sum('inputCount1',-1)\" />\r\n                                <input type=\"text\" id=\"inputCount1\" value=\"1\" name=\"\" />\r\n                                <input type=\"hidden\" id=\"hd_stock_quantity\" value=\"0\" />\r\n                                <img class=\"add_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/add.jpg\" width=\"14\" height=\"14\" onclick=\"change_sum('inputCount1',1)\"/></div>\r\n                        </div>\r\n                        <div class=\"Product_detail_main_explain\">\r\n                            <dl>\r\n                                <dt>选项说明：</dt>\r\n                                <dd>请认真选择您想要的规格,没有则不选</dd>\r\n                            </dl>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"sold\">\r\n                <dl>\r\n                    <dt>已售出：</dt>\r\n                    <dd id=\"dd_order_good_count\">\r\n                        0件</dd>\r\n                </dl>\r\n            </div>\r\n            <!--商品详情 内容 end-->\r\n            <!--商品详情 底部 start-->\r\n            <div class=\"Product_detail_main_bottom\">\r\n                <ul>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_product.jpg') no-repeat 21px 19px #ff572a;\r\n                        color: #fff;\">商品</a> </li>\r\n                    <li name=\"li_good_meal\"><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_collocation.jpg') no-repeat 21px 19px;\">\r\n                        搭配</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_detail.jpg') no-repeat 21px 19px;\">\r\n                        详情</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/activity.jpg') no-repeat 8px 19px;\r\n                        padding-left: 25px; width: 82px\">活动& 推荐</a> </li>\r\n                </ul>\r\n                <div class=\"Product_detail_bottom_right\">\r\n                    <div class=\"add_car\">\r\n                    <input type=\"hidden\" id=\"hd_goods\" value=\"\" />\r\n                        <a href=\"javascript:;\" onclick=\"add_car()\">放入购物车</a> \r\n                        </div>\r\n                    <div class=\"detail_collect\">\r\n                        <a href=\"#\">收藏</a><span class=\"top_tip\">1</span></div>\r\n                </div>\r\n            </div>\r\n        </div>");


	templateBuilder.Append("\r\n        <!--商品详情 底部 end-->\r\n        <!--商品详情 end-->\r\n        <!--详情页 搭配 start-->\r\n       ");

	templateBuilder.Append(" <div class=\"collocation\">\r\n            <!--详情页 搭配 顶部 start-->\r\n            <div class=\"collocation_top\">\r\n                <div class=\"collocation_top_left\">\r\n                    搭配 <span sytle=\"float:left\">COLLOCATION</span> <span style=\"float: right; line-height: 30px;\" id=\"collocation_good_name\">\r\n                        </span></div>\r\n                <div class=\"collocation_top_right\">\r\n                    <img onclick=\"close_shopping()\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/close_detail.jpg\" width=\"14\" height=\"17\" /></div>\r\n            </div>\r\n            <!--详情页 搭配 顶部 end-->\r\n            <!--详情页 搭配 内容 start-->\r\n            <div class=\"collocation_main\">\r\n                <div class=\"Popular_collocation\" id=\"div_meal_box\">\r\n                    <div class=\"Popular_collocation_top\">\r\n                        人气组合</div>\r\n                    <div class=\"Popular_collocation_main\">\r\n                        <div class=\"Popular_collocation_classes\" id=\"div_meal\">\r\n                            \r\n                            </div>\r\n                        <div class=\"Popular_collocation_detail\">\r\n                        <div style=\" width:100px; float:left; padding-left:10px;\">\r\n                        <img src=\"\" width=\"100\" height=\"98\" name=\"img_meal\"/>\r\n                        <p name=\"p_meal_good_name\"></p>\r\n                        <div class=\"select_collocation\" name=\"div_meal_price\"></div> \r\n                        </div>\r\n                        <span></span>\r\n                        <div style=\"width: 580px;overflow-x: scroll;height: 165px; float:left;\">\r\n                            <ul id=\"ul_meal_good\">\r\n                            </ul>\r\n                            </div>\r\n                            <div class=\"Popular_collocation_detail_right\">\r\n                                <div class=\"Popular_collocation_detail_right_title\">\r\n                                    购买人气组合</div>\r\n                                <div class=\"Popular_collocation_detail_right_price\">\r\n                                    <p >\r\n                                        总价：<b id=\"b_meal_price1\"></b></p> \r\n                                </div>\r\n                                <div class=\"Popular_collocation_detail_right_bottom\">\r\n                                    <a href=\"#\">购买组合</a>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"Recommend_collocation\" id=\"div_red_box\">\r\n                    <div class=\"Popular_collocation_top\">\r\n                        推荐配件</div>\r\n                    <div class=\"Popular_collocation_main\">\r\n                        <div class=\"Popular_collocation_detail\" style=\"padding: 42px 32px 7px 8px;\">\r\n                        <div style=\" width:100px; float:left; padding-left:10px;\">\r\n                        <img src=\"\" width=\"100\" height=\"98\" name=\"img_meal\"/>\r\n                        <p name=\"p_meal_good_name\"></p>\r\n                        <div class=\"select_collocation\" name=\"div_meal_price\"></div>\r\n                        \r\n                        </div>\r\n                        <span></span>\r\n\r\n                        <div style=\"width: 580px;overflow-x: scroll;height: 165px; float:left;\">\r\n                            <ul id=\"ul_red_good\">\r\n                                \r\n                            </ul>\r\n\r\n                            </div>\r\n                            <div class=\"Popular_collocation_detail_right\">\r\n                                <div class=\"Popular_collocation_detail_right_title\" style=\"color: #000; font-weight: normal\">\r\n                                    已选择0个配件</div>\r\n                                <div class=\"Popular_collocation_detail_right_price\">\r\n                                    <p>\r\n                                        总价：<b id=\"b_red_price1\">￥</b></p> \r\n                                </div>\r\n                                <div class=\"Popular_collocation_detail_right_bottom\">\r\n                                    <a href=\"#\">立即购买</a>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!--详情页 搭配 内容 end-->\r\n            <!--详情页 搭配 底部 start-->\r\n            <div class=\"Product_detail_main_bottom\">\r\n                <ul>\r\n                    <li><a href=\"javascript:;\" style=\"background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_no.jpg) no-repeat 21px 19px;\">\r\n                        商品</a> </li>\r\n                    <li name=\"li_good_meal\"><a href=\"javascript:;\" style=\"background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/coll_yes.jpg) no-repeat 21px 19px #ff572a;\r\n                        color: #fff;\">搭配</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_detail.jpg') no-repeat 21px 19px;\">\r\n                        详情</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/activity.jpg') no-repeat 8px 19px;\r\n                        padding-left: 25px; width: 82px\">活动& 推荐</a> </li>\r\n                </ul>\r\n                <div class=\"Product_detail_bottom_right\">\r\n                    <div class=\"add_car\">\r\n                        <a href=\"javascript:;\" onclick=\"add_car()\">放入购物车</a></div>\r\n                    <div class=\"detail_collect\">\r\n                        <a href=\"#\">收藏</a><span class=\"top_tip\">1</span></div>\r\n                </div>\r\n            </div>\r\n            <!--详情页 搭配 底部 end-->\r\n        </div>");


	templateBuilder.Append("\r\n        <!--详情页 搭配 end-->\r\n        <!--详情页 内容 start-->\r\n        ");

	templateBuilder.Append(" <div class=\"good_content\">\r\n            <!--详情页 搭配 顶部 start-->\r\n            <div class=\"collocation_top\">\r\n                <div class=\"collocation_top_left\">\r\n                    详情 <span sytle=\"float:left\">CONTENT</span> <span style=\"float: right; line-height: 30px;\" id=\"collocation_good_name\">\r\n                        </span></div>\r\n                <div class=\"collocation_top_right\">\r\n                    <img onclick=\"close_shopping()\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/close_detail.jpg\" width=\"14\" height=\"17\" /></div>\r\n            </div>\r\n            <!--详情页 搭配 顶部 end-->\r\n            <!--详情页 搭配 内容 start-->\r\n            <div class=\"content_main\" id=\"div_good_content\">\r\n              \r\n            </div>\r\n            <!--详情页 搭配 内容 end-->\r\n            <!--详情页 搭配 底部 start-->\r\n            <div class=\"Product_detail_main_bottom\">\r\n                <ul>\r\n                    <li><a href=\"javascript:;\" style=\"background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_no.jpg) no-repeat 21px 19px;\">\r\n                        商品</a> </li>\r\n                    <li name=\"li_good_meal\"><a href=\"javascript:;\" style=\"background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/coll_yes.jpg) no-repeat 21px 19px;\">搭配</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_detail.jpg') no-repeat 21px 19px #ff572a; color: #fff;\">\r\n                        详情</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/activity.jpg') no-repeat 8px 19px;\r\n                        padding-left: 25px; width: 82px\">活动& 推荐</a> </li>\r\n                </ul>\r\n                <div class=\"Product_detail_bottom_right\">\r\n                    <div class=\"add_car\">\r\n                        <a href=\"javascript:;\" onclick=\"add_car()\">放入购物车</a></div>\r\n                    <div class=\"detail_collect\">\r\n                        <a href=\"#\">收藏</a><span class=\"top_tip\">1</span></div>\r\n                </div>\r\n            </div>\r\n            <!--详情页 搭配 底部 end-->\r\n        </div>");


	templateBuilder.Append("\r\n        <!--详情页 内容 end-->\r\n        <!--详情页 推荐 start-->\r\n       ");

	templateBuilder.Append(" <div class=\"recommended\">\r\n            <!--详情页 推荐 顶部 start-->\r\n            <div class=\"collocation_top\">\r\n                <div class=\"collocation_top_left\">\r\n                    活动&推荐 <span>RECOMMENDED</span> <span style=\"float: right; line-height: 30px;\">得力(deli)837\r\n                        轻便经济款通用型桌面计算器</span></div>\r\n                <div class=\"collocation_top_right\">\r\n                    <img onclick=\"close_shopping()\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/close_detail.jpg\" width=\"14\" height=\"17\" /></div>\r\n            </div>\r\n            <!--详情页 推荐 顶部 end-->\r\n            <!--详情页 推荐 内容 start-->\r\n            <div class=\"underway\">\r\n                <p>\r\n                    UnderWay</p>\r\n                <p>\r\n                    <span>正在进行</span>\r\n                    <p>\r\n            </div>\r\n            <div class=\"underway_img\">\r\n                <ul>\r\n                    <li style=\"margin-left: 0\"><a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/recommended_img.jpg\" width=\"226\" height=\"164\" /></a></li>\r\n                    <li><a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/recommended_img.jpg\" width=\"226\" height=\"164\" /></a></li>\r\n                    <li><a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/recommended_img.jpg\" width=\"226\" height=\"164\" /></a></li>\r\n                    <li><a href=\"#\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/recommended_img.jpg\" width=\"226\" height=\"164\" /></a></li>\r\n                </ul>\r\n            </div>\r\n            <div class=\"guess_favorite\">\r\n                <div class=\"guess_main\">\r\n                    <div class=\"guess_main_top\">\r\n                        猜你喜欢</div>\r\n                    <div class=\"guess_main_center\">\r\n                        <ul>\r\n                            <li style=\"margin-left: 0\"><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/guess_favorite.jpg\" width=\"133\" height=\"130\" />夏普（SHARP）EL-2135商务办公\r\n                                计算器 红色 </a><span><strong>￥99.00</strong></span>\r\n                                <div class=\"Procurement_list_li_bottom guess\">\r\n                                    <img class=\"reduce_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/reduce.jpg\" width=\"14\" height=\"14\" />\r\n                                    <input type=\"text\" id=\"inputCount\" value=\"1\" name=\"\" />\r\n                                    <img class=\"add_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/add.jpg\" width=\"14\" height=\"14\" /><a onclick=\"open_shopping()\"\r\n                                        href=\"javascript:;\" class=\"enter_shoppingcar\">进购物车</a></div>\r\n                            </li>\r\n                            <li><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/guess_favorite.jpg\" width=\"133\" height=\"130\" />夏普（SHARP）EL-2135商务办公\r\n                                计算器 红色 </a><span><strong>￥99.00</strong></span>\r\n                                <div class=\"Procurement_list_li_bottom guess\">\r\n                                    <img class=\"reduce_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/reduce.jpg\" width=\"14\" height=\"14\" />\r\n                                    <input type=\"text\" id=\"inputCount\" value=\"1\" name=\"\" />\r\n                                    <img class=\"add_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/add.jpg\" width=\"14\" height=\"14\" /><a onclick=\"open_shopping()\"\r\n                                        href=\"javascript:;\" class=\"enter_shoppingcar\">进购物车</a></div>\r\n                            </li>\r\n                            <li><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/guess_favorite.jpg\" width=\"133\" height=\"130\" />夏普（SHARP）EL-2135商务办公\r\n                                计算器 红色 </a><span><strong>￥99.00</strong></span>\r\n                                <div class=\"Procurement_list_li_bottom guess\">\r\n                                    <img class=\"reduce_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/reduce.jpg\" width=\"14\" height=\"14\" />\r\n                                    <input type=\"text\" id=\"inputCount\" value=\"1\" name=\"\" />\r\n                                    <img class=\"add_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/add.jpg\" width=\"14\" height=\"14\" /><a onclick=\"open_shopping()\"\r\n                                        href=\"javascript:;\" class=\"enter_shoppingcar\">进购物车</a></div>\r\n                            </li>\r\n                            <li><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/guess_favorite.jpg\" width=\"133\" height=\"130\" />夏普（SHARP）EL-2135商务办公\r\n                                计算器 红色 </a><span><strong>￥99.00</strong></span>\r\n                                <div class=\"Procurement_list_li_bottom guess\">\r\n                                    <img class=\"reduce_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/reduce.jpg\" width=\"14\" height=\"14\" />\r\n                                    <input type=\"text\" id=\"inputCount\" value=\"1\" name=\"\" />\r\n                                    <img class=\"add_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/add.jpg\" width=\"14\" height=\"14\" /><a onclick=\"open_shopping()\"\r\n                                        href=\"javascript:;\" class=\"enter_shoppingcar\">进购物车</a></div>\r\n                            </li>\r\n                            <li><a href=\"#\">\r\n                                <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/guess_favorite.jpg\" width=\"133\" height=\"130\" />夏普（SHARP）EL-2135商务办公\r\n                                计算器 红色 </a><span><strong>￥99.00</strong></span>\r\n                                <div class=\"Procurement_list_li_bottom guess\">\r\n                                    <img class=\"reduce_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/reduce.jpg\" width=\"14\" height=\"14\" />\r\n                                    <input type=\"text\" id=\"inputCount\" value=\"1\" name=\"\" />\r\n                                    <img class=\"add_btn\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/add.jpg\" width=\"14\" height=\"14\" /><a onclick=\"open_shopping()\"\r\n                                        href=\"javascript:;\" class=\"enter_shoppingcar\">进购物车</a></div>\r\n                            </li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!--详情页 推荐 内容 end-->\r\n            <!--详情页 推荐 底部 start-->\r\n            <div class=\"Product_detail_main_bottom\">\r\n                <ul>\r\n                    <li><a href=\"javascript:;\" style=\"background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_no.jpg) no-repeat 21px 19px;\">\r\n                        商品</a> </li>\r\n                    <li name=\"li_good_meal\"><a href=\"javascript:;\" style=\"background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_collocation.jpg) no-repeat 21px 19px;\">\r\n                        搭配</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url('");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/detail_bottom_detail.jpg') no-repeat 21px 19px;\">\r\n                        详情</a> </li>\r\n                    <li><a href=\"javascript:;\" style=\"background: url(");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/activity_yes.jpg) no-repeat 8px 19px #ff572a;\r\n                        color: #fff; padding-left: 25px; width: 82px\">活动& 推荐</a> </li>\r\n                </ul>\r\n                <div class=\"Product_detail_bottom_right\">\r\n                    <div class=\"add_car\">\r\n                        <a href=\"#\">放入购物车</a></div>\r\n                    <div class=\"detail_collect\">\r\n                        <a href=\"\">收藏</a><span class=\"top_tip\">1</span></div>\r\n                </div>\r\n            </div>\r\n            <!--详情页 推荐 底部 start-->\r\n        </div>");


	templateBuilder.Append("\r\n        <!--详情页 推荐 end-->\r\n        <!--搜索页 start-->\r\n        ");

	templateBuilder.Append("<div class=\"Search_page\">\r\n            <!--搜索页 顶部 start-->\r\n            <div class=\"collocation_top\">\r\n                <div class=\"collocation_top_right\" style=\"float: right; margin-right: 10px\">\r\n                    <img onclick=\"close_shopping()\" src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/close_detail.jpg\" width=\"14\" height=\"17\" /></div>\r\n            </div>\r\n            <!--搜索页 顶部 end-->\r\n            <!--搜索页 内容 start-->\r\n            <div class=\"search_center\">\r\n                <div class=\"search_main\">\r\n                    <p>\r\n                        <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/search_logo.jpg\" /></p>\r\n                    <div class=\"search_box\">\r\n                        <div class=\"search_box_content\">\r\n                            <input type=\"text\" id=\"search\" />\r\n                        </div>\r\n                        <button type=\"sumbit\" id=\"search_button\" onclick=\"getpagedata_search()\">\r\n                        </button>\r\n                    </div>\r\n                    <div class=\"search_menu\" style=\" display:none;\">\r\n                        <ul>\r\n                            <li>\r\n                                <input type=\"checkbox\" name=\"\" class=\"search_check\" id=\"key_content\" />\r\n                                <label>\r\n                                    桌面办公\r\n                                </label>\r\n                                <a href=\"javascript:;\"></a>\r\n                                <ul>\r\n                                    <li>\r\n                                        <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                        <label>\r\n                                            桌面办公></label>\r\n                                        <ul>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                            <li><a href=\"#\">计算机</a></li>\r\n                                        </ul>\r\n                                    </li>\r\n                                    <li>\r\n                                        <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                        <label>\r\n                                            桌面办公></label>\r\n                                    </li>\r\n                                    <li>\r\n                                        <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                        <label>\r\n                                            桌面办公></label>\r\n                                    </li>\r\n                                    <li>\r\n                                        <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                        <label>\r\n                                            桌面办公></label>\r\n                                    </li>\r\n                                    <li>\r\n                                        <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                        <label>\r\n                                            桌面办公></label>\r\n                                    </li>\r\n                                </ul>\r\n                            </li>\r\n                            <li>\r\n                                <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                <label>\r\n                                    桌面办公\r\n                                </label>\r\n                                <a href=\"javascript:;\"></a></li>\r\n                            <li>\r\n                                <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                <label>\r\n                                    桌面办公\r\n                                </label>\r\n                                <a href=\"javascript:;\"></a></li>\r\n                            <li>\r\n                                <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                <label>\r\n                                    桌面办公\r\n                                </label>\r\n                                <a href=\"javascript:;\"></a></li>\r\n                            <li>\r\n                                <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                <label>\r\n                                    桌面办公\r\n                                </label>\r\n                                <a href=\"javascript:;\"></a></li>\r\n                            <li>\r\n                                <input type=\"checkbox\" name=\"\" class=\"search_check\" />\r\n                                <label>\r\n                                    桌面办公\r\n                                </label>\r\n                                <a href=\"javascript:;\"></a></li>\r\n                        </ul>\r\n                    </div>\r\n                    <div class=\"hot_search\">\r\n                   \r\n                        热搜词：  ");
	                        string hot_search = "";
	                        hot_search = config.hot_search;
	                    if (hot_search.Contains(","))
	            {
	                for (int i = 0; i < hot_search.Split(',').Length; i++)
	                {
	                string aa=hot_search.Split(',')[i].ToString();
	                    

	templateBuilder.Append("\r\n                  <a href=\"javascript:getpagedata(");
	templateBuilder.Append(Utils.ObjectToStr(aa));
	templateBuilder.Append(", 0, 0, 1);\">");
	templateBuilder.Append(Utils.ObjectToStr(aa));
	templateBuilder.Append("</a> \r\n                     ");   }}

	templateBuilder.Append("</div>\r\n                    <div class=\"search_bottom\">\r\n                        <div class=\"search_bottom_top\">\r\n                            <ul style=\"margin-top: 0\">\r\n                                <li><a href=\"javascript:;\">计算器</a></li>\r\n                                <li><a href=\"javascript:;\">百事贴</a></li>\r\n                                <li><a href=\"javascript:;\">便签纸</a></li>\r\n                                <li><a href=\"javascript:;\">票夹</a></li>\r\n                                <li><a href=\"javascript:;\">剪刀</a></li>\r\n                            </ul>\r\n                        </div>\r\n                        <div class=\"search_bottom_main\">\r\n                            <ul>\r\n                                <li><a href=\"#\">\r\n                                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/search_bottom.jpg\" /></a></li>\r\n                                <li><a href=\"#\">\r\n                                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/search_bottom.jpg\" /></a></li>\r\n                                <li><a href=\"#\">\r\n                                    <img src=\"");
	templateBuilder.Append("/templates/ql");
	templateBuilder.Append("/images/search_bottom.jpg\" /></a></li>\r\n                            </ul>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!--搜索页 内容 end-->\r\n        </div>");


	templateBuilder.Append("\r\n        <!--搜索页 end-->\r\n    </div>\r\n    <!--弹出框 end-->");


	templateBuilder.Append("\r\n    <!--/Footer-->\r\n\r\n\r\n\r\n\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
