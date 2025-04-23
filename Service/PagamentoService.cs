using System;
using Microsoft.Data.Sqlite;
using Db;

namespace Service
{
    public class PagamentoService
    {
        public string SimularTransacao(string tipo)
        {
            return tipo.ToUpper()[0] + Guid.NewGuid().ToString("N")[..8].ToUpper();
        }

        public void SalvarPagamento(string tipo, decimal valor, string status, string dados, int usuarioId)
        {
            using var connection = DbService.ObterConexao();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO pagamentos (tipo, valor, status, dados, data, usuario_id)
                VALUES ($tipo, $valor, $status, $dados, $data, $usuarioId);
            ";

            cmd.Parameters.AddWithValue("$tipo", tipo);
            cmd.Parameters.AddWithValue("$valor", valor);
            cmd.Parameters.AddWithValue("$status", status);
            cmd.Parameters.AddWithValue("$dados", dados);
            cmd.Parameters.AddWithValue("$data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("$usuarioId", usuarioId);

            cmd.ExecuteNonQuery();
        }

        public void ListarPagamentosDoUsuario(int usuarioId)
        {
            using var connection = DbService.ObterConexao();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT id, tipo, valor, status, dados, data
                FROM pagamentos
                WHERE usuario_id = $usuarioId
                ORDER BY data DESC;
            ";

            cmd.Parameters.AddWithValue("$usuarioId", usuarioId);

            using var reader = cmd.ExecuteReader();
            Console.WriteLine("\n--- Pagamentos Realizados ---");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string tipo = reader.GetString(1);
                decimal valor = reader.GetDecimal(2);
                string status = reader.GetString(3);
                string dados = reader.GetString(4);
                string data = reader.GetString(5);

                Console.WriteLine($"[{id}] {tipo} | R$ {valor:F2} | {status} | Dados: {dados} | Data: {data}");
            }
            Console.WriteLine("------------------------------\n");
        }

        public void ListarPagamentosPendentes(int usuarioId)
        {
            using var connection = DbService.ObterConexao();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT id, tipo, valor, dados, data
                FROM pagamentos
                WHERE usuario_id = $usuarioId AND status = 'pendente'
                ORDER BY data DESC;
            ";

            cmd.Parameters.AddWithValue("$usuarioId", usuarioId);

            using var reader = cmd.ExecuteReader();
            bool temResultados = false;
            Console.WriteLine("\n--- Pagamentos Pendentes ---");
            while (reader.Read())
            {
                temResultados = true;
                int id = reader.GetInt32(0);
                string tipo = reader.GetString(1);
                decimal valor = reader.GetDecimal(2);
                string dados = reader.GetString(3);
                string data = reader.GetString(4);

                Console.WriteLine($"[{id}] {tipo} | R$ {valor:F2} | Dados: {dados} | Data: {data}");
            }

            if (!temResultados)
            {
                Console.WriteLine("Nenhum pagamento pendente. Obrigado!");
            }

            Console.WriteLine("-----------------------------\n");
        }
    }
}
