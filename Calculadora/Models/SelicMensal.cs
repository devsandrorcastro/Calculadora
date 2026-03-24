namespace CalculadoraDebitos.Models
{
    public class SelicMensal
    {
        public int Id { get; set; }

        public DateTime Competencia { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public decimal PercentualMensal { get; set; }
    }
}
