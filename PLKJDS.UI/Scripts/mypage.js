/**
* 基于bootstrap3的jquery分页插件
* 调用方式分两种
* 1.直接调用法
*    普通大小
*   $.mypage(id,now,max,fn);
*    大尺寸
*   $.mypagelg(id,now,max,fn);
*    小尺寸
*   $.mypagesm(id,now,max,fn);
* 
*   参数说明：id为放置分页容器的ID，now为当前页，max为最大页，fn为回掉函数，回掉函数有一个参数为点击的页码
* 
* 2.选择器调用法
*   $(selector).mypage({
*     now:now,
*     last:last,
*     callback:fn,
*     max:max,
*     first:first,
*     style,style
*   });
*   参数说明：now为当前页，max为最大页，callback为回掉函数，回掉函数有一个参数为点击的页码，style可选参数，有"big" 和"small"，fitst为首页按钮的文本，last为尾页按钮的文本
* 
* 当最大页为1时将不显示，当当前页设置小于1时默认为1，当前页大于最大页时默认为最大页
* 引用本js前请先引用jquery的js文件和bootstrap3的css文件
* 
*/
(function ($) {
  $.fn.mypage = function(options){
    var defaults = {
      now:1,
      max:1,
      callback:null,
      style:null,
      first:"&laquo;",
      last:"&raquo;"
    }
    var options = $.extend(defaults, options);
    this.each(function(){
      options.max=Math.round(options.max);
      options.now=Math.round(options.now);
      if(options.max<=1||isNaN(options.max)||isNaN(options.now))return;
      options.now=options.now<1?1:options.now>options.max?options.max:options.now;
      var mainbox=$(this).html("");
      var page_box= $("<ul></ul>").addClass("pagination").appendTo(mainbox);
      if(options.style!=null) page_box.addClass(options.style=="big"?"pagination-lg":options.style=="small"?"pagination-sm":options.style)
      var page_back=$("<li><a href=\"javascript:void(0)\">"+options.first+"</a></li>").appendTo(page_box);
      if(options.now==1) page_back.addClass("disabled");
      else page_back.on("click",function(){if(typeof options.callback === "function")options.callback(1);})
      var page_next=$("<li><a href=\"javascript:void(0)\">"+options.last+"</a></li>");
      if(options.now==options.max) page_next.addClass("disabled");
      else page_next.on("click",function(){if(typeof options.callback === "function")options.callback(options.max);})
      var page_now=$("<li><a href=\"javascript:void(0)\">"+options.now+"</a></li>").addClass("active");
      if(options.max<=10)
        for(var i=1;i<=options.max;i++) $.mypageInsertItem(i,options.now,page_now,page_box,options.callback);
      else
        if(options.now<5){
          for(var i=1;i<=6;i++) $.mypageInsertItem(i,options.now,page_now,page_box,options.callback);
          $.mypageInsertOther(page_box);
        }else if(options.max-options.now<4){
          $.mypageInsertOther(page_box);
          for(var i=options.max-5;i<=options.max;i++) $.mypageInsertItem(i,options.now,page_now,page_box,options.callback);
        }else{
          $.mypageInsertOther(page_box);
          for(var i=options.now-2;i<=options.now+2;i++) $.mypageInsertItem(i,options.now,page_now,page_box,options.callback);
          $.mypageInsertOther(page_box);
        }
      page_next.appendTo(page_box);
    })
  },
  $.mypageInsertItem=function(i,now,page_now,page_box,fn){
    if(i!=now) $("<li><a href=\"javascript:void(0)\">"+i+"</a></li>").on("click",function(){if(typeof fn === "function")fn($(this).text());}).appendTo(page_box);
    else page_now.appendTo(page_box);
  },
  $.mypageInsertOther=function(page_box){
    $("<li><a href=\"javascript:void(0)\">…</a></li>").addClass("disabled").appendTo(page_box);
  },
  $.mypage=function(id,now,max,fn){$("#"+id).mypage({now:now,max:max,callback:fn})},
  $.mypagesm=function(id,now,max,fn){$("#"+id).mypage({now:now,max:max,callback:fn,style:"pagination-sm"})},
  $.mypagelg=function(id,now,max,fn){$("#"+id).mypage({now:now,max:max,callback:fn,style:"pagination-lg"})}
})(jQuery);
