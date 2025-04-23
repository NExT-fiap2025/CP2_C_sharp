using System;
using Microsoft.Data.Sqlite;
using Db;

namespace Service
{
    public class PagamentoService
    {
        public string SimularTransacao(string tipo)
        {
            return tipo.ToUpper()[0] + Guid.NewGuid().ToString("N")[..8].ToUpper(); // Ex: C6A1F8A2
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
    }
}
