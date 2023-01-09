import type { CreatePessoaDto, GetPessoaListDto, PessoaDto, UpdatePessoaDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PessoaService {
  apiName = 'Default';
  

  create = (input: CreatePessoaDto) =>
    this.restService.request<any, PessoaDto>({
      method: 'POST',
      url: '/api/app/pessoa',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/pessoa/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, PessoaDto>({
      method: 'GET',
      url: `/api/app/pessoa/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: GetPessoaListDto) =>    
    this.restService.request<any, PagedResultDto<PessoaDto>>({
      method: 'GET',
      url: '/api/app/pessoa',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: UpdatePessoaDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/pessoa/${id}`,
      body: input,
    },
    { apiName: this.apiName });


  constructor(private restService: RestService, private httpClient : HttpClient) {}
}
