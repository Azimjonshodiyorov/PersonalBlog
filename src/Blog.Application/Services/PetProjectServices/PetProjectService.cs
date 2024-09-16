using AutoMapper;
using Blog.Application.DTOs.PetProjects;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Application.Services.PetProjectServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PetProjectServices;

public class PetProjectService : IPetProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMinioService<PetProjectFile> _minioService;
    private readonly IMapper _mapper;

    public PetProjectService(IUnitOfWork unitOfWork , IMinioService<PetProjectFile> minioService , IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _minioService = minioService;
        _mapper = mapper;
    }
    public async Task<PetProjectDto> CreateAsync(CreatePetProjectDto dto)
    {
        try
        {
            var petPro = _mapper.Map<PetProject>(dto);
            await _unitOfWork.PetProjects.AddAsync(petPro);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<PetProjectDto>(dto);
            return result;
        }
        catch (Exception e)
        {
            throw new Exception($"Hatolik {e.InnerException} {e.StackTrace}");
        }
    }

    public async Task<PetProjectDto> UpdateAsync(UpdatePetProjectDto dto)
    {
        try
        {
            var petPro = _mapper.Map<PetProject>(dto);
            await _unitOfWork.PetProjects.UpdateAsync(petPro);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<PetProjectDto>(dto);
            return result;
        }
        catch (Exception e)
        {
            throw new Exception($"Hatolik {e.InnerException} {e.StackTrace}");
        }
    }

    public async Task<PagedResult<PetProjectDto>> GetListAsync(int pageNumber, int pageSize)
    {
        var query = _unitOfWork.PetProjects.Entities
            .AsQueryable().Include(x => x.PetProjectFiles);
        var pagedPosts = PagedResult<PetProject>.Paginate(query, pageNumber, pageSize);

        var postDtos = _mapper.Map<List<PetProjectDto>>(pagedPosts.Items);

        return new PagedResult<PetProjectDto>(
            postDtos, 
            pagedPosts.TotalRecords,
            pagedPosts.PageNumber,
            pagedPosts.PageSize
        );
    }

    public async Task<PetProjectDto> GetByIdAsync(long id)
    {
        var petPro = await _unitOfWork.PetProjects
            .Entities
            .Include(p => p.PetProjectFiles) 
            .FirstOrDefaultAsync(p => p.Id == id);
        if (petPro is null)
            throw new Exception($"Post not found ");
        var postMap = _mapper.Map<PetProjectDto>(petPro);
        return postMap;
    }

    public async Task<PetProjectDto> DeleteByIdAsync(long id)
    {
        var petProject = await _unitOfWork.PetProjects.
            Entities.
            Where(x => x.Id == id && !x.IsDelete).FirstOrDefaultAsync(); ;
        if (petProject is null) throw new Exception($"{id} li petProject topilmadi");
        petProject.IsDelete = true;
        await _unitOfWork.SaveChangesAsync();
        var postMap = _mapper.Map<PetProjectDto>(petProject);
        return postMap;
    }

    public async Task<string> UploadFile(IFormFile file, long ownerId)
    {
        try
        {
            await _minioService.UploadFileAsync(file, DocumentStorageConst.Pet_Project_File, Guid.NewGuid(), ownerId );
            return file.FileName;
        }
        catch (Exception e)
        {
            throw new Exception($"{e.InnerException} {e.StackTrace} ");
        }
    }

    public async Task<byte[]> DownloadFile(string backetName, Guid id2)
    {
        return await this._minioService.GetFileByIdAsync(backetName, id2);
    }
}