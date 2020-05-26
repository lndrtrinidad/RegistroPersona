using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPersonas.Entidades
{
   public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombres = string.Empty;
        }
    }
}
