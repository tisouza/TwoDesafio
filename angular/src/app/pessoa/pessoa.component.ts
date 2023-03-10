import { Component, OnInit, ViewChild } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { PessoaService, PessoaDto, GetPessoaListDto } from '@proxy/pessoas';
import { FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl, ValidationErrors, FormControl } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class PessoaComponent implements OnInit {

  pessoa = { items: [], totalCount: 0 } as PagedResultDto<PessoaDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedPessoa = {} as PessoaDto;
  customValidatorEmail = false;
  email =  new FormControl(this.selectedPessoa.email || '', [Validators.required, Validators.email, customValidator()]);
  file: File;
  itensGrid:PessoaDto[];
  
  
  constructor(
    public readonly list: ListService,
    private pessoaService: PessoaService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    this.buscarPessoas('');
  }

  buscarPessoas(name :string){
    let input: any = {};
    this.list.filter = name;
    const pessoaStreamCreator = (input) => this.pessoaService.getList(input);
    this.list.hookToQuery(pessoaStreamCreator).subscribe((response) => {
      this.pessoa = response;
      this.itensGrid = response.items;
    });
  }

  updateFilter(event) {
    const val = event.target.value.toLowerCase();

    // filter our data
    this.buscarPessoas(val);

    // update the rows
    //this.itensGrid = temp.items;
    // Whenever the filter changes, always go back to the first page
    //this.table.offset = 0;
  }

  createPessoa() {
    this.selectedPessoa = {} as PessoaDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editPessoa(id: string) {
    this.pessoaService.get(id).subscribe((pessoa) => {
      this.selectedPessoa = pessoa;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedPessoa.name || '', Validators.required],
      birthDate: [
        this.selectedPessoa.birthDate ? new Date(this.selectedPessoa.birthDate) : null,
        Validators.required,
      ],
      email: this.email,
      job:[this.selectedPessoa.job || ''],
      file: [this.selectedPessoa.file || null]
    });
  }

  async onChangeFile(event) {
    
    this.file = event.target.files[0];
    let arquivo = await this.getBase64(this.file);
    
    this.selectedPessoa.file = arquivo;
    this.form.patchValue({
      file: arquivo
    });
    
  }

  getBase64(file) {

    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onload = () => resolve(reader.result);
      reader.onerror = reject;
      reader.readAsDataURL(file);
    });
 }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedPessoa.id) {
      this.pessoaService
        .update(this.selectedPessoa.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {     
      
      this.pessoaService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.pessoaService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }
}


export function customValidator(): ValidatorFn {
  return (control:AbstractControl) : ValidationErrors | null => {

      const value = control.value;
      if (value.length > 10) {
        
          return null;
      }
      
      return  {emailInvalido:true};
      // const hasUpperCase = /[A-Z]+/.test(value);

      // const hasLowerCase = /[a-z]+/.test(value);

      // const hasNumeric = /[0-9]+/.test(value);

      // const passwordValid = hasUpperCase && hasLowerCase && hasNumeric;

      // return !passwordValid ? {passwordStrength:true}: null;
  }
}