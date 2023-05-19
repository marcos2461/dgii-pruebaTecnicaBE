using System.ComponentModel.DataAnnotations.Schema;

namespace DGII_PruebaTecnica.Core.Entities
{
    public class contribuyente : EntityBase
    {
        public string nombre { get; set; }
        public string apellido { get; set; }    
        public int tipoIdentificacionId { get; set; }   
        public string numeroIdentificacion { get; set; }    
        public bool estatus { get; set; }
        public int tipoContribuyenteId { get; set; }
        public tipoIdentificacion tipoIdentificacion { get; set; }
        public tipoContribuyente tipoContribuyente { get; set; }
        [NotMapped]
        public List<comprobantesFiscales> comprobantesFiscales { get; set; }

    }
}
