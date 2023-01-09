import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaApiManualComponent } from './pessoa-api-manual.component';

describe('PessoaApiManualComponent', () => {
  let component: PessoaApiManualComponent;
  let fixture: ComponentFixture<PessoaApiManualComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PessoaApiManualComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PessoaApiManualComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
