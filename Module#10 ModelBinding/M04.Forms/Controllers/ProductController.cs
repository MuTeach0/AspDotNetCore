
using Microsoft.AspNetCore.Mvc;

namespace M04.Forms.Controllers;

[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("product-controller")]
    public IActionResult Get([FromForm] string name, [FromForm] decimal price) =>
       Ok(new { name, price });

    [HttpPost("upload-controller")]
    public async Task<IActionResult> PostAsync(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("No file uploaded.");

        // Process the file (e.g., save it to a location)
        // For demonstration, we'll just return a success message.
        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        Directory.CreateDirectory(uploads);

        var path = Path.Combine(uploads, file.FileName);

        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        return Ok("File uploaded successfully.");

    }
}