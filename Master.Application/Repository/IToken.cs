using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IToken
    {
        public string GenerateToken(LoginDTO details);
    }
}
