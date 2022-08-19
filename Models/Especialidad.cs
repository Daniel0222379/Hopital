using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models{
    public class Especialidad{

        [Key]
        public int IdEspecialidad{get;set;}

        public string Nombre{get;set;}

        public List<MedicoEspecialidad> MedicoEspecialidad{get;set;}
        
    }
}