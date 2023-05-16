namespace SocialConnect.Model
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHashBase64 { get; set; }
        public string PasswordSaltBase64 { get; set; }
    }
}
