namespace KingICTAkademijaSC.Models
{
    public class LoginModel
    {
    }

    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public int expiresInMins { get; set; } = 60;
    }

    public class LoginResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

}
