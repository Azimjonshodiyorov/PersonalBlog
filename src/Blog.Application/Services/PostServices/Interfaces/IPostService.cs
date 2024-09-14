using Blog.Application.DTOs.Post;
using Blog.Core.Common;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.PostServices.Interfaces;

public interface IPostService
{
    Task<PostDto> CreateAsync(CreatePostDto dto);
    Task<PostDto> UpdateAsync(UpdatePostDto dto);
    Task<string> UploadFile(IFormFile file, long ownerId);
    Task<byte[]> DownloadFile(string backetName, Guid id2);
    Task<PostDto> GetByIdAsync(long id);
    Task<PagedResult<PostDto>> GetListAsync(int pageNumber , int pageSize);
}