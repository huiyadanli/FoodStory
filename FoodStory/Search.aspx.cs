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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["q"] != null)
            {
                string[] keywords = Request.QueryString["q"].Split(' ');
                FoodBLL foodBLL = new FoodBLL();
                UserBLL userBLL = new UserBLL();
                DataTable dt = foodBLL.Search(keywords);
                if (dt.Rows.Count == 0)
                {
                    this.masonryDiv.InnerHtml = "<h2 align=\"center\">什么都没有找到</h2>";
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    User user = userBLL.QueryInfoByID(dt.Rows[i][1].ToString());
                    string facePath = "";
                    if (user != null && user.FacePath != "")
                    {
                        facePath = "Static/Image/Face/face_avatar2_" + user.FacePath + ".jpg";
                    }
                    else
                    {
                        facePath = "Static/Image/face_avatar_default.png";
                    }
                    string foodTitle = dt.Rows[i]["Title"].ToString();
                    if (Encoding.Default.GetByteCount(foodTitle) > 18)
                    {
                        foodTitle = foodTitle.Substring(0, 17) + "…";
                    }
                    string foodUrl = "Foods.aspx?id=" + dt.Rows[i]["ID"];
                    //构造html
                    this.masonryDiv.InnerHtml += "<div class=\"item thumbnail\">"
                        + "<img class=\"img-rounded\" src=\"Static/Image/loading.gif\" data-original=\"Static/Image/Cover/cover_"
                        + dt.Rows[i]["Cover"].ToString()
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
                //Response.Redirect("Index.aspx");
            }
        }
    }
}
