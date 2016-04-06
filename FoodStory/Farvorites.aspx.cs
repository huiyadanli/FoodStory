using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;
using System.Text;

namespace FoodStory
{
    public partial class Farvorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                FoodBLL foodBLL = new FoodBLL();
                UserBLL userBLL = new UserBLL();
                User userMe = userBLL.QueryInfo(Session["userName"].ToString());
                DataTable dtFarvorite = userBLL.FarvoriteTable(userMe.ID);
                for (int i = 0; i < dtFarvorite.Rows.Count; i++)
                {
                    Food food = foodBLL.Query(dtFarvorite.Rows[i]["FoodID"].ToString());

                    User user = userBLL.QueryInfoByID(food.UploaderID);
                    string facePath = "";
                    if (user != null && user.FacePath != "")
                    {
                        facePath = "Static/Image/Face/face_avatar2_" + user.FacePath + ".jpg";
                    }
                    else
                    {
                        facePath = "Static/Image/face_avatar_default.png";
                    }
                    string foodTitle = food.Title;
                    if (Encoding.Default.GetByteCount(foodTitle) > 18)
                    {
                        foodTitle = foodTitle.Substring(0, 17) + "…";
                    }
                    string foodUrl = "Foods.aspx?id=" + food.ID;
                    //构造html
                    this.masonryDiv.InnerHtml += "<div class=\"item thumbnail\">"
                        + "<img class=\"img-rounded\" src=\"Static/Image/loading.gif\" data-original=\"Static/Image/Cover/cover_"
                        + food.Cover
                        + "\" >"
                        + "<hr />"
                        + "<div class=\"container-fluid\" style=\"margin-top: 5px;\">"
                        + "<div class=\"row-fluid\" >"
                        + "<div class=\"col-md-2 nop\">" + "<img class=\"img-circle img-face\" src=\"" + facePath + "\" title=\""
                        + user.NickName + "\" >" + "</div>"
                        + "<div class=\"col-md-3 nop food-title\"><p>分享的:</p></div>"
                        + "<div class=\"col-md-7 nop food-title\"><a href=\"" + foodUrl + "\">" + foodTitle + "</a></div>"
                        + "</div></div>"
                        + "</div>\r\n";
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
    }
}
