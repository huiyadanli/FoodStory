<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true"
    CodeBehind="Share.aspx.cs" Inherits="FoodStory.Share" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Static/CSS/fileinput.min.css" />
    <style>
        body
        {
            background-image: url("Static/Image/index_bg.png");
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" role="main">

        <script type="text/javascript" src="Static/Extend/ckeditor/ckeditor.js"></script>

        <script type="text/javascript" src="Static/JS/layer.js"></script>

        <script type="text/javascript" src="Static/JS/fileinput.min.js"></script>

        <script type="text/javascript" src="Static/JS/fileinput_locale_zh.js"></script>

        <form id="Form1" runat="server" class="form-horizontal">
        <div class="page-header">
            <h2 align="center">
                分享美食</h2>
        </div>
        <div class="panel panel-default" style="padding-top: 25px">
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label">
                        标题</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" placeholder="你要分享的美食主题"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">
                        封面</label>
                    <div class="col-sm-6">
                        <input id="inputCover" runat="server" class="file" type="file" data-min-file-count="1">
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">
                        内容</label>
                    <div class="col-sm-8">
                        <textarea id="txtCkeditor" runat="server" class="ckeditor"></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-2">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" class="btn btn-primary" Width="100%"
                            OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
        </form>

        <script>
            $(".file").fileinput({
                //uploadUrl: '#', // you must set a valid URL here else you will get an error
                allowedFileExtensions: ['jpg', 'png', 'gif'],
                //overwriteInitial: false,
                showUpload: false,
                showCaption: false,
                removeClass: "btn btn-danger",
                browseIcon: "<i class=\"glyphicon glyphicon-picture\"></i> ",
                maxFileSize: 2000,
                maxFilesCount: 1,
                allowedFileTypes: ['image'],
                slugCallback: function(filename) {
                    return filename.replace('(', '_').replace(']', '_');
                }
            });
        </script>

    </div>
</asp:Content>
