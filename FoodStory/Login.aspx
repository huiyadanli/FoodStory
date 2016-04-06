<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="FoodStory.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body
        {
            background-image: url("Static/Image/index_bg.png");
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" role="main">

        <script type="text/javascript" src="Static/JS/layer.js"></script>

        <div class="page-header">
            <h1 align="center">
                登陆美食物语</h1>
        </div>
        <form class="form-horizontal" runat="server">
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-4">
                <div class="input-group"">
                    <span class="input-group-addon" id="email-addon"><span class="glyphicon glyphicon-envelope"
                        aria-hidden="true"></span></span>
                    <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="请输入邮箱"
                        aria-describedby="email-addon"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-4">
                <div class="input-group">
                    <span class="input-group-addon" id="pwd-addon"><span class="glyphicon glyphicon-asterisk"
                        aria-hidden="true"></span></span>
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="请输入密码"
                        aria-describedby="pwd-addon" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-2">
                <div class="checkbox">
                    <label>
                        <asp:CheckBox ID="chkRember" runat="server" Checked="True" />记住用户名
                    </label>
                </div>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnLogin" runat="server" Text="登陆" class="btn btn-default btn-primary"
                    Width="100%" OnClick="btnLogin_Click" />
            </div>
        </div>
        </form>
    </div>
</asp:Content>
