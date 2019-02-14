using ApoloWebApi.Data.VO;

namespace ApoloWebApi.Data
{
    public interface IPersonRepository
    {
        void AddPerson(string userId, Person person);
        void UpdatePerson(Person person, InputModelPerson input);
        Person GetPersonById(int? id);
        Person GetPersonByUserId(string id);
        string GetRoleName(ApplicationUser user);
    }
}
