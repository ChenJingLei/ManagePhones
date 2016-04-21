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
namespace ManagePhones.Web.good
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string gid= Request.Params["id"];
					ShowInfo(gid);
				}
			}
		}
			
	private void ShowInfo(string gid)
	{
		ManagePhones.BLL.good bll=new ManagePhones.BLL.good();
		ManagePhones.Model.good model=bll.GetModel(gid);
		this.lblgid.Text=model.gid;
		this.txtname.Text=model.name;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string gid=this.lblgid.Text;
			string name=this.txtname.Text;


			ManagePhones.Model.good model=new ManagePhones.Model.good();
			model.gid=gid;
			model.name=name;

			ManagePhones.BLL.good bll=new ManagePhones.BLL.good();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
