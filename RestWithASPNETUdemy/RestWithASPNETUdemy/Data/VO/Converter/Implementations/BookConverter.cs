﻿using RestWithASPNETUdemy.Data.VO.Converter.Contract;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.VO.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Books>, IParser<Books, BookVO>
    {
        public Books Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Books
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title,
            };
        }


        public BookVO Parse(Books origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title,
            };
        }
        public List<Books> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<BookVO> Parse(List<Books> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
