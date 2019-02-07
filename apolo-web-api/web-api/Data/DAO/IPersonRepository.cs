namespace ApoloWebApi.Data
{
    public interface IPersonRepository
    {
        void AddPerson(string userId, Person person);
    }
}
