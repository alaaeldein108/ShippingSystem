using Microsoft.AspNetCore.Http;

namespace Services.FileService
{
    public interface IFileService
    {
        Task<List<string>> SavePicturesAsync(List<IFormFile> imageUrls, string categoryFolder, string subCategoryFolder);
        Task<string> SavePictureAsync(IFormFile imageUrl, string categoryFolder, string subCategoryFolder);
        //Task <IFormFile> ConvertToFormFile(string pictureUrl);
    }
}
