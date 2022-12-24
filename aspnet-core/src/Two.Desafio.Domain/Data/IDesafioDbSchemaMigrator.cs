using System.Threading.Tasks;

namespace Two.Desafio.Data;

public interface IDesafioDbSchemaMigrator
{
    Task MigrateAsync();
}
