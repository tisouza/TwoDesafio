using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Two.Desafio.Authors;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Two.Desafio.Pessoas
{
    public interface IPessoaAppService : IApplicationService
    {
        Task<PessoaDto> GetAsync(Guid id);

        Task<PagedResultDto<PessoaDto>> GetListAsync(GetPessoaListDto input);

        Task<PessoaDto> CreateAsync(CreatePessoaDto input);

        Task UpdateAsync(Guid id, UpdatePessoaDto input);

        Task DeleteAsync(Guid id);
    }
}
