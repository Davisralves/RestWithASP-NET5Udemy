using Microsoft.EntityFrameworkCore.Internal;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
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
    }
}
