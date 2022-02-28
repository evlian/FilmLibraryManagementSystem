using System.Text.Json.Serialization;

namespace FilmLibraryManagementSystem.Model.Entitites
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
