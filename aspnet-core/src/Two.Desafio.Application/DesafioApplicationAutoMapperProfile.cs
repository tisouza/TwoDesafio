using AutoMapper;
using Two.Desafio.Authors;
using Two.Desafio.Books;
using Two.Desafio.Pessoas;

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
        CreateMap<Author, AuthorLookupDto>();
        CreateMap<Pessoa, PessoaDto>();
        CreateMap<CreatePessoaDto ,Pessoa>();
        CreateMap<UpdatePessoaDto, Pessoa>();



    }
}
