namespace PimEstoque.Models
{   public class Produto
{
    public int Id { get; set; }
    public string PartNumber { get; set; } = string.Empty;
    public string NomeProduto { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
}
}