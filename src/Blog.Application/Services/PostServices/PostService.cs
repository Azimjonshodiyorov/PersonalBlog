using AutoMapper;
using Blog.Application.DTOs.Post;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Application.Services.PostServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.PostServices;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMinioService<PostFile> _minioService;
    private readonly IMapper _mapper;

    public PostService(IUnitOfWork unitOfWork , IMinioService<PostFile>  minioService , IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _minioService = minioService;
        _mapper = mapper;
    }

    public async Task<PostDto> CreateAsync(CreatePostDto dto)
    {
        try
        {
                var postMap = _mapper.Map<Post>(dto);
                await this._unitOfWork.Posts.AddAsync(postMap);
                await this._unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<PostDto>(dto);
                return result;
        }
        catch (Exception e)
        {
            throw new Exception($"Post Serviceda xatolik {e.StackTrace} {e.InnerException}");
        }
    }

    public async Task<PostDto> UpdateAsync(UpdatePostDto dto)
    {
        try
        {
            var postMap = _mapper.Map<Post>(dto);
            await this._unitOfWork.Posts.UpdateAsync(postMap);
            await this._unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<PostDto>(dto);
            return result;
        }
        catch (Exception e)
        {
            throw new Exception($"Post Serviceda xatolik {e.StackTrace} {e.InnerException}");
        }
    }

    public async Task<string> UploadFile(IFormFile file, long ownerId)
    {
        try
        {
           await _minioService.UploadFileAsync(file, DocumentStorageConst.Post_File, Guid.NewGuid(), ownerId );
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

    public async Task<PostDto> GetByIdAsync(long id)
    {
        var post = await _unitOfWork.Posts
                                        .Entities
                                        .Include(p => p.PostFiles) // PostFile larni birga olib kelish
                                        .FirstOrDefaultAsync(p => p.Id == id);
        if (post is null)
            throw new Exception($"Post not found ");
        var postMap = _mapper.Map<PostDto>(post);
        return postMap;
    }

    public async Task<PagedResult<PostDto>> GetListAsync(int pageNumber , int pageSize)
    {
        var query = _unitOfWork.Posts.Entities
            .AsQueryable()
            .Include(x=>x.PostFiles);

        var pagedPosts = PagedResult<Post>.Paginate(query, pageNumber, pageSize);

        var postDtos = _mapper.Map<List<PostDto>>(pagedPosts.Items);

        return new PagedResult<PostDto>(
            postDtos, 
            pagedPosts.TotalRecords,
            pagedPosts.PageNumber,
            pagedPosts.PageSize
        );

    }
}