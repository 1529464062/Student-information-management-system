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
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //接收form表单
            string UserName = Request.Form["UserName"];
            string UserPassword = Request.Form["UserPassword"];
            string UserFlag = Request.Form["UserFlag"];
            string Code = Request.Form["Captcha"];
            //定义返回值
            string Return_Message = "";
            //判断登录对象身份
            if (UserFlag == "0")
            {
                //根据身份查询
                Maticsoft.DAL.student_info student_info = new Maticsoft.DAL.student_info();
                if (student_info.Exists_StudentName(UserName))
                {
                    if (student_info.GetModel_StudentName(UserName).StudentPassword == UserPassword)
                    {
                        if (Session["Code"].ToString().ToUpper() == Code.ToUpper())
                        {
                            Return_Message = "OK";
                        }
                        else
                        {
                            Return_Message = "验证码错误";
                        }
                    }
                    else
                    {
                        Return_Message = "用户名密码错误";
                    }
                }
                else
                {
                    Return_Message = "用户名错误，或不存在此用户";
                }
            }
            else
            {
                if (UserFlag == "1")
                {
                    Maticsoft.DAL.admin_user admin_user = new Maticsoft.DAL.admin_user();
                    if (admin_user.Exists_UserName(UserName))
                    {
                        if (admin_user.GetModel_UserName(UserName).UserPassword == UserPassword)
                        {
                            if (Session["Code"].ToString().ToUpper() == Code.ToUpper())
                            {
                                Return_Message = "OK";
                            }
                            else
                            {
                                Return_Message = "验证码错误";
                            }
                        }
                        else
                        {
                            Return_Message = "用户名密码错误";
                        }
                    }
                    else
                    {
                        Return_Message = "用户名错误，或不存在此用户";
                    }
                }
            }
            //JObject DataJson = (JObject)JsonConvert.DeserializeObject(Data);
            //验证验证码是否输入正确
            //if(""Session["Code"]==)
            Response.ContentType = "text/plain";
            Response.Write(Return_Message);
        }
    }
}
