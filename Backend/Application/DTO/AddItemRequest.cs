namespace Application.DTO;

public class AddItemRequest
{
    public AddItemRequest() { }
    public AddItemRequest(string name){
        this.Name = name;
    }
    public string Name;
}