using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace ManagePhones.Web.in_warehouse
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtgid.Text.Trim().Length==0)
			{
				strErr+="gid不能为空！\\n";	
			}
			if(this.txtimei.Text.Trim().Length==0)
			{
				strErr+="imei不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtintime.Text))
			{
				strErr+="intime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string gid=this.txtgid.Text;
			string imei=this.txtimei.Text;
			DateTime intime=DateTime.Parse(this.txtintime.Text);

			ManagePhones.Model.in_warehouse model=new ManagePhones.Model.in_warehouse();
			model.gid=gid;
			model.imei=imei;
			model.intime=intime;

			ManagePhones.BLL.in_warehouse bll=new ManagePhones.BLL.in_warehouse();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
