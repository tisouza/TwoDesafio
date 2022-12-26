using System;
using Two.Desafio.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Two.Desafio.Books
{
    public class BookAppService :
        CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto>, //Used to create/update a book
        IBookAppService //implement the IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {
            GetPolicyName = DesafioPermissions.Books.Default;
            GetListPolicyName = DesafioPermissions.Books.Default;
            CreatePolicyName = DesafioPermissions.Books.Create;
            UpdatePolicyName = DesafioPermissions.Books.Edit;
            DeletePolicyName = DesafioPermissions.Books.Delete;

        }
    }
}
