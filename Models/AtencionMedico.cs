namespace Hospital.Models{

    public class AtencionMedico{

        public int IdAtencion{get;set;}

        public int IdMedico{get;set;}

        public Atencion Atencion{get;set;}

        public Medico Medico{get;set;}
    }
}