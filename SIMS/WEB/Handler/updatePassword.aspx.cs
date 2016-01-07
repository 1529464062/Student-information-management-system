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
    public partial class updatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //接收form表单
            string UserName = Request.Form["UserName"];
            string UserPassword = Request.Form["UserPassword"];
            string NewPassword = Request.Form["NewUserPassword"];
            string UserFlag = Request.Form["UserFlag"];
            //定义返回值
            string Return_Message = "";
            //根据UserFlag选择基础表

            if (int.Parse(UserFlag) == 0)
            {
                Maticsoft.DAL.student_info student_info = new Maticsoft.DAL.student_info();
                Maticsoft.BLL.student_info BLL_student_info = new Maticsoft.BLL.student_info();
                Maticsoft.Model.student_info Model_student_info = new Maticsoft.Model.student_info();
                Model_student_info = student_info.GetModel_StudentName(UserName);
                if (Model_student_info.StudentPassword == UserPassword)
                {
                    Model_student_info.StudentPassword = NewPassword;
                    if (BLL_student_info.Update(Model_student_info))
                    {
                        Return_Message = "OK";
                    }
                    else
                    {
                        Return_Message = "出现未知问题，请重新修改";
                    }
                }
                else
                {
                    Return_Message = "原密码不正确，请重新输入";
                }
            }
            else
            {
                if (int.Parse(UserFlag) == 1)
                {
                    Maticsoft.DAL.admin_user DAL_admin_user = new Maticsoft.DAL.admin_user();
                    Maticsoft.BLL.admin_user BLL_admin_user = new Maticsoft.BLL.admin_user();
                    Maticsoft.Model.admin_user Model_admin_user = new Maticsoft.Model.admin_user();
                    Model_admin_user = BLL_admin_user.GetModel_UserName(UserName);
                    if (Model_admin_user.UserPassword.Trim() == UserPassword)
                    {
                        Model_admin_user.UserPassword = NewPassword;
                        if (BLL_admin_user.Update(Model_admin_user))
                        {
                            Return_Message = "OK";
                        }
                        else
                        {
                            Return_Message = "出现未知问题，请重新修改";
                        }
                    }
                    else
                    {
                        Return_Message = "原密码不正确，请重新输入";
                    }

                }
                else
                {
                    Return_Message = "出现错误，请重新登录后修改";
                }
            }
            Response.ContentType = "text/plain";
            Response.Write(Return_Message);

        }
    }
}
