using CalculadoraDebitos.DTO;

namespace CalculadoraDebitos.Services
{
    public class CalculadoraService
    {
        private readonly SelicService _selicService;
        private readonly UffiService _uffiService;
        public CalculadoraService(SelicService selicService, UffiService uffiService)
        {
            _selicService = selicService;
            _uffiService = uffiService;
        }

        public async Task<ResultadoCalculo> Calcular(
            decimal valorPrincipal,
            DateTime vencimento,
            DateTime pagamento)
        {
            var resultado = new ResultadoCalculo();

            resultado.Principal = valorPrincipal;

            // -----------------------------
            // CORREÇÃO UFFI (exemplo fixo)
            // -----------------------------
            //decimal uffiInicio = 117.28m;
            decimal uffiInicio = await _uffiService.UffiNoAnoDaDataVencimento(vencimento);
            //decimal uffiFinal = 122.18m;
            decimal uffiFinal = await _uffiService.UffiNoAnoDaDataPagamento(pagamento);
            decimal valorCorrigido =
                (valorPrincipal / uffiInicio) * uffiFinal;

            resultado.CorrecaoUffi = valorCorrigido - valorPrincipal;

            var memoriaUffi = new List<ItemUffi>();
            memoriaUffi.Add(new ItemUffi
            {
                AnoVenciento = vencimento.Year,
                TaxaAnoVencimento = uffiInicio,
                AnoCorrecao = pagamento.Year,
                TaxaAnoCorrecao = uffiFinal,
                Base=valorPrincipal,
                Taxa = uffiFinal / uffiInicio ,
                Valor = valorCorrigido


            });

            resultado.MemoriaUffi = memoriaUffi;



            // -----------------------------
            // BASE PARA SELIC
            // -----------------------------

            // decimal baseSelic = valorPrincipal + resultado.CorrecaoUffi;
            decimal baseSelic = valorPrincipal ;

            // -----------------------------
            // SELIC
            // -----------------------------

            var (fatorSelic, memoria) =
                await _selicService.CalcularSelic(
                    baseSelic,
                    vencimento,
                    pagamento);

            resultado.MemoriaSelic = memoria;

            // decimal valorComSelic =  baseSelic * fatorSelic;
            decimal valorComSelic = 0;
            foreach (var m in memoria)
            {
                valorComSelic = valorComSelic + m.Valor;

            }

            //resultado.CorrecaoSelic = valorComSelic - baseSelic;
            resultado.CorrecaoSelic = valorComSelic;

            // -----------------------------
            // MULTA 2%
            // -----------------------------

            resultado.Multa =
                valorComSelic * 0.02m;

            // -----------------------------
            // TOTAL
            // -----------------------------

            //resultado.Total = valorComSelic + resultado.Multa;
            resultado.Total = valorComSelic + baseSelic + resultado.CorrecaoUffi;

            return resultado;
        }
    }
}