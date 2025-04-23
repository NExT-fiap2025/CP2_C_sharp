using System;
using Service;

namespace Controller
{
    public class PagamentoController
    {
        private readonly PagamentoService _service = new();
        private readonly int usuarioId = 1; // Simula��o

        public void ProcessarCartao()
        {
            Console.Write("Informe o n�mero do cart�o: ");
            string numero = Console.ReadLine();

            Console.Write("Informe o valor do pagamento: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inv�lido.");
                return;
            }

            string idTransacao = _service.SimularTransacao("cartao");
            _service.SalvarPagamento("Cart�o", valor, "conclu�do", numero, usuarioId);

            Console.WriteLine($"Pagamento processado com cart�o. ID Transa��o: {idTransacao}");
        }

        public void ProcessarBoleto()
        {
            Console.Write("Informe o c�digo de barras: ");
            string codigo = Console.ReadLine();

            Console.Write("Informe o valor do pagamento: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inv�lido.");
                return;
            }

            string idTransacao = _service.SimularTransacao("boleto");
            _service.SalvarPagamento("Boleto", valor, "conclu�do", codigo, usuarioId);

            Console.WriteLine($"Pagamento processado com boleto. ID Transa��o: {idTransacao}");
        }
    }
}
