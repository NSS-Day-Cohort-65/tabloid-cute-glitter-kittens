public class PostTag
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}