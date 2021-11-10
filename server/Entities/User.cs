using System.Text.Json.Serialization;

namespace server.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }

		[JsonIgnore]
        public string Password { get; set; }
    }
}
