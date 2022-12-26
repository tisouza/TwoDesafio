
using Volo.Abp.Application.Dtos;

namespace Two.Desafio.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
