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
namespace ManagePhones.Web.good
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					string gid= strid;
					ShowInfo(gid);
				}
			}
		}
		
	private void ShowInfo(string gid)
	{
		ManagePhones.BLL.good bll=new ManagePhones.BLL.good();
		ManagePhones.Model.good model=bll.GetModel(gid);
		this.lblgid.Text=model.gid;
		this.lblname.Text=model.name;

	}


    }
}
