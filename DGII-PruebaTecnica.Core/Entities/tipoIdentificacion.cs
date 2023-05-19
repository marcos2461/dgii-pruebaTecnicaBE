using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DGII_PruebaTecnica.Core.Entities
{
    public class tipoIdentificacion : EntityBase
    {
        public string descripcion { get; set; }
        [JsonIgnore]
        [NotMapped]
        public List<contribuyente> contribuyes { get;set; }
    }
}
