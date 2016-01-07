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
    public partial class fileUpLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["StudentPhoto"];
            string filePath = "../fileUpLoad/";
            string _fileName = Server.MapPath(filePath);
            string fileName=DateTime.Now.ToString("yyyyMMddhhmmss");
            string fileName_=file.FileName.Substring(file.FileName.LastIndexOf("."));
            file.SaveAs(_fileName + fileName + fileName_);
            Response.Write(filePath+fileName+fileName_);
        }
    }
}
