using Blog.Application.DTOs.Files;
using Blog.Core.Common;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.FileServices.Interfaces;

public interface IFileCvService
{
    Task<PagedResult<FileCvDto>> GetAllCvAsync(int pageNumber, int pageSize);
    Task<FileCvDto> GetByIdFileAsync(long id);
    Task<string> UploadFile(IFormFile file, long ownerId);
    Task<byte[]> DownloadFile(string bucktName, Guid id2);
    Task<FileCvDto> UpdateCv(UpdateFileCvDto dto);
    Task<FileCvDto> Delete(long id);
}