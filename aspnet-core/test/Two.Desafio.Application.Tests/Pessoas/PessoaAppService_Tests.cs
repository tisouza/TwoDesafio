using System;
using Shouldly;

using System.Threading.Tasks;
using Two.Desafio.Authors;
using Xunit;

namespace Two.Desafio.Pessoas
{
    public class PessoaAppService_Tests : DesafioApplicationTestBase
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaAppService_Tests()
        {
            _pessoaAppService = GetRequiredService<IPessoaAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Pessoas_Without_Any_Filter()
        {
            var result = await _pessoaAppService.GetListAsync(new GetPessoaListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(author => author.Name == "nome 1");
            result.Items.ShouldContain(author => author.Name == "nome 10");
        }

        [Fact]
        public async Task Should_Get_Filtered_Pessoas()
        {
            var result = await _pessoaAppService.GetListAsync(
                new GetPessoaListDto { Filter = "nome 1" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(author => author.Name == "nome 1");
            result.Items.ShouldNotContain(author => author.Name == "nome 2");
        }

        [Fact]
        public async Task Should_Create_A_New_Pessoa()
        {
            var pessoaDto = await _pessoaAppService.CreateAsync(
                new CreatePessoaDto
                {
                    Name = "nome pessoa",
                    BirthDate = new DateTime(1850, 05, 22),
                    Email = "examplepessoa@gmail.com",
                    Job = "job 1"
                }
            );

            pessoaDto.Id.ShouldNotBe(Guid.Empty);
            pessoaDto.Name.ShouldBe("nome pessoa");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Nome_Pessoa()
        {
            await Assert.ThrowsAsync<PessoaNomeAlreadyExistsException>(async () =>
            {
                var pessoaDto = await _pessoaAppService.CreateAsync(
                    new CreatePessoaDto
                    {
                        Name = "nome 1",
                        BirthDate = new DateTime(1971, 03, 22),
                        Email = "examplepessoa@gmail.com",
                        Job = "job 1"
                    }
                );
            });
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Email_Pessoa()
        {
            await Assert.ThrowsAsync<PessoaEmailAlreadyExistsException>(async () =>
            {
                var pessoaDto = await _pessoaAppService.CreateAsync(
                    new CreatePessoaDto
                    {
                        Name = "nome jhgh1",
                        BirthDate = new DateTime(1971, 03, 22),
                        Email = "email1@example.com",
                        Job = "job 1"
                    }
                );
            });
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Pessoa_Menor_Idade()
        {
            await Assert.ThrowsAsync<PessoaMenorIdadeException>(async () =>
            {
                var pessoaDto = await _pessoaAppService.CreateAsync(
                    new CreatePessoaDto
                    {
                        Name = "nome pessoa",
                        BirthDate = new DateTime(2021, 03, 22),
                        Email = "examplepessoa@gmail.com",
                        Job = "job 1"
                    }
                );
            });
        }

        //TODO: Test other methods...
    }
}