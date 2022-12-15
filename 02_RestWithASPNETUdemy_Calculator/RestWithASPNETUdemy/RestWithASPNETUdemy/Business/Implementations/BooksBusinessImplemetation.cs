using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BooksBusinessImplemetation : IBooksBusiness
    {
        private readonly IBooksRepository _repository;

        public BooksBusinessImplemetation(IBooksRepository repository)
        {
            _repository = repository;
        }

        public Books Create(Books books)
        {
            return _repository.Create(books);
        }

        public Books FindByID(int id)
        {
            return _repository.FindById(id);
        }

        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books Update(Books books)
        {
            return _repository.Update(books);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
