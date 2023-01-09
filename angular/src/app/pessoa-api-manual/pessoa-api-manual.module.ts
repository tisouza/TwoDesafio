import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PessoaApiManualComponent } from './pessoa-api-manual.component';
import { PessoaApiManualRoutingModule } from './pessoa-api-manual-routing.module';



@NgModule({
  declarations: [
    PessoaApiManualComponent
  ],
  imports: [
    CommonModule,
    PessoaApiManualRoutingModule
  ]
})
export class PessoaApiManualModule { }
