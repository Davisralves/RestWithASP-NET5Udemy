using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Data.VO.Converter.Implementations;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BooksBusinessImplemetation : IBooksBusiness
    {
        private readonly IRepository<Books> _repository;

        private readonly BookConverter _converter;
        public BooksBusinessImplemetation(IRepository<Books> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO books)
        {
            var bookEntity = _converter.Parse(books);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO Update(BookVO books)
        {
            var bookEntity = _converter.Parse(books);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
