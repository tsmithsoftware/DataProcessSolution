using System;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using DataProcessSolution.API.Backend.Utilities;
using DataProcessSolution.SharedObjects;

namespace DataProcessSolution.API.Backend
{
    public class BlobStorageHandler
    {
        private readonly IFileHandler _fileHandler;
        private static readonly string BlobContainerName = ConfigurationManager.AppSettings["AzureContainerName"];
        public BlobStorageHandler(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }
        public CloudBlobContainer GetContainer()
        {
            CloudStorageAccount storageAccount;
            if (bool.Parse(ConfigurationManager.AppSettings["UseDevelopmentStorage"]))
            {
                storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
            }
            else
            {
                storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            }
            var blobClient = storageAccount.CreateCloudBlobClient();
            
            CloudBlobContainer container = blobClient.GetContainerReference(
                BlobContainerName
                );

            container.CreateIfNotExists();

            return container;
        }

        public List<UploadResult> UploadBlobs(params string[] locations)
        {
            List<UploadResult> results = new List<UploadResult>();
            CloudBlobContainer container = GetContainer();
            foreach (string location in locations)
            {
                FileInfo file = _fileHandler.GetFileFromString(location);
                if (file.FullName != string.Empty)
                {
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.Name);
                    blockBlob.UploadFromStream(new FileStream(file.FullName, FileMode.Open));
                    FileReference reference = new FileReference()
                    {
                        BlockId = Guid.NewGuid().ToString(),
                        ContainerName = BlobContainerName,
                        Name = file.Name
                    };
                    results.Add(new UploadResult(true,reference));
                }
            }
            return results;
        }
    }
}
