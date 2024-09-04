using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities;

[Table("refresh_token",Schema ="blog")]
public class RefreshToken : BaseEntity
{
    [Column("token")]
    public string Token { get; set; }

    [Column("expires")]
    public DateTime Expires { get; set; }

    [Column("is_expired")]
    public bool IsExpired { get; set; }

    [Column("revoked")]
    public DateTime? Revoked { get; set; }

    [Column("is_active")]
    public bool IsActive ;

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}