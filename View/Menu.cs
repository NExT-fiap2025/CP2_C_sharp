namespace View
{
    public static class Menu
    {
        public static void ExibirMenu()
        {
            Console.WriteLine("***** Sistema de Processamento de Pagamentos *****");
            Console.WriteLine("********** Escolha a forma de pagamento **********");
            Console.WriteLine("1 - Cartão");
            Console.WriteLine("2 - Boleto");
            Console.WriteLine("3 - Ver pagamentos");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
        }

    }
}
