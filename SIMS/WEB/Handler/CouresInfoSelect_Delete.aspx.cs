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
    public partial class CouresInfoSelect_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = int.Parse(Request.Form["Id"]);
            Maticsoft.BLL.student_course student_course_BLL = new Maticsoft.BLL.student_course();
            Maticsoft.DAL.student_course student_course_DAL = new Maticsoft.DAL.student_course();
            Maticsoft.Model.student_course student_course_Model = new Maticsoft.Model.student_course();
            student_course_Model = student_course_BLL.GetModel(Id);
            int CourseId = int.Parse(student_course_Model.CourseId);
            if (student_course_BLL.Delete(Id))
            {
                Maticsoft.BLL.course course_BLL = new Maticsoft.BLL.course();
                Maticsoft.DAL.course course_DAL = new Maticsoft.DAL.course();
                Maticsoft.Model.course course_Model = new Maticsoft.Model.course();
                course_Model = course_BLL.GetModel_CourseId(CourseId);
                course_Model.CourseStudentNum = course_Model.CourseStudentNum - 1;
                if (course_BLL.Update(course_Model))
                {
                    Response.Write("ok");
                }
                else {
                    Response.Write("no");
                }

                
            }
            else {
                Response.Write("no");
            }
        }
    }
}
