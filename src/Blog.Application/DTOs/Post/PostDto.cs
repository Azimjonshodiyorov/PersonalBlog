using Blog.Core.Entities;

namespace Blog.Application.DTOs.Post;

public class PostDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDelete { get; set; }
    public DateTime CreateAt { get; set; }
    public long UserId { get; set; }

    public List<PostFileDto> PostFiles { get; set; }
}