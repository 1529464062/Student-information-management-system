using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Maticsoft.BLL.View_Course view_Course_BLL = new Maticsoft.BLL.View_Course();
            Maticsoft.Model.View_Course view_Course_Model = new Maticsoft.Model.View_Course();
            DataTable dt = new DataTable();
            dt=view_Course_BLL.GetAllList().Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
