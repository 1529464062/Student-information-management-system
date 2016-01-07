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
    public partial class CourseInfoAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int CouresId=0;
            string CourseName="";
            string CourseTeacher="";
            string CourseInfo="";
            int CourseStudentSumNum=0;
            if (Request.Form["CouresId"] != null)
            {
                CouresId = int.Parse(Request.Form["CouresId"]);
            } 
            if (Request.Form["CourseName"] != null)
            {
                CourseName = Request.Form["CourseName"];
            } 
            if (Request.Form["CourseTeacher"] != null)
            {
                CourseTeacher = Request.Form["CourseTeacher"];
            } 
            if (Request.Form["CourseInfo"] != null)
            {
                CourseInfo = Request.Form["CourseInfo"];
            }
            if (Request.Form["CourseStudentSumNum"] != null)
            {
                CourseStudentSumNum = int.Parse(Request.Form["CourseStudentSumNum"]);
            }
            Maticsoft.BLL.course course_BLL = new Maticsoft.BLL.course();
            Maticsoft.Model.course course_Model = new Maticsoft.Model.course();
            Maticsoft.DAL.course course_Dal = new Maticsoft.DAL.course();

            if (CourseName != "")
            {
                if (!course_BLL.Exists_CourseId(CouresId))
                {
                    course_Model.CourseId = CouresId.ToString();
                    course_Model.CourseName = CourseName;
                    course_Model.CourseTeacher = CourseTeacher;
                    course_Model.CourseInfo = CourseInfo;
                    course_Model.CourseStudentSumNum = CourseStudentSumNum;

                    if (course_BLL.Add(course_Model) > 0)
                    {
                        Response.Write("ok");
                    }
                    else
                    {
                        Response.Write("no");
                    }
                }
                else
                {
                    Response.Write("CourseId");
                }
            }
            else {
                Response.Write("no");
            }
        }
    }
}
