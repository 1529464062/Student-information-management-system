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
    public partial class CouresInfoSelect_Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string StudentId = Request.Form["StudentId"];
            string CourseId = Request.Form["CourseId"];
            string CourseScore = Request.Form["CourseScore"];
            int Id =int.Parse(Request.Form["Id"]);
            Maticsoft.BLL.student_course student_course_BLL = new Maticsoft.BLL.student_course();
            Maticsoft.DAL.student_course student_course_DAL = new Maticsoft.DAL.student_course();
            Maticsoft.Model.student_course student_course_Model = new Maticsoft.Model.student_course();

            student_course_Model.Id=Id;
            student_course_Model.StudentId=StudentId;
            student_course_Model.CourseId=CourseId;
            student_course_Model.CourseScore=Convert.ToDecimal(CourseScore);
            if (student_course_BLL.Update(student_course_Model))
            {
                Response.Write("ok");
            }
            else {
                Response.Write("no");
            }
        }
    }
}
