#pragma checksum "C:\Users\Ankkit\source\repos\QRScanner1\QRScanner\Views\QRCodeScannerForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5caf1907ad966d19c45c0600a7132fa615977884"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QRCodeScannerForm), @"mvc.1.0.view", @"/Views/QRCodeScannerForm.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5caf1907ad966d19c45c0600a7132fa615977884", @"/Views/QRCodeScannerForm.cshtml")]
    public class Views_QRCodeScannerForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ankkit\source\repos\QRScanner1\QRScanner\Views\QRCodeScannerForm.cshtml"
  
    ViewData["Title"] = "QRCodeScannerForm";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>QRCodeScannerForm</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Ankkit\source\repos\QRScanner1\QRScanner\Views\QRCodeScannerForm.cshtml"
 using (Html.BeginForm("Scan", "QRCode", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Ankkit\source\repos\QRScanner1\QRScanner\Views\QRCodeScannerForm.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-horizontal\">\r\n    <h4>Upload QR Code file</h4>\r\n\r\n    <div class=\"form-group\">\r\n        \r\n        ");
#nullable restore
#line 17 "C:\Users\Ankkit\source\repos\QRScanner1\QRScanner\Views\QRCodeScannerForm.cshtml"
   Write(Html.TextBox("file", "", new { type = "file" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n        \r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" value=\"Submit\" />\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
#nullable restore
#line 28 "C:\Users\Ankkit\source\repos\QRScanner1\QRScanner\Views\QRCodeScannerForm.cshtml"

        }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591