using Service;

namespace Controller
{
    public class LoginController
    {
        private readonly UsuarioService _usuarioService;

        public LoginController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public int Autenticar(string nome)
        {
            int usuarioId = _usuarioService.ObterUsuarioPorNome(nome);
            if (usuarioId == -1)
            {
                usuarioId = _usuarioService.CadastrarUsuario(nome);
                Console.WriteLine("Usuário não encontrado. Novo usuário criado.");
            }

            return usuarioId;
        }
    }
}
