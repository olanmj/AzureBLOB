using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzurePix.Helpers
{
    public interface IStorageHandler
    {
        void Upload(HttpPostedFileBase file);
        List<string> GetFileNames();
    }
}