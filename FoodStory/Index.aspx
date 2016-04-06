<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="FoodStory.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body
        {
            background-image: url("Static/Image/index_bg.png");
        }
        .item
        {
            width: 270px;
        }
        hr
        {
            margin: 5px;
        }
        .img-rounded
        {
            cursor: pointer;
        }
        .img-face
        {
            width: 30px;
            height: 30px;
        }
        .food-title
        {
            margin-top: 6px;
            margin-bottom: 6px;
        }
        .nop
        {
            padding: 0px;
        }
        p
        {
            margin: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" role="main">

        <div id="masonryDiv" class="masonry" runat="server">
        </div>

        <script type="text/javascript" src="Static/JS/jquery.masonry.min.js"></script>

        <script type="text/javascript" src="Static/JS/jquery.lazyload.min.js"></script>

        <script type="text/javascript" src="Static/JS/layer.js"></script>

        <script>
        //瀑布流、lazyload效果
        $(function() {
	        f_masonry();
	        $("img").lazyload({
		        effect:"fadeIn",
		        failurelimit:40,
		        load:f_masonry,
	        });
        });

        function f_masonry() {
	        $('.masonry').masonry({
		        gutterWidth: 20,
		        itemSelector: '.item',
		        isAnimated: true,
	        });
        }
        //鼠标悬停效果
        $('.img-rounded').hover(
          function(){
            //鼠标进入
            $(this).fadeTo(300,0.8);
          },
          function(){
            //鼠标离开
            $(this).fadeTo(300,1);
          }
        );
        
        $('.img-rounded').click(function(){
            var foodurl=$(this).parent().find("a").attr("href")
            layer.open({
                type: 2,
                title: 'Foods',
                shadeClose: true,
                shade: 0.8,
                area: ['80%', '90%'],
                content: foodurl
            }); 
        });
        
        /*$(window).scroll(function(){
             if ($(document).height() - $(this).scrollTop() - $(this).height()<100) {
               ajax_load_data();
             }
        });*/
        </script>

    </div>
</asp:Content>
