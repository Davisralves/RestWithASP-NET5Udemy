using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
        User ValidadeteCredentials(UserVO user);

        User ValidadeteCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}
