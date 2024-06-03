using Application.Models;
using MediatR;

namespace Application.Usecase.GetListPost
{
    public class GetListPostQuery : IRequest<List<PostDto>>
    {
    }
}
