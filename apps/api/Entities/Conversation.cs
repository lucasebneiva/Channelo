namespace ChanneloApi.Entities;
public class Conversation
{
    public Guid Id { get; set; }
    public string Type { get; set; } = null!;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public User CreatedBy { get; set; } = null!;
    public ICollection<ConversationMember> Members { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];
}