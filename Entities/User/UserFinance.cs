using System.Text.Json.Serialization;

namespace FinanceProject;

public class UserFinance
{
    public long Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string birthdate { get; init; }

    [JsonPropertyName("profile_picture")]
    public string ProfilePicture { get; init; }
}