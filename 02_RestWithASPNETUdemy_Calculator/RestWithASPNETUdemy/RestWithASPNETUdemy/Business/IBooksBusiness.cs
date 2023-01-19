using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBooksBusiness
    {
        BookVO Create(BookVO books);
        BookVO FindByID(int id);
        List<BookVO> FindAll();
        BookVO Update(BookVO books);
        void Delete(int id);
    }
}
