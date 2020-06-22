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

        // We can check file size using conditional code as well and show message to end user
        [RequestSizeLimit(1048576)]
        public  IActionResult Index([FromForm]QRCodeFileModel myFile)
        {
            try
            {
                var file = myFile.Image;
                var allowedExtensions = new[] { ".png", ".gif", ".jpeg" };
                                
                if (file != null && file.Length > 0)
                {
                    ViewBag.FileLength = "";
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var flag = false;
                    var fileExt = Path.GetExtension(fileName);
                    foreach (var itm in allowedExtensions)
                    {
                        if (itm.Contains(fileExt))
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        // To Create a file on server
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }


                        var fileFormat = fileExt.Trim('.');
                        FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                        byte[] data = new byte[fs.Length];
                        fs.Read(data, 0, data.Length);
                        fs.Close();

                        // Generate post objects
                        Dictionary<string, object> postParameters = new Dictionary<string, object>();
                        postParameters.Add("filename", fileName);
                        postParameters.Add("fileformat", fileFormat);
                        postParameters.Add("file", new FormUploadModel.FileParameter(data, fileName, "multipart/form-data"));

                        // Create request and receive response
                        string postURL = "http://api.qrserver.com/v1/read-qr-code/?file=";
                        string userAgent = "file";
                        HttpWebResponse webResponse = FormUploadModel.MultipartFormDataPost(postURL, userAgent, postParameters);

                        // Process response
                        StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                        string fullResponse = responseReader.ReadToEnd();
                        webResponse.Close();

                        ViewBag.Message = fullResponse;

                        // Delete QR file created on server
                        System.IO.File.Delete(fullPath);
                    }
                    else {
                        ViewBag.Message = "File type should be .png/.gif/.jpeg.";
                    }
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
