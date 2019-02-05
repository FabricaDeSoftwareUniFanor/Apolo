using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApoloWebApp.Data
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Occupation { get; set; }
    }
}
