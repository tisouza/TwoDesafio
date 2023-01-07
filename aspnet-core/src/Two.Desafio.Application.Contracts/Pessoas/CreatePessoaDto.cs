using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Two.Desafio.Localization;
using Volo.Abp.Localization;

namespace Two.Desafio.Pessoas
{
    public class CreatePessoaDto
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

        public string File { get; set; }



    }
}
