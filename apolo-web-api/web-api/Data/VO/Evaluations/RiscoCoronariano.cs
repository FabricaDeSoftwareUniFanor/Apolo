using System;

namespace ApoloWebApi.Data.VO.Evaluations
{
    public class RiscoCoronariano
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Person Patient { get; set; }
        public DateTime Date { get; set; }

        public int Idade { get; set; }
        public int Sexo { get; set; }
        public int Peso { get; set; }
        public int Tabagismo { get; set; }
        public int ExercicioFisico { get; set; }
        public int PressaoSistolica { get; set; }
        public int Historico { get; set; }
        public int Colesterol { get; set; }
        public int Risco { get; set; }
        public string Comentarios { get; set; }
    }
}
