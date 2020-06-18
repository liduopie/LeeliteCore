using Leelite.Framework.WebApi;
using Leelite.Samples.ModuleSample.Dtos;
using Leelite.Samples.ModuleSample.Interfaces;
using Leelite.Samples.ModuleSample.Models.BlogAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Samples.ModuleSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : RESTfulController<Blog, int, BlogDto, BlogCreateRequest, BlogUpdateRequest, BlogQueryParameter>
    {
        private readonly IBlogService _service;

        public BlogController(IBlogService service) : base(service)
        {
            _service = service;
        }

        // GET api/values/5
        [HttpGet("GetUrl/{id}")]
        public ActionResult<BlogDto> GetUrl(int id)
        {
            var blog = _service.GetById(id);

            if (blog == null)
                return NotFound();
            else
                return blog;
        }
    }
}
