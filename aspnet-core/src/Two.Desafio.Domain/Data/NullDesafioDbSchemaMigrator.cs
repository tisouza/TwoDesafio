using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Two.Desafio.Data;

/* This is used if database provider does't define
 * IDesafioDbSchemaMigrator implementation.
 */
public class NullDesafioDbSchemaMigrator : IDesafioDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
