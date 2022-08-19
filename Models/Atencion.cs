
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace Hospital.Models{


    public enum Estado{
        Verde,
        Amarilla,
        Roja
    }

    public class Atencion{

        [Key]
        public int IdAtencion{get;set;}

        [DisplayName("Paciente")]
        public string NombrePaciente{get;set;}

        [DisplayName("Medicamento")]
        public string NombreMedicamento{get;set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:d-M-yyyy}")]
        public DateTime Fecha { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:h:mm tt}")]
        public DateTime Hora { get; set;}

        public Estado Categoria{get;set;}

        public List<AtencionMedico> AtencionMedico{get;set;} 

        
       

       

        


    }
}