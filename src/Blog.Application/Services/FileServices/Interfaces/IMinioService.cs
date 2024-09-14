using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.FileServices.Interfaces;

public interface IMinioService
{
    Task<string> UploadFileAsync(IFormFile file, string bucketName, Guid id2 , long ownerId);
    Task<byte[]> GetFileByIdAsync(string bucketName, Guid id2);
    Task<bool> DeleteFileAsync(string bucketName, Guid id2);
    Task<bool> SaveFileMetadataAsync(Guid id2, string fileName, string fileExtension, long ownerId); 
    Task<bool> UpdateFileStatusAsync(Guid id2, bool isDeleted); 
}