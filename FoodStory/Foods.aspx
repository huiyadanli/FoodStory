<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Foods.aspx.cs" Inherits="FoodStory.Foods"
    MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>美食物语</title>
    <link rel="Stylesheet" href="Static/CSS/bootstrap.min.css" />

    <script type="text/javascript" src="Static/JS/jquery.min.js"></script>

    <script type="text/javascript" src="Static/JS/bootstrap.min.js"></script>

    <style>
        .col-centered
        {
            float: none;
            margin: 0 auto;
        }
        body
        {
            background-color: #EEE;
        }
        .thumbnail
        {
            background-image: url("Static/Image/transp_bg.png");
        }
        .user-text
        {
            font-size: 16px;
            margin-top: 22px;
            margin-bottom: 22px;
            margin-left: 10px;
        }
    </style>
</head>
<body style="margin-top: 30px; margin-bottom: 30px;">

    <script type="text/javascript" src="Static/JS/layer.js"></script>

    <form id="form1" runat="server">
    <div class="container" role="main">
        <div class="row-fluid">
            <div class="col-md-8">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <h2 id="titleFood" runat="server" align="center">
                            拼命加载中...</h2>
                        <div class="thumbnail" style="padding-top: 20px; padding-bottom: 20px;">
                            <img id="imgFood" runat="server" src="Static/Image/loading.gif">
                        </div>
                        <div class="row-fluid">
                            <div class="col-md-3 col-centered">
                                <button id="btnFarvorite" runat="server" type="button" class="btn btn-danger btn-lg"
                                    title="喜欢" onserverclick="btnFarvorite_Click">
                                    <span class='glyphicon glyphicon-heart-empty'></span>
                                </button>
                                <button id="btnLike" runat="server" type="button" class="btn btn-primary btn-lg"
                                    title="点赞" onserverclick="btnLike_Click">
                                    <span class="glyphicon glyphicon-thumbs-up"></span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        上传者</div>
                    <div class="panel-body">
                        <div class="row-fluid">
                            <div class="col-md-4">
                                <img id="imgFace" class="img-rounded" runat="server" src="Static/Image/face_avatar_default.png">
                            </div>
                            <div class="col-md-8">
                                <p id="textNickName" class="user-text" runat="server">
                                    努力加载中的昵称..</p>
                                <p id="textEmail" class="user-text" runat="server">
                                    努力加载中的账号名..</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        美食介绍</div>
                    <div class="panel-body">
                        <div id="textFood" runat="server">
                            该用户很懒，什么都没有留下…</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
