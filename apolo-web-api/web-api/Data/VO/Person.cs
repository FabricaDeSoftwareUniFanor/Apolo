using System;

namespace ApoloWebApi.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Occupation { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public void Modify(string name, DateTime birthDate, string occupation)
        {
            Name = name;
            BirthDate = birthDate;
            Occupation = occupation;
        }

    }
}
