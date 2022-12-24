using System;
using System.Collections.Generic;
using System.Text;
using Two.Desafio.Localization;
using Volo.Abp.Application.Services;

namespace Two.Desafio;

/* Inherit your application services from this class.
 */
public abstract class DesafioAppService : ApplicationService
{
    protected DesafioAppService()
    {
        LocalizationResource = typeof(DesafioResource);
    }
}
