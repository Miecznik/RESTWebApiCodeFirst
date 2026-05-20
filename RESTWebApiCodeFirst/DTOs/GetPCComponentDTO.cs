namespace RESTWebApiCodeFirst.DTOs;

public class GetPCComponentDTO
{
    
    public string ComponentCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Amount { get; set; }

}