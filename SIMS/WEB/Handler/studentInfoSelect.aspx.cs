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
    public partial class studentInfoSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int StudentId = int.Parse(Request.QueryString["StudentId"]);
            Maticsoft.BLL.student_info student_info_BLL = new Maticsoft.BLL.student_info();
            Maticsoft.DAL.student_info student_info_DAL = new Maticsoft.DAL.student_info();
            Maticsoft.Model.student_info student_info_Model = new Maticsoft.Model.student_info();
            DataTable dt = student_info_BLL.GetListByPage("StudentId=" + StudentId, "", 0, 1).Tables[0];
            string resultJson = Maticsoft.DAL.DataTableToJson.DataTableToJsonString(dt);
            Response.Write(resultJson);

        }
    }
}
