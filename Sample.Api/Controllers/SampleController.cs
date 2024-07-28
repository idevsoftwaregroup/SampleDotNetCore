using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Contract.DTOs;
using Sample.Application.Contract.Interfaces;
using System.Net;
using System.Runtime.CompilerServices;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleItemService _sampleItemService;
        public SampleController(ISampleItemService sampleItemService)
        {
            _sampleItemService = sampleItemService;
        }
        [HttpGet("GetSampleItems")]
        public async Task<ActionResult<List<SampleItemApplicationDTO>>> GetSampleItems(CancellationToken cancellationToken = default)
        {
            var dataSample = await _sampleItemService.GetSampleItems(cancellationToken);
            return dataSample.Any() ? Ok(dataSample) : StatusCode((int)HttpStatusCode.NoContent, dataSample);
        }
    }
}
