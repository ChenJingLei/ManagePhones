using System;
using ManagePhones.BLL;
using ManagePhones.Model;

namespace ManagePhonesWeb.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uname = this.username.Text;
            string pwd = this.password.Text;
            
            UsersBLL usersBll = new UsersBLL();

            if (usersBll.Login(uname, pwd))
            {
                Users users = usersBll.GetModelbyUsername(uname);
                Session["username"] = users.username;
                Response.Redirect("Mainpage.aspx");
            }
            else
            {
                Response.Write("用户名或密码错误");
            }
        }
    }
}