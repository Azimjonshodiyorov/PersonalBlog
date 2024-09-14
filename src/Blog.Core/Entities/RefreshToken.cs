using System.ComponentModel.DataAnnotations.Schema;
using Blog.Core.Common;

namespace Blog.Core.Entities;

[Table("refresh_token",Schema ="blog")]
public class RefreshToken : BaseEntity
{
    [Column("token")]
    public string Token { get; set; }

    [Column("expires")]
    public DateTime Expires { get; set; }

    [NotMapped]
    public bool IsExpired => DateTime.UtcNow >= Expires;

    [Column("revoked")]
    public DateTime? Revoked { get; set; }

    [NotMapped]
    public bool IsActive => Revoked == null && !IsExpired;

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}