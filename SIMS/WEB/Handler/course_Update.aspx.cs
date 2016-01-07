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
    public partial class course_Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int CourseId = int.Parse(Request.QueryString["CourseId"]);
            int StudentId = int.Parse(Request.QueryString["StudentId"]);

            Maticsoft.BLL.course course_BLL = new Maticsoft.BLL.course();
            Maticsoft.Model.course course_Model = new Maticsoft.Model.course();
            Maticsoft.DAL.course course_Dal = new Maticsoft.DAL.course();
            course_Model = course_BLL.GetModel_CourseId(CourseId);
            course_Model.CourseStudentNum = course_Model.CourseStudentNum + 1;
            if (course_BLL.Update(course_Model))
            {
                Maticsoft.BLL.student_course student_course_BLL = new Maticsoft.BLL.student_course();
                Maticsoft.Model.student_course student_course_Model = new Maticsoft.Model.student_course();
                Maticsoft.DAL.student_course student_course_Dal = new Maticsoft.DAL.student_course();
                student_course_Model.CourseId = CourseId.ToString();
                student_course_Model.StudentId = StudentId.ToString();
                if (student_course_BLL.Add(student_course_Model) > 0)
                {
                    Response.Write("ok");
                }
                else
                {
                    course_Model = course_BLL.GetModel_CourseId(CourseId);
                    course_Model.CourseStudentNum = course_Model.CourseStudentNum - 1;
                    course_BLL.Update(course_Model);
                }
            }
            else {
                Response.Write("no");
            }
        }
    }
}
