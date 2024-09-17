using Blog.Application.Common;
using Blog.Application.DTOs.PetProjects;
using Blog.Application.DTOs.Post;
using Blog.Application.Services.PetProjectServices.Interfaces;
using Blog.Core.Common;
using Blog.Core.Entities;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PetProjectController : ControllerBase
    {
        private readonly IPetProjectService _projectService;
        private readonly IUnitOfWork _unitOfWork;

        public PetProjectController(IPetProjectService projectService , IUnitOfWork unitOfWork)
        {
            _projectService = projectService;
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("getList")]
        public async Task<PagedResult<PetProjectDto>> GetList(int pageNumber, int pageSize)
        {
            return await _projectService.GetListAsync(pageNumber, pageSize);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await this._projectService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync(CreatePetProjectDto dto)
        {
            return Ok( await this._projectService.CreateAsync(dto));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdatePetProjectDto dto)
        {
            return Ok(await this._projectService.UpdateAsync(dto));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(long  id)
        {
            return Ok(await this._projectService.DeleteByIdAsync(id));
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file , long id)
        {
            return Ok(await _projectService.UploadFile(file , id));

        }

        [HttpPost("download")]
        public async Task<IActionResult> DownloadFile(string backetName, Guid id2)
        {
            var fileFormat = await _unitOfWork.Context.Set<PetProjectFile>()
                .FirstOrDefaultAsync(x=>x.Id2 == id2);
            var fileExtantion = AppExtension.GetMimeType(fileFormat.FileExtension);
            if (fileFormat == null || fileExtantion == null)
                throw new Exception("");

        
            var post = await _projectService.DownloadFile(backetName, id2);
            return File(post, fileExtantion, fileFormat.FileName);
        }
    }
}
