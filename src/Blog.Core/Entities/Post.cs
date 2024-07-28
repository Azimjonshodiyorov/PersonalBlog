﻿using System.Xml.Linq;

namespace Blog.Core.Entities;

public class Post : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int ReadingTime { get; set; }
    public string? Image { get; set; }
    public required DateTime CreateTime { get; set; }
    public Guid? AddressId { get; set; }
    public IList<Tag> Tags { get; set; }
    public IList<Like> Likes { get; set; }
    public IList<Comment> Comments { get; set; }
    public IList<User> FavoriteByUsers { get; set; }

    public User User { get; set; }
    public required Guid UserId { get; set; }

    public Community? Community { get; set; }
    public Guid? CommunityId { get; set; }
}