using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Net;
using System.IO;

namespace WebApplication2
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RequestData rd = new RequestData();
            string url = "http://www.kobis.or.kr/kobisopenapi/webservice/rest/boxoffice/searchDailyBoxOfficeList.xml?key=";
            string key = "104ceb526e55c7c8e5fbabb9b9c61775";
            string targetDt = DateTime.Now.ToString("yyyymmdd");

            string BoxOfficeUrl = url + key + "&targetDt=" + targetDt;

            string json = JsonConvert.SerializeObject(rd.RequestAPIData(BoxOfficeUrl));
            this.result.Text = json;
            // this.result.Text = rd.RequestAPIData(BoxOfficeUrl);


        }
    }
}