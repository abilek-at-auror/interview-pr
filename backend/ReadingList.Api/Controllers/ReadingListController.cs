using Microsoft.AspNetCore.Mvc;
using ReadingListApi.Services;

namespace ReadingListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingListController : ControllerBase
    {
        private readonly ReadingListService _readingListService;

        public ReadingListController(ReadingListService readingListService)
        {
            _readingListService = readingListService;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            var items = _readingListService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _readingListService.GetItemById(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ReadingItem newItem)
        {
            var addedItem = _readingListService.AddItem(newItem);
            return CreatedAtAction(nameof(GetItemById), new { id = addedItem.Id }, addedItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] ReadingItem updatedItem)
        {
            var success = _readingListService.UpdateItem(id, updatedItem);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var success = _readingListService.DeleteItem(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
