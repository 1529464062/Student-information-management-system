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
    public partial class studentInfoSelectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string wherestr = "";
            if (Request.QueryString["wherestr"].Trim() != "")
            {
                wherestr = Request.QueryString["wherestr"];
            }
            if (Request.QueryString["nowPage"] != null)
            {
                int startIndex = (int.Parse(Request.QueryString["nowPage"]) - 1) * 10;
                int endIndex = int.Parse(Request.QueryString["nowPage"]) * 10 - 1;
                Maticsoft.BLL.student_info student_Info_BLL = new Maticsoft.BLL.student_info();
                Maticsoft.DAL.student_info student_Info_DAL = new Maticsoft.DAL.student_info();
                Maticsoft.Model.student_info student_Info_Model = new Maticsoft.Model.student_info();
                DataTable dt = new DataTable();
                dt = student_Info_BLL.GetListByPage(wherestr, "StudentId", startIndex, endIndex).Tables[0];
                StringBuilder JsonString = new StringBuilder();
                JsonString.Append("{");
                JsonString.Append("\"RecordCount\":");
                JsonString.Append("\"" + student_Info_DAL.GetRecordCount(wherestr) + "\",");
                JsonString.Append("\"product\":");
                JsonString.Append(DataTableToJson.DataTableToJsonString(dt));
                JsonString.Append("}");
                Response.Write(JsonString);
            }
        }
    }
}
