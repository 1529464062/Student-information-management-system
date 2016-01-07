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
using Maticsoft.BLL;
using Maticsoft.DAL;
using Maticsoft.Model;
using System.Text;

namespace WEB.Handler
{
    public partial class CourseInfoManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["nowPage"]!=null)
            {
                int nowPage = int.Parse(Request.QueryString["nowPage"]);
                int startIndex = (nowPage - 1) * 10;
                int endIndex = nowPage * 10 - 1;
                Maticsoft.BLL.course course_BLL = new Maticsoft.BLL.course();
                Maticsoft.Model.course course_Model = new Maticsoft.Model.course();
                Maticsoft.DAL.course course_Dal = new Maticsoft.DAL.course();

                DataTable dt = course_BLL.GetListByPage("", "", startIndex, endIndex).Tables[0];
                StringBuilder JsonString = new StringBuilder();
                JsonString.Append("{");
                JsonString.Append("\"RecordCount\":");
                JsonString.Append("\"" + course_Dal.GetRecordCount("") + "\",");
                JsonString.Append("\"product\":");
                JsonString.Append(DataTableToJson.DataTableToJsonString(dt));
                JsonString.Append("}");

                Response.Write(JsonString);
            }
        }
    }
}
