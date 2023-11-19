using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForensicBones2.Models
{
    [Table("InventariosEsqueleto")]
    public class InventarioEsqueleto
    {
        [ForeignKey("Relatorio")]
        public int InventarioEsqueletoId { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }


        [Display(Name = "Código do Relatório")]
        public int RelatorioId { get; set; }

        [ForeignKey("RelatorioId")]
        public Relatorio Relatorio { get; set; }
        


        //[Display(Name = "Id Inventário do Crânio")]
        //public int InventarioCranioId { get; set; }

        //[ForeignKey("InventarioCranio")]
        //public InventarioCranio InventarioCranio { get; set; }


    }
}
