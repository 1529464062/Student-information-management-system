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
    public partial class NewsList_GetList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["nowPage"] != null)
            {
                int nowPage = int.Parse(Request.QueryString["nowPage"]);
                int startIndex = (nowPage - 1) * 10;
                int endIndex = nowPage * 10 - 1;
                Maticsoft.BLL.news news_BLL = new Maticsoft.BLL.news();
                Maticsoft.DAL.news news_DAL = new Maticsoft.DAL.news();
                Maticsoft.Model.news news_Model = new Maticsoft.Model.news();

                DataTable dt = new DataTable();
                dt = news_BLL.GetListByPage("", "", startIndex, endIndex).Tables[0];
                StringBuilder JsonString = new StringBuilder();
                JsonString.Append("{");
                JsonString.Append("\"RecordCount\":");
                JsonString.Append("\"" + news_DAL.GetRecordCount("") + "\",");
                JsonString.Append("\"product\":");
                JsonString.Append(DataTableToJson.DataTableToJsonString(dt));
                JsonString.Append("}");
                Response.Write(JsonString);
            }
        }
    }
}
