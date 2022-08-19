using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models{


    public class Medico{

        [Key]
        public int IdMedico{get;set;}
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Nombre{get;set;}
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Apellido{get;set;}
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Cedula{get;set;}

        public List<MedicoEspecialidad> MedicoEspecialidad{get;set;}
        public List<AtencionMedico> AtencionMedico{get;set;}

        
    }
}