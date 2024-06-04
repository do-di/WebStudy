using Microsoft.AspNetCore.Http;

namespace Application.Models
{
    public class CreatePostRequest
    {
        // Gets or sets the title.
        public string Title { get; set; } = String.Empty;

        // Gets the file.
        public IFormFile file { get; }
    }
}