using Blog.Application.Common;
using Blog.Application.DTOs.Files;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.WebAPI.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FileCvController : ControllerBase
{
    private readonly IFileCvService _fileCvService;
    private readonly IUnitOfWork _unitOfWork;

    public FileCvController(IFileCvService fileCvService , IUnitOfWork unitOfWork)
    {
        _fileCvService = fileCvService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("getList")]
    public async Task<PagedResult<FileCvDto>> GetList(int pageNumber, int pageSize)
    {
        return await _fileCvService.GetAllCvAsync(pageNumber, pageSize);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await this._fileCvService.GetByIdFileAsync(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateFileCvDto dto)
    {
        return Ok(await this._fileCvService.UpdateCv(dto));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await this._fileCvService.Delete(id));
    }

    [HttpPost("uploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile file, long owerId)
    {
        return Ok(await this._fileCvService.UploadFile(file, owerId));
    }

    [HttpGet("download")]
    public async Task<IActionResult> DownloadFile(string backtName, Guid id2)
    {
        var fileFormat = await _unitOfWork.Context.Set<FileCv>()
            .FirstOrDefaultAsync(x => x.Id2 == id2);
        var fileExtantion = AppExtension.GetMimeType(fileFormat.FileExtension);
        if (fileFormat == null || fileExtantion == null)
            throw new Exception("");
        var post = await this._fileCvService.DownloadFile(backtName, id2);
        return File(post, fileExtantion, fileFormat.FileName);
    }
}