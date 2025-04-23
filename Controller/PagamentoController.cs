using System;
using Service;

namespace Controller
{
    public class PagamentoController
    {
        private readonly PagamentoService _service = new();
        private readonly int usuarioId = 1; // Simulação

        public void ProcessarCartao()
        {
            Console.Write("Informe o número do cartão: ");
            string numero = Console.ReadLine();

            Console.Write("Informe o valor do pagamento: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            string idTransacao = _service.SimularTransacao("cartao");
            _service.SalvarPagamento("Cartão", valor, "concluído", numero, usuarioId);

            Console.WriteLine($"Pagamento processado com cartão. ID Transação: {idTransacao}");
        }

        public void ProcessarBoleto()
        {
            Console.Write("Informe o código de barras: ");
            string codigo = Console.ReadLine();

            Console.Write("Informe o valor do pagamento: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            string idTransacao = _service.SimularTransacao("boleto");
            _service.SalvarPagamento("Boleto", valor, "concluído", codigo, usuarioId);

            Console.WriteLine($"Pagamento processado com boleto. ID Transação: {idTransacao}");
        }
    }
}
