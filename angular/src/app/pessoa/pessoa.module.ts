import { NgModule } from '@angular/core';
import { PessoaRoutingModule } from './pessoa-routing.module';
import { PessoaComponent } from './pessoa.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    PessoaComponent
  ],
  imports: [
    SharedModule, 
    NgbDatepickerModule,
    PessoaRoutingModule
  ]
})
export class PessoaModule { }


