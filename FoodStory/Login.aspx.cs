using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace FoodStory
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["loginout"] == "true")
            {
                Session.RemoveAll();
            }
            if (IsPostBack == false)
            {
                if (Request.Cookies["FoodPrevUser"] != null)
                {
                    txtUsername.Text = Request.Cookies["FoodPrevUser"].Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 3 || txtUsername.Text.Length > 40)
            {
                LayerShow.Msg(this, "用户名长度不合法");
                return;
            }
            if (txtPassword.Text.Length < 6 || txtUsername.Text.Length > 32)
            {
                LayerShow.Msg(this, "密码长度不合法");
                return;
            }

            if (chkRember.Checked)
            {
                Response.Cookies["FoodPrevUser"].Value = txtUsername.Text;
                Response.Cookies["FoodPrevUser"].Expires = DateTime.Now.AddDays(7);
            }

            UserBLL userBLL = new UserBLL();
            if (userBLL.VerifyPwd(txtUsername.Text, txtPassword.Text))
            {
                Session["userName"] = txtUsername.Text;
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                LayerShow.Msg(this, "用户名或者密码错误");
            }
        }
    }
}
