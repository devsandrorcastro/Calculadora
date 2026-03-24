namespace CalculadoraDebitos.Models
{
    public class CalculoDebito
    {
        public int Id { get; set; }

        public decimal ValorOriginal { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal ValorCorrigidoUffi { get; set; }

        public decimal ValorSelic { get; set; }

        public decimal ValorTotalAtualizado { get; set; }
    }
}
