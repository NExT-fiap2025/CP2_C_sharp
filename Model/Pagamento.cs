using System;

namespace Model
{
    public class Pagamento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public string Dados { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
    }
}
