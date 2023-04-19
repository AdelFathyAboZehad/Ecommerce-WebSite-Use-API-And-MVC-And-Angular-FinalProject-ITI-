using AdminSiteUseMVC.Options;
using AdminSiteUseMVC.Services.Abstract;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

namespace AdminSiteUseMVC.Services.Concrete
{
    public class ImageServices : IImageServices
    {
        private readonly AzureOptions _azureOptions;
        public ImageServices(IOptions<AzureOptions> azureOptions)
        {
            _azureOptions = azureOptions.Value;
        }
        public async Task< string> UploadImageToAzure(IFormFile file)
        {
            string FileExtintion = Path.GetExtension(file.FileName);

            using MemoryStream fileUploadStream = new MemoryStream();
            file.CopyTo(fileUploadStream);
            fileUploadStream.Position = 0;
            BlobContainerClient blobContainerClient = new BlobContainerClient(
                _azureOptions.ConnectionString,
                _azureOptions.Container
                );

            var uniqName = Guid.NewGuid().ToString() + FileExtintion;
            BlobClient blobClient = blobContainerClient.GetBlobClient(uniqName);
            await blobClient.UploadAsync(fileUploadStream, new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentType = "image/bitmap"
                    // ContentType = "image/*"
                }
            }, cancellationToken: default);

            var url = blobClient.Uri.AbsoluteUri;

            return url;
        }

    }
}
