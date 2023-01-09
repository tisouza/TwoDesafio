import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PessoaApiManualService {

  constructor(private readonly httpClient: HttpClient) { }

  buscarPessoas(){
    return this.httpClient.get<any>('https://localhost:44385/api/pessoaapi');
  }
}
