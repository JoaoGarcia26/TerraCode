using System.Security.Cryptography;
using System.Text;

namespace TerraCode.Service
{
    public class PasswordService
    {
        public string GerarSenhaHash(string password)
        {
            // Criar uma instância de SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converte a senha em uma matriz de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converte os bytes para uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
