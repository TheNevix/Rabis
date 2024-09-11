namespace Rabis.Api.Dtos.User.Requests
{
    public class UpdateUserRequest
    {
        public required Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
