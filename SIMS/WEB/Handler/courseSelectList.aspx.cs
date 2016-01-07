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

namespace WEB.Handler
{
    public partial class courseSelectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Maticsoft.BLL.course course_BLL = new Maticsoft.BLL.course();
            Maticsoft.Model.course course_Model = new Maticsoft.Model.course();
            Maticsoft.DAL.course course_Dal = new Maticsoft.DAL.course();
            Response.Write(Maticsoft.DAL.DataTableToJson.DataTableToJsonString(course_BLL.GetAllList().Tables[0]));
        }
    }
}
