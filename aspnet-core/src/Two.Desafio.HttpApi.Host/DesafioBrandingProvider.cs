using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Two.Desafio;

[Dependency(ReplaceServices = true)]
public class DesafioBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Desafio";
}
