namespace CalculadoraDebitos.DTO
{
    public class ResultadoCalculo
    {
        public decimal Principal { get; set; }

        public decimal CorrecaoUffi { get; set; }

        public decimal CorrecaoSelic { get; set; }

        public decimal Multa { get; set; }

        public decimal Total { get; set; }

        public List<ItemSelic> MemoriaSelic { get; set; } = new();
        public List<ItemUffi> MemoriaUffi { get; set; } = new();
    }
}
