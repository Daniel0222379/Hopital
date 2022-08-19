using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Hospital.Models{

    public class Paciente{

        [Key]
        public int IdPaciente{get;set;}

        public string Nombre{get;set;}

        public string Apellido{get;set;}

        public string Cedula{get;set;}

        public string Email{get;set;}

        public string Direccion{get;set;}

       

        

        


        
    }
}