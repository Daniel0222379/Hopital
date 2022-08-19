using System.Collections.Generic;
namespace Hospital.Models{

    public class MedicoEspecialidad{

        public int IdEspecialidad{get;set;}
        public int IdMedico{get;set;}
        

        public Medico Medico{get;set;}

        public Especialidad Especialidad{get;set;}
    }
}