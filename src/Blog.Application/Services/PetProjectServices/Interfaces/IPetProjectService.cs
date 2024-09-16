using Blog.Application.DTOs.PetProjects;
using Blog.Core.Common;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services.PetProjectServices.Interfaces;

public interface IPetProjectService
{
   Task<PetProjectDto> CreateAsync(CreatePetProjectDto dto);
   Task<PetProjectDto> UpdateAsync(UpdatePetProjectDto dto);
   Task<PagedResult<PetProjectDto>> GetListAsync(int pageNumber , int pageSize);
   Task<PetProjectDto> GetByIdAsync(long id);
   Task<PetProjectDto> DeleteByIdAsync(long id);
   Task<string> UploadFile(IFormFile file, long ownerId);
   Task<byte[]> DownloadFile(string backetName, Guid id2);
}