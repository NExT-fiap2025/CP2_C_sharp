using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Model;
using Db;

namespace Service
{
    public class UsuarioService
    {
        public int ObterUsuarioPorNome(string nome)
        {
            using var conn = DbService.ObterConexao();
            conn.Open();

            var selectCmd = conn.CreateCommand();
            selectCmd.CommandText = "SELECT id FROM usuarios WHERE LOWER(nome) = LOWER($nome);";
            selectCmd.Parameters.AddWithValue("$nome", nome);

            var result = selectCmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public int CadastrarUsuario(string nome)
        {
            using var conn = DbService.ObterConexao();
            conn.Open();

            var insertCmd = conn.CreateCommand();
            insertCmd.CommandText = "INSERT INTO usuarios (nome) VALUES ($nome); SELECT last_insert_rowid();";
            insertCmd.Parameters.AddWithValue("$nome", nome);

            long novoId = (long)insertCmd.ExecuteScalar();
            Console.WriteLine("Usuário não encontrado. Novo usuário criado.");
            return (int)novoId;
        }

        public List<Usuario> ListarUsuarios()
        {
            var lista = new List<Usuario>();
            using var conn = DbService.ObterConexao();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, nome FROM usuarios;";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                });
            }

            return lista;
        }
    }
}
