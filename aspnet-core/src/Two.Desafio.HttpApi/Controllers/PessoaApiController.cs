using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two.Desafio.Pessoas;
using Volo.Abp.Application.Dtos;

namespace Two.Desafio.Controllers
{
    [Route("/api/pessoaapi")]
    public class PessoaApiController:DesafioController
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaApiController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }
        [HttpGet]
        public async Task<PagedResultDto<PessoaDto>> GetList()
        {
            var getListDto = new GetPessoaListDto
            {
                SkipCount = 10,
                MaxResultCount = 100
            };
            var retorno =  await _pessoaAppService.GetListAsync(getListDto);
            return retorno;
        }
    }
}
