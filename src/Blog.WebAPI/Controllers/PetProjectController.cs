using Blog.Application.Services.PetProjectServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PetProjectController : ControllerBase
    {
        private readonly IPetProjectService projectService;

        public PetProjectController(IPetProjectService projectService)
        {
            this.projectService = projectService;
        }



    }
}
