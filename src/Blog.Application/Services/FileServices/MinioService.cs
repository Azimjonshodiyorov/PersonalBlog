using Blog.Application.Services.FileServices.Interfaces;
using Blog.Core.Common;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;

namespace Blog.Application.Services.FileServices;

public class MinioService<T> : IMinioService<T> where T : class ,IFileMetadata
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly MinioClient _minioClient;
    private readonly IFileMetadataRepository<T> _fileMetadataRepository;

    public MinioService(IUnitOfWork unitOfWork , MinioClient minioClient , IFileMetadataRepository<T> fileMetadataRepository) 
    {
        _unitOfWork = unitOfWork;
        _minioClient = minioClient ?? throw new ArgumentNullException(nameof(minioClient));
        _fileMetadataRepository = fileMetadataRepository;
    }
    public async Task<string> UploadFileAsync(IFormFile file, string bucketName, Guid id2, long ownerId)
    {
        try
        {
            var fileName = $"{id2}{Path.GetExtension(file.FileName)}";
            await using var stream = file.OpenReadStream();

            bool bucketExists = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));
            if (!bucketExists)
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs()
                    .WithBucket(bucketName));
            }

            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(file.FileName)
                .WithStreamData(stream)
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType));

            var fileMetadata = Activator.CreateInstance<T>();
            fileMetadata.Id2 = id2;
            fileMetadata.FileName = file.FileName;
            fileMetadata.FileExtension = Path.GetExtension(file.FileName);
            fileMetadata.IsDeleted = false;
            fileMetadata.OwnerId = ownerId;

            await _fileMetadataRepository.AddAsync(fileMetadata);
            await _unitOfWork.SaveChangesAsync();

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
        try
        {
            var fileName = $"{id2}";
            await _minioClient.RemoveObjectAsync(new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName));

            await UpdateFileStatusAsync(id2, true);

            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Faylni o'chirishda xatolik yuz berdi", ex);
        }    }

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
        var fileMetadata = await _fileMetadataRepository.FindByIdAsync(id2);

        if (fileMetadata != null)
        {
            fileMetadata.IsDeleted = isDeleted;
            //fileMetadata.DeletedAt = isDeleted ? DateTime.UtcNow : (DateTime?)null;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        return false;    }
}