using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNETUdemy.Services.Implemetations
{
    public class PersonServiceImplemetation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons =  new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
        }


        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlandia",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person name" + i,
                LastName = "Person Lastname" + i,
                Address = "some address" + i,
                Gender = "Male"+ i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
