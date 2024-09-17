using AutoMapper;
using Blog.Application.DTOs.Certificates;
using Blog.Application.Services.CertificateServices.Interfaces;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.CertificateServices;

public class CertificateService : ICertificateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMinioService<CertificateFile> _minioService;

    public CertificateService(IUnitOfWork unitOfWork , IMapper mapper , IMinioService<CertificateFile> minioService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _minioService = minioService;
    }
    public async Task<PagedResult<CertificateDto>> GetListAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public async Task<CertificateDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<CertificateDto> CreateAsync(CreateCertificateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<CertificateDto> UpdateAsync(UpdateCertificateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<CertificateDto> Delete(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<byte[]> Download(string backetName, Guid id2)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadFile(IFormFile file, long ownerId)
    {
        throw new NotImplementedException();
    }
}