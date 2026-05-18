namespace PimEstoque.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int EnderecoId { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
    }
}