using Two.Desafio.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Two.Desafio;

[DependsOn(
    typeof(DesafioEntityFrameworkCoreTestModule)
    )]
public class DesafioDomainTestModule : AbpModule
{

}
