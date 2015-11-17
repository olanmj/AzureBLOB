using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;
using System.IO;
using AzurePix.Helpers;

namespace AzurePix.Controllers
{
    public class HomeController : Controller
    {
        private IStorageHandler handler  = new BlobHandler();

        public ActionResult Index()
        {
            return View(handler.GetFileNames());
         //   return View(ShowBlobs());
        }
      
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            handler.Upload(file);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}