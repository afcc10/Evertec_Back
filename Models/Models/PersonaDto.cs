using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PersonaDto
    {        
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] FotoUsuario { get; set; }

        public int EstadoCivil { get; set; }

        public bool TieneHermanos { get; set; }
    }
}
