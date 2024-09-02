using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class UsuarioService
    {
        private UsuarioRepository _usuarioRepository;
        private PasswordService _passwordService;
        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
            _passwordService = new PasswordService();
        }

        public ResultadoOperacao ValidarLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Username e senha são obrigatórios." };
            }

            string passwordHash = _passwordService.GerarSenhaHash(password);
            Usuario user = _usuarioRepository.GetUsuarioByUsername(username);

            if (user == null || user.Password != passwordHash)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Usuário ou senha incorretos" };
            } else
            {
                return new ResultadoOperacao { Sucesso = true };
            }
        }

        public ResultadoOperacao InserirUsuario(string nomeCompleto, string username, string password, string passwordRepetida)
        {
            if (string.IsNullOrEmpty(nomeCompleto))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "O campo usuário é obrigatório."};
            }
            if (string.IsNullOrEmpty(username))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "O campo username é obrigatório." };
            }
            if (string.IsNullOrEmpty(password))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "O campo senha é obrigatório." };
            }
            if (string.IsNullOrEmpty(passwordRepetida) || password != passwordRepetida)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "As senhas não conferem." };
            }

            string passwordHash = _passwordService.GerarSenhaHash(password);

            if (_usuarioRepository.CreateUsuario(nomeCompleto, username, passwordHash))
            {
                return new ResultadoOperacao { Sucesso = true };
            } else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Falha na criação do usuário."};
            }
        }
    }
}
