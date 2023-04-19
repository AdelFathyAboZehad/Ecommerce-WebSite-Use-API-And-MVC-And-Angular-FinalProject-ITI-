namespace AdminSiteUseMVC.Services.Abstract
{
    public interface IImageServices
    {
        Task<string> UploadImageToAzure(IFormFile file);
    }
}
