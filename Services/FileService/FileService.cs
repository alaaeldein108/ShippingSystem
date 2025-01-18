using Microsoft.AspNetCore.Http;

namespace Services.FileService
{
    public class FileService : IFileService
    {
        public async Task<List<string>> SavePicturesAsync(List<IFormFile> imageUrls, string categoryFolder, string subCategoryFolder)
        {
            var urls = new List<string>();

            foreach (var imageUrl in imageUrls)
            {
                var fileUrl = await SavePictureAsync(imageUrl, categoryFolder, subCategoryFolder);
                urls.Add(fileUrl);
            }

            return urls;
        }
        public async Task<string> SavePictureAsync(IFormFile imageUrl, string categoryFolder, string subCategoryFolder)
        {
            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageUrl.FileName)}";

            var filePath = Path.Combine("wwwroot", categoryFolder, subCategoryFolder, fileName);

            // Ensure the directory exists
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save the file to the local file system
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(stream);
            }

            // Generate the URL (assumes the application is hosted at the root level)
            var fileUrl = $"/{categoryFolder}/{subCategoryFolder}/{fileName}";
            return fileUrl;
        }


    }
}
