namespace CalculadoraDebitos.DTO
{
    public class MemoriaUffi
    {
        public int AnoVenciento { get; set; }
        public int AnoCorrecao { get; set; }
        
        public decimal TaxaAnoVencimento { get; set; }
        public decimal TaxaAnoCorrecao { get; set; }
        public decimal Taxa { get; set; }
        public decimal Base { get; set; }
        public decimal Valor { get; set; }
    }
}
