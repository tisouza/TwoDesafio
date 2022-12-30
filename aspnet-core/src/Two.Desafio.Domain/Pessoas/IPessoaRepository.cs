using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two.Desafio.Authors;
using Volo.Abp.Domain.Repositories;

namespace Two.Desafio.Pessoas
{
    public interface IPessoaRepository : IRepository<Pessoa, Guid>
    {

        Task<Pessoa> FindByNameAsync(string name);

        Task<Pessoa> FindByStringAsync(string filter);

        Task<List<Pessoa>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
