using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Work_Orders
{
    public class Blob
    {
        private string connectionstring;
        private Microsoft.WindowsAzure.Storage.CloudStorageAccount AZStorageAccount;
        private Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient BlobClient;

        public enum ContainerPermissions
        {
            Private = 0,
            Public = 1,
            Limited = 2
        }

        public enum Tier
        {
            Cool = 0,
            Hot = 1,
            Archive = 2
        }

        public Blob(string Name, string Key)
        {
            connectionstring = "DefaultEndpointsProtocol=https;AccountName=" + Name + ";AccountKey=" + Key;
            AZStorageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(connectionstring);
            BlobClient = AZStorageAccount.CreateCloudBlobClient();
        }
        public string GetConnectionString()
        {
            return connectionstring;
        }

        public void CreateContainer(string ContainerName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            BlobContainer.CreateIfNotExists();
        }

        public Boolean CheckifContainerExists(string ContainerName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            return BlobContainer.Exists();
        }

        public void DeleteContainer(string ContainerName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            BlobContainer.DeleteIfExists();
        }

        public List<string> ListSubDirectory(string ContainerName, string SubDirectory)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlobDirectory = BlobContainer.GetDirectoryReference(SubDirectory);
            var ContainerList = new List<string>();
            string[] ContainerItem;
            foreach (var Item in BlobDirectory.ListBlobs())
            {
                if (Item.GetType() == typeof(Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob))
                {
                    var Blob = (Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob)Item;
                    ContainerItem = Blob.Uri.ToString().Split('/');
                    ContainerList.Add(ContainerItem[ContainerItem.Count() - 1]);
                }
            }
            return ContainerList;
        }

        public List<string> ListContainerFiles(string ContainerName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var ContainerList = new List<string>();
            string[] ContainerItem;
            foreach (var Item in BlobContainer.ListBlobs())
            {
                if (Item.GetType() == typeof(Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob))
                {
                    var Blob = (Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob)Item;
                    ContainerItem = Blob.Uri.ToString().Split('/');
                    ContainerList.Add(ContainerItem[ContainerItem.Count() - 1]);
                }
            }
            return ContainerList;
        }

        public void SetContainerPermissions(string ContainerName, ContainerPermissions Permission)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);

            switch (Permission)
            {
                case ContainerPermissions.Private:

                    BlobContainer.SetPermissions(new Microsoft.WindowsAzure.Storage.Blob.BlobContainerPermissions { PublicAccess = Microsoft.WindowsAzure.Storage.Blob.BlobContainerPublicAccessType.Off });
                    break;

                case ContainerPermissions.Public:

                    BlobContainer.SetPermissions(new Microsoft.WindowsAzure.Storage.Blob.BlobContainerPermissions { PublicAccess = Microsoft.WindowsAzure.Storage.Blob.BlobContainerPublicAccessType.Container });
                    break;

                case ContainerPermissions.Limited:

                    BlobContainer.SetPermissions(new Microsoft.WindowsAzure.Storage.Blob.BlobContainerPermissions { PublicAccess = Microsoft.WindowsAzure.Storage.Blob.BlobContainerPublicAccessType.Blob });
                    break;

            }
        }

        public void SetAccessTier(string ContainerName, string FileName, Tier tier)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            switch (tier)
            {
                case Tier.Cool:
                    BlockBlob.SetStandardBlobTier(Microsoft.WindowsAzure.Storage.Blob.StandardBlobTier.Cool);
                    break;
                case Tier.Hot:
                    BlockBlob.SetStandardBlobTier(Microsoft.WindowsAzure.Storage.Blob.StandardBlobTier.Hot);
                    break;
                case Tier.Archive:
                    BlockBlob.SetStandardBlobTier(Microsoft.WindowsAzure.Storage.Blob.StandardBlobTier.Archive);
                    break;
            }
        }
        public void UploadFile(string ContainerName, string FileName, string FilePath)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            var File = System.IO.File.OpenRead(FilePath);
            BlockBlob.UploadFromStream(File);
        }

        public void UploadFileFromStream(string ContainerName, string FileName, System.IO.Stream stream, Tier tier)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            BlockBlob.UploadFromStream(stream);

            switch (tier)
            {
                case Tier.Cool:
                    BlockBlob.SetStandardBlobTier(Microsoft.WindowsAzure.Storage.Blob.StandardBlobTier.Cool);
                    break;
                case Tier.Hot:
                    BlockBlob.SetStandardBlobTier(Microsoft.WindowsAzure.Storage.Blob.StandardBlobTier.Hot);
                    break;
                case Tier.Archive:
                    BlockBlob.SetStandardBlobTier(Microsoft.WindowsAzure.Storage.Blob.StandardBlobTier.Archive);
                    break;
            }
        }

        public Boolean DownloadFile(string ContainerName, string FileName, string FilePath)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            using (System.IO.FileStream File = System.IO.File.OpenWrite(FilePath))
            {
                BlockBlob.DownloadToStream(File);
            }
            //var File = System.IO.File.OpenWrite(FilePath);

            return true;
        }

        public System.IO.Stream DownloadFileToStream(string ContainerName, string FileName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            System.IO.Stream FileStream = new System.IO.MemoryStream();
            BlockBlob.DownloadToStream(FileStream);
            return FileStream;
        }

        async public Task XDownloadFile(string ContainerName, string FileName, string FilePath)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            //var File = System.IO.File.OpenWrite(FilePath);
            using (System.IO.FileStream File = System.IO.File.OpenWrite(FilePath))
            {
                await BlockBlob.DownloadToStreamAsync(File);
            }
        }

        public string ReadFile(string ContainerName, string FileName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            var MStream = new System.IO.MemoryStream();
            BlockBlob.DownloadToStream(MStream);
            return System.Text.Encoding.UTF8.GetString(MStream.ToArray());
        }
        public void WriteFile(string ContainerName, string FileName, string Text)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            var TextStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(Text));
            BlockBlob.UploadFromStream(TextStream);
        }

        public void AppendFile(string ContainerName, string FileName, string Text)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetAppendBlobReference(FileName);
            if (BlockBlob.Exists() == false)
            {
                BlockBlob.CreateOrReplace();
            }
            BlockBlob.AppendText(Text);
        }

        public void DeleteFile(string ContainerName, string FileName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            BlockBlob.Delete();
        }

        public Boolean CheckFileExist(string ContainerName, string FileName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            return BlockBlob.Exists();
        }
        public DateTime GetLastModified(string ContainerName, string FileName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            BlockBlob.FetchAttributes();
            var SourceTime = BlockBlob.Properties.LastModified;
            var ConvertedTime = SourceTime.Value.ToLocalTime();
            var TargetTime = ConvertedTime.DateTime;
            return TargetTime;
        }

        public Uri GetBlobUri(string ContainerName, string FileName)
        {
            var BlobContainer = BlobClient.GetContainerReference(ContainerName);
            var BlockBlob = BlobContainer.GetBlockBlobReference(FileName);
            return BlockBlob.Uri;
        }

        

    }
}
