namespace ChanneloApi.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<Conversation> CreatedConversations { get; set; } = [];
    public ICollection<ConversationMember> ConversationMembers { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];
}
