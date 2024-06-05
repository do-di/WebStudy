using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Usecase.CreatePost;

// Create post command.
public class CreatePostCommand : IRequest
{
    // Gets or sets the title.
    public string Title { get; set; } = string.Empty;

    // Gets the file.
    public IFormFile? File { get; set; }
}