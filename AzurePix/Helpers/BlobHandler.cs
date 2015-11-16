﻿using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzurePix.Helpers
{
    public class BlobHandler : IStorageHandler
    {
        public List<string> GetFileNames()
        {
            throw new NotImplementedException();
        }

        public void Upload(HttpPostedFileBase file)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                                        CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("fakebook");

            // Retrieve reference to a blob.
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(file.FileName));
            // Use this for Azure hosted app
            blockBlob.UploadFromStream(file.InputStream);
        }
    }
}