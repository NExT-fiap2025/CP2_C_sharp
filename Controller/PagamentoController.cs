using System;
using Service;

namespace Controller
{
    public class PagamentoController
    {
        private readonly PagamentoService _service = new();
        private readonly int _usuarioId;

        public PagamentoController(int usuarioId)
        {
            _usuarioId = usuarioId;
        }

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

            _service.SalvarPagamento("Cartão", valor, "concluído", numero, _usuarioId);

            Console.WriteLine($"Pagamento CONCLUÍDO com cartão. ID Transação: {idTransacao}");
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

            _service.SalvarPagamento("Boleto", valor, "pendente", codigo, _usuarioId);

            Console.WriteLine($"Pagamento registrado como PENDENTE com boleto. ID Transação: {idTransacao}");
        }

        public void VerPagamentos()
        {
            _service.ListarPagamentosDoUsuario(_usuarioId);
        }
    }
}
