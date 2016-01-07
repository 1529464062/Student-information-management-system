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
using Maticsoft.DAL;

namespace WEB.Handler
{
    public partial class View_Course_GetStudentIdList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int StudentId = -1;
            if (Request.QueryString["StudentId"] != null)
            {
                StudentId = int.Parse(Request.QueryString["StudentId"]);
            }
            int nowPage = 1;
            if (Request.QueryString["nowPage"] != null)
            {
                nowPage = int.Parse(Request.QueryString["nowPage"]);
            }
            /*
            Maticsoft.BLL.View_Course view_Course_BLL = new Maticsoft.BLL.View_Course();
            Maticsoft.Model.View_Course view_Course_Model = new Maticsoft.Model.View_Course();
            Maticsoft.DAL.View_Course view_Course_Dal = new Maticsoft.DAL.View_Course();
            if (CourseId != -1) {
                DataTableToJson.DataTableToJsonString(view_Course_BLL.GetListByPage("CourseId=" + CourseId, "", 0, 10).Tables[0]);
            }

             */
            int startIndex = (nowPage-1)*10; //int.Parse(Request.QueryString["startIndex"]);
            int endIndex = nowPage * 10 - 1; //int.Parse(Request.QueryString["endIndex"]);

            if (StudentId != -1)
            {
                Maticsoft.BLL.View_Course view_Course_BLL = new Maticsoft.BLL.View_Course();
                Maticsoft.Model.View_Course view_Course_Model = new Maticsoft.Model.View_Course();
                Maticsoft.DAL.View_Course view_Course_Dal = new Maticsoft.DAL.View_Course();

                DataTable dt = view_Course_BLL.GetListByPage("StudentId=" + StudentId, "", startIndex, endIndex).Tables[0];
                StringBuilder JsonString = new StringBuilder();
                JsonString.Append("{");
                JsonString.Append("\"RecordCount\":");
                JsonString.Append("\"" + view_Course_Dal.GetRecordCount("StudentId=" + StudentId) + "\",");
                JsonString.Append("\"product\":");
                JsonString.Append(DataTableToJson.DataTableToJsonString(dt));
                JsonString.Append("}");

                Response.Write(JsonString);
            }
        }
    }
}
