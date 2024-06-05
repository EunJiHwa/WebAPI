using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication2
{
    public class RequestData
    {
        public string RequestAPIData(string url) {
            string responseFromServer = string.Empty;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();

            }

            // Close the response.
            response.Close();
            return responseFromServer;
        }
    }
}