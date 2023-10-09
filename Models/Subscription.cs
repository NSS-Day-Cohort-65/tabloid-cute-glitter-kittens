using Tabloid.Models;

public class Subscription
{
    public int Id { get; set; }
    public int SubscriberUserProfileId { get; set; }
    public UserProfile SubscriberUserProfile { get; set; }
    public int ProviderUserProfileId { get; set; }
    public UserProfile ProviderUserProfile { get; set; }
    public DateTime BeginDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}