using Volo.Abp;

namespace Two.Desafio.Pessoas
{
    public class PessoaEmailAlreadyExistsException : BusinessException
    {
        public PessoaEmailAlreadyExistsException(string email)
            : base(DesafioDomainErrorCodes.PessoaEmailAlreadyExists)
        {
            WithData("email", email);
        }
    }
}
