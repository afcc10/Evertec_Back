using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column("FotoUsuario")]
        public byte[] FotoUsuario { get; set; }

        [Column("EstadoCivil")]
        public int EstadoCivil { get; set; }

        [Column("TieneHermanos")]
        public bool TieneHermanos { get; set; }
    }
}
