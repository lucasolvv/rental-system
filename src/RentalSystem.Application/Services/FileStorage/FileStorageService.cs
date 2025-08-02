using RentalSystem.Exceptions.ExceptionBase;
using System.Drawing;
using System.Drawing.Imaging;

namespace RentalSystem.Application.Services.FileStorage
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "CNH");

        public FileStorageService()
        {
            if (!Directory.Exists(_basePath)) 
                Directory.CreateDirectory(_basePath);

        }
        public async Task<string> SaveImageAsync(string base64, string fileName)
        {
            if (!IsValidBased64Image(base64, out var extension))
                throw new ErrorOnValidationException("Formato de imagem inválido. Apenas PNG e BMP são suportados.");
            
            var filePath = Path.Combine(_basePath, fileName + extension);
            byte[] imageBytes = Convert.FromBase64String(base64);

            await File.WriteAllBytesAsync(filePath, imageBytes);
            return filePath;
        }

        private bool IsValidBased64Image(string base64, out string extension)
        {
            extension = null;
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64);

                using var ms = new MemoryStream(imageBytes);
                using var img = Image.FromStream(ms);

                if (ImageFormat.Png.Equals(img.RawFormat))
                {
                    extension = ".png";
                    return true;
                }
                if (ImageFormat.Bmp.Equals(img.RawFormat))
                {
                    extension = ".bmp";
                    return true;
                }
                return false;
            } 
            catch
            {
                return false;
            }
        }
    }
}
