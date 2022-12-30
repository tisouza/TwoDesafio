using Volo.Abp;

namespace Two.Desafio.Pessoas
{
    public class PessoaNomeAlreadyExistsException : BusinessException
    {
        public PessoaNomeAlreadyExistsException(string name)
            : base(DesafioDomainErrorCodes.PessoaNomeAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
