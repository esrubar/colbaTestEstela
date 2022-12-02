using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route ("[controller]")]
public class ThumbnailController: ControllerBase
{
    private static readonly List<Thumbnail> _thumbnails = ThumbnailsData.Thumbnails;

    [HttpGet]
    public List<Thumbnail> GetAll()
    {
        return _thumbnails;
    }
    
    [HttpPost]
    public Thumbnail Create([FromBody] Thumbnail thumbnail)
    {
        thumbnail.Id = Guid.NewGuid();
        _thumbnails.Add(thumbnail);
        return thumbnail;
    }
     
    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var thumbnail = _thumbnails.FirstOrDefault(thumbnail => thumbnail.Id == id);
        if (thumbnail is null)
        {
            return NotFound();
        }

        return new ObjectResult(thumbnail) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var thumbnail = _thumbnails.FirstOrDefault(thumbnail => thumbnail.Id == id);
        if (thumbnail is null)
        {
            return NotFound();
        }

        _thumbnails.Remove(thumbnail);
        return NoContent();
    }

    
}