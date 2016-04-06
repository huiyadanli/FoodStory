using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class User
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string NickName { get; set; }
        public string Sex { get; set; }
        public string FacePath { get; set; }
        public string Phone { get; set; }
        public string QQ { get; set; }
        public string EmailVerification { get; set; }
        public string RegTime { get; set; }

        public User()
        {
            ID = "";
            Email = "";
            Pwd = "";
            NickName = "";
            Sex = "保密";
            FacePath = "";
            Phone = "";
            QQ = "";
            EmailVerification = "未验证";
            RegTime = "";
        }
    }
}
