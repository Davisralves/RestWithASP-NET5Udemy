using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BooksRepositoryImplemetation : IBooksRepository
    {
        private MySQLContext _context;

        public BooksRepositoryImplemetation(MySQLContext context)
        {
            _context = context;
        }

        public Books Create(Books books)
        {
            try
            {
                _context.Add(books);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return books;
        }

        public void Delete(int id)
        {
            var result = _context.Books.SingleOrDefault(book => book.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Books> FindAll()
        {
            return _context.Books.ToList();
        }

        public Books FindById(int id)
        {
            return _context.Books.SingleOrDefault(book => book.Id == id);
        }

        public Books Update(Books books)
        {
            // We check if the person exists in the database
            // If it doesn't exist we return an empty person instance
            if (!Exists(books.Id)) return null;

            // Get the current status of the record in the database
            var result = _context.Books.SingleOrDefault(book => book.Id.Equals(books.Id));
            if (result != null)
            {
                try
                {
                    // set changes and save
                    _context.Entry(result).CurrentValues.SetValues(books);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return books;
        }

        private bool Exists(int id)
        {
            return _context.Books.Any(book => book.Id.Equals(id)); ;
        }
    }
}
