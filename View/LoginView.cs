namespace View
{
    public static class LoginView
    {
        public static string SolicitarNome()
        {
            Console.Write("Digite seu nome: ");
            string? nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido. Encerrando...");
                Environment.Exit(0);
            }

            return nome!.Trim();
        }
    }
}
