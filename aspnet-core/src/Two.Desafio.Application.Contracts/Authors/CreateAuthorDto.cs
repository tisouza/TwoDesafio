using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using Two.Desafio.Localization;

namespace Two.Desafio.Authors
{
    public class CreateAuthorDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]        
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}
