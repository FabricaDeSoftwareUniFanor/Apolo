using System;

namespace ApoloWebApi.Data.VO.Evaluations
{
    public class AvaliacaoPostural
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Person Patirnt { get; set; }
        public DateTime Date { get; set; }

        /*
        Cada item da avaliação postural possui três ou quatro alternativas
        A resposta será o índice de uma enumeração baseada nas questões
        */

        //Vista Superior
        public int Cabeca { get; set; }
        public int Ombros { get; set; }
        public int CristasIliacas { get; set; }
        public int Jelhos { get; set; }
        public int Pes { get; set; }
        public int Escoliose { get; set; }

        //Vista Lateral
        public int JoelhosLat { get; set; }
        public int Pelve { get; set; }
        public int ColunaLombar { get; set; }
        public int ColunaToracica { get; set; }
        public int OmbrosLat { get; set; }
        
        //Plantigrama
        public int Plantigrama { get; set; }
    }
}
