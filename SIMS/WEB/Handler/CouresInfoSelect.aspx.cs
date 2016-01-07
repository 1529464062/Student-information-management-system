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
using System.Text;

namespace WEB.Handler
{
    public partial class CouresInfoSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int CourseId=-1;
            if (Request.QueryString["CourseId"] != null)
            {
                CourseId = int.Parse(Request.QueryString["CourseId"]);
            }
            Maticsoft.BLL.course course_BLL = new Maticsoft.BLL.course();
            Maticsoft.Model.course course_Model = new Maticsoft.Model.course();
            Maticsoft.DAL.course course_Dal = new Maticsoft.DAL.course();
            if (CourseId != -1)
            {
                course_Model = course_BLL.GetModel_CourseId(CourseId);
                StringBuilder result = new StringBuilder();
                result.Append("{");

                result.Append("\"");
                result.Append("CourseId");
                result.Append("\":");
                result.Append("\"");
                result.Append(course_Model.CourseId);
                result.Append("\"");
                result.Append(",");

                result.Append("\"");
                result.Append("CourseName");
                result.Append("\":");
                result.Append("\"");
                result.Append(course_Model.CourseName);
                result.Append("\"");
                result.Append(",");

                result.Append("\"");
                result.Append("CourseTeacher");
                result.Append("\":");
                result.Append("\"");
                result.Append(course_Model.CourseTeacher);
                result.Append("\"");
                result.Append(",");

                result.Append("\"");
                result.Append("CourseInfo");
                result.Append("\":");
                result.Append("\"");
                result.Append(course_Model.CourseInfo);
                result.Append("\"");
                result.Append(",");

                result.Append("\"");
                result.Append("CourseStudentNum");
                result.Append("\":");
                result.Append("\"");
                result.Append(course_Model.CourseStudentNum);
                result.Append("\"");
                result.Append("}");

                Response.Write(result);
            }
            else {
                Response.Write("no");
            }

        }
    }
}
