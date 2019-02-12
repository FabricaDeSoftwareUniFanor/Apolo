using ApoloWebApi.Data.VO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ApoloWebApi.Data
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPerson(string userId, Person person)
        {
            var newPerson = new Person
            {
                Name = person.Name,
                BirthDate = person.BirthDate,
                Occupation = person.Occupation,
                UserId = userId
            };
            _context.Persons.Add(newPerson);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person, InputModelPerson input)
        {
            try
            {
                person.Modify(input.Name, input.BirthDate, input.Occupation);
                _context.Attach(person).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if(!_context.Persons.Any(p => p.Id == person.Id))
                    throw;
            }
        }

        public Person GetPersonById(int? id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person GetPersonByUserId(string id)
        {
            return _context.Persons.FirstOrDefault(p => p.UserId == id);
        }
    }
}
