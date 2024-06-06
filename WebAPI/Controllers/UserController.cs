using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Usecase.CreateUser;
using Application.Usecase.GetListUser;

namespace WebAPI.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            var command = new CreateUserCommand()
            {
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName,
            };
            var result = mediator.Send(command);
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetListUser()
        {
            var query = new GetListUserQuery()
            {
            };
            var result = await mediator.Send(query).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
