using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books books);
        Books FindByID(int id);
        List<Books> FindAll();
        Books Update(Books books);
        void Delete(int id);
    }
}
