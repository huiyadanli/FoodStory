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
    public partial class Foods : System.Web.UI.Page
    {
        FoodBLL foodBLL = new FoodBLL();
        UserBLL userBLL = new UserBLL();
        Food food;
        User author;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"];
                food = foodBLL.Query(id);
                if (food != null)
                {
                    author = userBLL.QueryInfoByID(food.UploaderID);
                    if (author != null)
                    {
                        //查询到food和user以后构建页面
                        this.titleFood.InnerHtml = food.Title;
                        this.imgFood.Src = "Static/Image/Cover/cover_" + food.Cover;
                        this.textFood.InnerHtml = food.Contents;
                        this.imgFace.Src = "Static/Image/Face/face_avatar1_" + author.FacePath + ".jpg";
                        this.textEmail.InnerHtml = author.Email;
                        this.textNickName.InnerHtml = author.NickName;
                    }
                    else
                    {
                        LayerShow.Alert(this, "内部错误，无效的上传者ID", "Index.aspx");
                    }
                }
                else
                {
                    LayerShow.Alert(this, "无法找到该页面", "Index.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx");
            }
        }

        protected void btnFarvorite_Click(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                User user = userBLL.QueryInfo(Session["userName"].ToString());
                if (user != null)
                {
                    if (foodBLL.FarvoriteFromUser(user.ID, food.ID))
                    {
                        LayerShow.Msg(this, "收藏成功");
                    }
                    else
                    {
                        if (foodBLL.RemoveFarvorite(user.ID, food.ID))
                        {
                            LayerShow.Msg(this, "取消收藏");
                        }
                        else
                        {
                            LayerShow.Msg(this, "内部错误");
                        }
                    }
                }
                else
                {
                    LayerShow.Alert(this, "内部错误，无效的用户ID", "Index.aspx");
                }
            }
            else
            {
                LayerShow.Msg(this, "登陆才能收藏哟");
            }
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            string ip = "";
            if (Request.ServerVariables["HTTP_VIA"] != null)
            {
                ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            if (ip != "")
            {
                if (foodBLL.LikeFromAny(ip, food.ID))
                {
                    LayerShow.Msg(this, "赞+1");
                }
                else
                {
                    LayerShow.Msg(this, "一天只能赞一次");
                }
            }
            else
            {
                LayerShow.Msg(this, "IP获取失败");
            }
        }

    }
}
