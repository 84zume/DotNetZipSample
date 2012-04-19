using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ionic.Zip;
using MvcZipDownloadSample.Web.Infras;

namespace MvcZipDownloadSample.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ZipFileResult Download()
        {
            var filePathList = new List<string>{
                Server.MapPath(@"~/Content\files\ファイル１.txt"),
                Server.MapPath(@"~/Content\files\ファイル２.txt"),
                Server.MapPath(@"~/Content\files\ファイル３.txt"),
                Server.MapPath(@"~/Content\files\ファイル４.txt"),
                Server.MapPath(@"~/Content\files\ファイル５.txt"),
                Server.MapPath(@"~/Content\files\file6.txt")
            };

            var zipFileName = "ZippedFile.zip";

            using (var zipFile = new ZipFile(Encoding.GetEncoding("shift_jis")))
            {
                zipFile.AddFiles(filePathList, "");
                return new ZipFileResult(zipFile, zipFileName);
            }
        }
    }
}
