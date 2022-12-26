using Volo.Abp;

namespace Two.Desafio.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(DesafioDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
