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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long id=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(long id)
	{
		ManagePhones.BLL.in_warehouse bll=new ManagePhones.BLL.in_warehouse();
		ManagePhones.Model.in_warehouse model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtgid.Text=model.gid;
		this.txtimei.Text=model.imei;
		this.txtintime.Text=model.intime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			long id=long.Parse(this.lblid.Text);
			string gid=this.txtgid.Text;
			string imei=this.txtimei.Text;
			DateTime intime=DateTime.Parse(this.txtintime.Text);


			ManagePhones.Model.in_warehouse model=new ManagePhones.Model.in_warehouse();
			model.id=id;
			model.gid=gid;
			model.imei=imei;
			model.intime=intime;

			ManagePhones.BLL.in_warehouse bll=new ManagePhones.BLL.in_warehouse();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
