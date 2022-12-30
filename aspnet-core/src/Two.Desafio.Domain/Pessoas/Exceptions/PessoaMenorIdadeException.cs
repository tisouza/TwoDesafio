using System;
using Volo.Abp;

namespace Two.Desafio.Pessoas
{
    public class PessoaMenorIdadeException : BusinessException
    {
        public PessoaMenorIdadeException(DateTime data)
            : base(DesafioDomainErrorCodes.PessoaMenorIdade)
        {
            
        }
    }
}
