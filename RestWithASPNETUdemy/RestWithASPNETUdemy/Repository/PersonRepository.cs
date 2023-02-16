using Microsoft.EntityFrameworkCore.Internal;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disable(int id)
        {
            if (!_context.Persons.Any(p => p.Id == id)) return null;
            var user = _context.Persons.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception) { throw; }
            }
            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            string[] names = { firstName, lastName };
            if (SomeNotNull(names.ToList()))
            {
            return _context.Persons.Where(
                p => p.FirstName.Contains(firstName) || p.LastName.Contains(lastName)).ToList();
            }
            return null;
        }

        private static bool SomeNotNull(List<string> names)
        {
            bool namesAreNotEmpty = names.Any(name => !string.IsNullOrWhiteSpace(name));
            return namesAreNotEmpty;
        }
    }
}
