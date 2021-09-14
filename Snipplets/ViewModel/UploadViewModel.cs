using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snipplets.ViewModel
{
    public class UploadViewModel
    {
        public int Id { get; set; }

        public HttpPostedFileBase file { get; set; }
    }
}