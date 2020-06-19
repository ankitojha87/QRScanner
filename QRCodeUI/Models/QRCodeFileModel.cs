using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCodeUI.Models
{
    public class QRCodeFileModel
    {
        public IFormFile Image { get; set; }
    }
}
