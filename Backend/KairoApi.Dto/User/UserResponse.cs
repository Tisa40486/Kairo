namespace KairoApi.Dto;

public class UserResponse
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? UserName { get; set; }
    public required bool IsVerified { get; set; }
    public string email { get; set; }
}