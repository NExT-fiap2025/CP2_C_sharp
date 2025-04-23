using Microsoft.Data.Sqlite;

namespace Db
{
    public static class DbService
    {
        private static readonly string DbPath = "pagamentos.db";

        public static void Inicializar()
        {
            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS usuarios (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nome TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS pagamentos (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    tipo TEXT NOT NULL,
                    valor REAL NOT NULL,
                    status TEXT NOT NULL,
                    dados TEXT,
                    data TEXT NOT NULL,
                    usuario_id INTEGER,
                    FOREIGN KEY(usuario_id) REFERENCES usuarios(id)
                );
            ";
            cmd.ExecuteNonQuery();
        }

        public static SqliteConnection ObterConexao()
        {
            return new SqliteConnection($"Data Source={DbPath}");
        }
    }
}
