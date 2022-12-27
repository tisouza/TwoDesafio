

using System;
using Volo.Abp.Application.Dtos;

namespace Two.Desafio.Books
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
