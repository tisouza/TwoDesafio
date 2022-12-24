using Two.Desafio.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Two.Desafio.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DesafioEntityFrameworkCoreModule),
    typeof(DesafioApplicationContractsModule)
    )]
public class DesafioDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
