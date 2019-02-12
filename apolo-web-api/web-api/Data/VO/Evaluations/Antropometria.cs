using System;

namespace ApoloWebApi.Data.VO.Evaluations
{
    public class Antropometria
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Person Patient { get; set; }
        public DateTime Date { get; set; }

        /*
         A Antropometria tem campos exclusivos para pacientes do sexo Masculino e Feminino         
        */

        //Perímetros
        public float BracoDRelaxado { get; set; }
        public float BracoERelaxado { get; set; }
        public float BracoDContraido { get; set; }
        public float BracoEContraido { get; set; }
        public float ToraxMesmoEsternal { get; set; } //masculino
        public float ToraxLinhaMamilos { get; set; }
        public float Cintura { get; set; } //masculino
        public float CinturaUmbilical { get; set; } //feminino
        public float CinturaMenorP { get; set; } //feminino
        public float Quadril { get; set; }
        public float CoxaD { get; set; }
        public float CoxaE { get; set; }
        public float PanturrilhaD { get; set; }
        public float PanturrilhaE { get; set; }

        //Dobras
        public float Biceps { get; set; }
        public float Triceps { get; set; }
        public float Subescapular { get; set; }
        public float AxilaMedia { get; set; }
        public float Peitoral { get; set; }
        public float Abdominal { get; set; }
        public float SupraIliaca { get; set; }
        public float Coxa { get; set; }
        public float Panturrilha { get; set; }

        //Outros
        public float Estatura { get; set; }
        public float Peso { get; set; }
        public float DiametroRadio { get; set; }
        public float DiametroFemur { get; set; }

        //Resultados
        public float Gordura { get; set; }
        public float JacksonPollock { get; set; } //feminino
        public float PesoGordura { get; set; }
        public float MassaMagra { get; set; }
        public float PesoResidual { get; set; }
        public float PesoOsseo { get; set; }
        public float PesoMuscular { get; set; }
        public float TonicidadeMusc { get; set; }
        public float IMC { get; set; }
        public float IMCMin { get; set; }
        public float IMCMed { get; set; }
        public float IMCMax { get; set; }

        //Distribuição Gordura Corporal  
    }
}
