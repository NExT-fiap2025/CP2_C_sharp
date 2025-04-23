using View;
using Controller;
using Db;

class Program
{
    static void Main(string[] args)
    {
        DbService.Inicializar();

        var controller = new PagamentoController();
        int opcao;

        do
        {
            Menu.ExibirMenu();
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcao)) continue;

            switch (opcao)
            {
                case 1: controller.ProcessarCartao(); break;
                case 2: controller.ProcessarBoleto(); break;
                case 3: Console.WriteLine("Encerrando..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine();

        } while (opcao != 3);
    }
}
