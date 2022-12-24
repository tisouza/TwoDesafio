using Two.Desafio.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Two.Desafio.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DesafioController : AbpControllerBase
{
    protected DesafioController()
    {
        LocalizationResource = typeof(DesafioResource);
    }
}
