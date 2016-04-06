<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="FoodStory.Register" %>

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

        <script type="text/javascript" src="Static/JS/bootstrapValidator.min.js"></script>

        <script type="text/javascript" src="Static/JS/layer.js"></script>

        <div class="page-header">
            <h1 align="center">
                注册美食物语</h1>
        </div>
        <form id="Form1" class="form-horizontal" runat="server" data-bv-message="This value is not valid"
        data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove"
        data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:TextBox ID="txtUsername" name="email" runat="server" class="form-control" placeholder="请输入邮箱"
                    aria-describedby="email-addon" data-bv-notempty="true" data-bv-notempty-message="邮箱地址不能为空"
                    data-bv-emailaddress="true" data-bv-emailaddress-message="无效的邮箱地址"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:TextBox ID="txtPassword" name="txtPassword" runat="server" class="form-control"
                    placeholder="请输入密码（6~16位）" TextMode="Password" data-bv-notempty="true" data-bv-notempty-message="密码不能为空"
                    data-bv-stringlength="true" data-bv-stringlength-min="6" data-bv-stringlength-max="16"
                    data-bv-stringlength-message="密码必须为6~16位"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:TextBox ID="txtPwdConfirm" name="txtPwdConfirm" runat="server" class="form-control"
                    placeholder="请确认密码" TextMode="Password" data-bv-notempty="true" data-bv-notempty-message="确认密码不能为空"
                    data-bv-identical="true" data-bv-identical-field="ctl00$ContentPlaceHolder1$txtPassword"
                    data-bv-identical-message="第二次输入密码不同"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="btnRegister" runat="server" Text="注册" class="btn btn-default btn-primary"
                    Width="100%" OnClick="btnRegister_Click" />
            </div>
        </div>
        </form>

        <script>
        $(document).ready(function() {
            $('.form-horizontal').bootstrapValidator();
        });
        </script>

    </div>
</asp:Content>
