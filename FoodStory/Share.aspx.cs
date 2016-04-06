using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Text;

namespace FoodStory
{
    public partial class Share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userName"] == null)
                {
                    LayerShow.Alert(this, "请先登录", "Login.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                FoodBLL foodBLL = new FoodBLL();
                Food food = new Food();
                food.UploaderID = user.ID;
                if (txtTitle.Text.Length >= 4 && txtTitle.Text.Length <= 30)
                {
                    food.Title = txtTitle.Text;
                }
                else
                {
                    LayerShow.Msg(this, "标题的长度必须为4~30个字符");
                    return;
                }
                //简单的二次过滤（仍旧不安全），我相信ckeditor的过滤...
                food.Contents = CheckStr(txtCkeditor.Value);
                //读取POST进来的图片
                HttpPostedFile file = Request.Files[Request.Files.AllKeys[0]];
                string fileName = DateTime.Now.ToString("yyyyMMddhhmmssff") + CreateRandomCode(8);
                int pos = file.FileName.LastIndexOf(".");
                string extName = file.FileName.Substring(pos, file.FileName.Length - pos);
                string virtualPath = string.Format("~/Static/Image/Cover/cover_{0}{1}", fileName, extName);
                file.SaveAs(Server.MapPath(virtualPath));
                food.Cover = fileName + extName;

                if (foodBLL.Insert(food) == true)
                {
                    LayerShow.Alert(this, "美食分享成功", "Index.aspx");
                }
                else
                {
                    LayerShow.Alert(this, "分享出错", "Share.aspx");
                }
            }
            else
            {
                LayerShow.Alert(this, "请先登录", "Login.aspx");
            }
        }

        private static string CheckStr(string html)
        {
            html = html.Replace("script", "");
            html = html.Replace("href", "");
            html = html.Replace("iframe", "");
            html = html.Replace("frameset", "");
            html = html.Replace("<style>", "");
            html = html.Replace("<applet>", "");
            return html;
        }

        private string CreateRandomCode(int length)
        {
            string[] codes = new string[36] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            StringBuilder randomCode = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                randomCode.Append(codes[rand.Next(codes.Length)]);
            }
            return randomCode.ToString();
        }
    }
}
