using Application.Usecase.GetListPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Models;

namespace WebAPI.Controllers
{
    [Route("post")]
    public class PostController : Controller
    {
        private readonly IMediator mediator;
        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetListPost()
        {
            var query = new GetListPostQuery();
            var result = await mediator.Send(query).ConfigureAwait(false);
            return Ok(result);
        }
        
        [HttpPost()]
        public IActionResult CreatePost(CreatePostRequest request)
        {
            return Ok();
        }
    }
}
