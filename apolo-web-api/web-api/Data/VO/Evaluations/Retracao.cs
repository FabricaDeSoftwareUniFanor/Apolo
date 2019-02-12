using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApoloWebApi.Data.VO.Evaluations
{
    public class Retracao
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Person Patient { get; set; }
        public DateTime Date { get; set; }

        public int Isquiotibiais { get; set; }
        public int Psoas { get; set; }
        public int Ombros { get; set; }
        public int Peitoral { get; set; }
        public int Lombares { get; set; }        
        public string Comentarios { get; set; }
    }
}
