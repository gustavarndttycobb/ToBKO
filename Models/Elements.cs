public class Elements
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Elements>? Children { get; set; }
    public string? ParentId { get; set; }
}