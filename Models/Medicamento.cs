using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Hospital.Models{

    public class Medicamento{

        [Key]
        public int IdMedicamento{get;set;}

        public string Nombre{get;set;}

        public string Codigo{get;set;}

        public string Observacion{get;set;}

       

        




        
    }
}