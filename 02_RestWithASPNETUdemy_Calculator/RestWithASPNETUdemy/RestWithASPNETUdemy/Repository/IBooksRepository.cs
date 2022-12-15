using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBooksRepository
    {
        Books Create(Books books);
        Books Update(Books books);
        void Delete(int id);
        Books FindById(int id);

        List<Books> FindAll();
    }
}
