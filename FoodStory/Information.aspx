<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true"
    CodeBehind="Information.aspx.cs" Inherits="FoodStory.Information" %>

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

        <script type="text/javascript" src="Static/JS/fullAvatarEditor.js"></script>

        <script type="text/javascript" src="Static/JS/swfobject.js"></script>

        <form id="Form1" runat="server" class="form-horizontal" data-bv-message="This value is not valid"
        data-bv-feedbackicons-valid="glyphicon glyphicon-ok" data-bv-feedbackicons-invalid="glyphicon glyphicon-remove"
        data-bv-feedbackicons-validating="glyphicon glyphicon-refresh">
        <div class="page-header">
            <h2 align="center">
                账户设置</h2>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <ul id="myTab" class="nav nav-tabs" style="margin-bottom: 30px">
                    <li class="active"><a href="#modifyInfo" data-toggle="tab">修改资料</a></li>
                    <li><a href="#modifyPhoto" data-toggle="tab">修改头像</a></li>
                    <li><a href="#modifyPwd" data-toggle="tab">修改密码</a></li>
                </ul>
                <div id="myTabContent" class="tab-content">
                    <!-- 修改资料 -->
                    <div class="tab-pane fade in active" id="modifyInfo">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                UID</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtUID" runat="server" class="form-control" disabled></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                邮箱</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtUsername" runat="server" class="form-control" disabled></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                昵称</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtNickName" runat="server" class="form-control" placeholder="您的昵称（2~20个字符）"
                                    data-bv-stringlength="true" data-bv-stringlength-min="2" data-bv-stringlength-max="20"
                                    data-bv-stringlength-message="昵称只能使用2~20个字符"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                性别</label>
                            <div class="col-sm-2">
                                <select id="ddlSex" runat="server" class="form-control" style="width: 50%">
                                    <option>保密</option>
                                    <option>男</option>
                                    <option>女</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                联系方式</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="您的联系方式"
                                    data-bv-regexp="true" data-bv-regexp-regexp="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"
                                    data-bv-regexp-message="请输入正确格式的联系方式（手机/电话）"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                QQ</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtQQ" runat="server" class="form-control" placeholder="您的QQ号码"
                                    data-bv-stringlength="true" data-bv-stringlength-min="5" data-bv-stringlength-max="11"
                                    data-bv-stringlength-message="您的QQ号长度不科学" data-bv-regexp="true" data-bv-regexp-regexp="^[0-9]*$"
                                    data-bv-regexp-message="请输入正确格式的QQ号码"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-2">
                                <asp:Button ID="btnSubmitInfo" runat="server" Text="提交" class="btn btn-primary" Width="100%"
                                    OnClick="btnSubmitInfo_Click" />
                            </div>
                        </div>
                    </div>
                    <!-- 修改头像 -->
                    <div class="tab-pane fade" id="modifyPhoto">
                        <div style="width: 630px; margin: 0 auto;">
                            <div>
                                <p id="swfContainer">
                                    本组件需要安装Flash Player后才可使用，请从<a href="http://www.adobe.com/go/getflashplayer">这里</a>下载安装。
                                </p>
                            </div>
                        </div>

                        <script type="text/javascript">
                        swfobject.addDomLoadEvent(function() {
                            var swf = new fullAvatarEditor("swfContainer", {
                                id: 'swf',
                                upload_url: 'Plus/Upload.aspx',
                                src_upload: 0
                            }, function(msg) {
                                switch (msg.code) {
                                    case 3:
                                        if (msg.type == 0) {
                                            alert("摄像头已准备就绪且用户已允许使用。");
                                        }
                                        else if (msg.type == 1) {
                                            alert("摄像头已准备就绪但用户未允许使用！");
                                        }
                                        else {
                                            alert("摄像头被占用！");
                                        }
                                        break;
                                    case 5:
                                        if (msg.type == 0) {
                                            layer.alert('头像修改成功', function() { window.location.href = 'Information.aspx' });
                                        }
                                        break;
                                }
                            }
				        );
                        });
                        </script>

                    </div>
                    <!-- 修改密码 -->
                    <div class="tab-pane fade" id="modifyPwd">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                原密码</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtOldPwd" name="txtOldPwd" runat="server" class="form-control"
                                    placeholder="请输入原来的密码" TextMode="Password" data-bv-notempty="true" data-bv-notempty-message="密码不能为空"
                                    data-bv-stringlength="true" data-bv-stringlength-min="6" data-bv-stringlength-max="16"
                                    data-bv-stringlength-message="密码必须为6~16位"></asp:TextBox>
                            </div>
                        </div>
                        <!-- 新密码确认 -->
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                新密码</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtNewPwd" name="txtNewPwd" runat="server" class="form-control"
                                    placeholder="请输入新密码（6~16位）" TextMode="Password" data-bv-notempty="true" data-bv-notempty-message="密码不能为空"
                                    data-bv-stringlength="true" data-bv-stringlength-min="6" data-bv-stringlength-max="16"
                                    data-bv-stringlength-message="密码必须为6~16位"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                重复新密码</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtNewPwdConfirm" name="txtNewPwdConfirm" runat="server" class="form-control"
                                    placeholder="请确认新密码" TextMode="Password" data-bv-notempty="true" data-bv-notempty-message="确认密码不能为空"
                                    data-bv-identical="true" data-bv-identical-field="ctl00$ContentPlaceHolder1$txtNewPwd"
                                    data-bv-identical-message="第二次输入密码不同"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-2">
                                <asp:Button ID="btnModifyPwd" runat="server" Text="提交" class="btn btn-primary" Width="100%"
                                    OnClick="btnModifyPwd_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </form>

        <script>
        $(document).ready(function() {
            $('.form-horizontal').bootstrapValidator();
        });
        $("li").click(function() {
            $('.form-horizontal').data('bootstrapValidator').resetForm();
        });
        </script>

    </div>
</asp:Content>
