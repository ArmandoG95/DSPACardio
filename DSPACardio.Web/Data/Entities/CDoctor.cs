using System;

namespace DSPACardio.Web.Data.Entities
{
    public class CDoctor
    {
        //relacion de asoacion binarioa unidireccional
        //Ya no hereda de user ahora usa esto
        public CUser User { get; set; }
        public float Salary { get; set; }
        public int Id { get; set; }
        public DateTime Birthday { get; set; }


        
    }
}
