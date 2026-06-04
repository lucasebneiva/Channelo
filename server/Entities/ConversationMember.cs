namespace server.Entities;
public class ConversationMember
{
    public Guid ConversationId { get; set; }
    public Guid UserId { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Conversation Conversation { get; set; } = null!;
    public User User { get; set; } = null!;
}