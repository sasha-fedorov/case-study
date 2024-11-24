using Microsoft.AspNetCore.Mvc;
using CaseStudy.Dto.Collections;
using CaseStudy.Services.Collections;

namespace CaseStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionsController(CollectionService collectionDtoService) : ControllerBase
    {
        private readonly CollectionService _collectionDtoService = collectionDtoService;

        /// <summary>
        /// Returning all entities.
        /// </summary>
        /// <response code="200">Requested data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _collectionDtoService.GetAllAsync(cancellationToken);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// Creating entity.
        /// </summary>
        /// <response code="200">Created entity.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAsync(CollectionDto entity, CancellationToken cancellationToken)
        {
            try
            {
                var createdEntity = await _collectionDtoService.AddAsync(entity, cancellationToken);
                return Ok(createdEntity);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// Updating entity.
        /// </summary>
        /// <response code="200">Updated entity.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(CollectionDto entity, CancellationToken cancellationToken)
        {
            try
            {
                var updatedEntity = await _collectionDtoService.UpdateAsync(entity, cancellationToken);
                return Ok(updatedEntity);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// Deleting entity.
        /// </summary>
        /// <response code="200">Entity deleted successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _collectionDtoService.DeleteAsync(id, cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
