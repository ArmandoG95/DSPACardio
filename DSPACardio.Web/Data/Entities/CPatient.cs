﻿using System;

namespace DSPACardio.Web.Data.Entities
{
    public class CPatient
    {

        //relacion de asoacion binarioa unidireccional
        //Ya no hereda de user ahora usa esto
        public CUser User { get; set; }
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        
    }
}
