using System.ComponentModel.DataAnnotations;

namespace ProductManagementApp.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do produto não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [StringLength(200, ErrorMessage = "A descrição não pode ter mais de 200 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [System.ComponentModel.DataAnnotations.Range(0.01, 999999.99, ErrorMessage = "O preço deve ser entre 0,01 e 999999,99.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        [System.ComponentModel.DataAnnotations.Range(0, 10000, ErrorMessage = "A quantidade em estoque deve ser entre 0 e 10.000.")]
        public int QuantidadeEmEstoque { get; set; }
    }
}
