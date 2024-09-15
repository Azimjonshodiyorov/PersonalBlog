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
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await this._postService.GetByIdAsync(id));
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreatePostAsync(CreatePostDto dto)
    {
        return Ok( await this._postService.CreateAsync(dto));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdatePostDto dto)
    {
        return Ok(await this._postService.UpdateAsync(dto));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(long  id)
    {
        return Ok(await this._postService.DeleteByIdAsync(id));
    }

    [HttpPost("uploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        return Ok(await _postService.UploadFile(file , 1));

    }

    [HttpPost("download")]
    public async Task<IActionResult> DownloadFile(string backetName, Guid id2)
    {

        return Ok(await _postService.DownloadFile(backetName, id2));

    }

}