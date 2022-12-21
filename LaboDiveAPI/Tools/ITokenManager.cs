using LaboDiveAPI.Models.DTO.UserAPI;

namespace LaboDiveAPI.Tools
{
    public interface ITokenManager
    {
        string GenerateJWTUser(User client);
    }
}
