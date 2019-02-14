using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MLSWebService
{
    public partial class VirtualTour : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tour"] != null)
            {
                repeaterbind(Request.QueryString["tour"]);
            }
        }
        private void repeaterbind(string id)
        {
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dt = new DataTable();
            dt = obj.GetAllImagesByVID(id);
            if (dt.Rows.Count > 0)
            {
                rptImages.DataSource = dt;
                rptImages.DataBind();
            }
            else
            {
                
                Vtour.Visible = false;
                detailbg.InnerHtml = "no images found";
            }
        }
    }
}