using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Two.Desafio.Data;
using Volo.Abp.DependencyInjection;

namespace Two.Desafio.EntityFrameworkCore;

public class EntityFrameworkCoreDesafioDbSchemaMigrator
    : IDesafioDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDesafioDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the DesafioDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DesafioDbContext>()
            .Database
            .MigrateAsync();
    }
}
