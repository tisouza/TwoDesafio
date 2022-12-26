using AutoMapper;
using Two.Desafio.Authors;
using Two.Desafio.Books;

namespace Two.Desafio;

public class DesafioApplicationAutoMapperProfile : Profile
{
    public DesafioApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();

    }
}
