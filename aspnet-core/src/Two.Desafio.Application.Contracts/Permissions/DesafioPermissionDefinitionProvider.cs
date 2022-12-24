using Two.Desafio.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Two.Desafio.Permissions;

public class DesafioPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DesafioPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DesafioPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DesafioResource>(name);
    }
}
