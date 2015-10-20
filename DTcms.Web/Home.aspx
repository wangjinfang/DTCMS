<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DTcms.Web.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/commonJs/jquery.SuperSlide.2.1.1.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--nav slider start-->
    <div class="indexWrap">
        <div id="nav">
            <ul class="tit">
                <asp:Literal runat="server" ID="ltNav"></asp:Literal>
                <%--<li class="mod_cate">
                    <h2><a href="#">办公文具</a></h2>
                    <p class="mod_cate_r"><a href="#">计算器</a><a href="#">文件夹</a><a href="#">文件柜</a><a href="#">推荐类目</a></p>
                    <div class="mod_subcate">
                        <div class="mod_subcate_main">
                            <div class="inBox">
                                <div class="inHd">
                                    <ul>
                                        <li>
                                            <a href="#"><span class="s-m1"></span>办公文具</a>
                                        </li>
                                        <li>
                                            <a href="#"><span class="s-m2"></span>办公文具</a>
                                        </li>
                                        <li>
                                            <a href="#"><span class="s-m3"></span>办公文具</a>
                                        </li>
                                        <li>
                                            <a href="#"><span class="s-m4"></span>办公文具</a>
                                        </li>
                                        <li>
                                            <a href="#"><span class="s-m5"></span>桌面办公</a>
                                        </li>
                                        <li>
                                            <a href="#"><span class="s-m6"></span>桌面办公</a>
                                        </li>
                                    </ul>
                                    <!--活动新闻-->
                                    <div class="mod_subcate_channel">
                                        <div class="title">最新活动</div>
                                        <div class="bd">
                                            <ul>
                                                <li>·&nbsp;<a href="#">办公用品满100送10</a></li>
                                                <li>·&nbsp;<a href="#">办公用品满100送10</a></li>

                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="inBd">
                                    <ul>
                                        <li>
                                            <div class="pic">
                                                <a href="#">
                                                    <img src="img/img-bg1.jpg" /></a>
                                            </div>
                                            <div class="title"><a href="#">计算器</a></div>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li>
                                            <div class="pic">
                                                <a href="#">
                                                    <img src="img/img-bg5.jpg" /></a>
                                            </div>
                                            <div class="title"><a href="#">计算器</a></div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <script type="text/javascript">
                                /* 内层inBox渐显切换，注意titCell、mainCell等不能与外层相同 */
                                jQuery(".inBox").slide({ titCell: ".inHd li", mainCell: ".inBd" });
                            </script>

                        </div>
                    </div>
                </li>--%>
            </ul>
        </div>
        <div class="g-index-r">
            <div class="g-slider">
                <img src="img/img-slider1.jpg" />
            </div>
            <div class="g-ad">
                <ul>
                    <li><a href="#">
                        <img src="img/img-ad1.jpg" /></a></li>
                    <li><a href="#">
                        <img src="img/img-ad2.jpg" /></a></li>
                    <li><a href="#">
                        <img src="img/img-ad3.jpg" /></a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--/nav slider end-->
    <div class="clear20"></div>
    <!--floor first start-->
    <div class="m-limited w1240">
        <ul class="ul-limit">
            <li>
                <div class="symbol">￥</div>
                <div class="money">05</div>
                <div class="info">
                    <h2>限量供应500张</h2>
                    <h3>满200可用</h3>
                    <a href="#">立即领取</a>
                </div>
            </li>
            <li>
                <div class="symbol">￥</div>
                <div class="money">10</div>
                <div class="info">
                    <h2>限量供应500张</h2>
                    <h3>满200可用</h3>
                    <a href="#">立即领取</a>
                </div>
            </li>
            <li>
                <div class="symbol">￥</div>
                <div class="money">30</div>
                <div class="info">
                    <h2>限量供应500张</h2>
                    <h3>满200可用</h3>
                    <a href="#">立即领取</a>
                </div>
            </li>
            <li>
                <div class="symbol">￥</div>
                <div class="money">50</div>
                <div class="info">
                    <h2>限量供应500张</h2>
                    <h3>满200可用</h3>
                    <a href="#">立即领取</a>
                </div>
            </li>
            <li class="last">
                <div class="symbol">￥</div>
                <div class="money">100</div>
                <div class="info">
                    <h2>限量供应500张</h2>
                    <h3>满200可用</h3>
                    <a href="#">立即领取</a>
                </div>
            </li>
        </ul>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <!--floor first start-->
    <div class="m-star w1240">
        <div class="picScroll-left">
            <div class="hd">
                <a class="next"></a>
                <a class="prev"></a>
                <h2>企力明星单品</h2>
            </div>
            <div class="bd">
                <ul class="picList">
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star1.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star2.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star3.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star4.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star2.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star3.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star1.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                    <li>
                        <div class="pic">
                            <a href="#" target="_blank">
                                <img src="img/img-star4.jpg" /></a>
                        </div>
                        <div class="title"><a href="#" target="_blank">主标题主标题主标题主标题</a></div>
                        <div class="explain"><a href="#" target="_blank">卖点卖点卖点卖点卖点卖点</a></div>
                    </li>
                </ul>
            </div>
        </div>
        <script type="text/javascript">
            jQuery(".picScroll-left").slide({ titCell: ".hd ul", mainCell: ".bd ul", autoPage: true, effect: "left", autoPlay: true, pnLoop: "false", scroll: 4, vis: 4, trigger: "click" });
        </script>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <!--floor first start-->
    <div class="w1240">
        <div class="m-sale">
            <div class="hd">限时特卖</div>
            <div class="bd">
                <ul>
                    <li>
                        <div class="sheng">
                            立省<br />
                            10.5元
                        </div>
                        <div class="title"><a href="#">得力STAR中性笔</a></div>
                        <div class="money"><a href="#">168元<del>187.9元</del></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-sale1.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="sheng">
                            立省<br />
                            10.5元
                        </div>
                        <div class="title"><a href="#">得力STAR中性笔</a></div>
                        <div class="money"><a href="#">168元<del>187.9元</del></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-sale2.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="sheng">
                            立省<br />
                            10.5元
                        </div>
                        <div class="title"><a href="#">得力STAR中性笔</a></div>
                        <div class="money"><a href="#">168元<del>187.9元</del></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-sale3.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="sheng">
                            立省<br />
                            10.5元
                        </div>
                        <div class="title"><a href="#">得力STAR中性笔</a></div>
                        <div class="money"><a href="#">168元<del>187.9元</del></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-sale4.jpg" /></a>
                        </div>
                    </li>
                </ul>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <!--floor first start-->
    <div class="w1240">
        <div class="m-worry">
            <div class="hd">省心搭配<span>帮你快速搭配采购单</span></div>
            <div class="bd">
                <ul>
                    <li>
                        <div class="title"><a href="#">财务室<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry1.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="title"><a href="#">茶水间<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry2.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="title"><a href="#">洗手间<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry3.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="title"><a href="#">档案室<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry4.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="title"><a href="#">物流间<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry5.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="title"><a href="#">会议室<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry6.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="title"><a href="#">文印室<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry7.jpg" /></a>
                        </div>
                    </li>
                    <li>
                        <div class="title"><a href="#">新员工<span>方案</span></a></div>
                        <div class="pic">
                            <a href="#">
                                <img src="img/img-worry8.jpg" /></a>
                        </div>
                    </li>
                </ul>
                <div class="clear"></div>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <!--floor first start-->
    <div class="w1240">
        <div class="m-floor">
            <div class="m-floor-l">
                <div class="hd">
                    <div class="t-right">办公文具</div>
                    <div class="t-left">1F</div>
                </div>
                <div class="clear"></div>
                <div class="bd">
                    <ul>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                    </ul>
                    <div class="clear"></div>
                    <div class="pic">
                        <a href="#">
                            <img src="img/img-floor1.jpg" /></a>
                    </div>
                </div>
            </div>
            <div class="m-floor-ad">
                <a href="#">
                    <img src="img/img-adf1.jpg" /></a>
            </div>
            <div class="m-floor-m">
                <div class="multipleColumn" id="mul-column1">
                    <div class="hd">
                        <ul></ul>
                    </div>
                    <div class="bd">
                        <div class="ulWrap">

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                        </div>
                        <!-- ulWrap End -->
                    </div>
                    <!-- bd End -->
                </div>
                <!-- multipleColumn End -->
                <script type="text/javascript">
                    /*
                        多行/多列的滚动解决思路在于：把每次滚动的n个li放到1个ul里面，然后用SuperSlide每次滚动1个ul，相当于每次滚动n个li
                    */
                    jQuery("#mul-column1").slide({ titCell: ".hd ul", mainCell: ".bd .ulWrap", autoPage: true, effect: "leftLoop", autoPlay: true, vis: 3 });
                </script>
            </div>
            <div class="m-floor-r">
                <div class="slideTxtBox" id="silder-box1">
                    <div class="hd">
                        <ul>
                            <li>点钞机</li>
                            <li>考勤机</li>
                            <li>碎石机</li>
                        </ul>
                    </div>
                    <div class="bd">
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
                <script type="text/javascript">jQuery("#silder-box1").slide();</script>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <div class="w1240">
        <div class="m-floor">
            <div class="m-floor-l">
                <div class="hd">
                    <div class="t-right">办公耗材</div>
                    <div class="t-left">2F</div>
                </div>
                <div class="clear"></div>
                <div class="bd">
                    <ul>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                    </ul>
                    <div class="clear"></div>
                    <div class="pic">
                        <a href="#">
                            <img src="img/img-floor1.jpg" /></a>
                    </div>
                </div>
            </div>
            <div class="m-floor-ad">
                <a href="#">
                    <img src="img/img-adf1.jpg" /></a>
            </div>
            <div class="m-floor-m">
                <div class="multipleColumn" id="mul-column2">
                    <div class="hd">
                        <ul></ul>
                    </div>
                    <div class="bd">
                        <div class="ulWrap">

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                        </div>
                        <!-- ulWrap End -->
                    </div>
                    <!-- bd End -->
                </div>
                <!-- multipleColumn End -->
                <script type="text/javascript">
                    /*
                        多行/多列的滚动解决思路在于：把每次滚动的n个li放到1个ul里面，然后用SuperSlide每次滚动1个ul，相当于每次滚动n个li
                    */
                    jQuery("#mul-column2").slide({ titCell: ".hd ul", mainCell: ".bd .ulWrap", autoPage: true, effect: "leftLoop", autoPlay: true, vis: 3 });
                </script>
            </div>
            <div class="m-floor-r">
                <div class="slideTxtBox" id="silder-box2">
                    <div class="hd">
                        <ul>
                            <li>点钞机</li>
                            <li>考勤机</li>
                            <li>碎石机</li>
                        </ul>
                    </div>
                    <div class="bd">
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
                <script type="text/javascript">jQuery("#silder-box2").slide();</script>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <div class="w1240">
        <div class="m-floor">
            <div class="m-floor-l">
                <div class="hd">
                    <div class="t-right">办公设备</div>
                    <div class="t-left">3F</div>
                </div>
                <div class="clear"></div>
                <div class="bd">
                    <ul>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                    </ul>
                    <div class="clear"></div>
                    <div class="pic">
                        <a href="#">
                            <img src="img/img-floor1.jpg" /></a>
                    </div>
                </div>
            </div>
            <div class="m-floor-ad">
                <a href="#">
                    <img src="img/img-adf1.jpg" /></a>
            </div>
            <div class="m-floor-m">
                <div class="multipleColumn" id="mul-column3">
                    <div class="hd">
                        <ul></ul>
                    </div>
                    <div class="bd">
                        <div class="ulWrap">

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                        </div>
                        <!-- ulWrap End -->
                    </div>
                    <!-- bd End -->
                </div>
                <!-- multipleColumn End -->
                <script type="text/javascript">
                    /*
                        多行/多列的滚动解决思路在于：把每次滚动的n个li放到1个ul里面，然后用SuperSlide每次滚动1个ul，相当于每次滚动n个li
                    */
                    jQuery("#mul-column3").slide({ titCell: ".hd ul", mainCell: ".bd .ulWrap", autoPage: true, effect: "leftLoop", autoPlay: true, vis: 3 });
                </script>
            </div>
            <div class="m-floor-r">
                <div class="slideTxtBox" id="silder-box3">
                    <div class="hd">
                        <ul>
                            <li>点钞机</li>
                            <li>考勤机</li>
                            <li>碎石机</li>
                        </ul>
                    </div>
                    <div class="bd">
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
                <script type="text/javascript">jQuery("#silder-box3").slide();</script>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <div class="w1240">
        <div class="m-floor">
            <div class="m-floor-l">
                <div class="hd">
                    <div class="t-right">办公生活</div>
                    <div class="t-left">4F</div>
                </div>
                <div class="clear"></div>
                <div class="bd">
                    <ul>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                    </ul>
                    <div class="clear"></div>
                    <div class="pic">
                        <a href="#">
                            <img src="img/img-floor1.jpg" /></a>
                    </div>
                </div>
            </div>
            <div class="m-floor-ad">
                <a href="#">
                    <img src="img/img-adf1.jpg" /></a>
            </div>
            <div class="m-floor-m">
                <div class="multipleColumn" id="mul-column4">
                    <div class="hd">
                        <ul></ul>
                    </div>
                    <div class="bd">
                        <div class="ulWrap">

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                        </div>
                        <!-- ulWrap End -->
                    </div>
                    <!-- bd End -->
                </div>
                <!-- multipleColumn End -->
                <script type="text/javascript">
                    /*
                        多行/多列的滚动解决思路在于：把每次滚动的n个li放到1个ul里面，然后用SuperSlide每次滚动1个ul，相当于每次滚动n个li
                    */
                    jQuery("#mul-column4").slide({ titCell: ".hd ul", mainCell: ".bd .ulWrap", autoPage: true, effect: "leftLoop", autoPlay: true, vis: 3 });
                </script>
            </div>
            <div class="m-floor-r">
                <div class="slideTxtBox" id="silder-box4">
                    <div class="hd">
                        <ul>
                            <li>点钞机</li>
                            <li>考勤机</li>
                            <li>碎石机</li>
                        </ul>
                    </div>
                    <div class="bd">
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
                <script type="text/javascript">jQuery("#silder-box4").slide();</script>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <div class="w1240">
        <div class="m-floor">
            <div class="m-floor-l">
                <div class="hd">
                    <div class="t-right">办公家具</div>
                    <div class="t-left">5F</div>
                </div>
                <div class="clear"></div>
                <div class="bd">
                    <ul>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                        <li><a href="#">关键词1</a></li>
                    </ul>
                    <div class="clear"></div>
                    <div class="pic">
                        <a href="#">
                            <img src="img/img-floor1.jpg" /></a>
                    </div>
                </div>
            </div>
            <div class="m-floor-ad">
                <a href="#">
                    <img src="img/img-adf1.jpg" /></a>
            </div>
            <div class="m-floor-m">
                <div class="multipleColumn" id="mul-column5">
                    <div class="hd">
                        <ul></ul>
                    </div>
                    <div class="bd">
                        <div class="ulWrap">

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                            <ul>
                                <!-- 把每次滚动的n个li放到1个ul里面 -->
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd1.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd2.jpg" /></a>
                                    </div>

                                </li>
                                <li>
                                    <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                    <div class="money"><b>￥</b>415.96</div>
                                    <div class="pic">
                                        <a href="#" target="_blank">
                                            <img src="img/img-hd3.jpg" /></a>
                                    </div>

                                </li>

                            </ul>

                        </div>
                        <!-- ulWrap End -->
                    </div>
                    <!-- bd End -->
                </div>
                <!-- multipleColumn End -->
                <script type="text/javascript">
                    /*
                        多行/多列的滚动解决思路在于：把每次滚动的n个li放到1个ul里面，然后用SuperSlide每次滚动1个ul，相当于每次滚动n个li
                    */
                    jQuery("#mul-column5").slide({ titCell: ".hd ul", mainCell: ".bd .ulWrap", autoPage: true, effect: "leftLoop", autoPlay: true, vis: 3 });
                </script>
            </div>
            <div class="m-floor-r">
                <div class="slideTxtBox" id="silder-box5">
                    <div class="hd">
                        <ul>
                            <li>点钞机</li>
                            <li>考勤机</li>
                            <li>碎石机</li>
                        </ul>
                    </div>
                    <div class="bd">
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <ul>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp2.jpg" /></a>
                                </div>
                            </li>
                            <li>
                                <div class="title"><span><a href="#">92614桌面碎石机</a></span></div>
                                <div class="money"><b>￥</b>415.96</div>
                                <div class="pic">
                                    <a href="#">
                                        <img src="img/img-cp1.jpg" /></a>
                                </div>
                            </li>
                            <div class="more"><a href="#">更多产品>></a></div>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
                <script type="text/javascript">jQuery("#silder-box5").slide();</script>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
    <!--floor first start-->
    <div class="w1240">
        <div class="m-parter">
            <div class="hd"><span>合作名企</span></div>
            <div class="bd">
                <ul>
                    <li><a href="#">
                        <img src="img/img-p1.jpg" /></a></li>
                    <li><a href="#">
                        <img src="img/img-p2.jpg" /></a></li>
                    <li><a href="#">
                        <img src="img/img-p3.jpg" /></a></li>
                    <li><a href="#">
                        <img src="img/img-p4.jpg" /></a></li>
                    <li><a href="#">
                        <img src="img/img-p5.jpg" /></a></li>
                </ul>
            </div>
        </div>
        <div class="m-company">
            <div class="hd"><span>企力百科</span></div>
            <div class="bd">
                <ul>
                    <li><a href="#" class="a-column">常识</a><a href="#" class="a-title">如何正确选择文件夹？</a></li>
                    <li><a href="#" class="a-column">常识</a><a href="#" class="a-title">如何正确选择文件夹？</a></li>
                    <li><a href="#" class="a-column">常识</a><a href="#" class="a-title">如何正确选择文件夹？</a></li>
                    <li><a href="#" class="a-column">常识</a><a href="#" class="a-title">如何正确选择文件夹？</a></li>
                    <li><a href="#" class="a-column">常识</a><a href="#" class="a-title">如何正确选择文件夹？</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--/floor first end-->
    <div class="clear20"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphBottom1" runat="server">
    <script type="text/javascript">
        $("#nav .tit").slide({
            type: "menu",
            titCell: ".mod_cate",
            targetCell: ".mod_subcate",
            delayTime: 0,
            triggerTime: 10,
            defaultPlay: false,
            returnDefault: true
        });
    </script>
     <script type="text/javascript">
                        /* 内层inBox渐显切换，注意titCell、mainCell等不能与外层相同 */
                      jQuery(".inBox").slide({ titCell: ".inHd li", mainCell: ".inBd" });
                     </script>
</asp:Content>
