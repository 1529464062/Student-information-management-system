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
    public partial class StudentInfoSelect_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StudentId"] != null)
            {
                int StudentId = int.Parse(Request.QueryString["StudentId"]);
                Maticsoft.BLL.student_info student_info_BLL = new Maticsoft.BLL.student_info();
                Maticsoft.DAL.student_info student_info_DAL = new Maticsoft.DAL.student_info();
                Maticsoft.Model.student_info student_info_Model = new Maticsoft.Model.student_info();
                if (student_info_BLL.Delete_StudentId(StudentId))
                {
                    Maticsoft.BLL.student_course student_course_BLL = new Maticsoft.BLL.student_course();
                    Maticsoft.DAL.student_course student_course_DAL = new Maticsoft.DAL.student_course();
                    Maticsoft.Model.student_course student_course_Model = new Maticsoft.Model.student_course();
                    if (student_course_BLL.Exists_StudentId(StudentId))
                    {
                        if (student_course_BLL.Delete_StudentId(StudentId))
                        {
                            Response.Write("ok");
                        }
                        else
                        {
                            Response.Write("no");
                        }
                    }
                    else {
                        Response.Write("ok");
                    }
                    if (Request.QueryString["Img"] != null) {
                        string imgPath = Server.MapPath(Request.QueryString["Img"]);
                        if (System.IO.File.Exists(imgPath)) {
                            System.IO.File.Delete(imgPath);
                        }
                    }
                }
                else
                {
                    Response.Write("no");
                }
            }
        }
    }
}
