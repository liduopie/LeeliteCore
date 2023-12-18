using FluentValidation;

using Leelite.AspNetCore.Mvc;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Service;
using Leelite.Framework.Service.Dtos;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Framework.WebApi
{
    [GenericControllerNameConvention(typeof(RESTfulController<,,,,,>))]
    public class RESTfulController<TEntity, TKey, TDto, TCreateRequest, TUpdateRequest, TQueryParameter> : AdminApiControllerBase
        where TEntity : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
        where TDto : IDto<TKey>
        where TCreateRequest : IRequest
        where TUpdateRequest : IUpdateRequest<TKey>
        where TQueryParameter : PageParameter<TEntity>
    {
        private readonly ICrudService<TEntity, TKey, TDto, TCreateRequest, TUpdateRequest, TQueryParameter> _service;

        public RESTfulController(ICrudService<TEntity, TKey, TDto, TCreateRequest, TUpdateRequest, TQueryParameter> service)
        {
            _service = service;
        }

        // GET: api/[area]/[controller]
        [HttpGet]
        public async Task<ActionResult<IList<TDto>>> Get([FromQuery] TQueryParameter queryParameter)
        {
            var list = await _service.GetPageAsync(queryParameter);

            return list.ToList();
        }

        // GET: api/[area]/[controller]/GetPageList
        [HttpGet("GetPageList")]
        public async Task<ActionResult<PageList<TDto>>> GetPageList([FromQuery] TQueryParameter queryParameter)
        {
            return await _service.GetPageListAsync(queryParameter);
        }

        // GET: api/[area]/[controller]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TDto>> Get(TKey id)
        {
            var dto = await _service.GetByIdAsync(id);

            if (dto == null)
                return NotFound();

            return dto;
        }

        // POST: api/[area]/[controller]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TDto>> Post([FromBody] TCreateRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var dto = await _service.CreateAsync(createRequest);
                return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
            }
            catch (ValidationException e)
            {
                // 应该是 422 UnprocessableEntityResult

                return BadRequest(e);
            }
        }

        // PUT: api/[area]/[controller]/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDto>> Put([FromQuery] TKey id, [FromBody] TUpdateRequest updateRequest)
        {
            if (!id.Equals(updateRequest.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var dto = await _service.UpdateAsync(updateRequest);

                return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
            }
            catch (ValidationException e)
            {
                // 应该是 422 UnprocessableEntityResult

                return BadRequest(e);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("数据已被更改!");
                    throw;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(TKey id)
        {
            if (!_service.Exists(id))
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
