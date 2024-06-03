using Application.Models;
using MediatR;

namespace Application.Usecase.GetListPost
{
    public class GetListPostHandler : IRequestHandler<GetListPostQuery, List<PostDto>>
    {
        public Task<List<PostDto>> Handle(GetListPostQuery request, CancellationToken cancellationToken)
        {
            var response = new List<PostDto>()
            {
                new PostDto()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "aaaa"
                }
            };
            return Task.FromResult(response);
        }
    }
}
