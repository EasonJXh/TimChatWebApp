
function fullScreen(el) {
    var rfs = el.requestFullScreen || el.webkitRequestFullScreen || el.mozRequestFullScreen || el.msRequestFullScreen,
        wscript;
    if (typeof rfs != "undefined" && rfs) {
        rfs.call(el);
        return;
    }
    if (typeof window.ActiveXObject != "undefined") {
        wscript = new ActiveXObject("WScript.Shell");
        if (wscript) {
            wscript.SendKeys("{F11}");
        }
    }
}
function exitFullScreen(el) {
    var el = document,
        cfs = el.cancelFullScreen || el.webkitCancelFullScreen || el.mozCancelFullScreen || el.exitFullScreen,
        wscript;
    if (typeof cfs != "undefined" && cfs) {
        cfs.call(el);
        return;
    }
    if (typeof window.ActiveXObject != "undefined") {
        wscript = new ActiveXObject("WScript.Shell");
        if (wscript != null) {
            wscript.SendKeys("{F11}");
        }
    }
}

/**
 * 标准化 fullscreen 属性 （只读）
 * 以同名方法替代
 * 其值为 boolean 类型，判断当前文档的全屏状态
 */
function fullscreen() {
    return document.fullscreen ||
        document.webkitIsFullScreen ||
        document.mozFullScreen ||
        false;
}


var btn = $(".chat-close-menu-fullscreen");    //全屏觸發元素
var content = $(".chatBox");   //被全屏显示的元素

//var icoHtml = "<div class='pos-absolute-right men-scr-ico dis' style='display:none'><i class='icon-narrow'></i></div>";
//icoHtml += "<div class='line dis' style='display:none'></div>"
////icoHtml += tleSideHtml;
//content.children().first().append(icoHtml);

btn.click(function () {
    //$(".dis").css('display', 'block');
    fullScreen(content[0]);
})

var closeBtn = $(".chat-close-menu-huanyuan");    //屏幕縮小觸發元素
closeBtn.click(function () {
    //$(".dis").css('display', 'none');
    exitFullScreen();
})


/**
 * @method
 * @desc 全屏時按下F11和ESC按鍵，頁面標題全屏樣式消失
 */
/* 如果使用 jQuery ： */
$(document).bind(
    'fullscreenchange webkitfullscreenchange mozfullscreenchange',
    function () {
        var judFullScreen = fullscreen();
        if (!judFullScreen) {
           // $(".dis").css('display', 'none');
        }
    }
);

//全屏時，點擊有彈出層按鈕時先退出全屏
function clickByFullScreen() {
    //$(".dis").css('display', 'none');
    exitFullScreen();
}