using Blog.Application.Services.CertificateServices.Interfaces;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;
    private readonly IUnitOfWork _unitOfWork;

    public CertificateController(ICertificateService certificateService , IUnitOfWork unitOfWork)
    {
        _certificateService = certificateService;
        _unitOfWork = unitOfWork;
    }

    // GET: api/<CertificateController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<CertificateController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<CertificateController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CertificateController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CertificateController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
