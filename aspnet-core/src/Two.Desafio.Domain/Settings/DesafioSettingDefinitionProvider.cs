using Volo.Abp.Settings;

namespace Two.Desafio.Settings;

public class DesafioSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DesafioSettings.MySetting1));
    }
}
