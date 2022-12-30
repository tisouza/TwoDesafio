using JetBrains.Annotations;
using System;
using Two.Desafio.Authors;
using Two.Desafio.Domain.Shared.Books;
using Volo.Abp.Domain.Entities.Auditing;

namespace Two.Desafio.Pessoas
{
    public class Pessoa : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; private set; }

        public string Job { get; set; }
        public Pessoa()
        {

        }
        internal Pessoa(
            Guid id,
            [NotNull] string name,
            DateTime birthDate,
            [NotNull] string email,
            [CanBeNull] string job = null)
            : base(id)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
        }

        internal Pessoa ChangeName([NotNull] string name)
        {
            Name = name;
            return this;
        }

        internal Pessoa ChangeEmail([NotNull] string email){
            Email = email;
            return this;
        }
    }
}
