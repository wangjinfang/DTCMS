$(function () {
    var oPic = $('.slider_pic').find('ul');
    var oImg = oPic.find('li');
    var oLen = oImg.length; 
    var oLi = oImg.width(); 
    var prev = $("#prev");
    var next = $("#next");

    oPic.width(oLen * 110); //计算总长度
    var iNow = 0;
    var iTimer = null;
    prev.click(function () {
        if (iNow > 0) {
            iNow--;

        }
        ClickScroll();
    })
    next.click(function () {
        if (iNow < oLen - 3) {
            iNow++
        }
        ClickScroll();
    })

    function ClickScroll() {

        iNow == 0 ? prev.addClass('no_click') : prev.removeClass('no_click');
        iNow == oLen - 3 ? next.addClass("no_click") : next.removeClass("no_click");

        oPic.animate({ left: -iNow * 110 })
    }

})
