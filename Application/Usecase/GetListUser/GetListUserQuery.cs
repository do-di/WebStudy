using Application.Models;
using MediatR;

namespace Application.Usecase.GetListUser
{
    public class GetListUserQuery : IRequest<List<UserDto>>
    {
    }
}
