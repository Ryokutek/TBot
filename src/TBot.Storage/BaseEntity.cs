using System.ComponentModel.DataAnnotations;

namespace TBot.Storage;

public class BaseEntity
{
    private Guid _id;
    [Key]
    public virtual Guid Id {
        get {
            _id = _id == Guid.Empty ? Guid.NewGuid() : _id;
            return _id;
        }
        set => _id = value;
    }

    public virtual DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}