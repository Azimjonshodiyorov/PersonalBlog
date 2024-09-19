using AutoMapper;
using Blog.Application.DTOs.Files;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.FileServices;

public class FileCvService : IFileCvService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMinioService<FileCv> _minioService;

    public FileCvService(IUnitOfWork unitOfWork , IMapper mapper , IMinioService<FileCv> minioService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _minioService = minioService;
    }
    public async Task<PagedResult<FileCvDto>> GetAllCvAsync(int pageNumber, int pageSize)
    {
        var fileCvs =  _unitOfWork.FileCvs.Entities.AsQueryable();
        var pageFileCv = PagedResult<FileCv>.Paginate(fileCvs, pageNumber, pageSize);
        var fileCvMap = _mapper.Map<List<FileCvDto>>(pageFileCv.Items);
        return new PagedResult<FileCvDto>(
            fileCvMap,
            pageFileCv.TotalPages,
            pageFileCv.PageNumber,
            pageFileCv.PageSize
        );
    }

    public async Task<FileCvDto> GetByIdFileAsync(long id)
    {
        var fileCv = await _unitOfWork.FileCvs.GetByIdAsync(id);
        if (fileCv is null)
            throw new Exception("File Id topilmadi");
        var fileCvMap = _mapper.Map<FileCvDto>(fileCv);
        return fileCvMap;
    }

    public async Task<string> UploadFile(IFormFile file, long ownerId)
    {
        var findOwner = await _unitOfWork.Context.Set<FileCv>()
            .FirstOrDefaultAsync(x => x.Id == ownerId);
        if (findOwner is null)
            throw new Exception("owner not found at FileCv");
        await _minioService.UploadFileAsync(file, DocumentStorageConst.File_Cv, Guid.NewGuid(), ownerId);
        return file.FileName;
    }

    public async Task<byte[]> DownloadFile(string bucktName, Guid id2)
    {
        return await _minioService.GetFileByIdAsync(bucktName, id2);
    }

    public async Task<FileCvDto> UpdateCv(UpdateFileCvDto dto)
    {
        var mapFileCv = _mapper.Map<FileCv>(dto);
        var updateCv = _unitOfWork.FileCvs.UpdateAsync(mapFileCv);
        return _mapper.Map<FileCvDto>(mapFileCv);
    }

    public async Task<FileCvDto> Delete(long id)
    {
        var findFileCv = await _unitOfWork.FileCvs.GetByIdAsync(id);
        if (findFileCv is null)
            throw new Exception("File id with Not found File");
        await _unitOfWork.FileCvs.DeleteAsync(findFileCv);
        var fileMap = _mapper.Map<FileCvDto>(findFileCv);
        return fileMap;
    }
}