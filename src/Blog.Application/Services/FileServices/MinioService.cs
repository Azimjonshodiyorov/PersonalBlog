using Blog.Application.Services.FileServices.Interfaces;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;

namespace Blog.Application.Services.FileServices;

public class MinioService : IMinioService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly MinioClient _minioClient;

    public MinioService(IUnitOfWork unitOfWork , MinioClient minioClient)
    {
        _unitOfWork = unitOfWork;
        _minioClient = minioClient;
    }
    public async Task<string> UploadFileAsync(IFormFile file, string bucketName, Guid id2, long ownerId)
    {
        try
        {
            var fileName = $"{id2}{Path.GetExtension(file.FileName)}";
            await using var stream = file.OpenReadStream();
            bool bucketExists = await _minioClient.BucketExistsAsync(new BucketExistsArgs()
                .WithBucket(bucketName));
            if (!bucketExists)
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            }
            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithStreamData(stream)
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType));
            
            await SaveFileMetadataAsync(id2, fileName, Path.GetExtension(file.FileName), ownerId);
            return fileName;
        }
        catch (Exception e)
        {
            throw new ApplicationException("File upload failed", e);
        }
    }

    public async Task<byte[]> GetFileByIdAsync(string bucketName, Guid id2)
    {
        try
        {
            var fileName = $"{id2}";
            using var memoryStream = new MemoryStream();
            await _minioClient.GetObjectAsync(new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithCallbackStream(stream => stream.CopyTo(memoryStream)));

            return memoryStream.ToArray();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("File retrieval failed", ex);
        }
    }

    public async Task<bool> DeleteFileAsync(string bucketName, Guid id2)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveFileMetadataAsync(Guid id2, string fileName, string fileExtension, long ownerId)
    {
        var petFile = new 
        {
            Id2 = id2,
            FileName = fileName,
            FileExtension = fileExtension,
            IsDeleted = false,
            UploadedAt = DateTime.UtcNow,
            OwnerId = ownerId
        };

        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateFileStatusAsync(Guid id2, bool isDeleted)
    {
        throw new NotImplementedException();
    }
}