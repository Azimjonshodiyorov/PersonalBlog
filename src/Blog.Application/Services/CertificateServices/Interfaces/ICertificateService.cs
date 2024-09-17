using Blog.Application.DTOs.Certificates;
using Blog.Core.Common;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.CertificateServices.Interfaces;

public interface ICertificateService
{
    Task<PagedResult<CertificateDto>> GetListAsync(int pageNumber, int pageSize);
    Task<CertificateDto> GetByIdAsync(long id);
    Task<CertificateDto> CreateAsync(CreateCertificateDto dto);
    Task<CertificateDto> UpdateAsync(UpdateCertificateDto dto);
    Task<CertificateDto> Delete(long id);
    Task<byte[]> Download(string backetName, Guid id2);
    Task<string> UploadFile(IFormFile file, long ownerId);
}