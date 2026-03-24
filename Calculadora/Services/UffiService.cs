using CalculadoraDebitos.Data;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraDebitos.Services
{
    public class UffiService
    {
        private readonly AppDbContext _context;

        public UffiService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> CalcularFator(
            DateTime vencimento,
            DateTime pagamento)
        {
            int anoVenc = vencimento.Year;
            int anoPag = pagamento.Year;

            var uffiVenc = await _context.UffiAnual
                .Where(x => x.Ano == anoVenc)
                .Select(x => x.Valor)
                .FirstAsync();

            var uffiPag = await _context.UffiAnual
                .Where(x => x.Ano == anoPag)
                .Select(x => x.Valor)
                .FirstAsync();

            return uffiPag / uffiVenc;
        }
        public async Task<decimal> UffiNoAnoDaDataVencimento(
           DateTime vencimento
           )
        {
            int anoVenc = vencimento.Year;
            

            var uffiVenc = await _context.UffiAnual
                .Where(x => x.Ano == anoVenc)
                .Select(x => x.Valor)
                .FirstAsync();

            
            return uffiVenc;
        }
        public async Task<decimal> UffiNoAnoDaDataPagamento(
           DateTime pagamento)
        {
            int anoPag = pagamento.Year;

            
            var uffiPag = await _context.UffiAnual
                .Where(x => x.Ano == anoPag)
                .Select(x => x.Valor)
                .FirstAsync();

            return uffiPag ;
        }
    }
}
