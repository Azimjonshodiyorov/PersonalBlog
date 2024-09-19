using Blog.Application.DTOs.Files;
using Blog.Core.Common;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.FileServices.Interfaces;

public interface IFileCvService
{
    Task<PagedResult<FileCvDto>> GetAllCvAsync(int pageNumber, int pageSize);
    Task<FileCvDto> GetByIdFileAsync(string bucktName, Guid id2);
    Task<string> UploadFile(IFormFile file, long ownerId);
    Task<byte[]> DownloadFile(string bucktName, long ownerId);
    Task<FileCvDto> UpdateCv(UpdateFileCvDto dto);
    Task<FileCvDto> Delete(long id);
}