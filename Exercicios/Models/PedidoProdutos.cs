namespace Exercicios.Models
{
    public class PedidoProdutos
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

    }
}
