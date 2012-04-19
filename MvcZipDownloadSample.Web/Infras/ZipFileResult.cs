using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ionic.Zip;

namespace MvcZipDownloadSample.Web.Infras
{
    public class ZipFileResult:ActionResult
    {
        public ZipFile zip { get; set; }
        public string fileName { get; set; }

        public ZipFileResult(ZipFile zip, string fileName)
        {
            this.zip = zip;
            this.fileName = fileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/zip";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            zip.Save(response.OutputStream);
            response.End();
        }
    }
}