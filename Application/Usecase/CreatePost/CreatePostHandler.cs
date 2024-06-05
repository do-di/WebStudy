using Domain.Interface.Storage;
using MediatR;

namespace Application.Usecase.CreatePost;

public class CreatePostHandler : IRequestHandler<CreatePostCommand>
{
    private readonly IAzureStorage azureStorage;

    public CreatePostHandler(IAzureStorage azureStorage)
    {
        this.azureStorage = azureStorage;
    }
    public Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {  
        ArgumentNullException.ThrowIfNull(request.File);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Title);
        var postId = Guid.NewGuid().ToString();
        var file = request.File.OpenReadStream();
        azureStorage.UploadFile(postId, file);
        return Task.CompletedTask;
    }
}