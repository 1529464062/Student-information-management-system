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
    public partial class student_course_getStudentIdList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StudentId"] != null)
            {
                int StudentId = int.Parse(Request.QueryString["StudentId"]);
                Maticsoft.BLL.student_course student_course_BLL = new Maticsoft.BLL.student_course();
                Maticsoft.DAL.student_course student_course_DAL = new Maticsoft.DAL.student_course();
                Maticsoft.Model.student_course student_course_Model = new Maticsoft.Model.student_course();
                Response.Write(Maticsoft.DAL.DataTableToJson.DataTableToJsonString(student_course_BLL.GetList("StudentId=" + StudentId).Tables[0]));
            }
        }
    }
}
