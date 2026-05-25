using Microsoft.AspNetCore.Mvc;
using AuraVisualsAPI.Models;
using AuraVisualsAPI.Services;

namespace AuraVisualsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RequestsController : ControllerBase
    {
        private readonly RequestService _service;

        public RequestsController(RequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<DesignRequest>> Get() =>
            await _service.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(DesignRequest request)
        {
            await _service.CreateAsync(request);

            return Ok(request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, DesignRequest request)
        {
            await _service.UpdateAsync(id, request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}