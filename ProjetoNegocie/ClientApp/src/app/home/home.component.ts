import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { EnderecoModel } from '../_libs/_models/endereco.model';
import { EnderecoService } from '../_libs/_services/_api/endereco.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public cep: string;
  public enderecoModel: EnderecoModel;
  public enderecoForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private enderecoService: EnderecoService) {

  }

  ngOnInit() {
    this.enderecoForm = this.formBuilder.group({
      cep: ['', Validators.required]
    });
  }

  consultaWS() {
    if (this.enderecoForm.valid) {
      this.enderecoService.getEnderecoFromAPI(this.enderecoForm.get('cep').value).subscribe(
        result => {
          this.enderecoModel = result;
        },
        error => {
          this.tratamentoErro(error.error.detail);
        }
      )
    }
    else
      this.limparCampos();
  }

  consultaDB() {
    if (this.enderecoForm.valid) {
      this.enderecoService.getEnderecoFromDB(this.enderecoForm.get('cep').value).subscribe(
        result => {
          this.enderecoModel = result;
          console.log(result);
        },
        error => {
          this.tratamentoErro(error.error.detail);
        }
      );
    }
    else
      this.limparCampos();
  }

  postDB() {
    if (this.enderecoModel) {
      this.enderecoService.post(this.enderecoModel).subscribe(
        result => {
          Swal.fire({
            title: 'Salvo com Sucesso!',
            text: "Todas as informações foram salvas com sucesso!",
            icon: 'success',
            showCloseButton: true,
            showCancelButton: false,
            allowOutsideClick: true,
            allowEscapeKey: true,
            backdrop: true
          });

          this.enderecoForm.get('cep').setValue('');
          this.enderecoModel = null;
        },
        error => {
          this.tratamentoErro(error.error.detail);
        }
      );
    }
    else
      Swal.fire('Oops...', 'Selecione um Endereço antes de continuar!', 'error');
  }

  tratamentoErro(error: string) {
    Swal.fire('Oops...', error, 'error');
    this.limparCampos();
  }

  limparCampos() {
    this.enderecoForm.get('cep').setValue('');
    this.enderecoModel = null;
  }
}
