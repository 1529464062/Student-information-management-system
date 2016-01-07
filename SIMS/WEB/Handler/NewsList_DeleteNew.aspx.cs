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
    public partial class NewsList_DeleteNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id;
            if(Request.QueryString["news_Id"]!=null){
                Id=int.Parse(Request.QueryString["news_Id"]);
                Maticsoft.BLL.news news_BLL = new Maticsoft.BLL.news();
                Maticsoft.DAL.news news_DAL = new Maticsoft.DAL.news();
                Maticsoft.Model.news news_Model = new Maticsoft.Model.news();
                if (news_BLL.Delete(Id))
                {
                    Response.Write("ok");
                }
                else {
                    Response.Write("no");
                }
            }
        }
    }
}
