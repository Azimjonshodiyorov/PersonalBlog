using Blog.Application.Common;
using Blog.Application.DTOs.Certificates;
using Blog.Application.DTOs.PetProjects;
using Blog.Application.Services.CertificateServices.Interfaces;
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
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;
    private readonly IUnitOfWork _unitOfWork;

    public CertificateController(ICertificateService certificateService, IUnitOfWork unitOfWork)
    {
        _certificateService = certificateService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("getList")]
    public async Task<PagedResult<CertificateDto>> GetList(int pageNumber, int pageSize)
    {
        return await _certificateService.GetListAsync(pageNumber, pageSize);
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await this._certificateService.GetByIdAsync(id));
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateAsync(CreateCertificateDto dto)
    {
        return Ok(await this._certificateService.CreateAsync(dto));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateCertificateDto dto)
    {
        return Ok(await this._certificateService.UpdateAsync(dto));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(await this._certificateService.Delete(id));
    }

    [HttpPost("uploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile file, long id)
    {
        return Ok(await _certificateService.UploadFile(file, id));

    }

    [HttpPost("download")]
    public async Task<IActionResult> DownloadFile(string backetName, Guid id2)
    {
        var fileFormat = await _unitOfWork.Context.Set<CertificateFile>()
            .FirstOrDefaultAsync(x => x.Id2 == id2);
        var fileExtantion = AppExtension.GetMimeType(fileFormat.FileExtension);
        if (fileFormat == null || fileExtantion == null)
            throw new Exception("");
        var post = await _certificateService.Download(backetName, id2);
        return File(post, fileExtantion, fileFormat.FileName);
    }
}
