using Blog.Application.Services.FileServices.Interfaces;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers;
[Authorize]
[Route("api/[controller]")]
public class FileCvController : ControllerBase
{
    private readonly IFileCvService _fileCvService;
    private readonly IUnitOfWork _unitOfWork;

    public FileCvController(IFileCvService fileCvService , IUnitOfWork unitOfWork)
    {
        _fileCvService = fileCvService;
        _unitOfWork = unitOfWork;
    }
}