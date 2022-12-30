using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Two.Desafio.Pessoas
{
    public class GetPessoaListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
