using System;

namespace ApoloWebApi.Data.VO.Evaluations
{
    public class Anamnese
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Person Patient { get; set; }
        public DateTime Date { get; set; }

        /*
         As respostas das questões da avaliação persistem em SIM/NÃO e um comentário
         Caso a resposta seja SIM haverá um comentário
         -- Se o campo no banco for null, subtende-se que a resposta é NÃO --
         Para não haver campus nulos no banco, cada resposta negativa será registrada com "N"
         */

        public string DistCardiaco { get; set; }
        public string HipertensaoHipotensao { get; set; }
        public string DistPlmonar { get; set; }
        public string DistAlergico { get; set; }
        public string DiabetesHipoglicemia { get; set; }
        public string IntervCirurgica { get; set; }
        public string DoresFrequentes { get; set; }
        public string Eplepsia { get; set; }
        public string ProblArticular { get; set; }
        public string InfluAtvdFisica { get; set; }
        public string Historico { get; set; }
        public string Objetivos { get; set; }
    }
}
