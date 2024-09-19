using Blog.Application.DTOs.Files;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Core.Common;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.FileServices;

public class FileCvService : IFileCvService
{
    public async Task<PagedResult<FileCvDto>> GetAllCvAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public async Task<FileCvDto> GetByIdFileAsync(string bucktName, Guid id2)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadFile(IFormFile file, long ownerId)
    {
        throw new NotImplementedException();
    }

    public async Task<byte[]> DownloadFile(string bucktName, long ownerId)
    {
        throw new NotImplementedException();
    }

    public async Task<FileCvDto> UpdateCv(UpdateFileCvDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<FileCvDto> Delete(long id)
    {
        throw new NotImplementedException();
    }
}