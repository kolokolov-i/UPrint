using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UPrint;
using UPrint.entity;
using UPrint.logic;

namespace ClientApi
{
    /// <summary>
    /// Summary description for UprintService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class UprintService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public UPrintDataSet GetEmptyPrinters()
        {
            BusinessLogic logic = new BusinessLogic();
            logic.init();
            logic.GetEmptyPrinters();
            return logic.dataSet;
        }
    }
}
