
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Two.Desafio.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Two.Desafio.Pessoas
{
    public class EfCorePessoaRepository
        : EfCoreRepository<DesafioDbContext, Pessoa, Guid>,
            IPessoaRepository
    {
        public EfCorePessoaRepository(
            IDbContextProvider<DesafioDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Pessoa> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(pessoa => pessoa.Name == name);
        }

        public async Task<Pessoa> FindByStringAsync(string filter)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(pessoa => pessoa.Name == filter || pessoa.Email == filter);
        }

        

        public async Task<List<Pessoa>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    pessoa => pessoa.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
