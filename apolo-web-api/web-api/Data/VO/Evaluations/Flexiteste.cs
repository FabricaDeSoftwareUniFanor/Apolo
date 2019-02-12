using System;

namespace ApoloWebApi.Data.VO.Evaluations
{
    public class Flexiteste
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Person Patient { get; set; }        
        public DateTime Date { get; set; }

        public int FlexaoQuadril { get; set; }
        public int ExtensaoQuadril { get; set; }
        public int AbducaoQuadril { get; set; }
        public int FlexaoTronco { get; set; }
        public int FlexaoLatTronco { get; set; }
        public int ExtensaoAducaoTronco { get; set; }
        public int AducaoPostOmbro { get; set; }
        public int ExtensaoPostOmbro { get; set; }
        public int Indice { get; set; }        
    }
}
