import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreatePessoaDto {
  name: string;
  birthDate: string;
  email: string;
  job?: string;
}

export interface GetPessoaListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface PessoaDto extends EntityDto<string> {
  name?: string;
  birthDate?: string;
  email?: string;
  job?: string;
  file?:any;
}

export interface UpdatePessoaDto {
  name: string;
  birthDate: string;
  email: string;
  job?: string;
}
