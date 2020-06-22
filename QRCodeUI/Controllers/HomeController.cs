using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRCodeUI.Models;

namespace QRCodeUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index([FromForm]QRCodeFileModel myFile)
        {
            try
            {
                var file = myFile.Image;
                // var file = Request.Form.Files[0];
                if (file != null && file.Length > 0)
                {                    
                    FileStream fs = new FileStream("d:\\download.png" , FileMode.Open, FileAccess.Read);
                    byte[] data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                    fs.Close();

                    // Generate post objects
                    Dictionary<string, object> postParameters = new Dictionary<string, object>();
                    postParameters.Add("filename", "download.png");
                    postParameters.Add("fileformat", "png");
                    postParameters.Add("file", new FormUploadModel.FileParameter(data, "download.png", "multipart/form-data"));

                    // Create request and receive response
                    string postURL = "http://api.qrserver.com/v1/read-qr-code/?file=";
                    string userAgent = "file";
                    HttpWebResponse webResponse = FormUploadModel.MultipartFormDataPost(postURL, userAgent, postParameters);

                    // Process response
                    StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                    string fullResponse = responseReader.ReadToEnd();
                    webResponse.Close();
                    // Response.Write(fullResponse);

                    // return Ok(null);

                    ViewBag.Message = fullResponse;
                }
                else
                {
                    ViewBag.Message = "You have not specified a file.";                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
