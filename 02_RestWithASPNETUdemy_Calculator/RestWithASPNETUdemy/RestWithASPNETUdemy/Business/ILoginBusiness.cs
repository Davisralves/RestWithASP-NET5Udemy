using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Data.VO.Converter;

namespace RestWithASPNETUdemy.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}
