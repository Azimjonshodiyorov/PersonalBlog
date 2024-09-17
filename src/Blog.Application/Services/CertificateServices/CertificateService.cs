using AutoMapper;
using Blog.Application.DTOs.Certificates;
using Blog.Application.Services.CertificateServices.Interfaces;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        var query =  _unitOfWork.Certificates.Entities
            .Include(x => x.CertificateFiles);
        var pegedCertifcate = PagedResult<Certificate>.Paginate(query, pageNumber, pageSize);
        var certifcateMap = _mapper.Map<List<CertificateDto>>(pegedCertifcate.Items);
        return new PagedResult<CertificateDto>(
            certifcateMap,
            pegedCertifcate.TotalRecords,
            pegedCertifcate.PageNumber,
            pegedCertifcate.PageSize);
    }

    public async Task<CertificateDto> GetByIdAsync(long id)
    {
        var certifcate = await _unitOfWork.Certificates.Entities
            .Include(x => x.CertificateFiles)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (certifcate is null)
            throw new Exception($" {id} Certificate topilmadi ");
        var certificateMap = _mapper.Map<CertificateDto>(certifcate);
        return certificateMap;
    }

    public async Task<CertificateDto> CreateAsync(CreateCertificateDto dto)
    {
        try
        {
            var certificate = _mapper.Map<Certificate>(dto);
            await _unitOfWork.Certificates.AddAsync(certificate);
            await _unitOfWork.SaveChangesAsync();
            var certificateMap = _mapper.Map<CertificateDto>(certificate);
            return certificateMap;
        }
        catch (Exception e)
        {
            throw new Exception($"Certificate yaratishda hatolik  {e.InnerException} {e.StackTrace}");
        }
    }

    public async Task<CertificateDto> UpdateAsync(UpdateCertificateDto dto)
    {
        try
        {
            var certificate = _mapper.Map<Certificate>(dto);
            await _unitOfWork.Certificates.UpdateAsync(certificate);
            await _unitOfWork.SaveChangesAsync();
            var certificateMap = _mapper.Map<CertificateDto>(certificate);
            return certificateMap;
        }
        catch (Exception e)
        {
            throw new Exception($"Certificate Yanagilashda hatolik  {e.InnerException} {e.StackTrace}");
        }
    }

    public async Task<CertificateDto> Delete(long id)
    {
        try
        {
            var certificate = await _unitOfWork.Certificates.GetByIdAsync(id);
            if (certificate == null)
                throw new Exception();
            await _unitOfWork.Certificates.DeleteAsync(certificate);
            await _unitOfWork.SaveChangesAsync();
            var certificateMap = _mapper.Map<CertificateDto>(certificate);
            return certificateMap;
        }
        catch (Exception e)
        {
            throw new Exception($"Certificate o'chrishda hatolik  {e.InnerException} {e.StackTrace}");
        }
    }

    public async Task<byte[]> Download(string backetName, Guid id2)
    {
        return await _minioService.GetFileByIdAsync(backetName, id2);
    }

    public async Task<string> UploadFile(IFormFile file, long ownerId)
    {
        try
        {
            var owner = await _unitOfWork.Context.Set<Certificate>()
                .FirstOrDefaultAsync(x=>x.Id == ownerId);
            if (owner is null)
                return $"{ownerId} Bunday id Certificate yuq";
            await _minioService.UploadFileAsync(file, DocumentStorageConst.Certificate_File, Guid.NewGuid(), ownerId );
            return file.FileName;
        }
        catch (Exception e)
        {
            throw new Exception($"{e.InnerException} {e.StackTrace} ");
        }
    }
}