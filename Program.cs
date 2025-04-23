// Program.cs
using View;
using Controller;
using Service;
using Db;

class Program
{
    static void Main(string[] args)
    {
        DbService.Inicializar();

        var usuarioService = new UsuarioService();
        var pagamentoService = new PagamentoService();
        var loginController = new LoginController(usuarioService);

        string nome = LoginView.SolicitarNome();
        int usuarioId = loginController.Autenticar(nome);

        Console.WriteLine($"Login efetuado com sucesso! ID do usuário: {usuarioId}");
        pagamentoService.ListarPagamentosPendentes(usuarioId);

        var controller = new PagamentoController(usuarioId);

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
                case 3: controller.VerPagamentos(); break;
                case 4: Console.WriteLine("Encerrando..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

            Console.WriteLine();

        } while (opcao != 4);
    }
}