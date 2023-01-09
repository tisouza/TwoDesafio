using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two.Desafio.Authors;
using Two.Desafio.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;

namespace Two.Desafio.Pessoas
{
    [Audited]
    public class PessoaAppService : DesafioAppService, IPessoaAppService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly PessoaManager _pessoaManager;
        private readonly IBlobContainer _blobContainer;

        public PessoaAppService(PessoaManager pessoaManager, IPessoaRepository pessoaRepository, IBlobContainer blobContainer)
        {
            _pessoaManager = pessoaManager;
            _pessoaRepository = pessoaRepository;
            _blobContainer = blobContainer;
        }
        
        [Authorize(DesafioPermissions.Pessoas.Create)]
        public async Task<PessoaDto> CreateAsync(CreatePessoaDto input)
        {
            var pessoa = await _pessoaManager.CreateAsync(
                    input.Name,
                    input.BirthDate,
                    input.Email,
                    input.Job
                );

            await _pessoaRepository.InsertAsync(pessoa);
            
            if(input.File != null)
                await _blobContainer.SaveAsync(pessoa.Id.ToString(), 
                Convert.FromBase64String(input.File.Substring(input.File.LastIndexOf("base64,")).Replace("base64,", "")));
            return ObjectMapper.Map<Pessoa, PessoaDto>(pessoa);
        }

        [Authorize(DesafioPermissions.Pessoas.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _pessoaRepository.DeleteAsync(id);
        }

        public async Task<PessoaDto> GetAsync(Guid id)
        {

            var pessoa = await _pessoaRepository.GetAsync(id);
            return ObjectMapper.Map<Pessoa, PessoaDto>(pessoa);
        }
        [Audited]
        public async Task<PagedResultDto<PessoaDto>> GetListAsync(GetPessoaListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Pessoa.Name);
            }

            var pessoas = await _pessoaRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _pessoaRepository.CountAsync()
                : await _pessoaRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<PessoaDto>(
                totalCount,
                ObjectMapper.Map<List<Pessoa>, List<PessoaDto>>(pessoas)
            );
        }

        [Authorize(DesafioPermissions.Pessoas.Edit)]
        public async Task UpdateAsync(Guid id, UpdatePessoaDto input)
        {
            var pessoa = await _pessoaRepository.GetAsync(id);

            if(!string.IsNullOrEmpty(input.Email))
                await _pessoaManager.ChangeEmailAsync(pessoa, input.Email);

            if(!string.IsNullOrEmpty(input.Name))
                await _pessoaManager.ChangeNameAsync(pessoa, input.Name);

            pessoa.Job = input.Job;
            pessoa.BirthDate = input.BirthDate;

            await _pessoaRepository.UpdateAsync(pessoa);
        }
    }
}
