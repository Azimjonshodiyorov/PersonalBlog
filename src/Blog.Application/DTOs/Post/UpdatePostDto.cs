namespace Blog.Application.DTOs.Post;

public class UpdatePostDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public long UserId { get; set; }
    public List<PostFileDto> PostFiles { get; set; }
}