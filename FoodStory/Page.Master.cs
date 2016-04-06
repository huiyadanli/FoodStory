using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace FoodStory
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                UserBLL userBLL = new UserBLL();
                User user = userBLL.QueryInfo(Session["userName"].ToString());
                string facePath = "";
                if (user.FacePath != "")
                {
                    facePath = "Static/Image/Face/face_avatar2_" + user.FacePath + ".jpg";
                }
                else
                {
                    facePath = "Static/Image/face_avatar_default.png";
                }
                this.variednav.InnerHtml = "<ul class=\"nav navbar-nav navbar-right\"><li><a href=\"Index.aspx\" class=\"navbar-brand\" style=\"padding: 12px;\">"
                    + "<img src=\"" + facePath + "\" style=\"width: 25px; height: 25px; padding: 0px\"></a>"
                    + "</li><li class=\"dropdown\"><a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\"aria-haspopup=\"true\" aria-expanded=\"false\">个人中心<span class=\"caret\"></span></a>"
                    + "<ul class=\"dropdown-menu\">"
                    + "<li><a href=\"Share.aspx\">分享美食</a></li>"
                    + "<li><a href=\"Farvorites.aspx\">我的收藏</a></li>"
                    + "<li><a href=\"MyShare.aspx\">我的分享</a></li>"
                    + "<li role=\"separator\" class=\"divider\"></li>"
                    + "<li><a href=\"Information.aspx\">账户设置</a></li>"
                    + "<li><a href=\"Login.aspx?loginout=true\">退出</a></li>"
                    + "</ul></li></ul>";
            }
        }
    }
}
