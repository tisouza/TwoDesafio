import { Component, OnDestroy, OnInit } from '@angular/core';
import { PessoaApiManualService } from './service/pessoa-api-manual.service';
import {Subject} from 'rxjs';

@Component({
  selector: 'app-pessoa-api-manual',
  templateUrl: './pessoa-api-manual.component.html',
  styleUrls: ['./pessoa-api-manual.component.scss']
})
export class PessoaApiManualComponent implements OnInit, OnDestroy {

  pessoas: any[];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  constructor(private readonly pessoaService: PessoaApiManualService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(){
    this.dtTrigger.unsubscribe();
  }

  buscarPessoas(){
    this.pessoaService.buscarPessoas().subscribe(retorno => {
      this.pessoas = retorno.items;
      this.dtTrigger.next(true);
    });
  }
}
