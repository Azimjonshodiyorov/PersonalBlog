using Blog.Application.DTOs.Post;
using Blog.Application.Services.PostServices.Interfaces;
using Blog.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("getList")]
    public async Task<PagedResult<PostDto>> GetList(int pageNumber, int pageSize)
    {
        return await _postService.GetListAsync(pageNumber, pageSize);
    }

    [HttpGet("getById")]
    public async Task<PostDto> GetById(long id)
    {
        return await this._postService.GetByIdAsync(id);
    }

    [HttpPost("add")]
    public async Task<PostDto> CreatePostAsync(CreatePostDto dto)
    {
        return await this._postService.CreateAsync(dto);
    }
    
}