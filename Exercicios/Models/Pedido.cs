namespace Exercicios.Models
{
    public class Pedido
    {
        public int PId { get; set; }
        public string Endereco { get; set; }
        public string Status { get; set; }

        public string MetodoPagamento { get; set; }

        public int? UId { get; set; }
        public virtual Usuario Usuario { get; set; }


    }
}
