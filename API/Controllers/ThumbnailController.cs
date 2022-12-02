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
    
}