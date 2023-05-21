using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPecas.Models
{
    [Table("Produto")]
    public class CadastroModel
    {
        [Column("id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Marca")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Column("Modelo")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Column("Peça")]
        [Display(Name = "Peça")]
        public string Peca { get; set; }
    }
}
