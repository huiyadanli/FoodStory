using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FoodStory
{
    public class LayerShow
    {
        //Layer 弹出层辅助类
        //Page page;

        //public LayerShow(Page p)
        //{
        //    this.page = p;
        //}

        public static void Msg(Page p, string msg)
        {
            p.ClientScript.RegisterStartupScript(p.GetType(), ""
                , "<script>;!function(){layer.msg('" + msg + "');}();</script>");
        }

        public static void Alert(Page p, string msg, string url)
        {
            p.ClientScript.RegisterStartupScript(p.GetType(), ""
                , "<script>;!function(){layer.alert('"
                + msg + "', function(){window.location.href='" + url + "'});}();</script>");
        }
    }
}
