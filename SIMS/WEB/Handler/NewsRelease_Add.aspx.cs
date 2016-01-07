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
    public partial class NewsRelease_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Title="", Author="", ReleaseTime="", Content="", RelateFile="";
            if (Request.Form["Title"] != null) {
                Title = Request.Form["Title"];
            }
            if (Request.Form["Author"] != null)
            {
                Author = Request.Form["Author"];
            }
            if (Request.Form["ReleaseTime"] != null)
            {
                ReleaseTime = Request.Form["ReleaseTime"];
            }
            if (Request.Form["Content"] != null)
            {
                Content = Request.Form["Content"];
            }
            if (Request.Form["RelateFile"] != null)
            {
                RelateFile = Request.Form["RelateFile"];
            }
            Maticsoft.BLL.news news_BLL = new Maticsoft.BLL.news();
            Maticsoft.DAL.news news_DAL = new Maticsoft.DAL.news();
            Maticsoft.Model.news news_Model = new Maticsoft.Model.news();
            news_Model.Title = Title;
            news_Model.Author = Author;
            news_Model.ReleaseTime = Convert.ToDateTime(ReleaseTime);
            news_Model.Content = Content;
            news_Model.RelateFile = RelateFile;
            if (news_BLL.Add(news_Model) > 0)
            {
                Response.Write("ok");
            }
            else {
                Response.Write("no");
            }
        }
    }
}
