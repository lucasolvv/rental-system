namespace RentalSystem.Application.Services.FileStorage
{
    public interface IFileStorageService
    {
        Task<string> SaveImageAsync(string base64, string fileName);
    }
}
