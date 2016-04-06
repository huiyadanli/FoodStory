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
    public partial class Information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] == null)
                {
                    LayerShow.Alert(this, "请先登录", "Login.aspx");
                }
                else
                {
                    //获取当前登陆用户信息
                    UserBLL userBLL = new UserBLL();
                    User user = userBLL.QueryInfo(Session["userName"].ToString());
                    txtUID.Text = user.ID;
                    txtUsername.Text = user.Email;
                    txtNickName.Text = user.NickName;
                    ddlSex.Value = user.Sex;
                    txtPhone.Text = user.Phone;
                    txtQQ.Text = user.QQ;
                }
            }
        }

        protected void btnSubmitInfo_Click(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                UserBLL userBLL = new UserBLL();
                User user = userBLL.QueryInfo(Session["userName"].ToString());
                if (user == null)
                {
                    LayerShow.Alert(this, "请先登录", "Login.aspx");
                    return;
                }
                user.NickName = txtNickName.Text.Replace(" ","");
                if (ddlSex.Value == "保密" || ddlSex.Value == "男" || ddlSex.Value == "女")
                {
                    user.Sex = ddlSex.Value;
                }
                else
                {
                    LayerShow.Msg(this, "性别信息有误");
                    return;
                }
                user.Phone = txtPhone.Text;
                user.QQ = txtQQ.Text;

                if (userBLL.ModifyInfo(user) == true)
                {
                    LayerShow.Alert(this, "用户资料修改成功", "Information.aspx");
                }
                else
                {
                    LayerShow.Alert(this, "用户资料修改失败", "Information.aspx");
                }
            }
            else
            {
                LayerShow.Alert(this, "请先登录", "Login.aspx");
            }
        }

        protected void btnModifyPwd_Click(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                UserBLL userBLL = new UserBLL();
                User user = userBLL.QueryInfo(Session["userName"].ToString());
                if (userBLL.ModifyPwd(Session["userName"].ToString(), txtOldPwd.Text, txtNewPwdConfirm.Text))
                {
                    LayerShow.Alert(this, "密码修改成功", "Information.aspx");
                }
                else
                {
                    LayerShow.Alert(this, "密码修改失败", "Information.aspx");
                }
            }
            else
            {
                LayerShow.Alert(this, "请先登录", "Login.aspx");
            }
        }
    }
}
