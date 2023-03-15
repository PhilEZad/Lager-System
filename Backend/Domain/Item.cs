namespace Domain;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int Status { get; set; }
    public Category Category { get; set; }
}