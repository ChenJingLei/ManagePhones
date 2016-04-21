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
namespace ManagePhones.Web.in_warehouse
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
					long id=(Convert.ToInt64(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(long id)
	{
		ManagePhones.BLL.in_warehouse bll=new ManagePhones.BLL.in_warehouse();
		ManagePhones.Model.in_warehouse model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblgid.Text=model.gid;
		this.lblimei.Text=model.imei;
		this.lblintime.Text=model.intime.ToString();

	}


    }
}
