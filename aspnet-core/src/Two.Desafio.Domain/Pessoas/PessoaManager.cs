using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Two.Desafio.Authors;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Two.Desafio.Pessoas
{
    public class PessoaManager: DomainService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaManager(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            [NotNull] string email,
            [CanBeNull] string job = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(email, nameof(email));


            var existingPessoa = await _pessoaRepository.FindByNameAsync(name);
            if (existingPessoa != null)
            {
                throw new PessoaNomeAlreadyExistsException(name);
            }

            existingPessoa = await _pessoaRepository.FirstOrDefaultAsync(x => x.Email == email);
            if (existingPessoa != null)
            {
                throw new PessoaEmailAlreadyExistsException(email);
            }

            if ((DateTime.Now.Subtract(birthDate).Days) / 365 < 18)
            {
                throw new PessoaMenorIdadeException(birthDate);

            }

            return new Pessoa(
                GuidGenerator.Create(),
                name,
                birthDate,
                email,
                job
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Pessoa pessoa,
            [NotNull] string newName)
        {
            Check.NotNull(pessoa, nameof(pessoa));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAuthor = await _pessoaRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != pessoa.Id)
            {
                throw new PessoaNomeAlreadyExistsException(newName);
            }

            pessoa.ChangeName(newName);
        }

        public async Task ChangeEmailAsync(
            [NotNull] Pessoa pessoa,
            [NotNull] string newEmail)
        {
            Check.NotNull(pessoa, nameof(pessoa));
            Check.NotNullOrWhiteSpace(newEmail, nameof(newEmail));

            var existingAuthor = await _pessoaRepository.FirstOrDefaultAsync(x => x.Email == newEmail);
            if (existingAuthor != null && existingAuthor.Id != pessoa.Id)
            {
                throw new PessoaEmailAlreadyExistsException(newEmail);
            }

            pessoa.ChangeEmail(newEmail);
        }
    }
}
