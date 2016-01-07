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
    public partial class studentInfoInsert_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int StudentId =int.Parse(Request.Form["StudentId"]);
            string StudentPassword = Request.Form["StudentPassword"];
            string StudentName = Request.Form["StudentName"];
            string StudentPhoto = Request.Form["StudentPhoto"];
            string StudentSex = Request.Form["StudentSex"];
            string StudentNation = Request.Form["StudentNation"];
            string StudentTelehpone = Request.Form["StudentTelehpone"];
            string StudentQQ = Request.Form["StudentQQ"];
            string StudentClass = Request.Form["StudentClass"];
            string StudentDormitory = Request.Form["StudentDormitory"];
            string StudentAddress = Request.Form["StudentAddress"];

            Maticsoft.BLL.student_info student_info_BLL = new Maticsoft.BLL.student_info();
            Maticsoft.DAL.student_info student_info_DAL = new Maticsoft.DAL.student_info();
            Maticsoft.Model.student_info student_info_Model = new Maticsoft.Model.student_info();

            if (!student_info_BLL.Exists_studentId(StudentId))
            {
                student_info_Model.StudentId = StudentId.ToString();
                student_info_Model.StudentPassword = StudentPassword;
                student_info_Model.StudentName = StudentName;
                student_info_Model.StudentPhoto = StudentPhoto;
                student_info_Model.StudentSex = StudentSex;
                student_info_Model.StudentNation = StudentNation;
                student_info_Model.StudentTelehpone = StudentTelehpone;
                student_info_Model.StudentQQ = StudentQQ;
                student_info_Model.StudentClass = StudentClass;
                student_info_Model.StudentDormitory = StudentDormitory;
                student_info_Model.StudentAddress = StudentAddress;
                if (student_info_BLL.Add(student_info_Model) > 0)
                {
                    Response.Write("ok");
                }else{
                    Response.Write("no");
                }
            }
            else {
                Response.Write("该学号已存在，请更换");
            }
        }
    }
}
