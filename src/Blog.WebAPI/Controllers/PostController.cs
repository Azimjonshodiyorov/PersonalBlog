using Blog.Application.Common;
using Blog.Application.DTOs.Post;
using Blog.Application.Services.PostServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace Blog.WebAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IUnitOfWork _unitOfWork;

    public PostController(IPostService postService, IUnitOfWork unitOfWork)
    {
        _postService = postService;
        _unitOfWork = unitOfWork;
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
        var fileFormat = await _unitOfWork.Context.Set<PostFile>()
            .FirstOrDefaultAsync(x=>x.Id2 == id2);
        var fileExtantion = AppExtension.GetMimeType(fileFormat.FileExtension);
        if (fileFormat == null || fileExtantion == null)
            throw new Exception("");

        
        var post = await _postService.DownloadFile(backetName, id2);
        return File(post, fileExtantion, fileFormat.FileName);
    }

}