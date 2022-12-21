using API.Models.DTO.UserAPI;

namespace API.Tools
{
    public interface ITokenManager
    {
        string GenerateJWTUser(User client);
    }
}
