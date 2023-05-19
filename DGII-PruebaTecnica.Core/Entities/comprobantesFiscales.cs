namespace DGII_PruebaTecnica.Core.Entities
{
    public class comprobantesFiscales : EntityBase
    {
        public string NCF { get; set; } 
        public decimal monto { get; set; }  
        public decimal itebis18 { get; set; }   
        public int contribuyenteId { get; set; }
        
        public contribuyente contribuyente { get; set; }
    }
}
