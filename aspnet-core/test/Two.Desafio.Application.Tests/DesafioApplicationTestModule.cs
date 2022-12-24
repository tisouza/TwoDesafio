using Volo.Abp.Modularity;

namespace Two.Desafio;

[DependsOn(
    typeof(DesafioApplicationModule),
    typeof(DesafioDomainTestModule)
    )]
public class DesafioApplicationTestModule : AbpModule
{

}
