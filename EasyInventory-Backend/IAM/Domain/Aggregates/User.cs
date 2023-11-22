using System.Text.Json.Serialization;
using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;

namespace EasyInventory_Backend.IAM.Domain.Aggregates;

public class User
{
    public  User()
    {
        Username = string.Empty;
        PasswordHash = string.Empty;
    }
    public  User(string username, string passwordHash,int profileId):this()
    {
        this.Username = username;
        this.PasswordHash = passwordHash;
        this.ProfileId = profileId;
    }

    public int Id { get; set; }
    public Profile Profile { get; set; }
    public int ProfileId { get; set; }
    public string Username { get; set; }
    [JsonIgnore]
    public string PasswordHash { get;private set; }

    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }


    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
    
    
}