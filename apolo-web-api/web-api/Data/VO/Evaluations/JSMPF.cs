using System;

namespace ApoloWebApi.Data.VO.Evaluations
{
    public class JSMPF
    {
        public int Id { get; set; }
        public int PatintId { get; set; }
        public Person Patient { get; set; }
        public DateTime Date { get; set; }

        //VO2 Max
        public float FCRepouso { get; set; }
        public float VelTerminoTeste { get; set; }
        public float FCInterrupcao { get; set; }
        public float ResultadoVO2 { get; set; }
        public float Indice { get; set; }

        //Prescrição do treino aeróbico por consumo metabólico
        public float CaloriasGastar { get; set; }
        public float Velocidade60 { get; set; }
        public float Velocidade80 { get; set; }
        public float KcalMin60 { get; set; }
        public float KcalMin80 { get; set; }
        public float TempoGastar60 { get; set; }
        public float TempoGastar80 { get; set; }

        //Prescrição do treino aeróbico pela FC
        public int VezesSemana { get; set; }
        public float LimiteMinFC { get; set; }
        public float LimiteMaxFC { get; set; }
        public float TempoEsteira { get; set; }
        public float VelocEsteira { get; set; }
        public float TempoBicicleta { get; set; }
        public float VelocBicicleta { get; set; }

        public int ValoresTreino { get; set; }
        
        public string Recomendacoes { get; set; }
    }
}
