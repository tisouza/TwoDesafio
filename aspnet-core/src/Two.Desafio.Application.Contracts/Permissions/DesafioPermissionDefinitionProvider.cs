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
        var booksPermission = myGroup.AddPermission(DesafioPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(DesafioPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(DesafioPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(DesafioPermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = myGroup.AddPermission(
    DesafioPermissions.Authors.Default, L("Permission:Authors"));

        authorsPermission.AddChild(
            DesafioPermissions.Authors.Create, L("Permission:Authors.Create"));

        authorsPermission.AddChild(
            DesafioPermissions.Authors.Edit, L("Permission:Authors.Edit"));

        authorsPermission.AddChild(
            DesafioPermissions.Authors.Delete, L("Permission:Authors.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DesafioResource>(name);
    }
}
