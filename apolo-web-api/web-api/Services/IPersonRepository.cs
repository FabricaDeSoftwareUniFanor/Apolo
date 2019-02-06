using ApoloWebApi.Data;

namespace ApoloWebApi.Services
{
    public interface IPersonRepository
    {
        void AddPerson(string userId, Person person);
    }
}
