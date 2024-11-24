using Microsoft.AspNetCore.Mvc;
using CaseStudy.Dto.Books;
using CaseStudy.Services.Books;

namespace CaseStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(BookService bookService) : ControllerBase
    {
        private readonly BookService _bookService = bookService;

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
                var entities = await _bookService.GetAllAsync(cancellationToken);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// Returning all book genres.
        /// </summary>
        /// <response code="200">Requested data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("genres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllGenresAsync()
        {
            try
            {
                var entities = _bookService.GetAllGenresAsync();
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
        public async Task<IActionResult> AddAsync(BookDto entity, CancellationToken cancellationToken)
        {
            try
            {
                var createdEntity = await _bookService.AddAsync(entity, cancellationToken);
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
        public async Task<IActionResult> UpdateAsync(BookDto entity, CancellationToken cancellationToken)
        {
            try
            {
                var updatedEntity = await _bookService.UpdateAsync(entity, cancellationToken);
                return Ok(updatedEntity);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// Adding book to collection.
        /// </summary>
        /// <response code="200">Book added to collection successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{bookId}/{collectionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddBookToCollectionAsync(Guid bookId, Guid collectionId, CancellationToken cancellationToken)
        {
            try
            {
                await _bookService.AddBookToCollectionAsync(bookId, collectionId, cancellationToken);
                return Ok();
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
                await _bookService.DeleteAsync(id, cancellationToken);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
