using Blog.Core.Common;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.FileServices.Interfaces;

public interface IMinioService<T> where T : class, IFileMetadata
{
    Task<string> UploadFileAsync(IFormFile file, string bucketName, Guid id2, long ownerId);
    Task<byte[]> GetFileByIdAsync(string bucketName, Guid id2);
    Task<bool> DeleteFileAsync(string bucketName, Guid id2);
    Task<bool> UpdateFileStatusAsync(Guid id2, bool isDeleted);
}