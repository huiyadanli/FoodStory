using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.Security;

namespace FoodStory
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPwdConfirm.Text)
            {
                LayerShow.Msg(this, "两次输入密码不同");
                return;
            }
            //定义一个userBLL
            UserBLL userBLL = new UserBLL();
            //判断是否被注册
            if (userBLL.IsExist(txtUsername.Text.Trim()) == true)
            {
                LayerShow.Msg(this, "该邮箱已经被注册了");
            }
            else
            {
                //获取填写的学生注册信息
                User user = new User();
                user.Email = txtUsername.Text.Trim();
                user.Pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
                bool result = userBLL.Register(user);
                if (result == true)
                {
                    Session["userName"] = txtUsername.Text.Trim();
                    LayerShow.Alert(this, "注册成功,快去为自己更换一个头像吧！","Index.aspx");
                }
                else
                {
                    LayerShow.Msg(this, "注册失败");
                }
            }
        }
    }
}
