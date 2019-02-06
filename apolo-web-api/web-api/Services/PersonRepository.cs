using ApoloWebApi.Data;

namespace ApoloWebApi.Services
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
            _context.Pessoas.Add(newPerson);
            _context.SaveChanges();
        }
    }
}
