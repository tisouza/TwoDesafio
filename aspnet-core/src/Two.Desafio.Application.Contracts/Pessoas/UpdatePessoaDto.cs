using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Two.Desafio.Pessoas
{
    public class UpdatePessoaDto
    {
        [Required]
        [StringLength(PessoaConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(PessoaConsts.MaxEmailLength)]
        public string Email { get; set; }

        [StringLength(PessoaConsts.MaxJobLength)]
        public string Job { get; set; }

    }
}
